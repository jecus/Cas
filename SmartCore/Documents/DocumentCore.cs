using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Aircrafts;
using SmartCore.Component;
using SmartCore.Entities;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Schedule;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Entities.NewLoader;
using SmartCore.Files;
using SmartCore.Filters;
using SmartCore.Purchase;

namespace SmartCore.Documents
{
	public class DocumentCore : IDocumentCore
	{
		private readonly ICasEnvironment _casEnvironment;
		private readonly INewLoader _newLoader;
		private readonly ILoader _loader;
		private readonly IAircraftsCore _aircraftsCore;
		private readonly INewKeeper _newKeeper;
		private readonly IComponentCore _componentCore;

		public DocumentCore(ICasEnvironment casEnvironment, INewLoader newLoader, ILoader loader,
							IAircraftsCore aircraftsCore, INewKeeper newKeeper, IComponentCore componentCore)
		{
			_casEnvironment = casEnvironment;
			_newLoader = newLoader;
			_loader = loader;
			_aircraftsCore = aircraftsCore;
			_newKeeper = newKeeper;
			_componentCore = componentCore;
		}

		#region public List<Document> GetDocuments(BaseEntityObject parent, DocumentType docType, bool onlyOperatorDocs = false)

		public List<Document> GetDocuments(BaseEntityObject parent, DocumentType docType, bool onlyOperatorDocs = false)
		{
			if (parent is Aircraft)
			{

				var filters = new List<Filter>
				{
					new Filter("ParentAircraftId",parent.ItemId)
				};
				if (docType != DocumentType.Other)
					filters.Add(new Filter("DocTypeId", docType.ItemId));

				var result = _newLoader.GetObjectListAll<DocumentDTO,Document>(filters, true);

				foreach (Document doc in result)
					doc.Parent = parent;

				return result.ToList();
			}
			if (parent is Specialist || parent is Supplier)
			{

				var filters = new List<Filter>
				{
					new Filter("ParentTypeId",parent.SmartCoreObjectType.ItemId),
					new Filter("ParentID", parent.ItemId)
				};

				if (docType != DocumentType.Other)
					filters.Add(new Filter("DocTypeId", docType.ItemId));

				var result = _newLoader.GetObjectListAll<DocumentDTO, Document>(filters, true);

				foreach (Document doc in result)
					doc.Parent = parent;			

				return result.ToList();
			}
			else
			{
				var filters = new List<Filter>();

				if (docType != DocumentType.Other)
					filters.Add(new Filter("DocTypeId", docType.ItemId));
				if (onlyOperatorDocs)
				{
					filters.AddRange(new[]
					{
						new Filter("ParentTypeId",parent.SmartCoreObjectType.ItemId),
						new Filter("ParentID",parent.ItemId)
					});
				}
				else
				{
					var types = new[]
					{
						SmartCoreType.Aircraft.ItemId, SmartCoreType.Operator.ItemId, SmartCoreType.Employee.ItemId,
						SmartCoreType.Component.ItemId, SmartCoreType.WorkPackage.ItemId,
						SmartCoreType.ComponentDirective.ItemId, SmartCoreType.DirectiveRecord.ItemId,
						SmartCoreType.AircraftFlight.ItemId, SmartCoreType.FlightNumberPeriod.ItemId,
						SmartCoreType.FlightPlanOpsRecords.ItemId
					};
					filters.AddRange(new[]
					{
						new Filter("ParentTypeId",types)
					});
				}

				var emp = new List<Specialist>();
				var directiveRecords = new List<DirectiveRecord>();

				var result = _newLoader.GetObjectListAll<DocumentDTO, Document>(filters, true);

				var empDocumentIds = result.Where(x => x.ParentTypeId == SmartCoreType.Employee.ItemId).Select(x => x.ParentId).ToArray();
				if(empDocumentIds.Length > 0)
					emp.AddRange(_newLoader.GetObjectListAll<SpecialistDTO,Specialist>(new Filter("ItemId", empDocumentIds)));

				var directiveRecorIds = result.Where(x => x.ParentTypeId == SmartCoreType.DirectiveRecord.ItemId).Select(x => x.ParentId).ToArray();
				if (directiveRecorIds.Length > 0)
					directiveRecords.AddRange(_newLoader.GetObjectListAll<DirectiveRecordDTO,DirectiveRecord>(new Filter("ItemId", directiveRecorIds)));

				//TODO:(Важно) Зря грузим компоненты и рабочие пакеты только для того что бы взять воздушное судно(подумать в сторону того чтобы Parent присваивать компнент либо раб пакет)
				var compDocumentIds = result.Where(x => x.ParentTypeId == SmartCoreType.Component.ItemId).Select(x => x.ParentId).ToArray();

				var components = new List<Entities.General.Accessory.Component>();
				if(compDocumentIds.Length > 0) 
					components = _newLoader.GetObjectListAll<ComponentDTO,Entities.General.Accessory.Component>(new List<Filter>()
					{
						new Filter("IsBaseComponent", false),
						new Filter("ItemId",compDocumentIds)
					}, true).ToList();

				var compDirectiveIds = result.Where(x => x.ParentTypeId == SmartCoreType.ComponentDirective.ItemId).Select(x => x.ParentId).ToList();
				compDirectiveIds.AddRange(directiveRecords.Where(d => d.ParentType.ItemId == SmartCoreType.ComponentDirective.ItemId).Select(x => x.ParentId));

				var componentDirctivess = new List<ComponentDirective>();
				if (compDirectiveIds.Count > 0)
					componentDirctivess = _componentCore.GetComponentDirectives(compDirectiveIds);

				var directiveIds = directiveRecords.Where(d => d.ParentType.ItemId == SmartCoreType.Directive.ItemId).Select(x => x.ParentId).ToArray();
				var dirctives = new List<Directive>();
				//if (directiveIds.Length > 0)
					//dirctives = _newLoader.GetObjectListAll<DirectiveDTO, Directive>(new Filter("ItemId", directiveIds)).ToList();
				if (directiveIds.Length > 0)
					dirctives = _loader.GetObjectListAll<Directive>(new ICommonFilter[]
					{
						new CommonFilter<int>(Directive.ItemIdProperty, FilterType.In, directiveIds), 
					}).ToList();

				var wptIds = result.Where(x => x.ParentTypeId == SmartCoreType.WorkPackage.ItemId).Select(x => x.ParentId).ToArray();
				var wps = new List<WorkPackage>();
				if (wptIds.Length > 0)
					wps.AddRange(_newLoader.GetObjectListAll<WorkPackageDTO, WorkPackage>(new Filter("ItemId", wptIds)));

				var resId = result.Select(r => r.ItemId);
 
				 var links = _newLoader.GetObjectListAll<ItemFileLinkDTO, ItemFileLink>(new List<Filter>()
				 {
					 new Filter("ParentTypeId",SmartCoreType.Document.ItemId),
					 new Filter("ParentId",resId)
				 });


				var aircraftFlights = new List<AircraftFlight>();
				var aircraftFlightids = result.Where(x => x.ParentTypeId == SmartCoreType.AircraftFlight.ItemId).Select(x => x.ParentId).ToArray();
				if(aircraftFlightids.Length > 0)
					aircraftFlights.AddRange(_newLoader.GetObjectListAll<AircraftFlightDTO,AircraftFlight>(new Filter("ItemId", aircraftFlightids)));
				var planOpsRecordIds = result.Where(x => x.ParentTypeId == SmartCoreType.FlightPlanOpsRecords.ItemId).Select(x => x.ParentId).ToArray();
				var planOpsRecords = new List<FlightPlanOpsRecords>();
				if (planOpsRecordIds.Length > 0)
					planOpsRecords.AddRange(_newLoader.GetObjectListAll<FlightPlanOpsRecordsDTO,FlightPlanOpsRecords>(new Filter("ItemId", planOpsRecordIds)));

				foreach (Document document in result)
				{
					document.HaveFile = links.FirstOrDefault(l => l.ParentId == document.ItemId) != null;

					if (document.ParentTypeId == SmartCoreType.Aircraft.ItemId)
					{
						var a = _aircraftsCore.GetAircraftById(document.ParentId);
						if (a != null)
							document.Parent = a;
						else document.Parent = new Aircraft
						{
							IsDeleted = true,
							RegistrationNumber = "Can't find aircraft with id = " + document.ParentId
						};
					}
					else if (document.ParentTypeId == SmartCoreType.Employee.ItemId)
					{
						document.Specialist = emp.FirstOrDefault(e => e.ItemId == document.ParentId);
					}
					else if (document.ParentTypeId == SmartCoreType.Component.ItemId)
					{
						var comp = components.FirstOrDefault(e => e.ItemId == document.ParentId);

						if (comp != null)
						{
							_newLoader.SetDestinations(comp);
							if (comp.ParentAircraftId > 0)
								document.Parent = _aircraftsCore.GetAircraftById(comp.ParentAircraftId);
							else if(comp.ParentStoreId > 0)
								document.Parent = _casEnvironment.Stores.GetItemById(comp.ParentStoreId);
						} 
					}
					else if (document.ParentTypeId == SmartCoreType.ComponentDirective.ItemId)
					{
						var cd = componentDirctivess.FirstOrDefault(c => c.ItemId == document.ParentId);

						if (cd != null)
						{
							try
							{
								if (cd.ParentComponent.ParentAircraftId > 0)
									document.Parent = _aircraftsCore.GetAircraftById(cd.ParentComponent.ParentAircraftId);
								else if (cd.ParentComponent.ParentStoreId > 0)
									document.Parent = _casEnvironment.Stores.GetItemById(cd.ParentComponent.ParentStoreId);
							}
							catch (Exception e)
							{
								Console.WriteLine(e);
								throw;
							}
						}
					}
					else if (document.ParentTypeId == SmartCoreType.WorkPackage.ItemId)
					{
						var wp = wps.FirstOrDefault(w => w.ItemId == document.ParentId);
						if (wp != null)
							document.Parent = _aircraftsCore.GetAircraftById(wp.ParentId);
					}
					else if(document.ParentTypeId == SmartCoreType.DirectiveRecord.ItemId)
					{
						var directive = directiveRecords.FirstOrDefault(d => d.ItemId == document.ParentId);
						if (directive != null)
						{
							if (directive.ParentType == SmartCoreType.ComponentDirective)
							{
								var cd = componentDirctivess.FirstOrDefault(e => e.ItemId == directive.ParentId);
								if (cd != null)
								{
									if (cd.ParentComponent.ParentAircraftId > 0)
										document.Parent = _aircraftsCore.GetAircraftById(cd.ParentComponent.ParentAircraftId);
									else if (cd.ParentComponent.ParentStoreId > 0)
										document.Parent = _casEnvironment.Stores.GetItemById(cd.ParentComponent.ParentStoreId);
								}
							}
							else if (directive.ParentType == SmartCoreType.Directive)
							{
								var d = dirctives.FirstOrDefault(e => e.ItemId == directive.ParentId);
								if (d != null)
								{
									document.Parent = _aircraftsCore.GetAircraftById(d.ParentBaseComponent.ParentAircraftId);
								}
							}
						}
					}
					else if (document.ParentTypeId == SmartCoreType.AircraftFlight.ItemId)
					{
						var flight = aircraftFlights.FirstOrDefault(d => d.ItemId == document.ParentId);

						if (flight != null)
							document.Parent = _aircraftsCore.GetAircraftById(flight.AircraftId);
					}
					else if (document.ParentTypeId == SmartCoreType.FlightPlanOpsRecords.ItemId)
					{
						document.Parent = planOpsRecords.FirstOrDefault(d => d.ItemId == document.ParentId);
					}
					else
					{
						var a = _casEnvironment.Operators.GetItemById(document.ParentId);
						if (a != null)
							document.Parent = a;
						else document.Parent = new Operator
						{
							IsDeleted = true,
							Name = "Can't find operator with id = " + document.ParentId
						};
					}
				}
				return result.ToList();
			}
		}
		#endregion

		#region public List<Document> GetDocumentsByParentType(BaseEntityObject parent, DocumentType docType, bool onlyOperatorDocs = false)

		public List<Document> GetDocumentsByParentType(BaseEntityObject parent, DocumentType docType)
		{
			if (parent is Aircraft || parent is Specialist || parent is Supplier)
			{
				var filters = new List<Filter>
				{
					new Filter("ParentTypeId",parent.SmartCoreObjectType.ItemId)
				};

				if (docType != DocumentType.Other)
					filters.Add(new Filter("DocTypeId", docType.ItemId));

				var result = _newLoader.GetObjectListAll<DocumentDTO,Document>(filters.ToArray(), true);

				foreach (Document doc in result) doc.Parent = parent;

				return result.ToList();

			}
			if (parent == SmartCoreType.Aircraft)
			{
				var filters = new List<Filter>
				{
					new Filter("ParentTypeId",parent.SmartCoreObjectType.ItemId),
					new Filter("ParentID",parent.ItemId)
				};

				if (docType != DocumentType.Other)
					filters.Add(new Filter("DocTypeId", docType.ItemId));
				var result = _newLoader.GetObjectListAll<DocumentDTO, Document>(filters, true);


				foreach (var doc in result)
				{
					if (doc.ParentTypeId == SmartCoreType.Aircraft.ItemId)
					{
						var a = _aircraftsCore.GetAircraftById(doc.ParentId);
						if (a != null) doc.Parent = a;
						else doc.Parent = new Aircraft
						{
							IsDeleted = true,
							RegistrationNumber =
								"Can't find aircraft with id = " + doc.ParentId
						};
					}
				}

				return result.ToList();

			}
			else
			{
				var filters = new List<Filter>();
				if (docType != DocumentType.Other)
					filters.Add(new Filter("DocTypeId", docType.ItemId));
				else
				{
					var types = new[] {SmartCoreType.Aircraft.ItemId, SmartCoreType.Operator.ItemId};
					filters.Add(new Filter("ParentTypeId", types));
				}

				var result = _newLoader.GetObjectListAll<DocumentDTO, Document>(filters, true);

				foreach (var certificate in result)
				{
					if (certificate.ParentTypeId == SmartCoreType.Aircraft.ItemId)
					{
						var a = _aircraftsCore.GetAircraftById(certificate.ParentId);
						if (a != null)
							certificate.Parent = a;
						else certificate.Parent = new Aircraft
						{
							IsDeleted = true,
							RegistrationNumber =
								"Can't find aircraft with id = " + certificate.ParentId
						};
					}
					else
					{
						Operator a = _casEnvironment.Operators.GetItemById(certificate.ParentId);
						if (a != null)
							certificate.Parent = a;
						else certificate.Parent = new Operator
						{
							IsDeleted = true,
							Name = "Can't find operator with id = " + certificate.ParentId
						};
					}
				}
				return result.ToList();
			}
		}
		#endregion

		#region public List<Document> GetAircraftDocuments(Aircraft parentAircraft)

		public List<Document> GetAircraftDocuments(Aircraft parentAircraft)
		{
			return GetDocuments(parentAircraft, DocumentType.Other);
		}
		#endregion

		#region public List<Document> GetOperatorDocuments(Operator parentOperator)

		public List<Document> GetOperatorDocuments(Operator parentOperator)
		{
			return GetDocuments(parentOperator, DocumentType.Other);
		}
		#endregion

		#region public List<Document> GetOperatorDocuments(Operator parentOperator)

		public List<Document> GetOperatorDocuments(Operator parentOperator, DocumentType docType)
		{
			return GetDocuments(parentOperator, docType);
		}
		#endregion

		#region public void SaveDocumentsList(BaseEntityObject parent, IList<Document> unsavedDocuments, out string errorMessage)

		public void SaveDocumentsList(BaseEntityObject parent, IList<Document> unsavedDocuments)
		{
			foreach (var unsavedDocument in unsavedDocuments)
				_newKeeper.Save(unsavedDocument);
		}

		#endregion

		#region private IList<Document> getDocuments(BaseEntityObject parent, IList<DocumentType> documentTypes, bool onlyOperatorDocs = false)

		private List<Document> getDocuments(BaseEntityObject parent, IList<DocumentType> documentTypes, bool onlyOperatorDocs = false)
		{
			if (parent is Aircraft || parent is Specialist || parent is Supplier)
			{
				var filters = new List<Filter>
				{
					new Filter("ParentTypeId", parent.SmartCoreObjectType.ItemId),
					new Filter("ParentID", parent.ItemId)
				};
				if (documentTypes.Count > 0 && documentTypes.All(d => d != DocumentType.Other))
				{
					var ids = documentTypes.Select(d => d.ItemId);
					filters.Add(new Filter("DocTypeId", ids));
				}

				var result = _newLoader.GetObjectListAll<DocumentDTO, Document>(filters, true);

				foreach (var doc in result)
					doc.Parent = parent;

				return result.ToList();

			}
			if (parent == SmartCoreType.Aircraft)
			{
				var filters = new List<Filter>
				{
					new Filter("ParentTypeId",parent.SmartCoreObjectType.ItemId),
					new Filter("ParentID",parent.ItemId)
				};

				if (documentTypes.Count > 0 && documentTypes.All(d => d != DocumentType.Other))
				{
					var ids = documentTypes.Select(d => d.ItemId);
					filters.Add(new Filter("DocTypeId", ids));
				}

				var result = _newLoader.GetObjectListAll<DocumentDTO,Document>(filters, true);

				foreach (var doc in result)
				{
					if (doc.ParentTypeId == SmartCoreType.Aircraft.ItemId)
					{
						var a = _aircraftsCore.GetAircraftById(doc.ParentId);
						if (a != null) doc.Parent = a;
						else
							doc.Parent = new Aircraft
							{
								IsDeleted = true,
								RegistrationNumber =
									"Can't find aircraft with id = " + doc.ParentId
							};
					}
				}

				return result.ToList();
			}
			else
			{
				var filters = new List<Filter>();

				if (documentTypes.Count > 0 && documentTypes.All(d => d != DocumentType.Other))
				{
					var ids = documentTypes.Select(d => d.ItemId);
					filters.Add(new Filter("DocTypeId", ids));
				}

				if (onlyOperatorDocs)
				{
					filters.AddRange(new []
					{
						new Filter("ParentTypeId",parent.SmartCoreObjectType.ItemId),
						new Filter("ParentID",parent.ItemId)
					});

				}
				else
				{
					var types = new[] { SmartCoreType.Aircraft.ItemId, SmartCoreType.Operator.ItemId };
					filters.Add(new Filter("ParentTypeId", types));
				}

				var result = _newLoader.GetObjectListAll<DocumentDTO, Document>(filters, true);

				foreach (var certificate in result)
				{
					if (certificate.ParentTypeId == SmartCoreType.Aircraft.ItemId)
					{
						var a = _aircraftsCore.GetAircraftById(certificate.ParentId);
						if (a != null)
							certificate.Parent = a;
						else
							certificate.Parent = new Aircraft
							{
								IsDeleted = true,
								RegistrationNumber = "Can't find aircraft with id = " + certificate.ParentId
							};
					}
					else
					{
						var a = _casEnvironment.Operators.GetItemById(certificate.ParentId);
						if (a != null)
							certificate.Parent = a;
						else
							certificate.Parent = new Operator
							{
								IsDeleted = true,
								Name = "Can't find operator with id = " + certificate.ParentId
							};
					}
				}
				return result.ToList();
			}
		}

		#endregion
	}
}