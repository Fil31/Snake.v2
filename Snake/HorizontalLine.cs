﻿using Snake;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Snake
{
    class HorizontalLine : Figure
    {

        public HorizontalLine(int xLeft, int xRight, int y, char symb)
        {
            pointList = new List<Point>();
            for (int i = xLeft; i <= xRight; i++)
            {
                Point p = new Point(i, y, symb);
                pointList.Add(p);
            }
        }
    }
}
