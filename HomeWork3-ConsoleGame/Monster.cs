using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3_ConsoleGame
{
    internal class Monster
    {
        public string Name { get; set; }      // имя монстра, может быть пустым
        public string Type { get; private set; }   // Скелет, Зомби, Призрак
        public int Health { get; private set; }    // жизни
        public bool IsFlying { get; private set; } // летает или нет
        public int Armor { get; private set; }     // уменьшает получаемый урон
        public int InvisibilityChance { get; private set; } // % шанс избежать урона

        // Конструктор
        public Monster(string type, int health = 100, bool isFlying = false, string name = "")
        {
            Type = type;
            Health = health;
            IsFlying = isFlying;
            Name = name;
            Armor = 0;
            InvisibilityChance = 0;
        }

        // Метод движения
        public string Move()
        {
            return IsFlying ? "Летает" : "По земле";
        }

        // Получение урона с учётом брони и невидимости
        public void TakeDamage(int baseDamage)
        {
            Random rnd = new Random();
            int chance = rnd.Next(0, 100);

            // Проверяем невидимость
            if (chance < InvisibilityChance)
            {
                Console.WriteLine($"{Type} {(Name != "" ? Name : "")} увернулся от атаки!");
                return;
            }

            // Генерируем фактический урон по смешанному распределению
            int damage = RandomHelper.NormalMixture(
                mean: baseDamage,
                stddev: baseDamage * 0.15, //Среднее отклонение
                min: 0,
                max: baseDamage * 2,
                extremeProb: 0.08 // 8% шанс экстремального удара
            );

            // Учитываем броню
            int effectiveDamage = damage - (damage * Armor / 100);
            if (effectiveDamage < 0) effectiveDamage = 0;

            Health -= effectiveDamage;

            Console.WriteLine($"{Type} {(Name != "" ? Name : "")} получил {effectiveDamage} урона (из {damage} до брони), осталось {Health} HP.");

            if (Health <= 0)
            {
                Console.WriteLine($"{Type} {(Name != "" ? Name : "")} погиб!");
            }

        }

    }
}
