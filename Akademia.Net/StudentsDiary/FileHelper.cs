using System.Xml.Serialization;

namespace StudentsDiary
{
    public class FileHelper<T> where T : new()
    {
        private string _filePath;

        public FileHelper(string filePath)
        {
            _filePath = filePath;
        }

        public void SerializeToFile(T students)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var streamWritet = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWritet, students);
                streamWritet.Close();
            }
        }

        public T DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
                return new T();

            var serializer = new XmlSerializer(typeof(T));

            using (var streamReader = new StreamReader(_filePath))
            {
                var students = (T)serializer.Deserialize(streamReader);
                streamReader.Close();

                return students;
            }
        }

        public void SerializeToFile2(List<Student> students)
        {
            var serializer = new XmlSerializer(typeof(List<Student>));
            StreamWriter streamWritet = null;

            try
            {

                streamWritet = new StreamWriter(_filePath);
                serializer.Serialize(streamWritet, students);
                streamWritet.Close();
            }
            finally
            {
                streamWritet.Dispose();
            }
        }
    }
}
