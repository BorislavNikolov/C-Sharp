namespace FightingClub.Models
{
    using System;
    using System.Text;

    using Contracts;
    public abstract class Person : IPerson
    {
        private int age;
        private string name;
        private string addres;
        private string nationality;
        public Person(int age, string name, string nationality, string addres)
        {
            this.Age = age;
            this.Name = name;
            this.Nationality = nationality;
            this.Addres = addres;
        }

        public int Age 
        {
            get => this.age;
            
            private set
            {
                if (value < 18 || value > 110)
                {
                    throw new ArgumentException("Age must be between eighteen and one hundred ten!");
                }

                this.age = value;
            }
        }

        public string Name 
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can not be null!");
                }

                this.name = value;
            } 
        }

        public string Nationality 
        {
            get => this.nationality;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Nationality can not be null!");
                }

                this.nationality = value;
            }
        }

        public string Addres
        {
            get => this.addres;

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Addres can not be null!");
                }

                this.addres = value;
            }

        }

        public void ChangeAddres(string newAddres)
        {
            this.Addres = newAddres;
            Console.WriteLine($"You have new addres: {this.Addres}");
        }

        public virtual string Info()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Name: {this.Name}");
            stringBuilder.AppendLine($"Age: {this.Age}");
            stringBuilder.AppendLine($"Nationality: {this.Nationality}");

            return stringBuilder.ToString().Trim();
        }

        public abstract void Work();
    }
}