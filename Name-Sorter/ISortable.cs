using System;

namespace Name_Sorter
{
    /// <summary>
    /// Base interface for sorting. All implementations must have a Func to a string property. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISortable<in T>
    {
        Func<T, string> SortProperty { get; }
    }
}