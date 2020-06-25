using SchoolInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolInformationSystem
{
    public class App
    {
        /// <summary>
        /// Навигация по меню
        /// </summary>
        /// <param name="items"></param>
        /// <returns>Guid выбранного пункта или пустой Guid</returns>
        public static Guid ConsoleMenu(List<Menu> items)
        {
            int index = 0;
            while (true)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.ForegroundColor = i == index ? ConsoleColor.Green : ConsoleColor.White;
                    Console.WriteLine($"{items[i].Name}");
                    Console.ResetColor();
                }

                ConsoleKeyInfo ckey = Console.ReadKey();
                Console.Clear();
                Console.CursorVisible = false;
                switch (ckey.Key)
                {
                    case ConsoleKey.DownArrow:
                        index++;
                        if (index == items.Count) index = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        index--;
                        if (index == -1) index = items.Count;
                        break;
                    case ConsoleKey.Escape:
                        return Guid.Empty;
                    case ConsoleKey.Enter:
                        return items[index].Id;
                    default:
                        break;
                }
            }
        }
    }
}
