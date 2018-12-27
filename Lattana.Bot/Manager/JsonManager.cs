using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Telegram.Bot.Examples.Echo.Manager
{
    public static class JsonManager
    {
        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                writer?.Close();
            }
        }

        public static T ReadFromJsonFile<T>(string filePath)
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            finally
            {
                reader?.Close();
            }
        }

        public static void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                var xmlDocument = new XmlDocument();
                var serializer = new XmlSerializer(serializableObject.GetType());
                using (var stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                IftttManager.SendException(ex.Message);
            }
        }

        public static T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            var objectOut = default(T);

            try
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                var xmlString = xmlDocument.OuterXml;

                using (var read = new StringReader(xmlString))
                {
                    var outType = typeof(T);

                    var serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                IftttManager.SendException(ex.Message);
            }

            return objectOut;
        }

        public static IEnumerable<string> GetAllJson(string path)
        {
            var directory = new DirectoryInfo(path);

            var files = directory.GetFiles("*.json");

            return files.Select(file => file.FullName).ToList();
        }

    }
}
