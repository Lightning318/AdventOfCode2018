using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Task_2;

namespace Task_2_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Program_FindSimilarBox()
        {
            var input = "abcde fghij klmno pqrst fguij axcye wvxyz";
            var result = "fgij";

            Program.FindSimilarBox(input).Should().Be(result);
        }
    }
}