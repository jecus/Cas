using System;
using System.Collections.Generic;
using System.Linq;
using EntityCore.Attributte;
using EntityCore.DTO.General;
using EntityCore.Filter;
using SmartCore.Aircrafts;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Component;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.NewLoader;
using SmartCore.Files;
using SmartCore.Purchase;
using SmartCore.Stores;

namespace SmartCore.TransferRec
{
	public class TransferRecordCore : ITransferRecordCore
	{
		private readonly INewLoader _newLoader;
		private readonly INewKeeper _newKeeper;
		private readonly IComponentCore _componentCore;
		private readonly IAircraftsCore _aircraftsCore;
		private readonly ICalculator _calculator;
		private readonly IStoreCore _storeCore;
		private readonly IFilesDataAccess _filesDataAccess;


		public TransferRecordCore(INewLoader newLoader,  INewKeeper newKeeper,
								  IComponentCore componentCore, IAircraftsCore aircraftsCore, ICalculator calculator,
								  IStoreCore storeCore, IFilesDataAccess filesDataAccess)
		{
			_newLoader = newLoader;
			_newKeeper = newKeeper;
			_componentCore = componentCore;
			_aircraftsCore = aircraftsCore;
			_calculator = calculator;
			_storeCore = storeCore;
			_filesDataAccess = filesDataAccess;
		}

		public TransferRecordCollection GetPreTransferRecordsFrom(BaseComponent baseComponent)
		{
			if (baseComponent == null) return null;
			var transferRecords = _newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new List<Filter>()
			{
				new Filter("DestinationObjectID",baseComponent.ItemId),
				new Filter("DestinationObjectType",SmartCoreType.BaseComponent.ItemId),
				new Filter("i.PreConfirmTransfer", true)
			}, true).OrderByDescending(t => t.TransferDate);
			var collection = new TransferRecordCollection(transferRecords.ToArray());

			// возвращаем результат
			SetParents(collection);
			return collection;
		}


		#region public TransferRecord[] GetLastTransferRecordsFrom(Aircraft aircraft)
		/// <summary>
		/// Возвращает все записи об удалении агрегатов с данного базового агрегата
		/// </summary>
		/// <returns></returns>
		public TransferRecordCollection GetLastTransferRecordsFrom(Aircraft aircraft)
		{
			if (aircraft == null) return null;
			var transferRecords = _newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new List<Filter>()
			{
				new Filter("FromBaseComponentID",0),
				new Filter("FromAircraftID",aircraft.ItemId),
				new Filter("FromStoreID",0),
				new Filter("PODR", false)
			}).OrderByDescending(t => t.TransferDate);
			var collection = new TransferRecordCollection(transferRecords.ToArray());
			// возвращаем результат
			SetParents(collection);
			return collection;
		}

		#endregion

		#region public TransferRecord[] GetLastTransferRecordsFrom(BaseComponent baseComponent))
		/// <summary>
		/// Возвращает все записи об удалении агрегатов с данного базового агрегата
		/// </summary>
		/// <returns></returns>
		public TransferRecordCollection GetLastTransferRecordsFrom(BaseComponent baseComponent)
		{
			if (baseComponent == null) return null;



			//if(baseComponent.ParentAircraftId > 0)
			//	filters.Add(new CommonFilter<int>(TransferRecord.FromAircraftIdProperty, baseComponent.ParentAircraftId));
			//if(baseComponent.ParentStoreId > 0)
			//	filters.Add(new CommonFilter<int>(TransferRecord.FromStoreIdProperty, baseComponent.ParentStoreId));
			var transferRecords = _newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new List<Filter>()
			{
				new Filter("FromBaseComponentID",baseComponent.ItemId),
				new Filter("PODR", false)
			},true).OrderByDescending(t => t.TransferDate);
			var collection = new TransferRecordCollection(transferRecords.ToArray());

			// возвращаем результат
			SetParents(collection);
			return collection;
		}

		#endregion

		#region public TransferRecordCollection GetLastTransferRecordsFrom(Store store, SmartCoreType componentType)
		/// <summary>
		/// Возвращает все записи об удалении агрегатов с данного склада
		/// </summary>
		/// <returns></returns>
		public TransferRecordCollection GetLastTransferRecordsFrom(Store store, SmartCoreType componentType)
		{
			if (store == null) return null;
			var transferRecords = _newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new List<Filter>()
			{
				new Filter("ParentType",componentType.ItemId),
				new Filter("FromStoreID",store.ItemId),
				new Filter("PODR", false)
			},true).OrderByDescending(t => t.TransferDate);
			var collection = new TransferRecordCollection(transferRecords.ToArray());
			// возвращаем результат
			SetParents(collection);
			return collection;
		}

		#endregion

		#region public TransferRecordCollection GetLastTransferRecordsFrom(Store store)
		/// <summary>
		/// Возвращает все записи об удалении агрегатов с данного склада
		/// </summary>
		/// <returns></returns>
		public TransferRecordCollection GetLastTransferRecordsFrom(Store store)
		{
			var collection = GetLastTransferRecordsFrom(store, SmartCoreType.Component);
			// возвращаем результат
			return collection;
		}

		#endregion


		public TransferRecordCollection GetLastTransferRecordsFromSuppliers()
		{
			var transferRecords = _newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new List<Filter>()
			{
				new Filter("ParentType",SmartCoreType.Component.ItemId),
				new Filter("FromSupplierId",FilterType.Grather, 0),
				new Filter("PODR", false)
			},true).OrderByDescending(t => t.TransferDate);
			var collection = new TransferRecordCollection(transferRecords.ToArray());
			// возвращаем результат
			SetParents(collection);
			return collection;
		}

		public TransferRecordCollection GetLastTransferRecordsFromSpecialist()
		{
			var transferRecords = _newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new List<Filter>()
			{
				new Filter("ParentType",SmartCoreType.Component.ItemId),
				new Filter("FromSpecialistId", FilterType.Grather,0),
				new Filter("PODR", false)
			},true).OrderByDescending(t => t.TransferDate);


			var collection = new TransferRecordCollection(transferRecords.ToArray());
			// возвращаем результат
			SetParents(collection);
			return collection;
		}

		#region public TransferRecord[] GetLastTransferRecordsFrom(Aircraft aircraft)
		/// <summary>
		/// Возвращает все записи о перемешении агрегатов на переданное ВС
		/// </summary>
		/// <returns></returns>
		public IEnumerable<TransferRecord> GetTransferRecordsFromAndTo(Aircraft aircraft, Store s)
		{
			if (aircraft == null && s == null) return null;
			string baseStatement = "";

			var collection = new List<TransferRecord>();

			if (aircraft != null)
			{
				var parentIds =_newLoader.GetSelectColumnOnly<TransferRecordDTO>(new List<Filter>()
				{
					new Filter("DestinationObjectID",aircraft.ItemId),
					new Filter("DestinationObjectType",aircraft.SmartCoreObjectType.ItemId),
				}, "ParentID");

				collection.AddRange(_newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new List<Filter>()
				{
					new Filter("FromAircraftID",aircraft.ItemId),
					new Filter("FromStoreID", 0)
				}, true).OrderByDescending(t => t.TransferDate));

				collection.AddRange(_newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new List<Filter>()
				{
					new Filter("DestinationObjectID",aircraft.ItemId),
					new Filter("DestinationObjectType", aircraft.SmartCoreObjectType.ItemId)
				}, true).OrderByDescending(t => t.TransferDate));

				collection.AddRange(_newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new Filter("DestinationObjectID", parentIds), true).OrderByDescending(t => t.TransferDate));

			}
			else
			{
				var parentIds = _newLoader.GetSelectColumnOnly<TransferRecordDTO>(new List<Filter>()
				{
					new Filter("DestinationObjectID",s.ItemId),
					new Filter("DestinationObjectType", s.SmartCoreObjectType.ItemId)
				} , "ParentID");

				collection.AddRange(_newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new Filter("FromStoreID", s.ItemId), true).OrderByDescending(t => t.TransferDate));

				collection.AddRange(_newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new List<Filter>()
				{
					new Filter("DestinationObjectID",s.ItemId),
					new Filter("DestinationObjectType", s.SmartCoreObjectType.ItemId)
				}, true).OrderByDescending(t => t.TransferDate));

				collection.AddRange(_newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new Filter("DestinationObjectID", parentIds), true).OrderByDescending(t => t.TransferDate));


			}


			var ids = collection.Select(a => a.ParentId);
			var components = _newLoader.GetObjectListAll<ComponentDTO, Entities.General.Accessory.Component>(new List<Filter>()
			{
				new Filter("IsBaseComponent",false),
				new Filter("ItemId",ids)
			}, true, true);

			var transferRecordIds = collection.Select(t => t.ItemId).ToList();
			var filesDict = _filesDataAccess.GetItemFileLinks(transferRecordIds, SmartCoreType.TransferRecord.ItemId).ToDictionary(d => d.ParentId);

			var suppliersIds = collection.Select(t => t.FromSupplierId).ToList();
			suppliersIds.AddRange(collection.Where(t => t.DestinationObjectType == SmartCoreType.Supplier).Select(t => t.DestinationObjectId).ToArray());
			var suppliers = _newLoader.GetObjectListAll<SupplierDTO, Supplier>(new Filter("ItemId", suppliersIds));

			var specialistIds = new List<int>();
			specialistIds.AddRange(collection.Where(t => t.DestinationObjectType == SmartCoreType.Employee).Select(t => t.DestinationObjectId));
			specialistIds.AddRange(collection.Select(t => t.FromSpecialistId));
			var specialists = _newLoader.GetObjectListAll<SpecialistDTO, Specialist>(new Filter("ItemId", specialistIds));

			foreach (var transferRecord in collection)
			{
				if(filesDict.ContainsKey(transferRecord.ItemId))
					transferRecord.Files.Add(filesDict[transferRecord.ItemId]);


				#region Родительский объект

				if (transferRecord.ParentType == SmartCoreType.BaseComponent)
				{
					var bd = _componentCore.GetBaseComponentById(transferRecord.ParentId) ?? 
					new BaseComponent
					{
						ItemId = transferRecord.ParentId,
						IsDeleted = true,
						Description = "Can't Find Base Component with id = " + transferRecord.ParentId,
						PartNumber = "Unknown",
						SerialNumber = "Unknown"
					};

					transferRecord.ParentComponent = bd;
				}
				else if (transferRecord.ParentType == SmartCoreType.Component)
				{
					var d = components.GetItemById(transferRecord.ParentId) ??
					new Entities.General.Accessory.Component
					{
						ItemId = transferRecord.ParentId,
						IsDeleted = true,
						Description = "Can't Find Component with id = " + transferRecord.ParentId,
						PartNumber = "Unknown",
						SerialNumber = "Unknown"
					};
					transferRecord.ParentComponent = d;
				}
				else
				{
					var d = new Entities.General.Accessory.Component
					{
						ItemId = transferRecord.ParentId,
						IsDeleted = true,
						Description = "Can't Find object with type = " + transferRecord.ParentType,
						PartNumber = "Unknown",
						SerialNumber = "Unknown"
					};
					transferRecord.ParentComponent = d;
				}

				#endregion

				#region Откуда перемещен

				if (transferRecord.FromAircraftId > 0)
				{
					var a = _aircraftsCore.GetAircraftById(transferRecord.FromAircraftId) ??
					new Aircraft
					{
						ItemId = transferRecord.FromAircraftId,
						IsDeleted = true,
						RegistrationNumber = "Can't Find Aircraft with id = " + transferRecord.FromAircraftId
					};
					transferRecord.FromAircraft = a;
				}

				if (transferRecord.FromBaseComponentId > 0)
				{
					var bd = _componentCore.GetBaseComponentById(transferRecord.FromBaseComponentId) ??
					new BaseComponent
					{
						ItemId = transferRecord.FromBaseComponentId,
						IsDeleted = true,
						Description = "Can't Find Base Component with id = " + transferRecord.FromBaseComponentId,
						PartNumber = "Unknown",
						SerialNumber = "Unknown"
					};

					var a = _aircraftsCore.GetAircraftById(bd.ParentAircraftId);
					if(a != null)
						bd.Aircraft = a.ToString();

					transferRecord.FromBaseComponent = bd;
				}

				if (transferRecord.FromStoreId > 0)
				{
					var store = _storeCore.GetStoreById(transferRecord.FromStoreId) ?? 
								  new Store
					              {
						              ItemId = transferRecord.FromStoreId,
						              IsDeleted = true,
						              Name = "Can't Find Store with id = " + transferRecord.FromStoreId,
					              };

					transferRecord.FromStore = store;
				}

				if (transferRecord.FromSupplierId > 0)
				{
					var supplier = suppliers.FirstOrDefault(x => x.ItemId == transferRecord.FromSupplierId) ??
					               new Supplier
					               {
						               ItemId = transferRecord.FromSupplierId,
						               IsDeleted = true,
						               Name = "Can't Find Supplier with id = " + transferRecord.FromSupplierId
					               };

					transferRecord.FromSupplier = supplier;
				}

				if (transferRecord.FromSpecialistId > 0)
				{
					var specialist = specialists.FirstOrDefault(x => x.ItemId == transferRecord.FromSpecialistId) ??
					                 new Specialist
					                 {
						                 ItemId = transferRecord.FromSpecialistId,
						                 IsDeleted = true,
						                 FirstName = "Can't Find Specialist with id = " + transferRecord.FromSpecialistId
					                 };

					transferRecord.FromSpecialist = specialist;
				}

				#endregion

				#region Куда перемещен
				if (transferRecord.DestinationObjectType == SmartCoreType.Store)
				{
					var store = _storeCore.GetStoreById(transferRecord.DestinationObjectId) ??
					new Store
					{
						ItemId = transferRecord.DestinationObjectId,
						IsDeleted = true,
						Name = "Can't Find Store with id = " + transferRecord.DestinationObjectId,
					};

					transferRecord.DestinationObject = store;
				}

				if (transferRecord.DestinationObjectType == SmartCoreType.BaseComponent)
				{
					var bd = _componentCore.GetBaseComponentById(transferRecord.DestinationObjectId) ??
							   new BaseComponent
							   {
								   ItemId = transferRecord.DestinationObjectId,
								   IsDeleted = true,
								   Description = "Can't Find Base Component with id = " + transferRecord.DestinationObjectId,
								   PartNumber = "Unknown",
								   SerialNumber = "Unknown"
							   };

					var a = _aircraftsCore.GetAircraftById(bd.ParentAircraftId);
					if (a != null)
						bd.Aircraft = a.ToString();

					transferRecord.DestinationObject = bd;
				}
				if (transferRecord.DestinationObjectType == SmartCoreType.Aircraft)
				{
					var a = _aircraftsCore.GetAircraftById(transferRecord.DestinationObjectId) ??
					new Aircraft
					{
						ItemId = transferRecord.DestinationObjectId,
						IsDeleted = true,
						RegistrationNumber = "Can't Find Aircraft with id = " + transferRecord.DestinationObjectId
					};
					transferRecord.DestinationObject = a;
				}

				if (transferRecord.DestinationObjectType == SmartCoreType.Supplier)
				{
					var supplier = suppliers.FirstOrDefault(x => x.ItemId == transferRecord.DestinationObjectId) ??
					               new Supplier
					               {
						               ItemId = transferRecord.FromSupplierId,
						               IsDeleted = true,
						               Name = "Can't Find Supplier with id = " + transferRecord.DestinationObjectId
								   };

					transferRecord.DestinationObject = supplier;
				}

				if (transferRecord.DestinationObjectType == SmartCoreType.Employee)
				{
					var specialist = specialists.FirstOrDefault(x => x.ItemId == transferRecord.DestinationObjectId) ??
					                 new Specialist
					                 {
						                 ItemId = transferRecord.FromSpecialistId,
						                 IsDeleted = true,
						                 FirstName = "Can't Find Specialist with id = " + transferRecord.DestinationObjectId
									 };

					transferRecord.DestinationObject = specialist;
				}
				#endregion
			}
			// возвращаем результат
			//SetParents(collection);
			return collection;
		}

		#endregion

		#region public IEnumerable<TransferRecord> GetTransferRecord(int aircraftId)
		
		public IEnumerable<TransferRecord> GetTransferRecord(int aircraftId)
		{
			var records = _newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new List<Filter>()
			{
				new Filter("FromAircraftID",aircraftId),
				new Filter("ReplaceComponentId",FilterType.Grather,0),
			});
			foreach (var transferRecord in records)
			{
				transferRecord.ReplaceComponent =
					_componentCore.GetBaseComponentById(transferRecord.ReplaceComponentId) ??
					_componentCore.GetComponentById(transferRecord.ReplaceComponentId);

				foreach (var record in transferRecord.ReplaceComponent.TransferRecords)
				{

					#region Откуда перемещен

					if (record.FromAircraftId > 0)
					{
						var a = _aircraftsCore.GetAircraftById(record.FromAircraftId) ??
						        new Aircraft
						        {
							        ItemId = record.FromAircraftId,
							        IsDeleted = true,
							        RegistrationNumber = "Can't Find Aircraft with id = " + record.FromAircraftId
						        };
						record.FromAircraft = a;
					}


					if (record.FromBaseComponentId > 0)
					{
						var bd = _componentCore.GetBaseComponentById(record.FromBaseComponentId) ??
						new BaseComponent
						{
							ItemId = record.FromBaseComponentId,
							IsDeleted = true,
							Description = "Can't Find Base Component with id = " + record.FromBaseComponentId,
							PartNumber = "Unknown",
							SerialNumber = "Unknown"
						};

						var a = _aircraftsCore.GetAircraftById(bd.ParentAircraftId);
						if (a != null)
							bd.Aircraft = a.ToString();

						record.FromBaseComponent = bd;
					}

					if (record.FromStoreId > 0)
					{
						var store = _storeCore.GetStoreById(record.FromStoreId) ??
									new Store
									{
										ItemId = record.FromStoreId,
										IsDeleted = true,
										Name = "Can't Find Store with id = " + record.FromStoreId,
									};

						record.FromStore = store;
					}

					#endregion

					#region Куда перемещен
					if (record.DestinationObjectType == SmartCoreType.Store)
					{
						var store = _storeCore.GetStoreById(record.DestinationObjectId) ??
						            new Store
						            {
							            ItemId = record.DestinationObjectId,
							            IsDeleted = true,
							            Name = "Can't Find Store with id = " + record.DestinationObjectId,
						            };

						record.DestinationObject = store;
					}

					if (record.DestinationObjectType == SmartCoreType.BaseComponent)
					{
						var bd = _componentCore.GetBaseComponentById(record.DestinationObjectId) ??
						         new BaseComponent
						         {
							         ItemId = record.DestinationObjectId,
							         IsDeleted = true,
							         Description = "Can't Find Base Component with id = " + record.DestinationObjectId,
							         PartNumber = "Unknown",
							         SerialNumber = "Unknown"
						         };

						var a = _aircraftsCore.GetAircraftById(bd.ParentAircraftId);
						if (a != null)
							bd.Aircraft = a.ToString();

						record.DestinationObject = bd;
					}
					if (record.DestinationObjectType == SmartCoreType.Aircraft)
					{
						var a = _aircraftsCore.GetAircraftById(record.DestinationObjectId) ??
						        new Aircraft
						        {
							        ItemId = record.DestinationObjectId,
							        IsDeleted = true,
							        RegistrationNumber = "Can't Find Aircraft with id = " + record.DestinationObjectId
						        };
						record.DestinationObject = a;
					}
					#endregion


				}

				#region Родительский объект

				if (transferRecord.ParentType == SmartCoreType.BaseComponent)
				{
					var bd = _componentCore.GetBaseComponentById(transferRecord.ParentId) ??
					         new BaseComponent
					         {
						         ItemId = transferRecord.ParentId,
						         IsDeleted = true,
						         Description = "Can't Find Base Component with id = " + transferRecord.ParentId,
						         PartNumber = "Unknown",
						         SerialNumber = "Unknown"
					         };

					transferRecord.ParentComponent = bd;
				}
				else if (transferRecord.ParentType == SmartCoreType.Component)
				{
					var d = _componentCore.GetComponentById(transferRecord.ParentId) ??
					        new Entities.General.Accessory.Component
					        {
						        ItemId = transferRecord.ParentId,
						        IsDeleted = true,
						        Description = "Can't Find Component with id = " + transferRecord.ParentId,
						        PartNumber = "Unknown",
						        SerialNumber = "Unknown"
					        };
					transferRecord.ParentComponent = d;
				}
				else
				{
					var d = new Entities.General.Accessory.Component
					{
						ItemId = transferRecord.ParentId,
						IsDeleted = true,
						Description = "Can't Find object with type = " + transferRecord.ParentType,
						PartNumber = "Unknown",
						SerialNumber = "Unknown"
					};
					transferRecord.ParentComponent = d;
				}

				#endregion

				#region Откуда перемещен

				if (transferRecord.FromAircraftId > 0)
				{
					var a = _aircraftsCore.GetAircraftById(transferRecord.FromAircraftId) ??
					        new Aircraft
					        {
						        ItemId = transferRecord.FromAircraftId,
						        IsDeleted = true,
						        RegistrationNumber = "Can't Find Aircraft with id = " + transferRecord.FromAircraftId
					        };
					transferRecord.FromAircraft = a;
				}

				if (transferRecord.FromBaseComponentId > 0)
				{
					var bd = _componentCore.GetBaseComponentById(transferRecord.FromBaseComponentId) ??
					         new BaseComponent
					         {
						         ItemId = transferRecord.FromBaseComponentId,
						         IsDeleted = true,
						         Description = "Can't Find Base Component with id = " + transferRecord.FromBaseComponentId,
						         PartNumber = "Unknown",
						         SerialNumber = "Unknown"
					         };

					var a = _aircraftsCore.GetAircraftById(bd.ParentAircraftId);
					if (a != null)
						bd.Aircraft = a.ToString();

					transferRecord.FromBaseComponent = bd;
				}

				if (transferRecord.FromStoreId > 0)
				{
					var store = _storeCore.GetStoreById(transferRecord.FromStoreId) ??
					            new Store
					            {
						            ItemId = transferRecord.FromStoreId,
						            IsDeleted = true,
						            Name = "Can't Find Store with id = " + transferRecord.FromStoreId,
					            };

					transferRecord.FromStore = store;
				}

				#endregion

				#region Куда перемещен
				if (transferRecord.DestinationObjectType == SmartCoreType.Store)
				{
					var store = _storeCore.GetStoreById(transferRecord.DestinationObjectId) ??
					            new Store
					            {
						            ItemId = transferRecord.DestinationObjectId,
						            IsDeleted = true,
						            Name = "Can't Find Store with id = " + transferRecord.DestinationObjectId,
					            };

					transferRecord.DestinationObject = store;
				}

				if (transferRecord.DestinationObjectType == SmartCoreType.BaseComponent)
				{
					var bd = _componentCore.GetBaseComponentById(transferRecord.DestinationObjectId) ??
					         new BaseComponent
					         {
						         ItemId = transferRecord.DestinationObjectId,
						         IsDeleted = true,
						         Description = "Can't Find Base Component with id = " + transferRecord.DestinationObjectId,
						         PartNumber = "Unknown",
						         SerialNumber = "Unknown"
					         };

					var a = _aircraftsCore.GetAircraftById(bd.ParentAircraftId);
					if (a != null)
						bd.Aircraft = a.ToString();

					transferRecord.DestinationObject = bd;
				}
				if (transferRecord.DestinationObjectType == SmartCoreType.Aircraft)
				{
					var a = _aircraftsCore.GetAircraftById(transferRecord.DestinationObjectId) ??
					        new Aircraft
					        {
						        ItemId = transferRecord.DestinationObjectId,
						        IsDeleted = true,
						        RegistrationNumber = "Can't Find Aircraft with id = " + transferRecord.DestinationObjectId
					        };
					transferRecord.DestinationObject = a;
				}
				#endregion
			}

			return records;
		}

		#endregion

		#region public IEnumerable<TransferRecord> GetTransferRecord()

		public IEnumerable<TransferRecord> GetTransferRecord()
		{
			var records = _newLoader.GetObjectListAll<TransferRecordDTO, TransferRecord>(new Filter("ReplaceComponentId", FilterType.Grather, 0));
			foreach (var transferRecord in records)
			{
				transferRecord.ReplaceComponent =
					_componentCore.GetBaseComponentById(transferRecord.ReplaceComponentId) ??
					_componentCore.GetComponentById(transferRecord.ReplaceComponentId);

				foreach (var record in transferRecord.ReplaceComponent.TransferRecords)
				{

					#region Откуда перемещен

					if (record.FromAircraftId > 0)
					{
						var a = _aircraftsCore.GetAircraftById(record.FromAircraftId) ??
								new Aircraft
								{
									ItemId = record.FromAircraftId,
									IsDeleted = true,
									RegistrationNumber = "Can't Find Aircraft with id = " + record.FromAircraftId
								};
						record.FromAircraft = a;
					}


					if (record.FromBaseComponentId > 0)
					{
						var bd = _componentCore.GetBaseComponentById(record.FromBaseComponentId) ??
						new BaseComponent
						{
							ItemId = record.FromBaseComponentId,
							IsDeleted = true,
							Description = "Can't Find Base Component with id = " + record.FromBaseComponentId,
							PartNumber = "Unknown",
							SerialNumber = "Unknown"
						};

						var a = _aircraftsCore.GetAircraftById(bd.ParentAircraftId);
						if (a != null)
							bd.Aircraft = a.ToString();

						record.FromBaseComponent = bd;
					}

					if (record.FromStoreId > 0)
					{
						var store = _storeCore.GetStoreById(record.FromStoreId) ??
									new Store
									{
										ItemId = record.FromStoreId,
										IsDeleted = true,
										Name = "Can't Find Store with id = " + record.FromStoreId,
									};

						record.FromStore = store;
					}

					#endregion

					#region Куда перемещен
					if (record.DestinationObjectType == SmartCoreType.Store)
					{
						var store = _storeCore.GetStoreById(record.DestinationObjectId) ??
									new Store
									{
										ItemId = record.DestinationObjectId,
										IsDeleted = true,
										Name = "Can't Find Store with id = " + record.DestinationObjectId,
									};

						record.DestinationObject = store;
					}

					if (record.DestinationObjectType == SmartCoreType.BaseComponent)
					{
						var bd = _componentCore.GetBaseComponentById(record.DestinationObjectId) ??
								 new BaseComponent
								 {
									 ItemId = record.DestinationObjectId,
									 IsDeleted = true,
									 Description = "Can't Find Base Component with id = " + record.DestinationObjectId,
									 PartNumber = "Unknown",
									 SerialNumber = "Unknown"
								 };

						var a = _aircraftsCore.GetAircraftById(bd.ParentAircraftId);
						if (a != null)
							bd.Aircraft = a.ToString();

						record.DestinationObject = bd;
					}
					if (record.DestinationObjectType == SmartCoreType.Aircraft)
					{
						var a = _aircraftsCore.GetAircraftById(record.DestinationObjectId) ??
								new Aircraft
								{
									ItemId = record.DestinationObjectId,
									IsDeleted = true,
									RegistrationNumber = "Can't Find Aircraft with id = " + record.DestinationObjectId
								};
						record.DestinationObject = a;
					}
					#endregion


				}

				#region Родительский объект

				if (transferRecord.ParentType == SmartCoreType.BaseComponent)
				{
					var bd = _componentCore.GetBaseComponentById(transferRecord.ParentId) ??
							 new BaseComponent
							 {
								 ItemId = transferRecord.ParentId,
								 IsDeleted = true,
								 Description = "Can't Find Base Component with id = " + transferRecord.ParentId,
								 PartNumber = "Unknown",
								 SerialNumber = "Unknown"
							 };

					transferRecord.ParentComponent = bd;
				}
				else if (transferRecord.ParentType == SmartCoreType.Component)
				{
					var d = _componentCore.GetComponentById(transferRecord.ParentId) ??
							new Entities.General.Accessory.Component
							{
								ItemId = transferRecord.ParentId,
								IsDeleted = true,
								Description = "Can't Find Component with id = " + transferRecord.ParentId,
								PartNumber = "Unknown",
								SerialNumber = "Unknown"
							};
					transferRecord.ParentComponent = d;
				}
				else
				{
					var d = new Entities.General.Accessory.Component
					{
						ItemId = transferRecord.ParentId,
						IsDeleted = true,
						Description = "Can't Find object with type = " + transferRecord.ParentType,
						PartNumber = "Unknown",
						SerialNumber = "Unknown"
					};
					transferRecord.ParentComponent = d;
				}

				#endregion

				#region Откуда перемещен

				if (transferRecord.FromAircraftId > 0)
				{
					var a = _aircraftsCore.GetAircraftById(transferRecord.FromAircraftId) ??
							new Aircraft
							{
								ItemId = transferRecord.FromAircraftId,
								IsDeleted = true,
								RegistrationNumber = "Can't Find Aircraft with id = " + transferRecord.FromAircraftId
							};
					transferRecord.FromAircraft = a;
				}

				if (transferRecord.FromBaseComponentId > 0)
				{
					var bd = _componentCore.GetBaseComponentById(transferRecord.FromBaseComponentId) ??
							 new BaseComponent
							 {
								 ItemId = transferRecord.FromBaseComponentId,
								 IsDeleted = true,
								 Description = "Can't Find Base Component with id = " + transferRecord.FromBaseComponentId,
								 PartNumber = "Unknown",
								 SerialNumber = "Unknown"
							 };

					var a = _aircraftsCore.GetAircraftById(bd.ParentAircraftId);
					if (a != null)
						bd.Aircraft = a.ToString();

					transferRecord.FromBaseComponent = bd;
				}

				if (transferRecord.FromStoreId > 0)
				{
					var store = _storeCore.GetStoreById(transferRecord.FromStoreId) ??
								new Store
								{
									ItemId = transferRecord.FromStoreId,
									IsDeleted = true,
									Name = "Can't Find Store with id = " + transferRecord.FromStoreId,
								};

					transferRecord.FromStore = store;
				}

				#endregion

				#region Куда перемещен
				if (transferRecord.DestinationObjectType == SmartCoreType.Store)
				{
					var store = _storeCore.GetStoreById(transferRecord.DestinationObjectId) ??
								new Store
								{
									ItemId = transferRecord.DestinationObjectId,
									IsDeleted = true,
									Name = "Can't Find Store with id = " + transferRecord.DestinationObjectId,
								};

					transferRecord.DestinationObject = store;
				}

				if (transferRecord.DestinationObjectType == SmartCoreType.BaseComponent)
				{
					var bd = _componentCore.GetBaseComponentById(transferRecord.DestinationObjectId) ??
							 new BaseComponent
							 {
								 ItemId = transferRecord.DestinationObjectId,
								 IsDeleted = true,
								 Description = "Can't Find Base Component with id = " + transferRecord.DestinationObjectId,
								 PartNumber = "Unknown",
								 SerialNumber = "Unknown"
							 };

					var a = _aircraftsCore.GetAircraftById(bd.ParentAircraftId);
					if (a != null)
						bd.Aircraft = a.ToString();

					transferRecord.DestinationObject = bd;
				}
				if (transferRecord.DestinationObjectType == SmartCoreType.Aircraft)
				{
					var a = _aircraftsCore.GetAircraftById(transferRecord.DestinationObjectId) ??
							new Aircraft
							{
								ItemId = transferRecord.DestinationObjectId,
								IsDeleted = true,
								RegistrationNumber = "Can't Find Aircraft with id = " + transferRecord.DestinationObjectId
							};
					transferRecord.DestinationObject = a;
				}
				#endregion
			}

			return records;
		}

		#endregion


		#region private void SetParents(IEnumerable<TransferRecord> transfers)

		/// <summary>
		/// Выставляет обратные ссылки на воздушные суда
		/// </summary>
		/// <param name="transfers"></param>
		private void SetParents(IEnumerable<TransferRecord> transfers)
		{
			foreach (var transferRecord in transfers)
			{
				transferRecord.ParentComponent =
					_componentCore.GetBaseComponentById(transferRecord.ParentId) ??
					_componentCore.GetComponentById(transferRecord.ParentId);
			}
		}

		#endregion

		#region public void Delete(TransferRecord transferRecord)
		/// <summary>
		/// Удаление TransferRecord
		/// </summary>
		/// <param name="transferRecord"></param>
		public void Delete(TransferRecord transferRecord)
		{
			// Ограничение - если у агрегата только одна transfer record - мы не можем ее удалить ... 
			// Добавление & удаление transfer record влияет на математический аппарат 
			// Обнуляем математический аппарат
			if (transferRecord.ParentComponent != null)
			{
				if (transferRecord.ParentComponent.TransferRecords.Count == 1)
					throw new Exception("1153: Can not delete single transfer record");

				if (transferRecord.ConsumableId > 0)
				{
					//Поиск комплектующего, часть которого была перемещена данной записью
					Entities.General.Accessory.Component fromConsumable = _componentCore.GetBaseComponentById(transferRecord.ConsumableId)
										    ?? _componentCore.GetComponentById(transferRecord.ConsumableId);
					if (fromConsumable != null)
					{
						//комплектующее найдено
						//Проверка, находится ли то комплектующее, часть которого была перемещена
						//на той же локации, с которой была перемещена данная часть
						TransferRecord consumLocation = fromConsumable.TransferRecords.GetLast();
						if (consumLocation != null &&
						   ((consumLocation.DestinationObjectType == SmartCoreType.BaseComponent &&
							 consumLocation.DestinationObjectId == transferRecord.FromBaseComponentId) ||
							(consumLocation.DestinationObjectType == SmartCoreType.Aircraft &&
							 consumLocation.DestinationObjectId == transferRecord.FromAircraftId) ||
							(consumLocation.DestinationObjectType == SmartCoreType.Store &&
							 consumLocation.DestinationObjectId == transferRecord.FromStoreId)))
						{
							//Если последняя точка назначения исходного комплектующего 
							//совпадает с отправной точкой данной части исходного комплектующего
							//то необходимо удалить данную часть комплектующуго, а кол-во 
							//перемещенных единиц добавить к исходному комплектующему
							transferRecord.ParentComponent.IsDeleted = true;
							_newKeeper.Delete(transferRecord.ParentComponent, true, false);

							fromConsumable.Quantity += transferRecord.ParentComponent.Quantity > 0
														   ? transferRecord.ParentComponent.Quantity
														   : 1;
							_componentCore.Save(fromConsumable);
						}
						else
						{
							// Иначе, если не найдена последняя запись о перемещении 
							// исходного расходника или
							// если исходный расходник был перемещен с отправной точки данной части
							// то нужно произвести простой откат данной записи о перемещении

							// Сохраняем запись 
							transferRecord.IsDeleted = true;
							_newKeeper.Save(transferRecord);
							transferRecord.ParentComponent.TransferRecords.Remove(transferRecord);

							// Обновляем состояние объекта
							_newLoader.SetDestinations(transferRecord.ParentComponent);

							if (transferRecord.ParentComponent is BaseComponent)
								_calculator.ResetMath((BaseComponent)transferRecord.ParentComponent);
						}

					}
					else
					{
						// если исходный расходник не найден
						// то нужно произвести простой откат данной записи о перемещении

						// Сохраняем запись 
						transferRecord.IsDeleted = true;
						_newKeeper.Save(transferRecord);
						transferRecord.ParentComponent.TransferRecords.Remove(transferRecord);

						// Обновляем состояние объекта
						_newLoader.SetDestinations(transferRecord.ParentComponent);

						if (transferRecord.ParentComponent is BaseComponent)
							_calculator.ResetMath((BaseComponent)transferRecord.ParentComponent);
					}
				}
				else
				{
					// Сохраняем запись 
					transferRecord.IsDeleted = true;
					_newKeeper.Save(transferRecord);
					transferRecord.ParentComponent.TransferRecords.Remove(transferRecord);

					// Обновляем состояние объекта
					_newLoader.SetDestinations(transferRecord.ParentComponent);

					if (transferRecord.ParentComponent is BaseComponent)
						_calculator.ResetMath((BaseComponent)transferRecord.ParentComponent);
				}
			}
			else
			{
				throw new Exception("1000: Failed to specify tranfer record parent type");
			}
		}

		#endregion


	}
}