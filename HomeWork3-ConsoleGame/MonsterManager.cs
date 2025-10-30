using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork3_ConsoleGame
{
    internal class MonsterManager
    {
        private readonly List<Monster> monsters = new List<Monster>();
        private int nextId = 1;

        public IReadOnlyList<Monster> Monsters => monsters.AsReadOnly();

        // Добавление общего монстра и назначение id
        public int AddMonster(Monster m)
        {
            if (m == null) throw new ArgumentNullException(nameof(m));
            m.Id = nextId++;
            monsters.Add(m);
            Console.WriteLine($"Добавлен: [{m.Id}] {m.NameOrType()} HP={m.Health}");
            return m.Id;
        }

        // Удобные фабричные методы для трёх типов
        public void AddSkeleton(string name = "")
            => AddMonster(new Monster("Скелет", health: 50, isFlying: false, name: name));

        public void AddZombie(string name = "")
            => AddMonster(new Monster("Зомби", health: 80, isFlying: false, name: name));

        public void AddGhost(string name = "")
            => AddMonster(new Monster("Призрак", health: 40, isFlying: true, name: name));

        // Нанести урон по id
        public bool DamageById(int id, int baseDamage)
        {
            var m = monsters.FirstOrDefault(x => x.Id == id);
            if (m == null)
            {
                Console.WriteLine($"Монстр с id={id} не найден.");
                return false;
            }

            m.TakeDamage(baseDamage);

            if (m.Health <= 0)
            {
                DeleteById(id); // удаляем и сообщаем
                return true;
            }

            return false;
        }

        // Нанести урон случайному монстру
        public bool DamageRandom(int baseDamage)
        {
            if (!monsters.Any())
            {
                Console.WriteLine("Список монстров пуст.");
                return false;
            }

            int idx = RandomHelper.NextInt(0, monsters.Count); // 0..Count-1
            var m = monsters[idx];
            Console.WriteLine($"Случайно выбран: [{m.Id}] {m.NameOrType()}");
            m.TakeDamage(baseDamage);

            if (m.Health <= 0)
            {
                DeleteById(m.Id);
                return true;
            }

            return false;
        }

        // Апгрейды
        public void UpgradeArmor(int id, int plus)
        {
            var m = monsters.FirstOrDefault(x => x.Id == id);
            if (m == null) { Console.WriteLine($"Монстр с id={id} не найден."); return; }
            m.UpgradeArmor(plus);
        }

        public void UpgradeInvisibility(int id, int plus)
        {
            var m = monsters.FirstOrDefault(x => x.Id == id);
            if (m == null) { Console.WriteLine($"Монстр с id={id} не найден."); return; }
            m.UpgradeInvisibility(plus);
        }

        // Удаление: публичный метод с именем, которое использует Menu
        public void DeleteById(int id)
        {
            var m = monsters.FirstOrDefault(x => x.Id == id);
            if (m == null)
            {
                Console.WriteLine($"Монстр с id={id} не найден.");
                return;
            }

            monsters.RemoveAll(x => x.Id == id);
            Console.WriteLine($"Монстр удалён: [{m.Id}] {m.NameOrType()}");
        }

        // Вывод краткой информации
        public void PrintAllShort()
        {
            if (!monsters.Any()) { Console.WriteLine("Нет монстров."); return; }

            foreach (var m in monsters)
            {
                Console.WriteLine($"[{m.Id}] {m.NameOrType()} | HP={m.Health} | Armor={m.Armor}% | Invis={m.InvisibilityChance}%");
            }
        }

        // Вывод подробной информации
        public void PrintAllDetailed()
        {
            if (!monsters.Any()) { Console.WriteLine("Нет монстров."); return; }

            foreach (var m in monsters)
            {
                Console.WriteLine($"[{m.Id}] {m.NameOrType()} | HP={m.Health} | Move={m.Move()} | Урон при входящем 100 = {m.CalculateEffectiveDamage(100)}");
            }
        }
    }
}
