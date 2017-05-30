using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Obstacle
    {
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public Obstacle(int x, int y)
        {
            XCoord = x;
            YCoord = y;
        }
    }
}
