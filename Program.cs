using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            database.Work();
        }
    }

    class Database
    {
        private List<Soldier> _soldiers = new List<Soldier>();

        public Database()
        {
            _soldiers.Add(new Soldier("Игорь", "Автомат", "Рядовой", 10));
            _soldiers.Add(new Soldier("Андрей", "Пистолет", "Сержант", 15));
            _soldiers.Add(new Soldier("Ярослав", "Нож", "Прапорщик", 6));
            _soldiers.Add(new Soldier("Владислав", "Автомат", "Майор", 20));
            _soldiers.Add(new Soldier("Эдуард", "Пистолет", "Капитан", 30));
            _soldiers.Add(new Soldier("Илья", "Автомат", "Полковник", 13));
            _soldiers.Add(new Soldier("Кирилл", "Нож", "Лейтинант", 17));
        }

        public void Work()
        {
            var soldiers = from Soldier soldier in _soldiers select new { Name = soldier.Name, Rank = soldier.Rank };

            foreach(var soldier in soldiers)
            {
                Console.WriteLine($"{soldier.Name} - {soldier.Rank}.");
            }

            Console.ReadLine();
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string Weapon { get; private set; }
        public string Rank { get; private set; }
        public int Time { get; private set; }

        public Soldier(string name, string weapon, string rank, int time)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            Time = time;
        }
    }
}
