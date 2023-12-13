using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeNumericalDifferentiator
{
    internal record TimeEntry
    {
        public int Minutes { get; init; }
        public int FullDistance { get; init; }


        public TimeEntry(int minutes, int fullDistance)
        {
            Minutes = minutes;
            FullDistance = fullDistance > 0 ? fullDistance : 1440;
        }

        private string GetTimeString(int minutes)
        {
            var Hours = minutes / 60;
            var Minute = minutes - (Hours * 60);
            return $"{Hours}:{Minute}";
        }

        public override string ToString() => $"({GetTimeString(Minutes)}, {GetTimeString(FullDistance)})";
    }
}
