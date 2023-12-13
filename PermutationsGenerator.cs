using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeNumericalDifferentiator
{
    internal static class PermutationsGenerator
    {
        public static IEnumerable<int[]> Generate(int n)
        {
            var numberOfPermuations = Combinatorics.Permutations(n);
            var original = Enumerable.Range(0, n).ToArray();
            for (var i = 0; i < numberOfPermuations; i++)
            {
                var poss = Combinatorics.SelectPermutation(original);
                yield return poss.ToArray();
            }
        }


    }
}
