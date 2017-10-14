using System.Collections.Generic;
using System.Linq;
using Name_Sorter.Services;
using Xunit;

namespace Name_Sorter_Testing
{
    public class TestPersonFactory
    {
        [Fact]
        public void TestFactory()
        {
            #region Arrange

            var inputText = new List<string>
            {
               "Janet Parsons",
               "Vaughn Lewis",
               "Adonis Julius Archer",
               "Shelby Nathan Yoder",
               "Marin Alvarez",
               "London Lindsey",
               "Beau Tristan Bentley",
               "Leo Gardner",
               "Hunter Uriah Mathew Clarke",
               "Mikayla Lopez",
               "Frankie Conner Ritter"
            };

            var inputText2 = new List<string>
            {
               "Janet,Parsons",
               "Vaughn,Lewis",
               "Adonis Julius;Archer",
               "Shelby Nathan Yoder",
               "Marin Alvarez",
               "London Lindsey",
               "Beau Tristan Bentley",
               "Leo Gardner",
               "Hunter Uriah Mathew Clarke",
               "Mikayla Lopez",
               "Frankie Conner Ritter"
            };


            #endregion

            #region Act

            var result = new PersonFactory().CreateFromStrings(inputText);
            var result2 = new PersonFactory().CreateFromStrings(inputText2);

            #endregion

            #region Assert

            Assert.Equal(11,result.Count);
            Assert.Equal("Janet", result.First().FirstAndMiddleNames);
            Assert.Equal("Ritter", result.Last().LastName);
            Assert.DoesNotContain(result2, x => x.LastName.Contains(',') || x.FirstAndMiddleNames.Contains(','));
            Assert.DoesNotContain(result2, x => x.LastName.Contains(';') || x.FirstAndMiddleNames.Contains(';'));

            #endregion
        }
    }
}
