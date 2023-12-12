using System.Xml.Linq;

namespace ListAndDictionary
{
    internal class Program
    {
        private static List<string> personList = new List<string>();
        private static Dictionary<string, int> personAgeDictionary = new Dictionary<string, int>();

        public static void Main()
        {
            Console.WriteLine("Welcome to the Person Manager!");
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Add New Person");
                Console.WriteLine("2. Remove Person");
                Console.WriteLine("3. Find Person");
                Console.WriteLine("4. List All Persons");
                Console.WriteLine("5. Exit");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        AddPerson();
                        break;
                    case "2":
                        RemovePerson();
                        break;
                    case "3":
                        FindPerson();
                        break;
                    case "4":
                        DisplayAllPersons();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        public static void AddPerson()
        {
            Console.WriteLine("Enter the person's name:");
            string name = Console.ReadLine();

            if (!personList.Contains(name))
            {
                personList.Add(name);
                Console.WriteLine($"{name} added to personList.");

                if (!personAgeDictionary.ContainsKey(name))
                {
                    Console.WriteLine("Enter the person's age:");
                    if (int.TryParse(Console.ReadLine(), out int age))
                    {
                        personAgeDictionary.Add(name, age);
                        Console.WriteLine($"{name} added to personAgeDictionary.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid age input. Person not added to personAgeDictionary.");
                    }
                }
                else
                {
                    Console.WriteLine($"{name} already exists in personAgeDictionary.");
                }
            }
            else
            {
                Console.WriteLine($"{name} already exists in personList.");
            }
        }

        public static void RemovePerson()
        {
            Console.WriteLine("Enter the person's name to remove:");
            string nameToRemove = Console.ReadLine();

            if (personList.Contains(nameToRemove))
            {
                personList.Remove(nameToRemove);
                Console.WriteLine($"{nameToRemove} removed from personList.");

                if (personAgeDictionary.ContainsKey(nameToRemove))
                {
                    personAgeDictionary.Remove(nameToRemove);
                    Console.WriteLine($"{nameToRemove} removed from personAgeDictionary.");
                }
                else
                {
                    Console.WriteLine($"{nameToRemove} does not exist in personAgeDictionary.");
                }
            }
            else
            {
                Console.WriteLine($"{nameToRemove} does not exist in personList.");
            }
        }

        public static void FindPerson()
        {
            Console.WriteLine("Enter the person's name to find:");
            string nameToFind = Console.ReadLine();

            if (personList.Contains(nameToFind))
            {
                Console.WriteLine($"{nameToFind} found in personList.");
            }
            else
            {
                Console.WriteLine($"{nameToFind} not found in personList.");
            }

            if (personAgeDictionary.ContainsKey(nameToFind))
            {
                Console.WriteLine($"{nameToFind} found in personAgeDictionary with age {personAgeDictionary[nameToFind]}.");
            }
            else
            {
                Console.WriteLine($"{nameToFind} not found in personAgeDictionary.");
            }
        }

        public static void DisplayAllPersons()
        {
            if (personList.Count == 0)
            {
                Console.WriteLine("No persons in the list.");
            }
            else
            {
                Console.WriteLine("Persons in personList:");
                foreach (var person in personList)
                {
                    Console.WriteLine(person);
                }
            }

            if (personAgeDictionary.Count == 0)
            {
                Console.WriteLine("No persons in the dictionary.");
            }
            else
            {
                Console.WriteLine("Persons in personAgeDictionary:");
                foreach (var kvp in personAgeDictionary)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value} years old");
                }
            }
        }
    }
}
