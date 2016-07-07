using System;
using System.IO;
using System.Runtime.Serialization.Json;
using WrokingWithJson.Models;

namespace WrokingWithJson.Examples
{
    public class DataContractJsonSerialization
    {
        public static void Run()
        {
            Person person = new Person();
            person.Name = "John";
            person.Age = 42;

            MemoryStream stream = new MemoryStream();
            SerializeToJson(person, stream);

            DeserializeFromJson(stream);
        }

        private static void SerializeToJson(Person person, MemoryStream stream)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
            ser.WriteObject(stream, person);
        }

        private static void DeserializeFromJson(MemoryStream stream)
        {
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            Console.WriteLine($"JSON form of Person object: {sr.ReadToEnd()}");
        }

    }
}
