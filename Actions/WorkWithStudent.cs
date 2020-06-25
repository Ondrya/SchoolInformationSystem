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
            Console.WriteLine($"2. Показать список учеников");
            Console.WriteLine($"2.1 Ученик: найти");
            Console.WriteLine($"2.2 Ученик: добавить");
            Console.WriteLine($"2.3 Ученик: редактировать");
            Console.WriteLine($"2.4 Ученик: удалить");
        }
    }
}
