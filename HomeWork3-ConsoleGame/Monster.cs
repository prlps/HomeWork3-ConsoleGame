using System;

namespace HomeWork3_ConsoleGame
{
    internal class Monster
    {
        public int Id { get; set; }                         // назначается менеджером
        public string Name { get; set; }                    // имя (может быть пустым)
        public string Type { get; private set; }            // тип: Скелет/Зомби/Призрак
        public int Health { get; private set; }             // жизни
        public bool IsFlying { get; private set; }          // летает или нет
        public int Armor { get; private set; }              // броня в процентах
        public int InvisibilityChance { get; private set; } // шанс увернуться в процентах (0-100)

        // Конструктор
        public Monster(string type, int health = 100, bool isFlying = false, string name = "")
        {
            Type = type;
            Health = health;
            IsFlying = isFlying;
            Name = name ?? string.Empty;
            Armor = 0;
            InvisibilityChance = 0;
        }

        // Читаемое представление типа + имени
        public string NameOrType()
        {
            return string.IsNullOrWhiteSpace(Name) ? Type : $"{Type} '{Name}'";
        }

        // Движение
        public string Move()
        {
            return IsFlying ? "Летает" : "По земле";
        }

        // Рассчитать эффективность урона с учётом брони (без влияния невидимости)
        public int CalculateEffectiveDamage(int incoming)
        {
            int effective = incoming - (incoming * Armor / 100);
            return Math.Max(0, effective);
        }

        // Получение урона: смешанное распределение урона + проверка невидимости + броня
        public void TakeDamage(int baseDamage)
        {
            // Проверка невидимости
            int roll = RandomHelper.NextInt(0, 100);
            if (roll < InvisibilityChance)
            {
                Console.WriteLine($"{NameOrType()} увернулся от атаки (roll={roll} < {InvisibilityChance}).");
                return;
            }

            // Генерируем фактический урон с возможностью крита
            int damage = RandomHelper.NormalWithCrit(
                mean: baseDamage,
                stddev: Math.Max(1.0, baseDamage * 0.15),
                min: 0,
                max: Math.Max(baseDamage, baseDamage * 2),
                critProb: 0.08,
                critMultiplier: 2.0
            );

            int effectiveDamage = CalculateEffectiveDamage(damage);
            Health -= effectiveDamage;
            if (Health < 0) Health = 0;

            // Выводим инфу
            Console.WriteLine($"{NameOrType()} получил {effectiveDamage} урона (из {damage} до брони). Осталось {Health} HP.");

            if (Health <= 0)
                Console.WriteLine($"{NameOrType()} погиб!");
        }

        // Апгрейды
        public void UpgradeArmor(int value)
        {
            if (value <= 0) return;
            Armor += value;
            if (Armor > 90) Armor = 90; // защита сверху ограничена
            Console.WriteLine($"{NameOrType()} получил +{value}% брони. Текущая броня: {Armor}%.");
        }

        public void UpgradeInvisibility(int value)
        {
            if (value <= 0) return;
            InvisibilityChance += value;
            if (InvisibilityChance > 95) InvisibilityChance = 95; // ограничение сверху
            Console.WriteLine($"{NameOrType()} получил +{value}% к шансу невидимости. Сейчас: {InvisibilityChance}%.");
        }
    }
}
