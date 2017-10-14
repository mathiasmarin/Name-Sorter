using System.Collections.Generic;
using System.Linq;

namespace Name_Sorter.Services
{
    public class PersonFactory: IPersonFactory
    {
        public ICollection<Person> CreateFromStrings(IEnumerable<string> unsorted)
        {
            //Each string in the unsorted will have a full name. To make it easier to sort, we create an poco object
            var result = new List<Person>();
            foreach (var unsortedName in unsorted)
            {
                var names = unsortedName.Split(' ',',',';').ToList(); // Split each name with common separators
                var lastName = names.Last(); // Lastname is last item in the resulting list
                names.Remove(lastName); //Remove the lastname from the list
                var firstAndMiddleNames = string.Join(" ",names); // The first and middle name is the rest of the list. 
                result.Add(new Person(lastName,firstAndMiddleNames)); // Add a new person to the list with the resulting first and middle names and last name. 

            }
            return result;
        }
    }
}