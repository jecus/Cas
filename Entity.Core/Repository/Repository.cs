using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Entity.Models.Attributte;
using Entity.Models.DTO;
using Entity.Models.DTO.General;
using Entity.Models.Filter;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace Entity.Core.Repository
{
	public class Repository<T> : IRepository<T> where T : BaseEntity
	{
		protected DbContext _context;
		protected DbSet<T> _dbset;

		public Repository(DataContext context)
		{
			_context = context;
			_dbset = context.Set<T>();
		}

		protected Repository()
		{
			
		}

		#region Async

		public async Task<IList<int>> GetSelectColumnOnlyAsync(IEnumerable<Filter> filters, string selectProperty)
		{
			using (_context)
			{
				IQueryable<T> query = _dbset;

				var conditionAttributes = typeof(T).GetCustomAttributes(typeof(ConditionAttribute), false).Cast<ConditionAttribute>().ToList();
				foreach (var attribute in conditionAttributes)
				{
					var func = LambdaConstructor<T>(attribute.ColumnName, attribute.Condition, FilterType.Equal);
					query = query.Where(func);
				}

				if (filters != null)
				{
					foreach (var filter in filters)
					{
						if (filter.Values != null && filter.Values.Any())
							query = query.Where(filter.FilterProperty, filter.Values);
						else if (filter.Value != null)
							query = query.Where(LambdaConstructor<T>(filter.FilterProperty, filter.Value, filter.FilterType));
					}
				}

				var any = DynamicQueryable.Any(query);
				if(any)
					return await query.AsNoTracking().Select(selectProperty).ToListAsync();

				return new List<int>();
			}
		}

		public async Task<T> GetObjectByIdAsync(int id, bool loadChild = false)
		{
			using (_context)
				return await getAllQueryable(new[] { new Filter("ItemId", id) }, loadChild).AsNoTracking().FirstOrDefaultAsync();
		}

		public async Task<T> GetObjectAsync(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false)
		{
			using (_context)
				return await getAllQueryable(filters, loadChild, getDeleted, getAll).AsNoTracking().FirstOrDefaultAsync();
		}

		public async Task<IList<T>> GetObjectListAsync(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
		{
            try
            {
                using (_context)
                    return await getAllQueryable(filters, loadChild, getDeleted).AsNoTracking().ToListAsync();
			}
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
			
		}

		public async Task<IList<T>> GetObjectListAllAsync(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
		{
			using (_context)
				return await getAllQueryable(filters, loadChild, getDeleted, true).AsNoTracking().ToListAsync();
		}

		public async Task<int> SaveAsync(T entity)
		{
			try
			{
				if (entity.ItemId <= 0)
				{
					entity.ItemId = 0;
					Add(entity);
				}
				else Update(entity);

				await _context.SaveChangesAsync();

				return entity.ItemId;
			}
			catch (Exception exception)
			{
				throw exception;
			}
		}

		public async Task DeleteAsync(T entity)
		{
			_dbset.Attach(entity);
			_dbset.Remove(entity);
			_context.Entry(entity).State = EntityState.Deleted;

			await _context.SaveChangesAsync();
		}

		private void Add(T entity)
		{
			_dbset.Add(entity);
			_context.Entry(entity).State = EntityState.Added;
		}

		private void Update(T entity)
		{
			_dbset.Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}

		public void Delete(T entity)
		{
			_dbset.Attach(entity);
			_dbset.Remove(entity);
			_context.Entry(entity).State = EntityState.Deleted;

			_context.SaveChanges();
		}

		public async Task BulkInsertASync(IEnumerable<T> entity, int? batchSize = null)
		{
			if (!batchSize.HasValue)
				batchSize = 250;

			await _context.BulkInsertAsync(entity.ToList(), config => { config.BatchSize = batchSize.Value;
			});
		}

		public async Task BulkUpdateAsync(IEnumerable<T> entity, int? batchSize = null)
		{
			if (!batchSize.HasValue)
				batchSize = 250;

			await _context.BulkUpdateAsync(entity.ToList(), config => { config.BatchSize = batchSize.Value; });
		}

		public async Task BulkDeleteAsync(IEnumerable<T> entity, int? batchSize = null)
		{
			if (!batchSize.HasValue)
				batchSize = 250;

			await _context.BulkDeleteAsync(entity.ToList(), config => { config.BatchSize = batchSize.Value; });
		}

		#endregion


		private IQueryable<T> getAllQueryable(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false)
		{
			IQueryable<T> query = _dbset;

			if (filters != null)
			{
				foreach (var filter in filters)
				{
					if(filter.Values != null && filter.Values.Any())
						query = query.Where(filter.FilterProperty, filter.Values);
					else if(filter.Value != null)
						query = query.Where(LambdaConstructor<T>(filter.FilterProperty, filter.Value, filter.FilterType));
				}
			}

			var conditionAttributes = typeof(T).GetCustomAttributes(typeof(ConditionAttribute), false).Cast<ConditionAttribute>().ToList();
			foreach (var attribute in conditionAttributes)
			{
				if(getDeleted && attribute.ColumnName.ToLower() == "isdeleted")
					continue;

				var func = LambdaConstructor<T>(attribute.ColumnName, attribute.Condition, FilterType.Equal);
				query = query.Where(func);
			}


			var includeProperties = typeof(T).GetProperties().Where(i => i.GetCustomAttributes(typeof(IncludeAttribute), false).Length != 0);
			foreach (var property in includeProperties)
			{
				query = query.Include(property.Name);


				IEnumerable<PropertyInfo> includeParentProperties;
				if (property.PropertyType.IsGenericType)
					includeParentProperties = property.PropertyType.GenericTypeArguments[0].GetProperties().Where(i => i.GetCustomAttributes(typeof(IncludeAttribute), false).Length != 0);
				else includeParentProperties = property.PropertyType.GetProperties().Where(i => i.GetCustomAttributes(typeof(IncludeAttribute), false).Length != 0);

				foreach (var propertyInfo in includeParentProperties)
					query = query.Include($"{property.Name}.{propertyInfo.Name}");

				if (getAll)
				{
					IEnumerable<PropertyInfo> childParentProperties;
					if (property.PropertyType.IsGenericType)
						childParentProperties = property.PropertyType.GenericTypeArguments[0].GetProperties().Where(i => i.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0);
					else childParentProperties = property.PropertyType.GetProperties().Where(i => i.GetCustomAttributes(typeof(IncludeAttribute), false).Length != 0);

					foreach (var propertyInfo in childParentProperties)
						query = query.Include($"{property.Name}.{propertyInfo.Name}");
				}
			}

			if (loadChild)
			{
				var childProperties = typeof(T).GetProperties().Where(i => i.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0);
				foreach (var property in childProperties)
				{
					var attribute = (ChildAttribute)property.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();
					if (string.IsNullOrEmpty(attribute.ParentProperty) && attribute.ParentProperty == null)
					{
						if (property.PropertyType.GenericTypeArguments.Length > 0)
							query = GetQuery(query, property.PropertyType.GenericTypeArguments[0].FullName, property.Name, false);
						else query = query.Include(property.Name);
					}
					else
						query = GetQuery(query, property.PropertyType.GenericTypeArguments[0].FullName, property.Name, attribute.ParentProperty, attribute.ParentPropertyValue, attribute.Filter, false);


					IEnumerable<PropertyInfo> includeParentProperties;
					if (property.PropertyType.IsGenericType)
						includeParentProperties = property.PropertyType.GenericTypeArguments[0].GetProperties().Where(i => i.GetCustomAttributes(typeof(IncludeAttribute), false).Length != 0);
					else includeParentProperties = property.PropertyType.GetProperties().Where(i => i.GetCustomAttributes(typeof(IncludeAttribute), false).Length != 0);
					
					foreach (var propertyInfo in includeParentProperties)
						query = query.Include($"{property.Name}.{propertyInfo.Name}");

					if (getAll)
					{
						IEnumerable<PropertyInfo> childParentProperties;
						if (property.PropertyType.IsGenericType)
							childParentProperties = property.PropertyType.GenericTypeArguments[0].GetProperties().Where(i => i.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0);
						else childParentProperties = property.PropertyType.GetProperties().Where(i => i.GetCustomAttributes(typeof(IncludeAttribute), false).Length != 0);

						foreach (var propertyInfo in childParentProperties)
							query = query.Include($"{property.Name}.{propertyInfo.Name}");
					}
				}
			}

			return query;
		}

		private Expression<Func<T, bool>> LambdaConstructor<T>(string propertyName, object inputText, FilterType condition) where T : BaseEntity
		{
			var item = Expression.Parameter(typeof(T), "item");
			var prop = Expression.Property(item, propertyName);
			var propertyInfo = typeof(T).GetProperty(propertyName);

			var type = propertyInfo.PropertyType;
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				type =  Nullable.GetUnderlyingType(type);
			}

			var value = Expression.Constant(Convert.ChangeType(inputText, type));
			var res = Expression.Convert(value, propertyInfo.PropertyType);
			BinaryExpression equal;
			switch (condition)
			{
				case FilterType.Equal:
					equal = Expression.Equal(prop, res);
					break;
				case FilterType.Grather:
					equal = Expression.GreaterThan(prop, res);
					break;
				case FilterType.GratherOrEqual:
					equal = Expression.GreaterThanOrEqual(prop, res);
					break;
				case FilterType.Less:
					equal = Expression.LessThan(prop, res);
					break;
				case FilterType.LessOrEqual:
					equal = Expression.LessThanOrEqual(prop, res);
					break;
				case FilterType.NotEqual:
					equal = Expression.NotEqual(prop, res);
					break;
				case FilterType.Contains:
					var parameterExp = Expression.Parameter(typeof(T), "type");
					var propertyExp = Expression.Property(parameterExp, propertyName);
					var method = type.GetMethod("Contains", new[] { type });
					var someValue = Expression.Constant(inputText, typeof(string));
					var containsMethodExp = Expression.Call(propertyExp, method, someValue);
					return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
					break;
				default:
					equal = Expression.Equal(prop, res);
					break;
			}
			var lambda = Expression.Lambda<Func<T, bool>>(equal, item);
			return lambda;
		}

		private IQueryable<T> GetQuery(IQueryable<T> query, string typeCollection, string property, string parentProperty,
			object inputText, FilterType condition, bool deletedCondition)
		{

			Type baseType = typeof(T);
			Type parentType = Type.GetType(typeCollection);
			// Create object of desired type
			ParameterExpression aircraftFlightObject = Expression.Parameter(baseType, "parameter");

			// Locate files property
			MemberExpression filesPropertyExpression = Expression.Property(aircraftFlightObject, property);

			// Prepare prototype where method
			var whereMethod =
				new Func<IEnumerable<IBaseEntity>, Func<IBaseEntity, bool>, IEnumerable<IBaseEntity>>(Enumerable.Where);

			// Prepare specific where method. itemFileLinkType can be replaced by any other type
			var whereMethodGeneric = whereMethod.Method.GetGenericMethodDefinition().MakeGenericMethod(parentType);

			// Getting item types and parentId property
			ParameterExpression itemFileLinkExpression = Expression.Parameter(parentType, "i");
			Expression parentTypeIdExpression = Expression.Property(itemFileLinkExpression, parentProperty);

			var type = parentType.GetProperty(parentProperty);

			BinaryExpression equal;
			// Create the lambda for where method (your condition for where clause)
			switch (condition)
			{
				case FilterType.Equal:
					equal = Expression.Equal(parentTypeIdExpression,
						Expression.Convert(Expression.Constant(inputText), type.PropertyType));
					break;
				case FilterType.Grather:
					equal = Expression.GreaterThan(parentTypeIdExpression,
						Expression.Convert(Expression.Constant(inputText), type.PropertyType));
					break;
				case FilterType.GratherOrEqual:
					equal = Expression.GreaterThanOrEqual(parentTypeIdExpression,
						Expression.Convert(Expression.Constant(inputText), type.PropertyType));
					break;
				case FilterType.Less:
					equal = Expression.LessThan(parentTypeIdExpression,
						Expression.Convert(Expression.Constant(inputText), type.PropertyType));
					break;
				case FilterType.LessOrEqual:
					equal = Expression.LessThanOrEqual(parentTypeIdExpression,
						Expression.Convert(Expression.Constant(inputText), type.PropertyType));
					break;
				case FilterType.NotEqual:
					equal = Expression.NotEqual(parentTypeIdExpression,
						Expression.Convert(Expression.Constant(inputText), type.PropertyType));
					break;
				default:
					equal = Expression.Equal(parentTypeIdExpression,
						Expression.Convert(Expression.Constant(inputText), type.PropertyType));
					break;
			}


			Expression isDelExpression = Expression.Property(itemFileLinkExpression, "IsDeleted");
			var isDeltype = parentType.GetProperty("IsDeleted");

			var isDel = Expression.Equal(isDelExpression, Expression.Convert(Expression.Constant(deletedCondition), isDeltype.PropertyType));

			var lambdaForWhere = Expression.Lambda(Expression.AndAlso(equal, isDel), itemFileLinkExpression);
			var whereCall = Expression.Call(null, whereMethodGeneric, filesPropertyExpression, lambdaForWhere);
			var lambda = Expression.Lambda(whereCall, aircraftFlightObject);

			if (typeCollection.Contains("ItemFileLinkDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<ItemFileLinkDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("ComponentLLPCategoryDataDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<ComponentLLPCategoryDataDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("ComponentLLPCategoryChangeRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<ComponentLLPCategoryChangeRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("TransferRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<TransferRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("ComponentDirectiveDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<ComponentDirectiveDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("ActualStateRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<ActualStateRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("MaintenanceProgramChangeRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<MaintenanceProgramChangeRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("AuditRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<AuditRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("DirectiveRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<DirectiveRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("CategoryRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<CategoryRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("AccessoryRequiredDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<AccessoryRequiredDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("KitSuppliersRelationDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<KitSuppliersRelationDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("EventConditionDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<EventConditionDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("DocumentDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<DocumentDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("DamageSectorDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<DamageSectorDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("DamageDocumentDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<DamageDocumentDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("FlightTrackRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<FlightTrackRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("InitialOrderRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<InitialOrderRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("JobCardTaskDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<JobCardTaskDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("MaintenanceDirectiveDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<MaintenanceDirectiveDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("MTOPCheckRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<MTOPCheckRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("ProcedureDocumentReferenceDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<ProcedureDocumentReferenceDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("RequestRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<RequestRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("RequestForQuotationRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<RequestForQuotationRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("SpecialistLicenseDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<SpecialistLicenseDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("SpecialistTrainingDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<SpecialistTrainingDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("SpecialistLicenseDetailDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<SpecialistLicenseDetailDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("SpecialistLicenseRemarkDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<SpecialistLicenseRemarkDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("SpecialistCAADTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<SpecialistCAADTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("SpecialistLicenseRatingDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<SpecialistLicenseRatingDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("SpecialistInstrumentRatingDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<SpecialistInstrumentRatingDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("WorkOrderRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<WorkOrderRecordDTO>>>(lambda.Body, lambda.Parameters));
			throw new Exception($"Type({typeCollection}) not Found!");
		}

		private IQueryable<T> GetQuery(IQueryable<T> query, string typeCollection, string property, bool deletedCondition)
		{

			Type baseType = typeof(T);
			Type parentType = Type.GetType(typeCollection);
			// Create object of desired type
			ParameterExpression aircraftFlightObject = Expression.Parameter(baseType, "parameter");

			// Locate files property
			MemberExpression filesPropertyExpression = Expression.Property(aircraftFlightObject, property);

			// Prepare prototype where method
			var whereMethod =
				new Func<IEnumerable<IBaseEntity>, Func<IBaseEntity, bool>, IEnumerable<IBaseEntity>>(Enumerable.Where);

			// Prepare specific where method. itemFileLinkType can be replaced by any other type
			var whereMethodGeneric = whereMethod.Method.GetGenericMethodDefinition().MakeGenericMethod(parentType);

			// Getting item types and parentId property
			ParameterExpression itemFileLinkExpression = Expression.Parameter(parentType, "i");
			

			Expression isDelExpression = Expression.Property(itemFileLinkExpression, "IsDeleted");
			var isDeltype = parentType.GetProperty("IsDeleted");

			var isDel = Expression.Equal(isDelExpression, Expression.Convert(Expression.Constant(deletedCondition), isDeltype.PropertyType));

			var lambdaForWhere = Expression.Lambda(isDel, itemFileLinkExpression);
			var whereCall = Expression.Call(null, whereMethodGeneric, filesPropertyExpression, lambdaForWhere);
			var lambda = Expression.Lambda(whereCall, aircraftFlightObject);

			if (typeCollection.Contains("ItemFileLinkDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<ItemFileLinkDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("ComponentLLPCategoryDataDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<ComponentLLPCategoryDataDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("ComponentLLPCategoryChangeRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<ComponentLLPCategoryChangeRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("TransferRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<TransferRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("ComponentDirectiveDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<ComponentDirectiveDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("ActualStateRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<ActualStateRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("MaintenanceProgramChangeRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<MaintenanceProgramChangeRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("AuditRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<AuditRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("DirectiveRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<DirectiveRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("CategoryRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<CategoryRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("AccessoryRequiredDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<AccessoryRequiredDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("KitSuppliersRelationDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<KitSuppliersRelationDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("EventConditionDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<EventConditionDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("DocumentDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<DocumentDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("DamageSectorDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<DamageSectorDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("DamageDocumentDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<DamageDocumentDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("FlightTrackRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<FlightTrackRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("InitialOrderRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<InitialOrderRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("JobCardTaskDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<JobCardTaskDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("MaintenanceDirectiveDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<MaintenanceDirectiveDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("MTOPCheckRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<MTOPCheckRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("ProcedureDocumentReferenceDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<ProcedureDocumentReferenceDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("RequestRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<RequestRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("RequestForQuotationRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<RequestForQuotationRecordDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("SpecialistLicenseDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<SpecialistLicenseDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("SpecialistTrainingDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<SpecialistTrainingDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("SpecialistLicenseDetailDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<SpecialistLicenseDetailDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("SpecialistLicenseRemarkDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<SpecialistLicenseRemarkDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("SpecialistCAADTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<SpecialistCAADTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("SpecialistLicenseRatingDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<SpecialistLicenseRatingDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("SpecialistInstrumentRatingDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<SpecialistInstrumentRatingDTO>>>(lambda.Body, lambda.Parameters));
			if (typeCollection.Contains("WorkOrderRecordDTO"))
				return query.IncludeFilter(Expression.Lambda<Func<T, IEnumerable<WorkOrderRecordDTO>>>(lambda.Body, lambda.Parameters));
			throw new Exception($"Type({typeCollection}) not Found!");
		}
	}
}