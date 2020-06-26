using SchoolInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolInformationSystem.Actions
{
    public class GroupAction
    {
        /// <summary>
        /// Показать все классы с навигацией, поиск по цифре класса опционно
        /// </summary>
        /// <param name="session"></param>
        /// <param name="search"></param>
        public static void ShowAll(Session session, string search = "")
        {
            Console.Clear();
            var groups = new List<Group>();


            if (string.IsNullOrWhiteSpace(search))
            {
                groups = DbConnector.GetGroups();
            }
            else
            {
                groups = DbConnector.GetGroups().Where(i => i.Rang.ToString().Contains(search)).ToList();
            }
            var menuItems = groups.Select(item => new Menu(item.Id, $"{item.Rang} {item.Letter}")).ToList();

            var ConsoleMenuResult = App.ConsoleMenu(menuItems);
            if (ConsoleMenuResult == Guid.Empty)
            {
                WorkWithGroup.ShowMenu(session);
            }
            else
            {
                GroupAction.Show(groups.SingleOrDefault(i => i.Id == ConsoleMenuResult), session);
            }
        }

        /// <summary>
        /// Отобразить предмет
        /// </summary>
        /// <param name="item"></param>
        /// <param name="session"></param>
        public static void Show(Group item, Session session)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(item);
                Console.WriteLine();
                Console.WriteLine($"=========");
                Console.WriteLine($"1. Редактировать");
                Console.WriteLine($"2. Удалить");
                Console.WriteLine($"3. Назад");
                Console.WriteLine($"");
                Console.Write($"Ваш выбор: ");
                var input = Console.ReadKey().KeyChar;
                var items = DbConnector.GetGroups();
                switch (input)
                {
                    case '1':
                        Console.WriteLine();
                        Console.WriteLine($"Редактирование: ");
                        var newItem = Create();
                        items.Where(s => s.Id == item.Id).ToList().ForEach(s => s.Letter = newItem.Letter);
                        items.Where(s => s.Id == item.Id).ToList().ForEach(s => s.Rang = newItem.Rang);
                        DbConnector.SaveGroups(items);
                        ShowAll(session);
                        break;
                    case '2':
                        DbConnector.SaveGroups(items.Where(i => i.Id != item.Id).ToList());
                        ShowAll(session);
                        break;
                    case '3':
                        ShowAll(session);
                        break;
                    default:
                        break;
                }
            }

        }

        /// <summary>
        /// Поиск класса по цифре класса
        /// </summary>
        /// <param name="session"></param>
        public static void Find(Session session)
        {
            string search = "";
            while (string.IsNullOrWhiteSpace(search))
            {
                Console.Clear();
                Console.WriteLine($"=========");
                Console.Write($"Цифра в названии класса: ");
                search = Console.ReadLine();
            }
            ShowAll(session, search);
        }

        /// <summary>
        /// Создать новый класс
        /// </summary>
        /// <param name="session"></param>
        public static void Create(Session session)
        {
            Console.Clear();
            Console.WriteLine($"Создание нового класса");
            Group item = Create();

            var items = DbConnector.GetGroups();
            items.Add(item);
            DbConnector.SaveGroups(items);

            WorkWithGroup.ShowMenu(session);
        }

        /// <summary>
        /// Интерактивное создание объекта
        /// </summary>
        /// <returns></returns>
        private static Group Create()
        {
            var rang = 0;
            var letter = ' ';
            var groupsRange = new List<int>();

            while ( rang == 0 )
            {
                Console.Write($"Номер класса: ");
                try
                {
                    rang = int.Parse(Console.ReadLine());
                }
                catch 
                {
                    Console.WriteLine($"Неверный ввод!");
                }  
            }

            while (letter == ' ')
            {
                Console.Write($"Буква класса: ");
                try
                {
                    letter = Console.ReadLine()[0];
                }
                catch 
                {
                    Console.WriteLine($"Неверный ввод!");
                }
            }
            return new Group(rang, letter);
        }
    }
}
