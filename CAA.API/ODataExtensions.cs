using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Entity.Abstractions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Microsoft.OData.UriParser;
using Newtonsoft.Json.Serialization;
using OData.QueryBuilder.Extensions.Odata;

namespace API.Abstractions
{
    public static class ODataExtensions
{
   public static ConcurrentDictionary<Type,ODataQueryContext> builders = new ConcurrentDictionary<Type,ODataQueryContext> ();
   public static ODataQueryOptions<TOutView> SetDefaultPageSize<TOutView>(this ODataQueryOptions<TOutView> options) where TOutView : class, IBaseEntity
   {
       if (options?.Top == null)
           options = options.SetTop(1000);
       else
       {
           if (int.TryParse(options.Top.RawValue, out var top))
           {
               if(top > 1000)
                   options = options.SetTop(1000);
           }
           else options = options.SetTop(1000);
       }

       if ((options?.Top != null || options?.Skip != null) && options.OrderBy == null)
           options = options.SetOrderBy(i => i.ItemId);

       return options;
   }
  
   public static ODataQueryOptions<TOutView> SetViewDefaultPageSize<TOutView>(this ODataQueryOptions<TOutView> options) where TOutView : class
   {
       if (options?.Top == null)
           options = options.SetTop(1000);
       else
       {
           if (int.TryParse(options.Top.RawValue, out var top))
           {
               if(top > 1000)
                   options = options.SetTop(1000);
           }
           else options = options.SetTop(1000);
       }
       return options;
   }
  
   /// <summary>
   /// В двух словах превращает проперти в snake_case чтоб Odata понимала как фильтровать
   /// </summary>
   /// <returns>Подготовленный для работы с snake case фильтр</returns>
   public static ODataQueryOptions PrepareFilter<TOutView>(this ODataQueryOptions<TOutView> options) where TOutView : class
   {
       if (builders.ContainsKey(typeof(TOutView)))
       {
           var context = builders[typeof(TOutView)];
           return new ODataQueryOptions(context, options.Request);
       }
       else
       {
           var namingStrategy = new CamelCaseNamingStrategy();
           var builder = new ODataConventionModelBuilder()
           {
               OnModelCreating = builder =>
               {
                   foreach (var structuralType in builder.StructuralTypes)
                   {
                       foreach (var prop in structuralType.Properties)
                           prop.Name = namingStrategy.GetPropertyName(prop.Name, false);
                   }
               }
           };
      
           builder.EntitySet<TOutView>(typeof(TOutView).Name);
           var context = new ODataQueryContext(builder.GetEdmModel(), typeof(TOutView), new ODataPath());
           builders.TryAdd(typeof(TOutView), context);
           return new ODataQueryOptions(context, options.Request);
       }
   }

   /// <summary>
   /// Apply the individual query to the given <see cref="IQueryable"/> in the right order
   /// and cast <see cref="IQueryable"/> to <see cref="IQueryable{TOutResult}"/>.
   /// Throw exception if cast not successful.
   /// </summary>
   public static IQueryable<TOutView> ApplyTo<TOutView>(this ODataQueryOptions options, IQueryable collection, AllowedQueryOptions ignoreQueryOptions = AllowedQueryOptions.None) where TOutView : class
   {
       return options.ApplyTo(collection,new ODataQuerySettings(){EnsureStableOrdering = false, TimeZone = TimeZoneInfo.Utc}, ignoreQueryOptions).Cast<TOutView>();
   }
  
  
   /// <summary>
   /// Метод который фиксит Contains(использует Like вместо CharIndex)
   /// </summary>
   /// <param name="query"></param>
   /// <typeparam name="T"></typeparam>
   /// <returns></returns>
   public static IQueryable<T> FixQuery<T>(this IQueryable<T> query)
   {
       return query.Provider.CreateQuery<T>(
           new FixQueryVisitor().Visit(query.Expression)
       );
   }
}





class FixQueryVisitor : ExpressionVisitor
{
   private readonly MethodInfo _likeMethod = ExtractMethod(() => EF.Functions.Like(string.Empty, string.Empty));
   private readonly string pattern= "%like%";

   private static MethodInfo ExtractMethod(Expression<Action> expr)
   {
       MethodCallExpression body = (MethodCallExpression)expr.Body;

       return body.Method;
   }
  
   protected override Expression VisitMethodCall(MethodCallExpression node)
   {
       if (node.Method.DeclaringType == typeof(string) && node.Method.Name == "Contains")
       {
           var method = typeof(string).GetMethod("Replace", new []{typeof(String), typeof(String)});
           var replaceCall = Expression.Call(Expression.Constant(pattern), method, Expression.Constant("like"), node.Arguments[0]);
           var call = Expression.Call(this._likeMethod, Expression.Constant(EF.Functions), node.Object, replaceCall);
           return call;
       }
      
       return base.VisitMethodCall(node);
   }
}


public static class Expand {
   public static string[] GetExpandProperties<TOutView>(ODataQueryOptions options)
   {
       var res = new List<string>();
       var expands = options?.SelectExpand?.RawExpand;
       if (string.IsNullOrWhiteSpace(expands))
           return res.ToArray();

       var properties = typeof(TOutView).GetProperties().Select(i => i.Name);

       foreach (var expand in expands.Split(','))
       {
           if (expand.Contains("/"))
           {
               var ex = expand.Split("/").Select(ToCamelCase);
               var newExpand =string.Join(".", ex);
               if(CheckPath(typeof(TOutView),newExpand))
                   res.Add(newExpand );
           }
           else if(properties.Contains(ToCamelCase(expand)))
               res.Add(ToCamelCase(expand));
       }
      
       return res.ToArray();
   }
  
   private static bool CheckPath(Type type, string path){
       var pp = path.Split('.');
       foreach(var prop in pp){
           var propInfo = type.GetProperty(prop);
           if(propInfo == null)
               return false;
           type = propInfo.PropertyType;
       }
       return true;
   }

   public static string ToCamelCase(string str)
   {
       return str.Split(new [] {"_"}, StringSplitOptions.RemoveEmptyEntries).Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1)).Aggregate(string.Empty, (s1, s2) => s1 + s2).Trim();
   }
}


}