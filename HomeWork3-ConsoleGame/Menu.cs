using System;

namespace HomeWork3_ConsoleGame
{
    internal class Menu
    {
        private readonly MonsterManager manager = new MonsterManager();
        private bool firstRun = true; // для приветствия только при первом запуске

        // Запуск главного цикла меню
        public void Run()
        {
            while (true)
            {
                ShowMainMenu();
                var key = Console.ReadKey(intercept: true);
                if (HandleMainMenuKey(key))
                    break; // выход из приложения
            }
        }

        // Главное меню (только вывод)
        private void ShowMainMenu()
        {
            Console.Clear();
            if (firstRun)
            {
                Console.WriteLine("Welcome to Monsters and Gaussian damage game");
                firstRun = false;
            }
            Console.WriteLine();
            Console.WriteLine("Главное меню:");
            Console.WriteLine("1) Призвать");
            Console.WriteLine("2) Атака");
            Console.WriteLine("3) Улучшение");
            Console.WriteLine("4) Уничтожение");
            Console.WriteLine("5) Вывод монстров");
            Console.WriteLine("Q) Выход");
            Console.WriteLine();
            Console.Write("Нажмите 1..5 или Q: ");
        }

        // Обработка нажатой клавиши в главном меню. Возвращает true если нужно выйти
        private bool HandleMainMenuKey(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    ShowSummonMenu();
                    return false;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ShowAttackMenu();
                    return false;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ShowUpgradeMenu();
                    return false;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ShowDestroyMenu();
                    return false;

                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    ViewMonstersMenu();
                    return false;

                case ConsoleKey.Q:
                    return true;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Неверный выбор. Нажмите 1..5 или Q.");
                    System.Threading.Thread.Sleep(600);
                    return false;
            }
        }

        // ---------- Призыв ----------
        private void ShowSummonMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Призыв монстров ===");
                Console.WriteLine("1) Призвать скелета");
                Console.WriteLine("2) Призвать зомби");
                Console.WriteLine("3) Призвать призрака");
                Console.WriteLine("B) Назад");
                Console.WriteLine();
                Console.Write("Нажмите 1/2/3 или B: ");

                var key = Console.ReadKey(intercept: true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        manager.AddSkeleton();
                        PauseShort();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        manager.AddZombie();
                        PauseShort();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        manager.AddGhost();
                        PauseShort();
                        break;
                    case ConsoleKey.B:
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Неверный выбор.");
                        System.Threading.Thread.Sleep(400);
                        break;
                }
            }
        }

        // ---------- Атака ----------
        private void ShowAttackMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Атака ===");
                Console.WriteLine("1) Нанести урон выбранному монстру (по id)");
                Console.WriteLine("2) Нанести урон случайному монстру");
                Console.WriteLine("B) Назад");
                Console.WriteLine();
                Console.Write("Нажмите 1/2 или B: ");

                var key = Console.ReadKey(intercept: true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine();
                        Console.Write("Введите id монстра: ");
                        string idStr = Console.ReadLine().Trim();
                        Console.Write("Введите величину урона: ");
                        string dmgStr = Console.ReadLine().Trim();
                        if (int.TryParse(idStr, out int id) && int.TryParse(dmgStr, out int dmg))
                            manager.DamageById(id, dmg);
                        else
                            Console.WriteLine("Неверные данные.");
                        PauseShort();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine();
                        Console.Write("Введите величину урона: ");
                        string dmgRandom = Console.ReadLine().Trim();
                        if (int.TryParse(dmgRandom, out int dmgR))
                            manager.DamageRandom(dmgR);
                        else
                            Console.WriteLine("Неверные данные.");
                        PauseShort();
                        break;

                    case ConsoleKey.B:
                        return;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Неверный выбор.");
                        System.Threading.Thread.Sleep(400);
                        break;
                }
            }
        }

        // ---------- Апгрейд ----------
        private void ShowUpgradeMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Улучшение монстра ===");
                Console.WriteLine("1) Улучшить броню (по id)");
                Console.WriteLine("2) Добавить шанс невидимости (по id)");
                Console.WriteLine("B) Назад");
                Console.WriteLine();
                Console.Write("Нажмите 1/2 или B: ");

                var key = Console.ReadKey(intercept: true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine();
                        Console.Write("Введите id монстра для апгрейда: ");
                        string idArmor = Console.ReadLine().Trim();
                        Console.Write("Укажите процент брони для добавления (0-90): ");
                        string addArmor = Console.ReadLine().Trim();
                        if (int.TryParse(idArmor, out int idA) && int.TryParse(addArmor, out int valueA))
                            manager.UpgradeArmor(idA, valueA);
                        else
                            Console.WriteLine("Неверные данные.");
                        PauseShort();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine();
                        Console.Write("Введите id монстра для апгрейда: ");
                        string idInv = Console.ReadLine().Trim();
                        Console.Write("Укажите процент шанса невидимости (0-95): ");
                        string addInv = Console.ReadLine().Trim();
                        if (int.TryParse(idInv, out int idI) && int.TryParse(addInv, out int valueI))
                            manager.UpgradeInvisibility(idI, valueI);
                        else
                            Console.WriteLine("Неверные данные.");
                        PauseShort();
                        break;

                    case ConsoleKey.B:
                        return;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Неверный выбор.");
                        System.Threading.Thread.Sleep(400);
                        break;
                }
            }
        }

        // ---------- Удаление ----------
        private void ShowDestroyMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Уничтожение монстра ===");
                Console.WriteLine("1) Уничтожить монстра по id");
                Console.WriteLine("B) Назад");
                Console.WriteLine();
                Console.Write("Нажмите 1 или B: ");

                var key = Console.ReadKey(intercept: true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine();
                        Console.Write("Введите id монстра для удаления: ");
                        string idDel = Console.ReadLine().Trim();
                        if (int.TryParse(idDel, out int idD))
                            manager.DeleteById(idD);
                        else
                            Console.WriteLine("Неверные данные.");
                        PauseShort();
                        break;

                    case ConsoleKey.B:
                        return;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Неверный выбор.");
                        System.Threading.Thread.Sleep(400);
                        break;
                }
            }
        }

        // ---------- Просмотр ----------
        private void ViewMonstersMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Список монстров ===");
                Console.WriteLine("1) Показать краткую информацию обо всех монстрах");
                Console.WriteLine("2) Показать подробную информацию обо всех монстрах");
                Console.WriteLine("B) Назад");
                Console.WriteLine();
                Console.Write("Нажмите 1/2 или B: ");

                var key = Console.ReadKey(intercept: true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine();
                        manager.PrintAllShort();
                        Console.WriteLine();
                        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться...");
                        Console.ReadKey(intercept: true); // дождаться любой клавиши
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine();
                        manager.PrintAllDetailed();
                        Console.WriteLine();
                        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться...");
                        Console.ReadKey(intercept: true); // дождаться любой клавиши
                        break;

                    case ConsoleKey.B:
                        return;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Неверный выбор.");
                        System.Threading.Thread.Sleep(400);
                        break;
                }
            }
        }

        // Небольшая пауза, чтобы пользователь успел прочитать сообщение
        private void PauseShort()
        {
            System.Threading.Thread.Sleep(1500); // 1.5 секунды
        }
    }
}
