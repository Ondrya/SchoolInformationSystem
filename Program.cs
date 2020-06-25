using SchoolInformationSystem.Actions;
using SchoolInformationSystem.Models;
using System;
using System.Net.Security;

namespace SchoolInformationSystem
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // авторизация пользователя
            var session = new Session(Guid.Empty, Roles.Student);
            while (session.UserId == Guid.Empty)
            {
                session = Auth.Do();
            }

            // тело программы
            while (true)
            {
                MainAction.Do(session);

                Console.WriteLine($"");
                Console.Write($"Выйти (y) ?: ");
                if (Console.ReadLine().ToUpper() == "Y") 
                { 
                    break; 
                }
            }
        }
    }
}
