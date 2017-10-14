using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Name_Sorter.Services;

namespace Name_Sorter
{
    public class Program
    {
        private static readonly ISorter<Person> SortingSerivce = new SorterBase<Person>();
        private static readonly IFileSerializer<IEnumerable<string>> TextSerializer = new TextSerializer();
        private static readonly IPersonFactory PersonFactory = new PersonFactory();

        public static void Main(string[] args)
        {
            var fileName = args.FirstOrDefault();
            var fileExist = File.Exists(fileName);

            if (!fileExist)
            {
                Console.WriteLine("File not found. Check filename and location and try again");
                Thread.Sleep(1000);
                Console.WriteLine("Closing application...");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

            var importedTextFile = TextSerializer.Deserialize(fileName);

            var persons = PersonFactory.CreateFromStrings(importedTextFile);

            var sorted = SortingSerivce.Sort(persons);

            foreach (var person in sorted)
            {
                Console.WriteLine(person.GetFullName());
            }
            try
            {
                TextSerializer.SerializeToTextFile(sorted.Select(h => h.GetFullName()), "./sorted-names-list.txt");

            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong trying to save the file: {e.Message}");
                Console.WriteLine("Closing application...");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

        }
    }
}
