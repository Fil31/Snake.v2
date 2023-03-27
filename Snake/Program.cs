using Snake;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Snake
{
    class Program
    {
        static MusicPlayer? _musicPlayer;

        static void Main(string[] args)
        {
            StartMusic();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            int score = 0;
            Walls walls = new Walls(80, 25);
            walls.Draw();
            Console.ForegroundColor = ConsoleColor.White;
            Point snakeTail = new Point(15, 15, '¤');
            Snake snake = new Snake(snakeTail, 5, Direction.RIGHT);
            snake.Draw();

            Console.ForegroundColor = ConsoleColor.White;
            FoodGenerator foodGenerator = new FoodGenerator(80, 25, '%');
            Point food = foodGenerator.GenerateFood();
            food.Draw();
            FoodGenerator foodGenerator2 = new FoodGenerator(70, 30, '%');
            Point food2 = foodGenerator2.GenerateFood2();
            food2.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodGenerator.GenerateFood();
                    food.Draw();
                    score++;
                }
                else
                {
                    snake.Move();
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }
                Thread.Sleep(100);

            }
            string str_score = Convert.ToString(score);
            WriteGameOver(str_score);
            Console.ReadLine();
            _musicPlayer?.Stop();
            _musicPlayer?.Dispose();
        }

        static void StartMusic()
        {
            _musicPlayer = new MusicPlayer(@"C:\Users\clash\source\repos\Snake\Snake\start.mp3");
            _musicPlayer.PlayLooping();
        }

        public static void WriteGameOver(string score)
        {
            Console.Beep();
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("========================", xOffset, yOffset++);
            WriteText("        GAME OVER       ", xOffset + 1, yOffset++);
            yOffset++;
            WriteText($" You Scored {score} points", xOffset + 2, yOffset++);
            WriteText("", xOffset + 1, yOffset++);
            WriteText("=========================", xOffset, yOffset++);
            return;
        }
        public static void WriteText(string text, int xOffset, int YOffset)
        {
            Console.SetCursorPosition(xOffset, YOffset);
            Console.WriteLine(text);
        }
    }
}
