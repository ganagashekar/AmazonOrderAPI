using AmazonOrderAPI.DataContext.Entities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AmazonOrderAPI.Business.CoreExtentions
{
    public static class ObjectExtensions
    {
        private static string[] _ExcludedProperties = new string[] { };
        static ObjectExtensions()
        {
           
        }

        /// <summary>
        /// Validate the object is null or not.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
        

        /// <summary>
        /// Validate the object is null or not.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns></returns>
        public static bool IsNotNull(this object obj)
        {
            return !obj.IsNull();
        }

        /// <summary>
        /// Whether the collection objcet has any data or not.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns></returns>
        public static bool IsNotValidCollection(this ICollection value)
        {
            if (value.IsNull() || value.Count == 0)
                return true;
            return false;
        }

       
        /// <summary>
        /// To get the id for BaseEntity.
        /// </summary>
        /// <typeparam name="T">Type should have BaseEntity.</typeparam>
        /// <param name="source">Source Data.</param>
        /// <returns></returns>
        public static long ToEntityId<T>(this T source) where T : Entity
        {
            return source.IsNotNull() ? source.Id :default(long);
        }

        
        public static object GetPropValue(object src, string propName)
        {
            if (src.GetType().GetProperty(propName) != null)
                return src.GetType().GetProperty(propName).GetValue(src, null);
            else
                return null;
        }

        /// <summary>
        /// Converts the object to Double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ParseDouble(this object value)
        {
            double output;
            if (value == null)
                return 0.0;
            Double.TryParse(value.ToString(), out output);
            return output;
        }

        /// <summary>
        /// Converts the object to Double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ParseString(this object value)
        {
            if (value == null)
                return "0.0";
            return value.ToString();
        }
        /// <summary>
        /// Converts the object to Decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ParseDecimal(object value)
        {
            decimal output;
            if (value == null)
                return decimal.Zero;
            decimal.TryParse(value.ToString(), out output);
            return output;
        }
        
       

        /// <summary>
        /// Converts the object to Double with single point
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ParseDoubleToSigleDecimal(object value)
        {
            double output;
            if (value == null)
                return string.Empty;
            Double.TryParse(value.ToString(), out output);
            return output == 0.0 ? string.Empty : Math.Abs(Math.Round(output, 1)).ToString();
        }

        /// <summary>
        /// Parse Nullable
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double? ParseNullableDouble(object value)
        {
            double output;
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return null;
            double.TryParse(value.ToString(), out output);
            return output;
        }

        /// <summary>
        /// Converts the object to Double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ParseStringByRounding(object value)
        {
            double output;
            if (value == null || value.ToString().ToUpper() == "infinity".ToUpper() || value.ToString().ToUpper() == "NaN".ToUpper())
                return string.Empty;
            Double.TryParse(value.ToString(), out output);
            return String.Concat(Math.Abs(Math.Round(output, 1)).ToString(), " x");
        }

        /// <summary>
        /// Converts the object to Integer
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ParseInt(object value)
        {
            int output;
            if (value == null)
                return (int)decimal.Zero;
            Int32.TryParse(value.ToString(), out output);
            return output;
        }
        /// <summary>
        /// Converts the object to Integer
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToParseInt(this object value)
        {
            int output;
            if (value == null)
                return (int)decimal.Zero;
            Int32.TryParse(value.ToString(), out output);
            return output;
        }

        /// <summary>
        /// To create a instance ,if the entity is null.
        /// </summary>
        /// <typeparam name="T">Type.Should have default constructor.</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        public static T ToInstance<T>(this T entity) where T : new()
        {
            return entity.IsNotNull() ? entity : new T { };
        }

        

        /// <summary>
        /// To deserialize the json string
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="jsonString">Json String</param>
        /// <returns></returns>
        public static T GetDeserialize<T>(this string jsonString) where T : class, new()
        {
            if (jsonString.IsNull())
                return new T { };
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static string GetserializeJsonString(this object obj) 
        {
            if (obj.IsNull())
                return string.Empty;
            return  JsonConvert.SerializeObject(obj);
           
        }


        public static long ToGetId<T>(this T data) where T : Entity
        {
            return data.IsNotNull() ? data.Id : 0;
        }

        public static bool IsExist(this string[] data, string code)
        {
            if (data.IsNull() || code.IsNull())
                return false;
            return data.Any(x => x.IsEqualsIgnoreCase(code));
        }

        public static string[] ToGetProperties(this Type type)
        {
            if (type.IsNull())
                return new string[] { };
            return type.GetProperties().Select(s => s.Name).ToArray();
        }

        public static string ToAppString(this object data)
        {
            if (data.IsNull())
                return string.Empty;
            return data.ToString();
        }

       

        public static bool HasChanges<T1, T2>(this T1 source, T2 otherSource, Type excludedType = null)
            where T1 : Entity, new()
            where T2 : Entity, new()
        {
            //   excludedType = excludedType ?? typeof(BaseAuditEntity);
            var otherSourceTemp = otherSource.ToDestination<T2, T1>();
            //if (typeof(BaseAuditEntity) == excludedType)
            //    return source.HasChanges<T1>(otherSourceTemp, _ExcludedProperties);
            return source.HasChanges<T1>(otherSourceTemp, excludedType.ToGetProperties());
        }

        public static bool HasChanges<T>(this T source, T otherSource, string[] excludedProperties) where T : class
        {
            excludedProperties = excludedProperties ?? new string[] { };
            if (source.IsNull() && otherSource.IsNull())
                return false;
            if ((source.IsNull() && otherSource.IsNotNull()) || (source.IsNotNull() && otherSource.IsNull()))
                return true;
            var status = false;
            // Should exclude all the complex type.
            var includedProperties = typeof(T).GetProperties().Where(x => !x.PropertyType.IsClass || (x.PropertyType.IsClass && x.PropertyType.FullName.IsEqualsIgnoreCase("System.String")))
                .Where(x => !excludedProperties.Any(s => s.IsEqualsIgnoreCase(x.Name)) && !x.PropertyType.FullName.IsStartWithIgnoreCase("System.Collections.Generic."));
            foreach (var property in includedProperties)
            {
                var soureValue = source.GetPropertyValue(property.Name).ToAppString();
                var otherSourceValue = otherSource.GetPropertyValue(property.Name).ToAppString();
                if (!soureValue.IsEqualsIgnoreCase(otherSourceValue))
                {
                    status = true;
                    break;
                }
            }
            return status;
        }

        public static void DbChange<T>(this ICollection<T> data, Action<T> updateAction) where T : Entity
        {
            if (data.IsNull() || updateAction.IsNull())
                return;
            data.ToList().ForEach(x => updateAction(x));
        }




        public static TResult ToFirstOrDefult<TEntity, TResult>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
            where TEntity : class
        {
            return query.Where(predicate).Select(selector).FirstOrDefault();
        }

        public static double? GetValue<T>(this List<T> src, string propName, bool isAll = true) where T : class
        {
            if (propName == null)
                return 0;

            if (isAll)
                return src.Sum(x => (double?)x.GetValue(propName));
            else
                return (double?)src.FirstOrDefault().GetValue(propName);

        }

        public static object GetValue<T>(this T src, string propName) where T : class
        {
            if (src.GetType().GetProperty(propName) != null)
                return src.GetType().GetProperty(propName).GetValue(src, null);
            else
                return null;
        }

        public static TEntity[] ToFilteredArray<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
          where TEntity : class
        {
            return query.Where(predicate).ToArray();
        }

        public static TResult[] ToFilteredArray<TEntity, TResult>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
            where TEntity : class
            where TResult : class
        {
            return query.Where(predicate).Select(selector).ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string input)
        {
            int test;
            return int.TryParse(input, out test);
        }
    }
}
