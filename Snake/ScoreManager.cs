using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Snake
{
    public class ScoreManager
    {
        private readonly string _fileName;

        public ScoreManager(string fileName)
        {
            _fileName = fileName;
        }

        public string GetPlayerName()
        {
            Console.WriteLine("Введите ваше имя (минимум 3 символа):");
            string playerName;
            do
            {
                playerName = Console.ReadLine();
            } while (playerName.Length < 3);

            return playerName;
        }

        public void SavePlayerScore(string playerName, string score)
        {
            using (StreamWriter sw = new StreamWriter(_fileName, true))
            {
                sw.WriteLine($"{playerName}:{score}");
            }
        }

        public void DisplayResults()
        {
            Console.Clear();
            Console.WriteLine("Результаты:");

            var results = new List<Tuple<string, int>>();

            using (StreamReader sr = new StreamReader(_fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string name = parts[0];
                        int score;
                        if (int.TryParse(parts[1], out score))
                        {
                            results.Add(new Tuple<string, int>(name, score));
                        }
                    }
                }
            }

            results = results.OrderByDescending(r => r.Item2).ToList();

            foreach (var result in results)
            {
                Console.WriteLine($"{result.Item1}: {result.Item2}");
            }
        }
    }
}
