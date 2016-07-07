using System;
using System.Runtime.Serialization;

namespace WrokingWithJson.Models
{
    [DataContract]
    public class Person : IEquatable<Person>
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name: {Name},\t Age: {Age}";
        }

        public bool Equals(Person other)
        {
            if(other == null)
            {
                return false;
            }
            return this.Name.Equals(other.Name);
        }
    }
}
