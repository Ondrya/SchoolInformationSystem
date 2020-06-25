using SchoolInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolInformationSystem.Actions
{
    public class WorkWithTeacher
    {
        public static void ShowMenu(Session session)
        {
            Console.Clear();
            Console.WriteLine($"");
            Console.WriteLine($"1. Показать список преподавателей");
            Console.WriteLine($"1.1 Преподаватель: найти");
            Console.WriteLine($"1.2 Преподаватель: добавить");
            Console.WriteLine($"1.3 Преподаватель: редактировать");
            Console.WriteLine($"1.4 Преподаватель: удалить");
        }
    }
}
