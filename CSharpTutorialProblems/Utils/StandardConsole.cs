using System;

namespace CSharpTutorialProblems.Utils {
    public class StandardConsole : IConsole {
        public void Write(string str) {
            Console.Write(str);
        }

        public string? ReadLine() {
            return Console.ReadLine();
        }
    }
}