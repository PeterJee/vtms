using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTMS.Common
{
    public class SizeAndPosition
    {
        public int width;
        public int height;
        public int locationX;
        public int locationY;

        public SizeAndPosition(int width, int height, int locationX, int locationY)
        {
            this.width = width;
            this.height = height;
            this.locationX = locationX;
            this.locationY = locationY;
        }
    }
}
