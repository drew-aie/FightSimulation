using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimulation
{
    struct Monster
    {
        public string name;
        public float health;
        public float attack;
        public float defense;

        // Constructor
        public Monster(
            string name,
            float health,
            float attack,
            float defense)
        {
            this.name = name;
            this.health = health;
            this.attack = attack;
            this.defense = defense;
        }
    }

    internal class Game
    {
        bool _gameOver = false;
        Monster _monster1;
        Monster _monster2;
        Monster _monster3;

        void Start()
        {
            // Monster 1
            _monster1 = new Monster("Wompus", 100, 15, 5);

            // Monster 2
            _monster2 = new Monster("Thwompus", 80, 15, 10);

            // Monster 3
            _monster3 = new Monster("Gim", 4800, 1000, 1);

            PrintStats(_monster1);
            PrintStats(_monster2);
        }

        void Update()
        {
            // Fight 1
            while (_monster1.health > 0 && _monster2.health > 0)
            {
                Console.WriteLine("---------------");
                // Monster 1 attacks Monster 2
                Console.WriteLine(_monster2.name + " has taken " + Fight(_monster1, ref _monster2) + " damage!");

                // Monster 2 attacks Monster 1
                Console.WriteLine(_monster1.name + " has taken " + Fight(_monster2, ref _monster1) + " damage!");

                PrintStats(_monster1);
                PrintStats(_monster2);
            }


            // Solution 2
            Monster winningMonster;
            if (_monster1.health <= 0)
            {
                winningMonster = _monster2;
            }
            else if (_monster2.health <= 0)
            {
                winningMonster = _monster1;
            }

            // winningMonster fights Gims


            // Solution 1
            if (_monster1.health <= 0)
            {
                // Monster 2 fights Gim
            }
            else if (_monster2.health <= 0)
            {
                // Monster 1 fights Gim
            }

            _gameOver = true;
        }

        void End()
        {
            Console.ReadKey();
        }

        public void Run()
        {
            Start();

            while (!_gameOver)
            {
                Update();
            }

            End();
        }

        float Fight(Monster attacker, ref Monster defender)
        {
            float damageTaken = CalculateDamage(attacker.attack, defender.defense);
            defender.health -= damageTaken;
            return damageTaken;
        }

        float CalculateDamage(float attack, float defense)
        {
            float damage = attack - defense;

            if (damage <= 0)
            {
                damage = 0;
            }

            return damage;
        }

        void PrintStats(Monster monster)
        {
            Console.WriteLine("Name:    " + monster.name);
            Console.WriteLine("Health:  " + monster.health);
            Console.WriteLine("Attack:  " + monster.attack);
            Console.WriteLine("Defense: " + monster.defense);
        }
    }
}
