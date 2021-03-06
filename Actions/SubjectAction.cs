﻿using SchoolInformationSystem.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SchoolInformationSystem.Actions
{
    public class SubjectAction
    {
        /// <summary>
        /// Показать все предметы с навигацией
        /// </summary>
        /// <param name="session"></param>
        public static void ShowAll(Session session, string search = "")
        {
            Console.Clear();
            var subjects = new List<Subject>();


            if (string.IsNullOrWhiteSpace(search))
            {
                subjects = DbConnector.GetSubjects();
            }
            else
            {
                subjects = DbConnector.GetSubjects().Where(i => i.Name.ToUpper().Contains(search.ToUpper())).ToList();
            }
            var menuItems = subjects.Select(item => new Menu(item.Id, item.Name)).ToList();

            var ConsoleMenuResult = App.ConsoleMenu(menuItems);
            if (ConsoleMenuResult == Guid.Empty)
            {
                WorkWithSubject.ShowMenu(session);
            }
            else
            {
                SubjectAction.Show(subjects.SingleOrDefault(i => i.Id == ConsoleMenuResult), session);
            }
        }

        /// <summary>
        /// Отобразить предмет
        /// </summary>
        /// <param name="item"></param>
        /// <param name="session"></param>
        public static void Show(Subject item, Session session)
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
                var items = DbConnector.GetSubjects();
                switch (input)
                {
                    case '1':
                        Console.WriteLine();
                        Console.WriteLine($"Редактирование: ");
                        var newSubject = Create();
                        items.Where(s => s.Id == item.Id).ToList().ForEach(s => s.Name = newSubject.Name);
                        items.Where(s => s.Id == item.Id).ToList().ForEach(s => s.GroupRanges = newSubject.GroupRanges);
                        DbConnector.SaveSubjects(items);
                        ShowAll(session);
                        break;
                    case '2':
                        DbConnector.SaveSubjects(items.Where(i => i.Id != item.Id).ToList());
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
        /// Поиск предмета по названию
        /// </summary>
        /// <param name="session"></param>
        public static void Find(Session session)
        {
            string search = "";
            while (string.IsNullOrWhiteSpace(search))
            {
                Console.Clear();
                Console.WriteLine($"=========");
                Console.Write($"Название предмета: ");
                search = Console.ReadLine();
            }
            ShowAll(session, search);
        }

        /// <summary>
        /// Создать новый предмет
        /// </summary>
        /// <param name="session"></param>
        public static void Create(Session session)
        {
            Console.Clear();
            Console.WriteLine($"Создание нового предмета");
            Subject item = Create();

            var items = DbConnector.GetSubjects();
            items.Add(item);
            DbConnector.SaveSubjects(items);

            WorkWithSubject.ShowMenu(session);
        }

        /// <summary>
        /// Интерактивное создание объекта
        /// </summary>
        /// <returns></returns>
        private static Subject Create()
        {
            var name = String.Empty;
            var groupsRange = new List<int>();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write($"Название предмета: ");
                name = Console.ReadLine();
            }

            while (groupsRange.Count == 0)
            {
                Console.Write($"В каких классах преподаётся (введите числа через пробел)? : ");
                try
                {
                    groupsRange = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();
                }
                catch
                {
                    Console.WriteLine($"Неверный ввод!");
                }
            }
            return new Subject(name, groupsRange);
        }
    }
}
