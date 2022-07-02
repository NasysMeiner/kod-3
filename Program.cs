using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Aquarium aquarium = new Aquarium();
            aquarium.Work();
        }
    }

    class Aquarium
    {
        private static int _numberMonths = 0;       
        private Stack<int> _deathFishs = new Stack<int>();
        private List<Fish> _fish = new List<Fish>();

        public Aquarium()
        {
            _fish.Add(new Fish("Oleg", 100));
            _fish.Add(new Fish("Fish", 3));
        }

        public void Work()
        {
            while (true)
            {
                Console.SetCursorPosition(80, 0);
                Console.WriteLine("Аквариум");
                Console.SetCursorPosition(80, 1);
                Console.WriteLine("1 - добавить рыбку.");
                Console.SetCursorPosition(80, 2);
                Console.WriteLine("2 - убрать рыбку.");
                Console.SetCursorPosition(0, 0);  

                ShowInfoFish();
                RemoveFish();

                ConsoleKeyInfo key = Console.ReadKey(true);
                ChooseItem(key);

                Console.Clear();
                _numberMonths++;
            }
        }

        public void ShowInfoFish()
        {
            string condition;
            int number = 0;            

            Console.WriteLine($"Рыб в аквариуме:{_fish.Count}.\nМесяц:{_numberMonths}\n");

            foreach (Fish fish in _fish)
            {
                if(fish.Life)
                {
                    condition = "Жива";
                }
                else
                {
                    condition = "Погибла";
                }

                Console.WriteLine($"Рыбка: {fish.Name} - {condition}, заявленное время жизни - {fish.LifeTime} месяцев. Id - {fish.FishId}.");

                if(fish.Life == false)
                {
                    _deathFishs.Push(number);                
                }

                fish.RunsTime();
                number++;
            }
        }

        private void RemoveFish()
        {
            if(_deathFishs.Count > 0)
            {
                int variable = _deathFishs.Count();

                for (int i = 0; i < variable; i++)
                {
                    _fish.RemoveAt(_deathFishs.Pop());
                }
            }        
        }

        private void AddFish()
        {
            Console.Clear();

            Random random = new Random();
            string name;           

            Console.Write("Введите имя:");
            name = Console.ReadLine();

            _fish.Add(new Fish(name, random.Next(2, 10)));
        }

        private void DeleteFish()
        {
            string userInputId;
            int deleteFish = 0;

            Console.Clear();

            Console.Write("Введите Id рыбки:");
            userInputId = Console.ReadLine();

            if(int.TryParse(userInputId, out int number))
            {
                foreach(Fish fish in _fish)
                {
                    if(fish.FishId == number)
                    {
                        _fish.Remove(fish);
                        deleteFish++;
                        break;
                    }
                }

                if(deleteFish > 0)
                {
                    Console.WriteLine("Рыбка удалена.");
                }
                else
                {
                    Console.WriteLine("Рыбка не найдена.");
                }
            }
            else
            {
                Console.WriteLine("Рыбки с таким Id нету.");
            }

            Console.ReadKey();
        }

        private void ChooseItem(ConsoleKeyInfo key)
        {
            switch(key.Key)
            {
                case ConsoleKey.D1:
                    AddFish();
                    break;    
                case ConsoleKey.D2:
                    DeleteFish();
                    break;
            }
        }
    }

    class Fish
    {
        private static int _globalIds = 10;

        public bool Life { get; private set; }
        public string Name { get; private set; }
        public int LifeTime { get; private set; }
        public int FishId { get; private set; }


        public Fish(string name, int lifeTime)
        {
            Name = name;
            LifeTime = lifeTime;
            Life = true;
            FishId = _globalIds++;
        }

        public void RunsTime()
        {
            if (LifeTime <= 0)
            {
                Life = false;
            }
            else
            {
                LifeTime--;
            }            
        }
    }
}
