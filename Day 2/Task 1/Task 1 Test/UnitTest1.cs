using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1;

namespace Task_1_Test
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("abcdef bababc abbcde abcccd aabcdd abcdee ababab", 12)]
        public void Program_CalculateChecksum(string input, int result)
        {
            Program.CalculateChecksum(input).Should().Be(result);
        }

        [DataTestMethod]
        [DataRow("abcdef", false)]
        [DataRow("bababc", true)]
        [DataRow("abbcde", true)]
        [DataRow("abcccd", false)]
        [DataRow("aabcdd", true)]
        [DataRow("abcdee", true)]
        [DataRow("ababab", false)]
        public void Program_HasDoubleLetter(string input, bool result)
        {
            Program.HasDoubleLetter(input).Should().Be(result);
        }

        [DataTestMethod]
        [DataRow("abcdef", false)]
        [DataRow("bababc", true)]
        [DataRow("abbcde", false)]
        [DataRow("abcccd", true)]
        [DataRow("aabcdd", false)]
        [DataRow("abcdee", false)]
        [DataRow("ababab", true)]
        public void Program_HasTripleLetter(string input, bool result)
        {
            Program.HasTripleLetter(input).Should().Be(result);
        }
    }
}
