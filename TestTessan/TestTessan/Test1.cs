using System;

using static TestTessan.Maths;

namespace TestTessan
{
    public class Test1 : ITest
    {
        private readonly int finalScore;

        public Test1(int finalScore) => this.finalScore = finalScore;

        public void Run()
        {
            Console.WriteLine($"Running Test1 with final score: {finalScore}");
            Console.WriteLine("Calculating number of combinations");

            int result = TotalOfCombinationsForScoreUsing1And2(finalScore);

            Console.WriteLine();
            Console.WriteLine($"Number of combinations to get a score of {finalScore}: {result}");
        }
    }
}