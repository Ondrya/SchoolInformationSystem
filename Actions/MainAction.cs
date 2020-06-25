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
                Console.WriteLine($"Действия администратора...");

                Console.WriteLine($"");
                Console.WriteLine($"1. Показать список преподавателей");
                Console.WriteLine($"1.1 Преподаватель: найти");
                Console.WriteLine($"1.2 Преподаватель: добавить");
                Console.WriteLine($"1.3 Преподаватель: редактировать");
                Console.WriteLine($"1.4 Преподаватель: удалить");

                Console.WriteLine($"");
                Console.WriteLine($"2. Показать список учеников");
                Console.WriteLine($"2.1 Ученик: найти");
                Console.WriteLine($"2.2 Ученик: добавить");
                Console.WriteLine($"2.3 Ученик: редактировать");
                Console.WriteLine($"2.4 Ученик: удалить");

                Console.WriteLine($"");
                Console.WriteLine($"3. Показать список предметов");
                Console.WriteLine($"3.1 Предмет: найти");
                Console.WriteLine($"3.2 Предмет: добавить");
                Console.WriteLine($"3.3 Предмет: редактировать");
                Console.WriteLine($"3.4 Предмет: удалить");

                Console.WriteLine($"");
                Console.WriteLine($"4. Показать список учебных классов");
                Console.WriteLine($"3.1 Класс: найти");
                Console.WriteLine($"3.2 Класс: добавить");
                Console.WriteLine($"3.3 Класс: редактировать");
                Console.WriteLine($"3.4 Класс: удалить");
            }
            if (session.UserRole == Roles.Teacher)
            {
                Console.WriteLine($"Действия преподавателя...");

                Console.WriteLine($"");
                Console.WriteLine($"1. Показать список доступных классов");
                Console.WriteLine($"1.1 Выбрать класс");
                Console.WriteLine($"1.2 Выбрать ученика");
                Console.WriteLine($"1.3 Оценка: поставить");
                Console.WriteLine($"1.4 Оценка: редактировать");
                Console.WriteLine($"1.5 Оценка: удалить");
            }
            if (session.UserRole == Roles.Student)
            {
                Console.WriteLine($"Действия ученика...");

                Console.WriteLine($"");
                Console.WriteLine($"1. Показать дневник");
            }

        }
    }
}
