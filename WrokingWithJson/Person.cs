using System;

namespace WrokingWithJson
{
    public class Person : IEquatable<Person>
    {
        public string Name { get; set; }
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
