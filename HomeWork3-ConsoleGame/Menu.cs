using System;

namespace HomeWork3_ConsoleGame
{
    internal class Menu
    {
        private readonly MonsterManager manager = new MonsterManager();
        private bool firstRun = true; // для приветствия только при первом запуске

        // Главное меню
        public void ShowMainMenu()
        {
            Console.Clear();
            if (firstRun)
            {
                Console.WriteLine("Welcome to My Diablo");
                firstRun = false;
            }
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

        // Обработка выбора главного меню
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

        // Меню призыва монстров
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
                        manager.AddSkeleton();
                        break;
                    case "2":
                        manager.AddZombie();
                        break;
                    case "3":
                        manager.AddGhost();
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

        // Меню атаки
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
                        Console.Write("Введите величину урона: ");
                        string dmgStr = Console.ReadLine().Trim();
                        if (int.TryParse(idStr, out int id) && int.TryParse(dmgStr, out int dmg))
                            manager.DamageById(id, dmg);
                        else
                            Console.WriteLine("Неверные данные.");
                        break;

                    case "2":
                        Console.Write("Введите величину урона: ");
                        string dmgRandom = Console.ReadLine().Trim();
                        if (int.TryParse(dmgRandom, out int dmgR))
                            manager.DamageRandom(dmgR);
                        else
                            Console.WriteLine("Неверные данные.");
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

        // Меню апгрейдов
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
                        if (int.TryParse(idArmor, out int idA) && int.TryParse(addArmor, out int valueA))
                            manager.UpgradeArmor(idA, valueA);
                        else
                            Console.WriteLine("Неверные данные.");
                        break;

                    case "2":
                        Console.Write("Введите id монстра для апгрейда: ");
                        string idInv = Console.ReadLine().Trim();
                        Console.Write("Укажите процент шанса невидимости (0-95): ");
                        string addInv = Console.ReadLine().Trim();
                        if (int.TryParse(idInv, out int idI) && int.TryParse(addInv, out int valueI))
                            manager.UpgradeInvisibility(idI, valueI);
                        else
                            Console.WriteLine("Неверные данные.");
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

        // Меню удаления монстра
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
                        if (int.TryParse(idDel, out int idD))
                            manager.DeleteById(idD);
                        else
                            Console.WriteLine("Неверные данные.");
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

        // Меню просмотра монстров
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
                        manager.PrintAllShort();
                        break;
                    case "2":
                        manager.PrintAllDetailed();
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
