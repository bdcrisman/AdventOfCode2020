using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Day1
{
    public class PartTwo
    {
        public void ProductOfThreeNumsSummingTotalSum(List<int> expenses, int totalSum)
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
                    var min = expenses[i];
                    for (var j = i + 1; j < expenses.Count; ++j)
                    {
                        var sum = min + big + expenses[j];
                        if (sum == totalSum)
                        {
                            var t = sw.ElapsedMilliseconds;
                            found = true;
                            Console.WriteLine($"Time: {t}ms :: sum: {min} + {big} + {expenses[j]} = {totalSum} :: product: {min} * {big} * {expenses[j]} = {min * big * expenses[j]} :: iterations: {iterations}");
                        }
                    }
                }
                --lastIndex;
            }
        }
    }
}
