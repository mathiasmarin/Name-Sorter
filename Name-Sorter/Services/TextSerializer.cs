using System.Collections.Generic;
using System.IO;

namespace Name_Sorter.Services
{
    public class TextSerializer : IFileSerializer<IEnumerable<string>>
    {
        
        public IEnumerable<string> Deserialize(string filepath)
        {
            FileStream fileObj = null;
            var result = new List<string>();
            try
            {
                if (!File.Exists(filepath))
                {
                    throw new FileNotFoundException("The file is not found. ", filepath);
                }

                fileObj = new FileStream(filepath, FileMode.Open);

                StreamReader reader = new StreamReader(fileObj);
                
                while (reader.Peek() != -1)
                {
                    result.Add(reader.ReadLine());
                }
            }
            finally
            {
                fileObj?.Close();
            }
            return result;

        }

        public void SerializeToTextFile(IEnumerable<string> input, string fileName)
        {
            var writer = File.CreateText(fileName);
            foreach (var name in input)
            {
                writer.WriteLine(name);
            }
            writer.Close();
        }
    }
}