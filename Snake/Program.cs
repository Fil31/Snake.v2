using NAudio.Wave;
using Snake;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        private static SoundManager _soundManager = new SoundManager();
        private static Score _score = new Score();
        private static ScoreManager _scoreManager = new ScoreManager("Names.txt");
        static void Main(string[] args)
        {
            _soundManager.PlayBackgroundMusicAsync();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            int score = 0;
            Walls walls = new Walls(80, 25);
            walls.Draw();
            Console.ForegroundColor = ConsoleColor.Black;
            Point snakeTail = new Point(15, 15, '¤');
            Snake snake = new Snake(snakeTail, 5, Direction.RIGHT);
            snake.Draw();
            snake.FoodEaten += (sender, e) => _soundManager.PlayEatSoundAsync();

            Console.ForegroundColor = ConsoleColor.Blue;
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
                    _soundManager.Stop();
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodGenerator.GenerateFood();
                    food.Draw();
                    score++;
                    _score.Increase(1);
                    _score.Draw(1, 26);
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
            string playerName = _scoreManager.GetPlayerName();
            _scoreManager.SavePlayerScore(playerName, str_score);
            _scoreManager.DisplayResults();

            Console.ReadLine();
        }

        public static void WriteGameOver(string score)
        {
            _soundManager.PlayGameOverSoundAsync();
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