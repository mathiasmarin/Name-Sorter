using System.Collections.Generic;
using System.Linq;

namespace Name_Sorter.Services
{
    
    /// <summary>
    /// Generic class for sorting a unsorted collection based on a given property
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SorterBase<T>: ISorter<T> where T : ISortable<T>
    {
        /// <summary>
        /// Base sorting is order by a property. Can be overwritten if custom sorting is required. 
        /// </summary>
        /// <param name="unsorted"></param>
        /// <returns></returns>
        public virtual ICollection<T> Sort(ICollection<T> unsorted)
        {
            return unsorted.OrderBy(x => x.SortProperty.Invoke(x)).ToList();
        }
    }
}