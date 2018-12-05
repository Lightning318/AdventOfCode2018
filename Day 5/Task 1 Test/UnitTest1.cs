using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Task_1;

namespace Task_1_Test
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow('a', 'a', false)]
        [DataRow('A', 'A', false)]
        [DataRow('a', 'A', true)]
        [DataRow('A', 'a', true)]
        [DataRow('a', 'B', false)]
        [DataRow('A', 'b', false)]
        public void Program_WouldReact(char a, char b, bool result)
        {
            Program.WouldReact(a, b).Should().Be(result);
        }
    }
}
