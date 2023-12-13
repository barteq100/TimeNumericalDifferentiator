using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeNumericalDifferentiator
{
    internal static class TimeDifferential
    {
        const int MINUTES_IN_DAY = 1440;
        public static string GetClosestNumerical(int hour, int minute)
        {
            var originalMinutes = hour * 60 + minute;
            var hours = hour;
            var minutes = minute;
            int[] hourNumbers = [.. SplitNumber(hours), .. SplitNumber(minutes)];
            var possibleTimes = GetPossibleTimes(hourNumbers).ToArray();
            var sortedTimes = possibleTimes.Select(x => GetTimeDistance(originalMinutes, x)).OrderBy(x => x.FullDistance).ToList();
            var result = sortedTimes.Count > 1 ? sortedTimes[1] : sortedTimes[0];
            return result.ToString();
        }

        private static TimeEntry GetTimeDistance(int originalMinutes, (int hours, int minutes) other)
        {
            var otherMinutes = other.hours * 60 + other.minutes;
            if (otherMinutes < originalMinutes)
            {
                return new TimeEntry(otherMinutes, MINUTES_IN_DAY - originalMinutes + otherMinutes);
            }
            return new TimeEntry(otherMinutes, otherMinutes - originalMinutes);
        }

        private static IEnumerable<int> SplitNumber(int number)
        {
            yield return (number / 10) % 10;
            yield return number % 10;
        }

        private static IEnumerable<(int hours, int minutes)> GetPossibleTimes(int[] timeNumbers)
        {
            var permutations = PermutationsGenerator.Generate(4).ToArray();
            foreach(var perm in permutations)
            {
                var hs = $"{timeNumbers[perm[0]]}{timeNumbers[perm[1]]}";
                var ms = $"{timeNumbers[perm[2]]}{timeNumbers[perm[3]]}";
                var hours = int.Parse(hs);
                var minutes = int.Parse(ms);
                if(IsTimeValid(hours, minutes))
                {
                    yield return (hours, minutes);
                }
            }
        }

        private static bool IsTimeValid(int hours, int minutes)
        {
            if(hours >= 24) return false;
            if(minutes >= 60) return false; 
            return true;
        }
    }
}
