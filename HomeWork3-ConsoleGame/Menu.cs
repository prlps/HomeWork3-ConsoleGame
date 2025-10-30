using System;

namespace HomeWork3_ConsoleGame
{
    internal class Menu
    {
        // Главное меню
        public void ShowMainMenu()
        {
            Console.Clear(); // очищаем консоль перед выводом
            Console.WriteLine("Welcome to My Diablo"); // приветственное сообщение. TODO: показывать только при первом запуске
            Console.WriteLine();
            Console.WriteLine("Главное меню:");
            Console.WriteLine("1) Призвать");
            Console.WriteLine("2) Атака");
            Console.WriteLine("3) Улучшение");
            Console.WriteLine("4) Уничтожение");
            Console.WriteLine("5) Вывод монстров");
            Console.WriteLine("q) Выход");
            Console.WriteLine();
            Console.Write("Выберите пункт: ");
        }

        // Обработка выбора в главном меню
        public void HandleMainMenuChoice(string input)
        {
            switch (input)
            {
                case "1":
                    ShowSummonMenu();
                    break;
                case "2":
                    ShowAttackMenu();
                    break;
                case "3":
                    ShowUpgradeMenu();
                    break;
                case "4":
                    ShowDestroyMenu();
                    break;
                case "5":
                    ViewMonstersMenu();
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
            }
        }

        // Менюшки второго уровня
        public void ShowSummonMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Призыв монстров ===");
                Console.WriteLine("1) Призвать скелета");
                Console.WriteLine("2) Призвать зомби");
                Console.WriteLine("3) Призвать призрака");
                Console.WriteLine("b) Назад в главное меню");
                Console.WriteLine();
                Console.Write("Выберите вариант: ");

                string choice = Console.ReadLine().Trim().ToLower();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Скелет призван!");
                        // TODO: AddSkeleton();
                        break;

                    case "2":
                        Console.WriteLine("Зомби призван!");
                        // TODO: AddZombie();
                        break;

                    case "3":
                        Console.WriteLine("Призрак призван!");
                        // TODO: AddGhost();
                        break;

                    case "b":
                        return; // выход в главное меню

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        public void ShowAttackMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Атака ===");
                Console.WriteLine("1) Нанести урон выбранному монстру (по id)");
                Console.WriteLine("2) Нанести урон случайному монстру");
                Console.WriteLine("b) Назад в главное меню");
                Console.WriteLine();
                Console.Write("Выберите вариант: ");

                string choice = Console.ReadLine().Trim().ToLower();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите id монстра: ");
                        string idStr = Console.ReadLine().Trim();
                        Console.Write("Введите величину урона (целое число): ");
                        string dmgStr = Console.ReadLine().Trim();
                        Console.WriteLine($"TODO: вызвать DamageById({idStr}, {dmgStr})");
                        // TODO: парсить id/dmg и вызвать реальную функцию DamageById(id, dmg);
                        break;

                    case "2":
                        Console.Write("Введите величину урона (целое число): ");
                        string dmgRandom = Console.ReadLine().Trim();
                        Console.WriteLine($"TODO: вызвать DamageRandom({dmgRandom})");
                        // TODO: парсить dmgRandom и вызвать реальную функцию DamageRandom(dmg);
                        break;

                    case "b":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        public void ShowUpgradeMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Улучшение монстра ===");
                Console.WriteLine("1) Улучшить броню (по id)");
                Console.WriteLine("2) Добавить шанс невидимости (по id)");
                Console.WriteLine("b) Назад в главное меню");
                Console.WriteLine();
                Console.Write("Выберите вариант: ");

                string choice = Console.ReadLine().Trim().ToLower();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите id монстра для апгрейда: ");
                        string idArmor = Console.ReadLine().Trim();
                        Console.Write("Укажите процент брони для добавления (0-90): ");
                        string addArmor = Console.ReadLine().Trim();
                        Console.WriteLine($"TODO: вызвать UpgradeArmor({idArmor}, {addArmor})");
                        // TODO: парсить и вызывать UpgradeArmor(id, value)
                        break;

                    case "2":
                        Console.Write("Введите id монстра для апгрейда: ");
                        string idInv = Console.ReadLine().Trim();
                        Console.Write("Укажите процент шанса невидимости для добавления (0-95): ");
                        string addInv = Console.ReadLine().Trim();
                        Console.WriteLine($"TODO: вызвать UpgradeInvisibility({idInv}, {addInv})");
                        // TODO: парсить и вызывать UpgradeInvisibility(id, value)
                        break;

                    case "b":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        public void ShowDestroyMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Уничтожение монстра ===");
                Console.WriteLine("1) Уничтожить монстра по id");
                Console.WriteLine("b) Назад в главное меню");
                Console.WriteLine();
                Console.Write("Выберите вариант: ");

                string choice = Console.ReadLine().Trim().ToLower();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите id монстра для удаления: ");
                        string idDel = Console.ReadLine().Trim();
                        Console.WriteLine($"TODO: вызвать DeleteById({idDel})");
                        // TODO: парсить id и вызывать DeleteById(id)
                        break;

                    case "b":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        public void ViewMonstersMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Список монстров ===");
                Console.WriteLine("1) Показать краткую информацию обо всех монстрах");
                Console.WriteLine("2) Показать подробную информацию обо всех монстрах");
                Console.WriteLine("b) Назад в главное меню");
                Console.WriteLine();
                Console.Write("Выберите вариант: ");

                string choice = Console.ReadLine().Trim().ToLower();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("TODO: вызвать PrintAllShort()");
                        // TODO: PrintAllShort();
                        break;

                    case "2":
                        Console.WriteLine("TODO: вызвать PrintAllDetailed()");
                        // TODO: PrintAllDetailed();
                        break;

                    case "b":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}
