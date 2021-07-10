using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace AmazonOrderAPI.Business.CoreExtentions
{
    public static class CoreMapExtension
    {

        /// <summary>
        ///  To convert the one object to other object..
        ///  Automapper is used for mapping.
        /// </summary>
        /// <typeparam name="TSource">Should Be Class Type.</typeparam>
        /// <typeparam name="TDest">Should Be Class Type.</typeparam>
        /// <param name="source">Source Data.</param>
        /// <param name="dest">Desdtination Data.</param>
        /// <returns></returns>
        public static TDest ToDestination<TSource, TDest>(this TSource source, TDest dest = null)
            where TSource : class, new()
            where TDest : class, new()
        {
            if (source.IsNull())
                return null;
            if (dest.IsNull())
                return Mapper.Map<TSource, TDest>(source);
            return Mapper.Map<TSource, TDest>(source, dest);
        }




        /// <summary>
        ///  To convert the one object to other object..
        ///  Automapper is used for mapping.
        /// </summary>
        /// <typeparam name="TSource">Should Be Class Type.</typeparam>
        /// <typeparam name="TDest">Should Be Class Type.</typeparam>
        /// <param name="source">Source Data.</param>
        /// <param name="opts">IMappingOperationOptions Data.</param>
        /// <returns></returns>
        public static TDest ToDestination<TSource, TDest>(this TSource source, Action<IMappingOperationOptions> opts)
            where TSource : class, new()
            where TDest : class, new()
        {
            if (source.IsNull())
                return null;
            if (opts.IsNull())
                return Mapper.Map<TSource, TDest>(source);
            return Mapper.Map<TSource, TDest>(source, opts);
        }

        /// <summary>
        ///  To convert the one object to other object..
        ///  Automapper is used for mapping.
        /// </summary>
        /// <typeparam name="TSource">Should Be Class Type.</typeparam>
        /// <typeparam name="TDest">Should Be Class Type.</typeparam>
        /// <param name="source">Source Data.</param>
        /// <param name="dest">Desdtination Data.</param>
        /// <param name="opts">IMappingOperationOptions Data.</param>
        /// <returns></returns>
        public static TDest ToDestination<TSource, TDest>(this TSource source, TDest dest, Action<IMappingOperationOptions> opts = null)
            where TSource : class, new()
            where TDest : class, new()
        {
            if (source.IsNull())
                return null;
            if (opts.IsNull())
                return Mapper.Map<TSource, TDest>(source, dest);
            return Mapper.Map<TSource, TDest>(source, dest, opts);
        }

        /// <summary>
        ///  ASync : To convert the one object to other object.
        ///  Automapper is used for mapping.
        /// </summary>
        /// <typeparam name="TSource">Should Be Class Type.</typeparam>
        /// <typeparam name="TDest">Should Be Class Type.</typeparam>
        /// <param name="source">Source Data.</param>
        /// <param name="dest">Destination Data.</param>
        /// <returns></returns>
        public static async Task<TDest> ToDestinationAsync<TSource, TDest>(this Task<TSource> source, TDest dest = null)
            where TSource : class, new()
            where TDest : class, new()
        {
            if (source.IsNull())
                return null;
            var data = await source;
            if (dest.IsNull())
                return Mapper.Map<TSource, TDest>(data);
            return Mapper.Map<TSource, TDest>(data, dest);
        }

        ///  To convert the ICollection Entity object to array of DTO.
        ///  Automapper is used for mapping.
        /// </summary>
        /// <typeparam name="TSource">Entity' Object Type.Base class should be Entity</typeparam>
        /// <typeparam name="TDestination">'DTO' Object Type.Base class should be BaseDto.</typeparam>
        /// <param name="list">ICollection of SOURCE array Type.It is collection of data .</param>
        /// <param name="opts">Option Data.</param>
        /// <returns>Array of 'DTO'.</returns>
        public static TDestination[] ToDestinationArray<TSource, TDestination>(this ICollection<TSource> list, Action<IMappingOperationOptions> opts = null)
            where TSource : class, new()
            where TDestination : class, new()
        {
            if (list.IsNull())
                return new TDestination[] { };
            return Mapper.Map<TSource[], TDestination[]>(list.ToArray());
            if (opts.IsNotNull())
                return Mapper.Map<TSource[], TDestination[]>(list.ToArray());
            return Mapper.Map<TSource[], TDestination[]>(list.ToArray(), opts);
        }


        ///  To convert the IEnumerable Entity object to array of DTO.
        ///  Automapper is used for mapping.
        /// </summary>
        /// <typeparam name="TSource">Entity' Object Type.Base class should be Entity</typeparam>
        /// <typeparam name="TDestination">'DTO' Object Type.Base class should be BaseDto.</typeparam>
        /// <param name="list">ICollection of SOURCE array Type.It is collection of data .</param>
        /// <returns>Array of 'DTO'.</returns>
        public static TDestination[] ToDestinationArray<TSource, TDestination>(this IEnumerable<TSource> list)
            where TSource : class, new()
            where TDestination : class, new()
        {
            if (list.IsNull())
                return new TDestination[] { };
            return Mapper.Map<TSource[], TDestination[]>(list.ToArray());
        }


        /// <summary>
        ///  Async method to convert the IQueryable of Entity object to task array of DTO object.
        ///  Automapper is used for mapping.
        /// </summary>
        /// <typeparam name="TSource">Entity' Object Type.Base class should be Entity</typeparam>
        /// <typeparam name="TDestination">'DTO' Object Type.Base class should be BaseDto.</typeparam>
        /// <param name="source">IQueryable Source data.</param>
        /// <returns>Array of 'DTO'.</returns>
        public static async Task<TDestination[]> ToDestinationArrayAsync<TSource, TDestination>(this IQueryable<TSource> source)
            where TSource : class, new()
            where TDestination : class, new()
        {
            if (source.IsNull())
                return new TDestination[] { };
            var data = await source.ToArrayAsync();
            return data.ToDestinationArray<TSource, TDestination>();
        }

        /// <summary>
        ///  To convert the queryable source to collection of destination.
        ///  Automapper is used for mapping.
        /// </summary>
        /// <typeparam name="TSource">Should Be Class Type.</typeparam>
        /// <typeparam name="TDest">Should Be Class Type.</typeparam>
        /// <param name="source">Source Data.</param>
        /// <param name="opts">Option Data.</param>
        /// <returns></returns>
        public static IEnumerable<TDest> ToDestinationEnumerable<TSource, TDest>(this ICollection<TSource> source, Action<IMappingOperationOptions> opts = null)
            where TSource : class, new()
            where TDest : class, new()
        {
            if (source.IsNull())
                return new TDest[] { };
            if (opts.IsNotNull())
                return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDest>>(source.AsEnumerable());
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDest>>(source.AsEnumerable(), opts);
        }

        /// <summary>
        ///  To convert the queryable source to collection of destination.
        ///  Automapper is used for mapping.
        /// </summary>
        /// <typeparam name="TSource">Should Be Class Type.</typeparam>
        /// <typeparam name="TDest">Should Be Class Type.</typeparam>
        /// <param name="source">Source Data.</param>
        /// <param name="opts">Option Data.</param>
        /// <returns></returns>
        public static List<TDest> ToDestinationList<TSource, TDest>(this IEnumerable<TSource> source, Action<IMappingOperationOptions> opts = null)
            where TSource : class, new()
            where TDest : class, new()
        {
            if (source.IsNull())
                return new List<TDest> { };
            if (opts.IsNull())
                return Mapper.Map<List<TSource>, List<TDest>>(source.ToList());
            return Mapper.Map<List<TSource>, List<TDest>>(source.ToList(), opts);
        }

        
    }
}
