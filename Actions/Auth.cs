using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchoolInformationSystem.Models;

namespace SchoolInformationSystem.Actions
{
    public class Auth
    {
        /// <summary>
        /// Ищем пользователя с заданными логином и паролем
        /// </summary>
        /// <returns></returns>
        public static Session Do()
        {
#if DEBUG 
            Console.WriteLine($"Данные для тестового входа");
            Console.WriteLine($" - Админ        : login: admin; password: admin");
            Console.WriteLine($" - Преподаватель: login:     s; password:     s");
            Console.WriteLine($" - Ученик       : login:     t; password:     t");
            Console.WriteLine($"");
            Console.WriteLine($"");
#endif

            var session  = new Session(Guid.Empty, Roles.Student);
            var login    = string.Empty;
            var password = string.Empty;

#if RELEASE
            Console.Clear();
#endif

            Console.WriteLine($"Авторизация");
            while (string.IsNullOrWhiteSpace(login))
            {
                Console.Write($"Логин : ");
                login = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(password))
            {
                Console.Write($"Пароль: ");
                password = Console.ReadLine();
            }

            var sessionTeacher = DbConnector
                .GetTeachers()
                .Where(t => t.Login == login && t.Password == password)
                .Select(u => new Session(u.Id, u.Role)).FirstOrDefault();

            var sessionStudent = DbConnector
                .GetStudents()
                .Where(t => t.Login == login && t.Password == password)
                .Select(u => new Session(u.Id, u.Role)).FirstOrDefault();

            var sessionAdmin = DbConnector
                .GetAdmins()
                .Where(t => t.Login == login && t.Password == password)
                .Select(u => new Session(u.Id, u.Role)).FirstOrDefault();

            if (sessionTeacher != null)
            {
                session.UserId   = sessionTeacher.UserId;
                session.UserRole = sessionTeacher.UserRole;
            }

            if (sessionStudent != null)
            {
                session.UserId = sessionStudent.UserId;
                session.UserRole = sessionStudent.UserRole;
            }

            if (sessionAdmin != null)
            {
                session.UserId = sessionAdmin.UserId;
                session.UserRole = sessionAdmin.UserRole;
            }

            return session;
        }
    }
}
