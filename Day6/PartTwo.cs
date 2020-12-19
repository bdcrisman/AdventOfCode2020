using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public class PartTwo
    {
        public int SumEveryoneYesAnswers(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            var lines = input.Split(Environment.NewLine).ToList();
            var l = new List<string>();
            var sum = 0;

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

            // sum remaining lines
            if (l.Count > 0)
                sum += SumAnswers(l);

            return sum;
        }

        private int SumAnswers(List<string> lines)
        {
            if (lines == null || lines.Count <= 0)
                return 0;

            var start = lines[0].Select(x => x.ToString());

            for(var i = 1; i < lines.Count; ++i)
            {
                var line = lines[i].Select(x => x.ToString());
                start = start.Intersect(line);
            }

            return string.Join("", start).Length;
        }
    }
}
