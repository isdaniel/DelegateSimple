using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDelegate
{
    public static class LinqExtension
    {
        /// <summary>
        /// 自訂一個Where 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source
            ,Func<TSource, bool> where)
        {
            foreach (var item in source)
            {
                if (where(item))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// 自訂Select
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> MySelect<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource,TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }
    }
}
