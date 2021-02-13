using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace TestTessan
{
    public static class Maths
    {
        public static int Factorial(int n)
        {
            if (n < 0)
                throw new InvalidOperationException("Can't calculate factorial for a negative number");

            return Product(1, n);
        }

        public static int Binomial(int n, int k)
        {
            if (k < 0 || k > n)
                throw new InvalidOperationException("Expected: 0 <= k <= n");

            if (k == n || k == 0) return 1;

            // Code below is faster when k is close to n so we use C(n, k) = C(n, n-k) to save up some computation time
            if (k < n / 2)
                return Binomial(n, n - k);

            return Product(k + 1, n) / Factorial(n - k);
        }

        public static int Product(int from, int to)
        {
            if (from > to)
                throw new InvalidOperationException($"{nameof(from)} > {nameof(to)}");

            int result = 1;

            for (int i = from; i <= to; i++)
                result *= i;

            return result;
        }

        public static int TotalOfCombinationsForScoreUsing1And2(int n)
        {
            // We write n as 2 * j + 1 * k and get the number of combinations for each of this cases
            int result = 0, j = 0, k = n;
            while (k >= 0)
            {
                result += Binomial(j + k, j);

                j++;
                k -= 2;
            }
            
            return result;
        }

        public static bool CanObtainResultByAddingTwoElementsOfArray(int[] input, int target, [MaybeNullWhen(false)] out (int, int) firstResult)
        {
            int[] cleanInput = input.Where(i => i >= 0 && i <= target).ToArray();

            HashSet<int> tested = new();

            for(int i = 0; i < cleanInput.Length - 1; i++)
            {
                int k = cleanInput[i];

                if (!tested.Add(k)) continue;

                ReadOnlySpan<int> otherElts = cleanInput.AsSpan(i + 1);
                foreach(int l in otherElts)
                {
                    if (l + k == target)
                    {
                        firstResult = (k, l);
                        return true;
                    }
                }
            }

            firstResult = default;
            return false;
        }
    }
}