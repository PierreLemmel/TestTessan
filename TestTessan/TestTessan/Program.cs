using System;
using System.Linq;
using TestTessan;

Func<ITest>[] testFactories = new Func<ITest>[]
{
    () => new Test1(26),
    () => new Test2(new[] { 1, 1, 2, 3, 5, 6, 12, 13, 15, 15, 16, 18, 20, 27, 29 }, 8),
};

int userChoice;
if (args.Any())
    userChoice = int.Parse(args.First());
else
{
    Console.WriteLine("Choose test to run:");
    Console.WriteLine(" 1 - Number of combinations");
    Console.WriteLine(" 2 - Get integer from array");
    Console.WriteLine();

    userChoice = MoreConsole.ReadInt();
}

int index = userChoice - 1;
if (index >= 0 && index < testFactories.Length)
{
    ITest test = testFactories[userChoice - 1]();
    test.Run();
}
else
    Console.Error.WriteLine($"Invalid test number: {userChoice}");