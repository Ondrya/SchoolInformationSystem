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
            Console.WriteLine($"4. Показать список учебных классов");
            Console.WriteLine($"3.1 Класс: найти");
            Console.WriteLine($"3.2 Класс: добавить");
            Console.WriteLine($"3.3 Класс: редактировать");
            Console.WriteLine($"3.4 Класс: удалить");
        }
    }
}
