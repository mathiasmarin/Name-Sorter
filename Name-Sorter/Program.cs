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
        private static ISorter<Person> _sortingSerivce;
        private static IFileSerializer<IEnumerable<string>> _textSerializer;
        private static IPersonFactory _personFactory;

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

            GetAllInstancesFromIocContainer();

            var importedTextFile = _textSerializer.Deserialize(fileName);

            var persons = _personFactory.CreateFromStrings(importedTextFile);
            
            var sorted = _sortingSerivce.Sort(persons);

            foreach (var person in sorted)
            {
                Console.WriteLine(person.GetFullName());
            }
            try
            {
                _textSerializer.SerializeToTextFile(sorted.Select(h => h.GetFullName()), "./sorted-names-list.txt");

            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong trying to save the file: {e.Message}");
                Console.WriteLine("Closing application...");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

        }

        private static void GetAllInstancesFromIocContainer()
        {
            Bootstrap.Start(); // Main is static and injection in constructor is therefore not possible. Have to get all instances from the ioc container.  

            _textSerializer = Bootstrap.Container.GetInstance<IFileSerializer<IEnumerable<string>>>();
            _personFactory = Bootstrap.Container.GetInstance<IPersonFactory>();
            _sortingSerivce = Bootstrap.Container.GetInstance<ISorter<Person>>();

        }
    }
}
