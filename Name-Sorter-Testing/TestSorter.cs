using System.Collections.Generic;
using System.Linq;
using Name_Sorter;
using Name_Sorter.Services;
using Xunit;

namespace Name_Sorter_Testing
{
    public class TestSorter
    {
        [Fact]
        public void TestPersonSorter()
        {
            #region Arrange

            var sortingService = new SorterBase<Person>();

            var unsortedList = new List<Person>
            {
                new Person("Parsons","Janet"),
                new Person("Lewis","Vaughn"),
                new Person("Archer","Adonis Julius"),
                new Person("Yoder","Shelby Nathan"),
                new Person("Alvarez","Marin"),
                new Person("Lindsey","London"),
                new Person("Bentley","Beau Tristan"),
                new Person("Gardner","Leo"),
                new Person("Clarke","Hunter Uriah Mathew"),
                new Person("Lopez","Mikayla"),
                new Person("Ritter","Frankie Conner"),

            };


            #endregion

            #region Act

            var result = sortingService.Sort(unsortedList);


            #endregion

            #region Assert


            Assert.Equal("Alvarez",result.First().LastName);
            Assert.Equal("Yoder",result.Last().LastName);


            #endregion
        }
    }
}