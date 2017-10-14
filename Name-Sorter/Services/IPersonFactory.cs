using System.Collections.Generic;

namespace Name_Sorter.Services
{
    public interface IPersonFactory
    {
        /// <summary>
        /// Create a collection of person based on input string collection
        /// </summary>
        /// <param name="unsorted"></param>
        /// <returns></returns>
        ICollection<Person> CreateFromStrings(IEnumerable<string> unsorted);
    }
}