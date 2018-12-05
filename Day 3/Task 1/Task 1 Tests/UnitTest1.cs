using System.Drawing;
using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Task_1;

namespace Task_1_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = "#1 @ 1,3: 4x4 #2 @ 3,1: 4x4 #3 @ 5,5: 2x2";
            var result = 4;

            Program.GetOverlappingSquareInches(input).Should().Be(result);
        }

        [TestMethod]
        public void Claim_ctor()
        {
            var input = "1 @ 1,3: 4x5";

            var claim = new Claim(input);

            claim.Id.Should().Be(1);
            claim.Width.Should().Be(4);
            claim.Height.Should().Be(5);
            claim.TopLeft.X.Should().Be(1);
            claim.TopLeft.Y.Should().Be(3);
        }

        [TestMethod]
        public void Claim_GetClaimedPoints()
        {
            var input = "1 @ 1,3: 4x5";

            var claim = new Claim(input);

            claim.GetClaimedPoints().Should().BeEquivalentTo(new[]
            {
                new Point {X = 1, Y = 3},
                new Point {X = 2, Y = 3},
                new Point {X = 3, Y = 3},
                new Point {X = 4, Y = 3},

                new Point {X = 1, Y = 4},
                new Point {X = 2, Y = 4},
                new Point {X = 3, Y = 4},
                new Point {X = 4, Y = 4},

                new Point {X = 1, Y = 5},
                new Point {X = 2, Y = 5},
                new Point {X = 3, Y = 5},
                new Point {X = 4, Y = 5},

                new Point {X = 1, Y = 6},
                new Point {X = 2, Y = 6},
                new Point {X = 3, Y = 6},
                new Point {X = 4, Y = 6},

                new Point {X = 1, Y = 7},
                new Point {X = 2, Y = 7},
                new Point {X = 3, Y = 7},
                new Point {X = 4, Y = 7},
            });
        }
    }
}
