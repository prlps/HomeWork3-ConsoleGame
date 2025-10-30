namespace HomeWork3_ConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Menu menu = new Menu();

            while (true)
            {
                menu.ShowMainMenu(); // вывод меню
                string choice = Console.ReadLine().Trim().ToLower(); // считываем ввод

                if (choice == "q") break; // выход

                menu.HandleMainMenuChoice(choice); // обрабатываем выбор
            }


        }
    }
}
