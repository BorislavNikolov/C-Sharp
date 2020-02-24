namespace FightingClub.Models
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    public class FightingClub : IFightingClub
    {
        private string name;
        private string location;
        private int fansCount;
        private readonly List<Fighter> fighters;
        private readonly List<Manager> managers;
        private readonly List<Coach> coaches;
            
        public FightingClub(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.FansCount = 100;
            this.fighters = new List<Fighter>();
            this.managers = new List<Manager>();
            this.coaches = new List<Coach>();
        }

        public string Name 
        {
            get => this.name;
            
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException("Name of Fighting Club must be at least five symbols!");
                }

                this.name = value;
            }
        }

        public string Location 
        {
            get => this.location;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Location can not be null or whitespace!");
                }

                this.location = value;
            }
        }
        public int FansCount 
        {
            get => this.fansCount;

            private set
            {
                if (value < 1)
                {
                    throw new Exception("Fans count should be at least one!");
                }

                this.fansCount = value;
            } 
        }

        public void AddCoach(Coach coach)
        {
            if (coaches.Count < 5)
            {
                coaches.Add(coach);
                Console.WriteLine($"Successfully added coach: {coach.Name}");
            }

            else
            {
                Console.WriteLine("You have no place for a new coach.");
            }
        }

        public void AddFighter(Fighter fighter)
        {
            if (fighters.Count < 10)
            {
                fighters.Add(fighter);
                Console.WriteLine($"Successfully added fighter: {fighter.Name}");
            }

            else
            {
                Console.WriteLine("You have no place for a new fighter.");
            }
        }

        public void AddManager(Manager manager)
        {
            if (managers.Count < 5)
            {
                managers.Add(manager);
                Console.WriteLine($"Successfully added manager: {manager.Name}");
            }

            else
            {
                Console.WriteLine("You have no place for a new manager.");
            }
        }
    }
}
