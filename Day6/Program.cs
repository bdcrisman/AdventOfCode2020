using System;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");
            Console.WriteLine($"Part 1: Sum of yes answers from groups: {new PartOne().SumYesAnswersFromGroups(input)}");
        }
    }
}
