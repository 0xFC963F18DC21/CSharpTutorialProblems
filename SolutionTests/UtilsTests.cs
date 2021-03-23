using System;
using System.Collections.Generic;
using System.IO;
using CSharpTutorialProblems.Utils;
using NUnit.Framework;

namespace SolutionTests {
    public class UtilsTests {
        [Test]
        public void TestListConsole() {
            ListConsole con = new();

            // Testing stdout output
            con.Write("Hello, ");
            con.WriteLine("World!");

            Assert.AreEqual(new List<string> { "Hello, World!" }, con.GetStdout());

            // Testing stdout clearing
            con.ClearStdout();
            Assert.AreEqual(0, con.GetStdout().Count);

            // Testing stdin I/O
            con.WriteLineToStdin("Test!");
            Assert.AreEqual("Test!", con.ReadLine());
            Assert.Null(con.ReadLine());
        }

        [Test]
        public void TestStandardConsole() {
            StringReader strRdr = new("listen let's be honest" + Environment.NewLine);
            StringWriter strWrt = new();

            Console.SetIn(strRdr);
            Console.SetOut(strWrt);

            StandardConsole con = new ();

            // Should be non-null
            Assert.NotNull(con.ReadLine());

            // Should be null
            Assert.Null(con.ReadLine());

            // Test printing
            con.Write("Hello, ");
            ((IConsole) con).WriteLine("World!");

            Assert.AreEqual("Hello, World!" + Environment.NewLine, strWrt.ToString());

            // Test clear... note that this doesn't actually work for
            // StringWriter fake consoles because StringWriter is stupid.
            con.ClearStdout();
        }
    }
}