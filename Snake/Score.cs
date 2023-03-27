using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Score
    {
        public int Value { get; private set; }

        public Score()
        {
            Value = 0;
        }

        public void Increase(int amount)
        {
            Value += amount;
        }

        public void Draw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write($"Score: {Value}");
        }
    }

}
