using Snake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();
            HorizontalLine top = new HorizontalLine(0, 80, 0, '#');
            VerticalLine left = new VerticalLine(0, 25, 0, '#');
            HorizontalLine bottom = new HorizontalLine(0, 80, 25, '$');
            VerticalLine right = new VerticalLine(0, 25, 80, '&');
            HorizontalLine takistus = new HorizontalLine(5, 30, 20, '@');
            VerticalLine takistus1 = new VerticalLine(10, 20, 60, '@');
            wallList.Add(top);
            wallList.Add(left);
            wallList.Add(bottom);
            wallList.Add(right);
            wallList.Add(takistus);
            wallList.Add(takistus1);
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }

        public bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }

            return false;
        }
    }

}
