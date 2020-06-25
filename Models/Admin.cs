using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolInformationSystem.Models
{
    public class Admin : User
    {
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
        public Admin(
            string login, string password,
            string surname, string firstName, string patronymic,
            DateTime dateOfBirth,
            Roles role = Roles.Admin)
            : base(login, password, surname, firstName, patronymic, dateOfBirth, role)
        {
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
        public Admin(
            Guid id,
            string login, string password,
            string surname, string firstName, string patronymic,
            DateTime dateCreation,
            DateTime dateOfBirth,
            Roles role = Roles.Admin)
            : base(id, login, password, surname, firstName, patronymic, dateCreation, dateOfBirth, role)
        {
        }
    }
}
