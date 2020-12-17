using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day5
{
    public class PartOne
    {
        const int RowCount = 128;
        const int ColCount = 8;
        const int Magic = 8;

        public int GetHighestSeatID(string puzzleInput)
        {
            if (string.IsNullOrWhiteSpace(puzzleInput))
                return 0;

            var lines = puzzleInput.Split('\n')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim());

            var highestSeatID = 0;
            foreach (var l in lines)
            {
                var id = GetSeatID(l);
                if (id > highestSeatID)
                    highestSeatID = id;
            }

            return lines.Count();
        }

        private int GetSeatID(string s)
        {
            var row = GetRow(s, 0, 0, RowCount);
            Console.WriteLine(row);
            return 0;
            //return GetRow(s.Substring(0, 7)`) * Magic + GetRow(s.Substring(7);
        }

        private int GetRow(string s, int sIndex, int min, int max)
        {
            if (sIndex >= s.Length || min < 0 || max < 0 || min == max)
                return min;

            int mid = (max - min) / 2 + 1;
            return (s[sIndex] == 'F')
                ? GetRow(s, sIndex + 1, min, mid)
                : GetRow(s, sIndex + 1, mid, max);
        }

        private int GetCol(string s)
        {
            var col = 0;
            var start = ColCount;
            for (var i = 0; i < s.Length; ++i)
            {
                start /= 2;
            }

            return col;
        }
    }
}
