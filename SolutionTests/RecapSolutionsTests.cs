using System;
using System.Collections.Generic;
using System.Linq;
using CSharpTutorialProblems;
using CSharpTutorialProblems.Utils;
using NUnit.Framework;

namespace SolutionTests {
    public class RecapSolutionsTests {
        [Test]
        public void TestGenerateCollatzSequence() {
            // 16 8 4 2 1
            var sixteenList = RecapSolutions.GenerateCollatzSequence(16);
            Assert.AreEqual(5, sixteenList.Count);
            Assert.AreEqual(new List<int> { 16, 8, 4, 2, 1 }, sixteenList);

            // 26 13 40 20 10 5 16 8 4 2 1
            var twentysixList = RecapSolutions.GenerateCollatzSequence(26);
            Assert.AreEqual(11, twentysixList.Count);
            Assert.AreEqual(new List<int> { 26, 13, 40, 20, 10, 5, 16, 8, 4, 2, 1 }, twentysixList);

            // Throws
            Assert.Throws<ArgumentException>(() => RecapSolutions.GenerateCollatzSequence(0));
        }

        [Test]
        public void TestProducesPalindromicCube() {
            Assert.True(RecapSolutions.ProducesPalindromicCube(0));
            Assert.True(RecapSolutions.ProducesPalindromicCube(1));
            Assert.True(RecapSolutions.ProducesPalindromicCube(2));
            Assert.False(RecapSolutions.ProducesPalindromicCube(3));
            Assert.False(RecapSolutions.ProducesPalindromicCube(4));
            Assert.False(RecapSolutions.ProducesPalindromicCube(5));
            Assert.False(RecapSolutions.ProducesPalindromicCube(6));
            Assert.True(RecapSolutions.ProducesPalindromicCube(7));
        }

        [Test]
        public void TestGenerateLotteryNumbers() {
            var numbers = RecapSolutions.GenerateLotteryNumbers();
            Assert.AreEqual(7, numbers.Count);
            Assert.True(
                numbers.Select(x => numbers.Count(y => y == x) == 1)
                    .All(b => b)
            );
        }

        [Test]
        public void TestGenerateAllRandomBetween() {
            var limit = 16;
            var numbers = RecapSolutions.GenerateAllRandomBetween(limit);

            Assert.True(numbers.Count >= 16);
            Assert.True(Enumerable.Range(0, 15).All(numbers.Contains));
            Assert.Throws<ArgumentException>(
                () => RecapSolutions.GenerateAllRandomBetween(0)
            );
        }

        [Test]
        public void TestReverseInputs() {
            var strings = new List<string> { "A man", "A plan", "A canal", "Panama" };
            var lCon = new ListConsole(strings, new List<string>());

            RecapSolutions.ReverseInputs(lCon);
            Assert.AreEqual(new List<string> { "Panama", "A canal", "A plan", "A man" }, lCon.GetStdout());

        }
    }
}