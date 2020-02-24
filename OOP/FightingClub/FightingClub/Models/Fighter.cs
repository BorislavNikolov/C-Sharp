namespace FightingClub.Models
{
    using System;

    using Contracts;
    public class Fighter : Person, IPerson
    {
        private int skills;
        public Fighter(int age, string name, string nationality, string addres) 
                        : base(age, name, nationality, addres)
        {
            this.Skills = 60;
        }

        public int Skills 
        {
            get => this.skills;
            
            private set
            {
                if (value > 100)
                {
                    throw new ArgumentException("Skills can not be more than one hundred.");
                }

                this.skills = value;
            }
        }

        public override void Work()
        {
            this.Skills++;
            Console.WriteLine("Training...");
        }

        public override string Info()
        {
            var info = base.Info() + Environment.NewLine + $"Skills: {this.Skills}";
            return info;
        }
    }
}
