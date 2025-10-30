using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3_ConsoleGame
{
    internal class Menu
    {
        // Главное меню
        public void ShowMainMenu()
        {
            Console.Clear(); // очищаем консоль перед выводом
            Console.WriteLine("Welcome to My Diablo"); // приветственное сообщение. TODO: показывать толкьо при первом запуске
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

        public void HandleMainMenuChoice(string input) 
        { 
            switch(input)
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
                    break;
            }
        }

        // Менюшки второго уровня
        public void ShowSummonMenu()
        {

        }

        public void ShowAttackMenu()
        {

        }

        public void ShowUpgradeMenu()
        {

        }

        public void ShowDestroyMenu()
        {

        }

        public void ViewMonstersMenu()
        {

        }

         