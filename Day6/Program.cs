using System;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");
            Console.WriteLine($"Part 1: Sum of anyone yes answers from groups: {new PartOne().SumAnyoneYesAnswers(input)}");
            Console.WriteLine($"Part 2: Sum of everyone yes answers from groups: {new PartTwo().SumEveryoneYesAnswers(input)}");
        }
    }
}
