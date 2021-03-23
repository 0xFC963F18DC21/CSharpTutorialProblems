using System;

namespace CSharpTutorialProblems.Utils {
    public interface IConsole {
        public void Write(string str);

        public void WriteLine(string str) {
            Write(str + Environment.NewLine);
        }

        public string? ReadLine();

        public void ClearStdout();
    }
}