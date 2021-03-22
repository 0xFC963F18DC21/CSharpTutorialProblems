using System;
using System.Collections.Generic;
using System.Linq;
using CSharpTutorialProblems.Utils;

namespace CSharpTutorialProblems {
    public static class RecapSolutions {
        private static Lazy<Random> Rnd = new();
        private static Lazy<IConsole> StdCon = new(() => new StandardConsole());

        public static List<int> GenerateCollatzSequence(int value) {
            switch (value) {
                case <= 0:
                    throw new ArgumentException("Number must be positive");
                case 1:
                    return new List<int> { 1 };
                default: {
                    List<int> l;

                    l = value % 2 == 0
                        ? GenerateCollatzSequence(value / 2)
                        : GenerateCollatzSequence(value * 3 + 1);

                    l.Insert(0, value);
                    return l;
                }
            }
        }

        public static bool ProducesPalindromicCube(int value) {
            var str = (value * value * value).ToString();
            var holds = true;

            for (int i = 0; holds && i < str.Length / 2; ++i) {
                holds = str[i] == str[str.Length - i - 1];
            }

            return holds;
        }

        public static List<int> GenerateLotteryNumbers() {
            var numbers = new List<int> { 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < numbers.Count; ++i) {
                int num;
                do {
                    num = Rnd.Value.Next(49) + 1;
                } while (numbers.Contains(num));

                numbers[i] = num;
            }

            return numbers;
        }

        public static List<int> GenerateAllRandomBetween(int exclusiveUpperBound) {
            if (exclusiveUpperBound <= 0) {
                throw new ArgumentException("Number must be positive");
            }

            var numbers = new List<int>();
            do {
                numbers.Add(Rnd.Value.Next(exclusiveUpperBound));
            } while (numbers.Select(x => x).Distinct().Count() < exclusiveUpperBound);

            return numbers;
        }

        public static void ReverseInputs() {
            ReverseInputs(StdCon.Value);
        }

        public static void ReverseInputs(IConsole console) {
            Stack<string> strs = new();

            string? input;
            while ((input = console.ReadLine()) != null) {
                strs.Push(input);
            }

            while (strs.Count > 0) {
                console.WriteLine(strs.Pop());
            }
        }
    }
}