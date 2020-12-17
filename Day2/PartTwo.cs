using System;

namespace Day2
{
    public class PartTwo
    {
        private int _validCount = 0;

        public int CheckHowManyPasswordsAreValidAgain(string puzzleInput)
        {
            var lines = puzzleInput.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                var p = ParseLine(line.Trim());
                if (IsValidPassword(p))
                    ++_validCount;
            }
            return _validCount;
        }

        private ParsedInput ParseLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            try
            {
                var elements = line.Split(' ');
                var minmax = elements[0].Split('-');

                return new ParsedInput
                {
                    Min = int.Parse(minmax[0]),
                    Max = int.Parse(minmax[1]),
                    Char = elements[1][0],
                    Password = elements[2]
                };
            }
            catch
            {
                return null;
            }
        }

        private bool IsValidPassword(ParsedInput p)
        {
            if (p == null || !p.Password.Contains(p.Char))
                return false;

            try
            {
                var pos1 = p.Password[p.Min - 1] == p.Char;
                var pos2 = p.Password[p.Max - 1] == p.Char;
                return pos1 ^ pos2;
            }
            catch
            {
                return false;
            }
        }
    }
}
