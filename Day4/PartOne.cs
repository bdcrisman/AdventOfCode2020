using System.Collections.Generic;
using System.IO;

namespace Day4
{
    public class PartOne
    {
        const string Optional = "cid";
        const int MaxFields = 8;
        const int MinFields = 7;

        public int NumberOfValidPassports(string puzzleInput)
        {
            if (string.IsNullOrEmpty(puzzleInput))
                return 0;

            var count = 0;
            using (var reader = new StringReader(puzzleInput))
            {
                var ppLines = new List<string>();

                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        // EOF
                        if (IsValidPassport(ppLines))
                            ++count;
                        break;
                    }
                    else if (line != string.Empty)
                    {
                        ppLines.Add(line);
                    }
                    else
                    {
                        // end of passport
                        if (IsValidPassport(ppLines))
                            ++count;
                        ppLines.Clear();
                    }
                }
            }

            return count;
        }

        private bool IsValidPassport(List<string> lines)
        {
            if (lines == null || lines.Count <= 0)
                return false;

            var d = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                var kvps = line.Trim().Split(" ");
                foreach (var kvp in kvps)
                {
                    var key = kvp.Split(':');
                    if (!string.IsNullOrEmpty(key[0]))
                        d[key[0]] = string.Empty;
                }
            }

            var result = (d.Count == MaxFields) ||
                   (d.Count == MinFields && !d.ContainsKey(Optional));

            return result;
        }
    }
}
