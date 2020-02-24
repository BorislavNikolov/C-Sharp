namespace FightingClub
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Contracts;
    public class Startup
    {
        static void Main(string[] args)
        {
            var fightingClub = new FightingClub("The Eagles MMA", "Moscow");

            var russianManager = new Manager(65, "Ivan", "Russian", "addres 65", 8);
            var brazilianManager = new Manager(44, "Anderson", "Brazilian", "addres 18", 6);
            var britishManager = new Manager(58, "Frank", "Englishman", "addres 99", 9);

            var bulgarianFighter = new Fighter(28, "Georgi", "Bulgarian", "addres 2");
            var serbianFighter = new Fighter(32, "Drago", "Serbian", "addres 7");
            var greeceFighter = new Fighter(19, "Nicolas", "Greek", "addres 1");

            var oldestCoach = new Coach(20, "Kiril", "Bulgarian", "addres 5");
            var youngestCoach = new Coach(23, "Mihail", "Russian", "addres 22");
            var coach = new Coach(55, "Denis", "Englishman", "addres 11");

            var persons = new List<IPerson>();
            persons.Add(britishManager);
            persons.Add(serbianFighter);
            persons.Add(oldestCoach);

            foreach (var person in persons)
            {
                if (person.GetType().Name == "Manager")
                {
                    fightingClub.AddManager((Manager)person);
                }

                else if (person.GetType().Name == "Fighter")
                {
                    fightingClub.AddFighter((Fighter)person);
                }

                else
                {
                    fightingClub.AddCoach((Coach)person);
                }
            }

            youngestCoach.Work();
            brazilianManager.Work();
            greeceFighter.Work();

            fightingClub.AddManager(russianManager);
            fightingClub.AddFighter(bulgarianFighter);
            fightingClub.AddCoach(coach);

            Console.WriteLine(brazilianManager.Info());
            Console.WriteLine(greeceFighter.Info());
            Console.WriteLine(youngestCoach.Info());

            youngestCoach.ChangeAddres("New Addres");
        }
    }
}