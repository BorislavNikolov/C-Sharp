namespace Concert
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            var bandNameAndItMembers = new Dictionary<string, List<string>>();
            var bandNameAndPlayTime = new Dictionary<string, int>();
            var totalTime = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "start of concert")
                {
                    break;
                }

                var inputSplited = input.Split("; ");
                var command = inputSplited[0];
                var bandName = inputSplited[1];

                if (command == "Add")
                {
                    var members = inputSplited[2].Split(", ");

                    if (bandNameAndItMembers.ContainsKey(bandName) == false)
                    {
                        bandNameAndItMembers.Add(bandName, new List<string>());

                        foreach (var member in members)
                        {
                            if (bandNameAndItMembers[bandName].Contains(member) == false)
                            {
                                bandNameAndItMembers[bandName].Add(member);
                            }
                        }
                    }

                    else
                    {
                        foreach (var member in members)
                        {
                            if (bandNameAndItMembers[bandName].Contains(member) == false)
                            {
                                bandNameAndItMembers[bandName].Add(member);
                            }
                        }
                    }
                }

                else if (command == "Play")
                {
                    var playTime = int.Parse(inputSplited[2]);

                    if (bandNameAndPlayTime.ContainsKey(bandName) == false)
                    {
                        bandNameAndPlayTime.Add(bandName, playTime);
                        totalTime += playTime;
                    }

                    else
                    {
                        bandNameAndPlayTime[bandName] += playTime;
                        totalTime += playTime;
                    }
                }
            }

            var bandMembersToPrint = Console.ReadLine();

            Console.WriteLine($"Total time: {totalTime}");

            foreach (var kvp in bandNameAndPlayTime.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            Console.WriteLine(bandMembersToPrint);

            foreach (var member in bandNameAndItMembers[bandMembersToPrint])
            {
                Console.WriteLine($"=> {member}");
            }
        }
    }
}
