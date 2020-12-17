using System;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var getter = new InputGetter();
            var result = await getter.GetAsync("https://www.adventofcode.com/2020/day/2/input");

            Console.WriteLine(result);
        }
    }
}
