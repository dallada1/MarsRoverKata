using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class LunarSurface
    {
        public int[,] surface;
        public LunarSurface(int width = 10, int height = 10)
        {
            //Check to see if inputs are at least 1x1 so that a rover can be present
            surface = new int[width, height];
        }

        private void AddRoverAtLocationWithDirection(int xCoordinate, int yCoordinate)
        {

        }
    }
}
