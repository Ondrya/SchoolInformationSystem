using SchoolInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolInformationSystem.Actions
{
    public class WorkWithGroup
    {
        public static void ShowMenu(Session session)
        {
            Console.Clear();
            Console.WriteLine($"");
            Console.WriteLine($"1. Показать список учебных классов");
            Console.WriteLine($"2. Класс: найти");
            Console.WriteLine($"3. Класс: добавить");
            Console.WriteLine($"0. Назад");
            Console.Write($"Ваш выбор: ");
            while (true)
            {
                var input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        GroupAction.ShowAll(session);
                        break;
                    case '2':
                        GroupAction.Find(session);
                        break;
                    case '3':
                        GroupAction.Create(session);
                        break;
                    case '0':
                        MainAction.Do(session);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
