namespace Name_Sorter.Services
{
    /// <summary>
    /// Generic interface for deserializing a file. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFileSerializer<T>
    {
        /// <summary>
        /// Serialize to textfile. 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fileName"></param>
        void SerializeToTextFile(T input, string fileName);
        /// <summary>
        /// Deserialize from file a T object
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        T Deserialize(string filepath);
    }
}