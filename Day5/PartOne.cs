using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    public class PartOne
    {
        public List<int> IDs = new List<int>();

        const int RowCount = 127;
        const int ColCount = 7;
        const int MagicValue = 8;

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

                IDs.Add(id);
            }

            return highestSeatID;
        }

        private int GetSeatID(string s)
        {
            return GetSeatID(s.Substring(0, 7), 0, 0, RowCount) * MagicValue + GetSeatID(s.Substring(7), 0, 0, ColCount);
        }

        private int GetSeatID(string s, int sIndex, int min, int max)
        {
            if (sIndex >= s.Length || min == max || min < 0 || max < 0)
                return min;

            int mid = (max - min) / 2 + min;
            return (s[sIndex] == 'F' || s[sIndex] == 'L')
                ? GetSeatID(s, sIndex + 1, min, mid)
                : GetSeatID(s, sIndex + 1, mid + 1, max);
        }
    }
}
