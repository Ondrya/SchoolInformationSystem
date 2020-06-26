using SchoolInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolInformationSystem.Actions
{
    public class StudentAction
    {
        /// <summary>
        /// Отобразить список учеников
        /// </summary>
        /// <param name="session"></param>
        /// <param name="search"></param>
        public static void ShowAll(Session session, string search = "")
        {
            Console.Clear();
            var items = new List<Student>();

            var groups = DbConnector.GetGroups().ToDictionary(g => g.Id);

            if (string.IsNullOrWhiteSpace(search))
            {
                items = DbConnector.GetStudents();
            }
            else
            {
                items = DbConnector.GetStudents().Where(i => i.Surname.ToUpper().Contains(search.ToUpper())).ToList();
            }
            var menuItems = items.Select(item => new Menu(item.Id, $"{item.Surname} {item.FirstName} {item.Patronymic}")).ToList();

            var ConsoleMenuResult = App.ConsoleMenu(menuItems);
            if (ConsoleMenuResult == Guid.Empty)
            {
                WorkWithStudent.ShowMenu(session);
            }
            else
            {
                StudentAction.Show(items.SingleOrDefault(i => i.Id == ConsoleMenuResult), session);
            }
        }

        /// <summary>
        /// Показать ученика
        /// </summary>
        /// <param name="item"></param>
        /// <param name="session"></param>
        public static void Show(Student item, Session session)
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
                var items = DbConnector.GetStudents();
                switch (input)
                {
                    case '1':
                        Console.WriteLine();
                        Console.WriteLine($"Редактирование: ");
                        var newSubject = Create();
                        //items.Where(s => s.Id == item.Id).ToList().ForEach(s => s.Name = newSubject.Name);
                        //items.Where(s => s.Id == item.Id).ToList().ForEach(s => s.GroupRanges = newSubject.GroupRanges);
                        DbConnector.SaveStudents(items);
                        ShowAll(session);
                        break;
                    case '2':
                        DbConnector.SaveStudents(items.Where(i => i.Id != item.Id).ToList());
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
        /// Поиск ученика по названию
        /// </summary>
        /// <param name="session"></param>
        public static void Find(Session session)
        {
            string search = "";
            while (string.IsNullOrWhiteSpace(search))
            {
                Console.Clear();
                Console.WriteLine($"=========");
                Console.Write($"Фамилия ученика: ");
                search = Console.ReadLine();
            }
            ShowAll(session, search);
        }

        /// <summary>
        /// Добавить новго ученика
        /// </summary>
        /// <param name="session"></param>
        public static void Create(Session session)
        {
            Console.Clear();
            Console.WriteLine($"Создание нового предмета");
            Student item = Create();

            var items = DbConnector.GetStudents();
            items.Add(item);
            DbConnector.SaveStudents(items);

            WorkWithStudent.ShowMenu(session);
        }

        /// <summary>
        /// Интерактивное создание объекта
        /// </summary>
        /// <returns></returns>
        private static Student Create()
        {
            var studentLogins = DbConnector.GetStudents().Select(s => s.Login.ToUpper()).ToList();
            var groups   = DbConnector.GetGroups();

            var group = Guid.Empty;
            var login = "";
            var password = "";
            var surname = "";
            var firstName = "";
            var patronomic = "";
            var dateOfBirth = DateTime.MinValue;

            // login
            while (string.IsNullOrWhiteSpace(login) || studentLogins.Contains(login.ToUpper()))
            {
                Console.Write($"Логин: ");
                try
                {
                    login = Console.ReadLine().Trim();
                }
                catch
                {
                    Console.WriteLine($"Неверный ввод!");
                }
            }
            // password
            while (string.IsNullOrWhiteSpace(password))
            {
                Console.Write($"Пароль: ");
                password = Console.ReadLine().Trim();
            }
            // surname
            while (string.IsNullOrWhiteSpace(surname))
            {
                Console.Write($"Фамилия: ");
                surname = Console.ReadLine().Trim();
            }
            // firstName
            while (string.IsNullOrWhiteSpace(firstName))
            {
                Console.Write($"Имя: ");
                firstName = Console.ReadLine().Trim();
            }
            // patronomic
            while (string.IsNullOrWhiteSpace(patronomic))
            {
                Console.Write($"Отчество: ");
                patronomic = Console.ReadLine().Trim();
            }
            // dateOfBirth
            while (dateOfBirth == DateTime.MinValue)
            {
                Console.Write($"Дата рождения в формате ГГГГ-ММ-ДД: ");
                try
                {
                    dateOfBirth = DateTime.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine($"Неверный ввод!");
                }
                
            }
            // group
            while (group == Guid.Empty)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"К какому классу привязать ученика: {surname} {firstName} {patronomic}");
                for (int i = 0; i < groups.Count; i++)
                {
                    Console.WriteLine($"{i+1} | {groups[i].Rang} {groups[i].Letter}");
                }
                Console.WriteLine();
                var selected = 0;
                while (true)
                {
                    Console.Write("Ваш выбор: ");
                    try
                    {
                        var s = int.Parse(Console.ReadLine());
                        if (s < 1 || s > groups.Count)
                        {
                            Console.WriteLine($"Неверный ввод!");
                        }
                        selected = s - 1;
                        break;
                    }
                    catch 
                    {
                        Console.WriteLine($"Неверный ввод!");
                    }
                }
                group = groups[selected].Id;
            }
            return new Student(group, login, password, surname, firstName, patronomic, dateOfBirth);
        }
    }
}
