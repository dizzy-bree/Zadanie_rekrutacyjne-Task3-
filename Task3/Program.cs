using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public static void PrintAscending(ICollection<Person> collection)
        {
           var sortedList = collection.OrderBy(x => x.Age);

            foreach (Object obj in from p in sortedList
                                   where p.Age >= 18
                                   select new { p.Name, p.Age })
            {
                Console.WriteLine(obj);
            }
        }

        public static void PrintOccurrenceOfGivenAge(ICollection<Person> collection, int age)
        {
            if (collection.Any(x => x.Age.Equals(age))) {Console.WriteLine(true);}
            else { Console.WriteLine(false); }
        }

        static void Main(string[] args)
        {
            var personList = new List<Person> {};

            var person1 = new Person("Ethan", 31);
            var person2 = new Person("Marry", 21);
            var person3 = new Person("Janek", 18);
            var person4 = new Person("Magda", 29);
            var person5 = new Person("John", 10);
            var person6 = new Person("Ola", 12);

            personList.Add(person1);
            personList.Add(person2);
            personList.Add(person3);
            personList.Add(person4);
            personList.Add(person5);
            personList.Add(person6);

            PrintAscending(personList);

            PrintOccurrenceOfGivenAge(personList, 1444);
            PrintOccurrenceOfGivenAge(personList, 18);

        }

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person != null &&
                   Name == person.Name &&
                   Age == person.Age;
        }

        public override int GetHashCode()
        {
            var hashCode = -1360180430;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return Name + "-" + Age;
        }
    }
}
