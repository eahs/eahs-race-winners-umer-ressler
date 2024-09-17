using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceWinners;

public class Program
{
    static async Task Main(string[] args)
    {
        DataService ds = new DataService();

        // Asynchronously retrieve the group (class) data
        var data = await ds.GetGroupRanksAsync();

        //list of class scores
        List<int> classes = new List<int>();
        List<double> avgScores = new List<double>();

        for (int i = 0; i < data.Count; i++)
        {
            // Combine the ranks to print as a list
            var ranks = String.Join(", ", data[i].Ranks);

            int sum = 0;


            //adds sums and averages to corresponding lists
            classes.Add(data[i].Ranks.Sum());
            avgScores.Add(data[i].Ranks.Average());


            //whitespace for better looks
            Console.WriteLine();

            Console.WriteLine($"{data[i].Name} - [{ranks}]");

            Console.WriteLine();
            //Displays average score of class and adds it to avg scores list
            Console.WriteLine(data[i].Name + " had a score of " +(double)classes[i] / data[i].Ranks.Count);

            avgScores.Add((double)classes[i] / data[i].Ranks.Count);
        }
        
        Console.WriteLine();
        Console.WriteLine("______________________________________________________________________________________");
        Console.WriteLine();
        double winningScore = avgScores.Min();

        //Displays winning class
        Console.WriteLine("The Winner is " + data[avgScores.IndexOf(winningScore)].Name + " With the Score of " + winningScore + "!!!");
    }
}





