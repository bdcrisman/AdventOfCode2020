using System.Collections.Generic;

namespace Day5
{
    public class PartTwo
    {
        public int GetSeatID(List<int> ids)
        {
            ids.Sort();
            int seatID = 0;
            int max = ids.Count - 1;
            
            for (var i = 0; i < max; ++i)
            {
                if (ids[i + 1] - ids[i] == 2)
                {
                    seatID = ids[i] + 1;
                    break;
                }
            }

            return seatID;
        }
    }
}
