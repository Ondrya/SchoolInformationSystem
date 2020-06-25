using System;
using System.Collections.Generic;
using System.Text;
using SchoolInformationSystem.Models;

namespace SchoolInformationSystem
{
    public class DbConnector
    {
        #region Считывание данных

        public static List<Admin> GetAdmins()
        {
            var res = new List<Admin>();
            res.Add(new Admin("admin", "admin", "Фамилия", "Имя", "Отчество", Convert.ToDateTime("1995/2/2")));
            return res;
        }

        /// <summary>
        /// Считать преподавателей из БД
        /// </summary>
        /// <returns></returns>
        public static List<Teacher> GetTeachers()
        {
            var res = new List<Teacher>();
            res.Add(new Teacher("t", "t", "Фамилия", "Имя", "Отчество", Convert.ToDateTime("1995/2/2"), null, null));
            return res;
        }

        /// <summary>
        /// Считать список учеников из БД
        /// </summary>
        /// <returns></returns>
        public static List<Student> GetStudents()
        {
            var res = new List<Student>();
            res.Add(new Student(Guid.NewGuid() ,"s", "s", "Фамилия", "Имя", "Отчество", Convert.ToDateTime("1995/2/2")));
            return res;
        }

        /// <summary>
        /// Считать список предметов из БД
        /// </summary>
        /// <returns></returns>
        public static List<Subject> GetSubjects()
        {
            return null;
        }

        /// <summary>
        /// Считать список классов из БД
        /// </summary>
        /// <returns></returns>
        public static List<Group> GetGroups()
        {
            return null;
        }
        #endregion
    }
}
