using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    public class PartTwo
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
                var kvpStr = line.Trim().Split(" ");
                foreach (var k in kvpStr)
                {
                    var kvp = k.Split(':');
                    if (!string.IsNullOrEmpty(kvp[0]))
                        d[kvp[0]] = kvp[1];
                }
            }

            var result = (d.Count == MaxFields) ||
                         (d.Count == MinFields && !d.ContainsKey(Optional));

            if (!result)
                return false;

            // further validation

            try
            {
                var byr = int.Parse(d["byr"]);
                var iyr = int.Parse(d["iyr"]);
                var eyr = int.Parse(d["eyr"]);
                var hgtCmStr = d["hgt"].Split("c");
                var hgtCM = hgtCmStr.Length > 1 ? int.Parse(hgtCmStr[0]) : -1;
                var hgtInStr = d["hgt"].Split("i");
                var hgtIN = hgtInStr.Length > 1 ? int.Parse(hgtInStr[0]) : -1;
                var hcl = d["hcl"];
                var ecl = d["ecl"];
                var pid = d["pid"];

                return byr >= 1920 && byr <= 2002 &&
                       iyr >= 2010 && iyr <= 2020 &&
                       eyr >= 2020 && eyr <= 2030 &&
                       ((hgtCM >= 150 && hgtCM <= 193) ||
                        (hgtIN >= 59 && hgtIN <= 76)) &&
                       hcl.StartsWith("#") && hcl.Length == 7 &&
                       (ecl == "amb" ^ ecl == "blu" ^ ecl == "brn" ^ ecl == "gry" ^ ecl == "grn" ^ ecl == "hzl" ^ ecl == "oth") &&
                       pid.Length == 9 && int.TryParse(pid, out var _);
            }
            catch
            {
                System.Console.WriteLine("oh geez");
                return false;
            }
        }
    }
}
