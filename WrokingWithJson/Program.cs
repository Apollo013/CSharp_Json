using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrokingWithJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "json2.json";
            //var NewtonJsonInstance = new NewtonSoftSerialization<Person>(fileName);
            //JsonTest(NewtonJsonInstance);

            var JavaScriptJsonInstance = new JavascriptSerialization<Person>(fileName);
            JsonTest(JavaScriptJsonInstance);
        }


        static void JsonTest(JsonBase<Person> jsonInstance)
        {
            
            string command = string.Empty;
            int memberAge = 0;
            string memberName = string.Empty;

            while (!command.Equals("q"))
            {
                Console.WriteLine("Press 'a' to Add a new Member");
                Console.WriteLine("Press 'd' to Delete a Member");
                Console.WriteLine("Press 's' to Show Members");
                Console.WriteLine("Press 'q' to Quit Program");
                Console.WriteLine("Enter Command:");
                command = Console.ReadLine();

                switch (command)
                {
                    case "a":
                        Console.WriteLine("Adding a new member");

                        Console.WriteLine("Enter Name");
                        memberName = Console.ReadLine();

                        Console.WriteLine("Enter Age (number only)");
                        memberAge = Convert.ToInt32(Console.ReadLine());

                        jsonInstance.Add(new Person { Name = memberName, Age = memberAge });
                        break;

                    case "d":
                        Console.WriteLine("Deleting a member");

                        Console.WriteLine("Enter Name");
                        memberName = Console.ReadLine();

                        jsonInstance.Remove(new Person { Name = memberName });
                        break;

                    case "s":
                        Console.WriteLine("Showing members");
                        jsonInstance.List();
                        break;

                    case "q":
                        Console.WriteLine("Quitting Program");
                        jsonInstance.SaveJsonFile();
                        break;

                    default:
                        Console.WriteLine("Incorrect command, please try again");
                        break;
                }
            }
        }

    }
}
