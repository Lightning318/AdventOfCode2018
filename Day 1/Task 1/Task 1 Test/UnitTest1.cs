using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Task_1;

namespace Task_1_Test
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("+1 +1 +1", 3)]
        [DataRow("+1 +1 -2", 0)]
        [DataRow("-1 -2 -3", -6)]
        public void Calculate_test(string input, int result)
        {
            Program.CalculateFrequency(input).Should().Be(result);
        }
    }
}
