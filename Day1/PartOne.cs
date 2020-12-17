using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Day1
{
    public class PartOne
    {
        public void ProductOfTwoNumsSummingTotalSum(List<int> expenses, int totalSum)
        {
            int lastIndex = expenses.Count - 1;
            int iterations = 0;
            bool found = false;

            var sw = new Stopwatch();
            sw.Start();

            while (!found && lastIndex > 0)
            {
                ++iterations;
                var big = expenses[lastIndex];
                for (var i = 0; i < expenses.Count; ++i)
                {
                    var sum = big + expenses[i];
                    if (sum > totalSum)
                    {
                        --lastIndex;
                        break;
                    }

                    if (sum == totalSum)
                    {
                        var t = sw.ElapsedMilliseconds;
                        found = true;
                        Console.WriteLine($"Time: {t}ms :: sum: {big} + {expenses[i]} = {totalSum} :: product: {big} * {expenses[i]} = {big * expenses[i]} :: iterations: {iterations}");
                    }
                }
            }
        }
    }
}
