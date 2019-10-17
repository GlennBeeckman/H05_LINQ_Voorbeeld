using System;

namespace Linq
{
    public class Step6
    {
        public void Execute()
        {
            Console.WriteLine("\nStep 6 : Expression bodied  members\n");

            Person p = new Person("Mandy", "Dejesus");
            Console.WriteLine(p);
            p.DisplayName();
        }

        public class Person
        {
            private string lname;

            public Person(string firstName, string lastName)
            {
                FName = firstName;
                LName = lastName;
            }

            public string LName
            {
                get => lname;

                set => lname = value;
            }

            public String FName { get; set; }

            public String FullName => $"{FName} {LName}";

            public override string ToString()
            {
                return $"{FName} {LName}".Trim();
            }

            public void DisplayName() => Console.WriteLine(ToString());
        }
    }
}
