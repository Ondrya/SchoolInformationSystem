using SchoolInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.WriteLine();
                Console.WriteLine($"1. Ученики");
                Console.WriteLine($"2. Предметы");
                Console.WriteLine($"3. Учебные классы");
                Console.WriteLine($"0. Выход");
                Console.WriteLine($"...");
                Console.Write($"Ваш выбор: ");
                while (true)
                {
                    var input = Console.ReadKey().KeyChar;
                    switch (input)
                    {
                        case '1':
                            WorkWithStudent.ShowMenu(session);
                            break;
                        case '2':
                            WorkWithSubject.ShowMenu(session);
                            break;
                        case '3':
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

            if (session.UserRole == Roles.Student)
            {
                var student = DbConnector.GetStudents().SingleOrDefault(s => s.Id == session.UserId);
                Console.WriteLine(student);

                Console.WriteLine($"\n\n\nДля выхода нажмите любую клавишу");
                Console.ReadKey();
                Environment.Exit(0);
            }

        }
    }
}
