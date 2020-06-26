using SchoolInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolInformationSystem.Actions
{
    public class WorkWithStudent
    {
        public static void ShowMenu(Session session)
        {
            Console.Clear();
            Console.WriteLine($"");
            Console.WriteLine($"1. Показать список учеников");
            Console.WriteLine($"2. Ученик: найти");
            Console.WriteLine($"3. Ученик: добавить");
            Console.WriteLine($"0. Назад");
            Console.Write($"Ваш выбор: ");
            while (true)
            {
                var input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        StudentAction.ShowAll(session);
                        break;
                    case '2':
                        StudentAction.Find(session);
                        break;
                    case '3':
                        StudentAction.Create(session);
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
