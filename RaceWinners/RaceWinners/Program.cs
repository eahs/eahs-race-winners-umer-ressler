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
        List<int> classes = new List<int>(){0, 0, 0, 0};


        for (int i = 0; i < data.Count; i++)
        {
            // Combine the ranks to print as a list
            var ranks = String.Join(", ", data[i].Ranks);
            //goes through each element in class
            for (int j = 0; j < data[i].Ranks.Count; j++)
            {
                //adds element to list from class list
                classes[i] += data[i].Ranks[j];
            }


            Console.WriteLine($"{data[i].Name} - [{ranks}]");\
                //displays amount of people in class
            Console.WriteLine(data[i].Ranks.Count);
        }
        //Displays the results for each team using the average of each class's placements
        Console.WriteLine((double)classes[0] / data[0].Ranks.Count);
        Console.WriteLine((double)classes[1] / data[1].Ranks.Count);
        Console.WriteLine((double)classes[2] / data[2].Ranks.Count);
        Console.WriteLine((double)classes[3] / data[3].Ranks.Count);
    }
}





