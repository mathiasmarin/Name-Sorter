using System.Collections.Generic;

namespace Name_Sorter.Services
{
    /// <summary>
    /// Generic interface for sorting a collection. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISorter<T> where T : ISortable<T>
    {
        /// <summary>
        /// Sorts a collection based on a given property. 
        /// </summary>
        /// <param name="unsorted"></param>
        /// <returns></returns>
        ICollection<T> Sort(ICollection<T> unsorted);
    }
}