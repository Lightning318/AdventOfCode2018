using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Task_2;

namespace Task_2_Test
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("+1 -1", 0)]
        [DataRow("+3 +3 +4 -2 -4", 10)]
        [DataRow("-6 +3 +8 +5 -6", 5)]
        [DataRow("+7 +7 -2 -7 -4", 14)]
        public void Calculate_test(string input, int result)
        {
            Program.CalculateFrequency(input).Should().Be(result);
        }
    }
}
