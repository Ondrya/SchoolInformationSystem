using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolInformationSystem.Models
{
    /// <summary>
    /// Преподаватель
    /// </summary>
    public class Teacher : User
    {
        /// <summary>
        /// Список предметов, которые может вести преподаватель
        /// </summary>
        List<Subject> Subjects { get; set; }
        /// <summary>
        /// Классы, в которых может преподавать учитель
        /// </summary>
        List<Group> Groups { get; set; }

        /// <summary>
        /// Конструктор для новых пользователей
        /// </summary>
        /// <param name="role"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="surname"></param>
        /// <param name="firstName"></param>
        /// <param name="patronymic"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="subjects"></param>
        /// <param name="groups"></param>
        public Teacher(
            string login, string password,
            string surname, string firstName, string patronymic,
            DateTime dateOfBirth,
            List<Subject> subjects, List<Group> groups,
            Roles role = Roles.Teacher) 
            : base(login, password, surname, firstName, patronymic, dateOfBirth, role)
        {
            Subjects = subjects;
            Groups = groups;
        }

        /// <summary>
        /// Конструктор для существующих пользователей
        /// </summary>
        /// <param name="id"></param>
        /// <param name="role"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="surname"></param>
        /// <param name="firstName"></param>
        /// <param name="patronymic"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="subjects"></param>
        /// <param name="groups"></param>
        public Teacher(
            Guid id,
            string login, string password,
            string surname, string firstName, string patronymic,
            DateTime dateCreation,
            DateTime dateOfBirth,
            List<Subject> subjects, List<Group> groups,
            Roles role = Roles.Teacher)
            : base(id, login, password, surname, firstName, patronymic, dateCreation, dateOfBirth, role)
        {
            Subjects = subjects;
            Groups = groups;
        }
    }
}
