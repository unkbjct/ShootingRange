using System;
using System.Collections.Generic; // подключаем Dictionary<TKey, TValue>

namespace Shooting
{
    public class User
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
    public class topScore
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    class Program
    {

        static int _InputInt()
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out int _UserCount))
                {
                    return _UserCount;
                }
                else
                {
                    Console.Write("На данном этапе только цифры!! Заново:");
                }
            }
        }

        static void Main(string[] args)
        {

            int _UserCount, _ShootCount, timeScore;

            Console.Write("Введите количество игроков: ");
            _UserCount = _InputInt();


            Console.Write("Введите сколько будет выстрелов: ");
            _ShootCount = _InputInt();

            var rnd = new Random();

            Dictionary<int, User> Users = new Dictionary<int, User>();
            Dictionary<int, topScore> TopUsers = new Dictionary<int, topScore>();

            for (int i = 0; i < _UserCount; i++)
            {

                int[,] ShootUser = new int[_ShootCount, 2];
                
                Console.Write($"Номер {i + 1}, введите свое имя: ");
                Users.Add(i, new User { Name = Console.ReadLine(), Score = 0});

                for (int j = 0; j < _ShootCount; j++)
                {
                    Console.WriteLine($"Нажмиет любую кнопку что бы сделать {j + 1}-ый выстрел!!"); ;
                    Console.ReadKey();
                    int TimeShoot = rnd.Next(1, 20);

                    for (int x = 0; x < 2; x++)
                    {
                        ShootUser[j, x] = TimeShoot;
                    }

                }

                timeScore = 0;

                for (int j = 0; j < _ShootCount; j++)
                {
                    if (5 < ShootUser[j, 0] && 5 < ShootUser[j, 1] && ShootUser[j, 0] < 10 && ShootUser[j, 1] < 10)
                    {
                        timeScore += 35;
                    }
                    else if (10 < ShootUser[j, 0] && 10 < ShootUser[j, 1] && ShootUser[j, 0] < 20 && ShootUser[j, 1] < 20)
                    {
                        timeScore += 25;
                    }
                    else if (0 < ShootUser[j, 0] && 0 < ShootUser[j, 1] && ShootUser[j, 0] < 5 && ShootUser[j, 1] < 5)
                    {
                        timeScore += 100;
                    }


                }
                Users[i].Score = timeScore;
                Console.WriteLine("_______________________________");
            }

            for (int i = 0; i < _UserCount; i++)
            {
                int timeTopScore = Users[i].Score, timeTopId = 0;
                string timeTopName = Users[i].Name;

                for (int j = 0; j < _UserCount; j++)
                {
                    if (timeTopScore <= Users[j].Score)
                    {
                        timeTopScore = Users[j].Score;
                        timeTopName = Users[j].Name;
                        timeTopId = j;
                    }

                }
                TopUsers.Add(i, new topScore { Name = timeTopName, Score = timeTopScore });
                Users[timeTopId].Score = -i;
            }

            for (int i = 0; i < _UserCount; i++)
            {
                Console.WriteLine($"Топ {i + 1} занял(а) {TopUsers[i].Name} со счетом {TopUsers[i].Score}");
            }
        }
    }
}