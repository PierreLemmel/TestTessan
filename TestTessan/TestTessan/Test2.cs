using System;

using static TestTessan.Maths;

namespace TestTessan
{
    public class Test2 : ITest
    {
        private readonly int[] input;
        private readonly int target;

        public Test2(int[] input, int target)
        {
            this.input = input;
            this.target = target;
        }

        public void Run()
        {
            Console.WriteLine($"Running Test2 with target: {target}");
            Console.WriteLine($"Input: [{string.Join(", ", input)}]");

            Console.WriteLine();
            if (CanObtainResultByAddingTwoElementsOfArray(input, target, out (int, int) firstResult))
            {
                (int i, int j) = firstResult;
                Console.WriteLine("First solution found:");
                Console.WriteLine($"{target} = {i} + {j}");
            }
            else
            {
                Console.WriteLine($"Can't get {target} by adding elements from input");
            }
        }
    }
}