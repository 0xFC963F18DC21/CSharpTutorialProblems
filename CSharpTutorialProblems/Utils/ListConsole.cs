using System.Collections.Generic;

namespace CSharpTutorialProblems.Utils {
    public class ListConsole : IConsole {
        private List<string> Stdin;
        private List<string> Stdout;

        public ListConsole(List<string> stdin, List<string> stdout) {
            Stdin = stdin;
            Stdout = stdout;
        }

        public ListConsole() {
            Stdin = new List<string>();
            Stdout = new List<string>();
        }

        public void Write(string str) {
            if (Stdout.Count > 0) {
                Stdout[^1] += str;
            } else {
                Stdout.Add(str);
            }
        }

        public void WriteLine(string str) {
            Write(str);
            Stdout.Add("");
        }

        public void WriteLineToStdin(string str) {
            Stdin.Add(str);
        }

        public List<string> GetStdout() {
            var l = Stdout.ConvertAll(s => s);
            if (l[^1] == "") {
                l.RemoveAt(l.Count - 1);
            }

            return l;
        }

        public string? ReadLine() {
            if (Stdin.Count <= 0) return null;

            var str = Stdin[0];
            Stdin.RemoveAt(0);

            return str;
        }
    }
}