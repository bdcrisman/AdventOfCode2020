using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public class PartTwo
    {
        public long CountTreesUsingSlope(string puzzleInput, int right, int down)
        {
            var map = LoadMap(puzzleInput);
            if (map == null)
                return 0;

            var lastIndex = map.Count - 1;
            var rowIndex = 0;
            var colIndex = 0;
            var treeCount = 0L;

            try
            {
                while ((rowIndex += down) <= lastIndex)
                {
                    var row = map[rowIndex];

                    // wrap colIndex, if needed
                    if ((colIndex += right) >= row.Count)
                        colIndex -= row.Count;

                    if (map[rowIndex][colIndex] == "#")
                        ++treeCount;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return treeCount;
        }

        private List<List<string>> LoadMap(string puzzleInput)
        {
            if (string.IsNullOrWhiteSpace(puzzleInput))
                return null;

            var list = new List<List<string>>();
            var lines = puzzleInput.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                var chars = line.Trim().Select(x => x.ToString()).ToList();
                if (chars.Count > 0)
                    list.Add(chars);
            }

            return list;
        }
    }
}
