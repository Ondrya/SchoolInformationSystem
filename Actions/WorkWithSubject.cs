using SchoolInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolInformationSystem.Actions
{
    public class WorkWithSubject
    {
        public static void ShowMenu(Session session)
        {
            Console.Clear();
            Console.WriteLine($"");
            Console.WriteLine($"1. Показать список предметов");
            Console.WriteLine($"2. Предмет: найти");
            Console.WriteLine($"3. Предмет: добавить");
            Console.WriteLine($"0. Назад");
            Console.WriteLine($"...");
            Console.Write($"Ваш выбор: ");
            while (true)
            {
                var input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        SubjectAction.ShowAll(session);
                        break;
                    case '2':
                        SubjectAction.Find(session);
                        break;
                    case '3':
                        SubjectAction.Create(session);
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
