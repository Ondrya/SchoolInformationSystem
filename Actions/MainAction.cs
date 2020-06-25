using SchoolInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolInformationSystem.Actions
{
    public class MainAction
    {
        private static string divider = "==================================================";
        public static void Do(Session session) 
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"{divider}");
            Console.WriteLine($"Вы вошли как {session.UserRole}; Id: {session.UserId}");
            Console.WriteLine($"{divider}");
            Console.WriteLine($"");
            Console.WriteLine($"Выберите нужное действие");

            if (session.UserRole == Roles.Admin)
            {
                Console.Clear();
                //Console.WriteLine($"Действия администратора...");
                Console.WriteLine($"1. Преподаватели");
                Console.WriteLine($"2. Ученики");
                Console.WriteLine($"3. Предметы");
                Console.WriteLine($"4. Учебные классы");
                Console.WriteLine($"0. Выход");
                Console.WriteLine($"...");
                Console.Write($"Ваш выбор: ");
                while (true)
                {
                    var input = Console.ReadKey().KeyChar;
                    switch (input)
                    {
                        case '1':
                            WorkWithTeacher.ShowMenu(session);
                            break;
                        case '2':
                            WorkWithStudent.ShowMenu(session);
                            break;
                        case '3':
                            WorkWithSubject.ShowMenu(session);
                            break;
                        case '4':
                            WorkWithGroup.ShowMenu(session);
                            break;
                        case '0':
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                
            }
            //if (session.UserRole == Roles.Teacher)
            //{
            //    Console.WriteLine($"Действия преподавателя...");

            //    Console.WriteLine($"");
            //    Console.WriteLine($"1. Показать список доступных классов");
            //    Console.WriteLine($"1.1 Выбрать класс");
            //    Console.WriteLine($"1.2 Выбрать ученика");
            //    Console.WriteLine($"1.3 Оценка: поставить");
            //    Console.WriteLine($"1.4 Оценка: редактировать");
            //    Console.WriteLine($"1.5 Оценка: удалить");
            //}
            //if (session.UserRole == Roles.Student)
            //{
            //    Console.WriteLine($"Действия ученика...");

            //    Console.WriteLine($"");
            //    Console.WriteLine($"1. Показать дневник");
            //}

        }
    }
}
