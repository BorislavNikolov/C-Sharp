namespace FightingClub.Models
{
    using System;

    using Contracts;
    public class Coach : Person, IPerson
    {
        private int experience;
        public Coach(int age, string name, string nationality, string addres) 
                : base(age, name, nationality, addres)
        {
            this.Experience = 0;
        }

        public int Experience 
        {
            get => this.experience;
            
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid Experience.");
                }

                this.experience = value;
            }
        }

        public override void Work()
        {
            this.Experience++;
            Console.WriteLine("Working...");
        }

        public override string Info()
        {
            var info = base.Info() + Environment.NewLine + $"Experience: {this.Experience}";
            return info;
        }
    }
}
