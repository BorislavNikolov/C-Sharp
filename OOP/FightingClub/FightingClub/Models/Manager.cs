namespace FightingClub.Models
{
    using System;

    using Contracts;
    public class Manager : Person, IPerson
    {
        private int rating;
        public Manager(int age, string name, string nationality, string addres, int rating) 
                        : base(age, name, nationality, addres)
        {
            this.Rating = rating;
        }

        public int Rating 
        {
            get => this.rating;

            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Invalid rating");
                }

                this.rating = value;
            } 
        }

        public override void Work()
        {
            Console.WriteLine("Manage...");
        }

        public override string Info()
        {
            var info =  base.Info() + Environment.NewLine + $"Rating: {this.Rating}";
            return info;
        }
    }
}
