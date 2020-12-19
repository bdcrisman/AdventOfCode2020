using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public class PartOne
    {
        public int SumYesAnswersFromGroups(string input)
        {
            var lines = input.Split(Environment.NewLine).ToList();
            var l = new List<string>();
            int sum = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    sum += SumAnswers(l);
                    l.Clear();
                    continue;
                }
                l.Add(line.Trim());
            }

            if (l.Count > 0)
                sum += SumAnswers(l);

            return sum;
        }

        private int SumAnswers(List<string> lines)
        {
            if (lines == null || lines.Count <= 0)
                return 0;

            return string.Join("", lines).Distinct().Count();
        }
    }
}
