using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public class PartOne
    {
        private List<List<string>> _map = new List<List<string>>();

        public int CountTreesUsingSlopeRightThreeDownOne(string puzzleInput)
        {
            if (!LoadMap(puzzleInput))
                return 0;

            var lastIndex = _map.Count - 1;
            var rowIndex = 0;
            var colIndex = 0;
            var treeCount = 0;

            while (rowIndex + 1 <= lastIndex)
            {
                var row = _map[++rowIndex];

                if ((colIndex += 3) >= row.Count)
                    colIndex -= row.Count;

                if (_map[rowIndex][colIndex] == "#")
                    ++treeCount;
            }

            return treeCount;
        }

        private bool LoadMap(string puzzleInput)
        {
            if (string.IsNullOrWhiteSpace(puzzleInput))
                return false;

            var lines = puzzleInput.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                var chars = line.Trim().Select(x => x.ToString()).ToList();
                if (chars.Count > 0)
                    _map.Add(chars);
            }

            return _map.Count > 0;
        }
    }
}
