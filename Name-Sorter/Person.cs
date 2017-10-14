using System;

namespace Name_Sorter
{
    /// <summary>
    /// Poco object for a person meaning one line in the incoming text file. 
    /// </summary>
    public class Person: ISortable<Person>
    {
        public Person(string lastName, string firstAndMiddle)
        {
            LastName = lastName;
            FirstAndMiddleNames = firstAndMiddle;
        }

        public string LastName { get; }
        public string FirstAndMiddleNames { get; }
        public Func<Person, string> SortProperty { get; } = x => x.LastName;

        public string GetFullName()
        {
            return string.Join(" ", FirstAndMiddleNames, LastName);
        }

       
    }
}