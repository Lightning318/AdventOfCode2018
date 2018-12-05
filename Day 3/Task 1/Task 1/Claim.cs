using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Task_1
{
    public class Claim
    {
        public int Id { get; }
        public Point TopLeft { get; }
        public int Width { get; }
        public int Height { get; }

        /// <summary>
        /// Processes a serialised claim onto an object.
        /// eg: 1 @ 1,3: 4x4
        /// </summary>
        public Claim(string claim)
        {
            var parts = claim.Split(' ');
            Id = int.Parse(parts[0]);

            TopLeft = new Point
            {
                X = int.Parse(parts[2].Split(',')[0]),
                Y = int.Parse(parts[2].Split(',')[1].TrimEnd(':'))
            };
            Width = int.Parse(parts[3].Split('x')[0]);
            Height = int.Parse(parts[3].Split('x')[1]);
        }

        public IEnumerable<string> GetClaimedPoints()
        {
            var points = new List<string>();
            for(var x = TopLeft.X; x < TopLeft.X + Width; x++)
            {
                for(var y = TopLeft.Y; y < TopLeft.Y + Height; y++)
                {
                    points.Add($"{x}x{y}");
                    //points.Add(new Point { X = x, Y = y });
                }
            }
            return points;
        }
    }
}
