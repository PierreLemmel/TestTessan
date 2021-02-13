using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestTessan.Tests
{
    public class MathsTests
    {
        [Test]
        [TestCaseSource(nameof(BinomialTestCases))]
        public void Binomial_Returns_Expected(int k, int n, int expected) => Assert.AreEqual(expected, Maths.Binomial(k, n));

        public static IEnumerable<object[]> BinomialTestCases => new object[][]
        {  
            new object[] { 10, 9, 10 },
            new object[] { 10, 1, 10 },
            new object[] { 4, 2, 6 },
            new object[] { 8, 2, 28 },
            new object[] { 8, 6, 28 },
            new object[] { 10, 0, 1 },
            new object[] { 10, 10, 1 },
        };

        [Test]
        [TestCaseSource(nameof(TotalOfCombinationsForScoreUsing1And2TestCases))]
        public void TotalOfCombinationsForScoreUsing1And2_Returns_Expected(int n, int expected) => Assert.AreEqual(expected, Maths.TotalOfCombinationsForScoreUsing1And2(n));

        public static IEnumerable<object[]> TotalOfCombinationsForScoreUsing1And2TestCases => new object[][]
        {
            new object[] { 2, 2 },
            new object[] { 3, 3 },
            new object[] { 4, 5 },
            new object[] { 6, 13 },
        };

        [Test]
        [TestCaseSource(nameof(CanObtainResultByAddingTwoElementsOfArrayTestCases))]
        public void CanObtainResultByAddingTwoElementsOfArray_Returns_Expecteds_When_Array_Contains_Elements(int[] input, int target, (int, int) expectedResult)
        {
            Assert.IsTrue(Maths.CanObtainResultByAddingTwoElementsOfArray(input, target, out (int i, int j) result));
            Assert.AreEqual(expectedResult, result);
        }

        public static IEnumerable<object[]> CanObtainResultByAddingTwoElementsOfArrayTestCases => new object[][]
        {
            new object[]
            {
                new int[] { 1, 1, 2, 3, 5, 6, 12, 13, 15, 15, 16, 18, 20, 27, 29 },
                8,
                (2, 6)
            },
            new object[]
            {
                new int[] { 1, 1, 2, 7, 3, 5, 6, 12, 13 },
                9,
                (2, 7)
            },
        };

        [Test]
        [TestCaseSource(nameof(CanNotObtainResultByAddingTwoElementsOfArrayTestCases))]
        public void CanObtainResultByAddingTwoElementsOfArray_Returns_False_When_Array_Does_Not_Contain_Elements(int[] input, int target) => Assert.IsFalse(Maths.CanObtainResultByAddingTwoElementsOfArray(input, target, out _));

        public static IEnumerable<object[]> CanNotObtainResultByAddingTwoElementsOfArrayTestCases => new object[][]
        {
            new object[]
            {
                new int[] { 1, 1, 2, 3, 5, 6, 12, 13, 15, 15, 16, 18, 20, 27, 29 },
                10,
            },
            new object[]
            {
                new int[] { 1, 1, 2, 7, 3, 5, 6, 12, 13 },
                32,
            },
            new object[]
            {
                new int[] { 1 },
                32,
            },
            new object[]
            {
                Array.Empty<int>(),
                32,
            },
        };
    }
}