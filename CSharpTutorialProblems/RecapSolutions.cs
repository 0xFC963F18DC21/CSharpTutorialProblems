using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static List<string> Partition(this string str) {
            List<string> words = new();
            StringBuilder sb = new();

            foreach (var c in str.ToCharArray()) {
                if (char.IsLetterOrDigit(c)) {
                    sb.Append(c);
                } else {
                    words.Add(sb.ToString());
                    words.Add( $"{c}");
                    sb.Length = 0; // Clear StringBuilder
                }
            }

            if (sb.Length > 0) {
                words.Add(sb.ToString());
            }

            return words;
        }

        public static string PigLatinize(this string word) {
            const string vowels = "aeiou";

            switch (word.Length) {
                case <= 0:
                    return "";
                case 1 when char.IsLetter(word[0]):
                    return vowels.Contains(char.ToLower(word[0])) ? word + "way" : word + "ay";
                case 1:
                    return word;
            }

            if (word.Any(char.IsDigit)) {
                return word;
            }

            var shouldCap = char.IsUpper(word[0]);
            var begin = char.ToLower(word[0]);

            if (!vowels.Contains(begin)) {
                StringBuilder sb = new(word.Substring(1).ToLower());
                var newStart = sb[0];

                sb.Insert(1, shouldCap ? char.ToUpper(newStart) : newStart);
                sb.Append(begin);
                sb.Append("ay");

                return sb.Remove(0, 1).ToString();
            } else {
                return (shouldCap ? char.ToUpper(begin) : begin) + word.Substring(1).ToLower() + "way";
            }
        }

        public static void PigLatinizeLine() {
            PigLatinizeLine(StdCon.Value);
        }

        public static void PigLatinizeLine(IConsole console) {
            var line = console.ReadLine();
            if (line == null) return;

            console.WriteLine(
                String.Join("",
                    line.Partition()
                        .Where(s => s.Length > 0)
                        .Select(PigLatinize)
                )
            );
        }

        public static List<string> GetWords(this string str) {
            StringBuilder sb = new();
            List<string> words = new();

            foreach (char c in str.ToCharArray()) {
                if (char.IsLetterOrDigit(c)) {
                    sb.Append(c);
                } else {
                    if (sb.Length > 0) {
                        words.Add(sb.ToString());
                        sb.Length = 0;
                    }
                }
            }

            if (sb.Length > 0) {
                words.Add(sb.ToString());
            }

            return words;
        }

        public static void InputCountStatistics() {
            InputCountStatistics(StdCon.Value);
        }
        public static void InputCountStatistics(IConsole console) {
            List<string> lines = new();
            string? ln;

            do {
                ln = console.ReadLine();
                if (ln != null) {
                    lines.Add(ln);
                }
            } while (ln != null);

            List<List<string>> words = lines.Select(GetWords).ToList();

            console.WriteLine($"Lines: {lines.Count}");
            console.WriteLine($"Words: {words.Aggregate(0, (sum, l) => l.Count + sum)}");
            console.WriteLine($"Characters: {words.Aggregate(0, (sum, l) => sum + l.Aggregate(0, (sm, s) => sm + s.Length))}");
        }
    }
}