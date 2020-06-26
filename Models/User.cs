using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolInformationSystem.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Роль
        /// </summary>
        public Roles Role { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Дата добавления пользователя
        /// </summary>
        public DateTime DateCreation { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        public User() { }

        /// <summary>
        /// Конструктор при создании
        /// </summary>
        /// <param name="role"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="surname"></param>
        /// <param name="firstName"></param>
        /// <param name="patronymic"></param>
        /// <param name="dateOfBirth"></param>
        public User(
            string login, string password, 
            string surname, string firstName, string patronymic, 
            DateTime dateOfBirth,
            Roles role)
        {
            Id = Guid.NewGuid();
            Role = role;
            Surname = surname;
            Login = login;
            Password = password;
            FirstName = firstName;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            DateCreation = DateTime.Now;
        }

        /// <summary>
        /// Конструктор для существующей записи
        /// </summary>
        /// <param name="id"></param>
        /// <param name="role"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="surname"></param>
        /// <param name="firstName"></param>
        /// <param name="patronymic"></param>
        /// <param name="dateCreation"></param>
        /// <param name="dateOfBirth"></param>
        public User(
            Guid id, 
            string login, string password, 
            string surname, string firstName, string patronymic, 
            DateTime dateCreation, DateTime dateOfBirth,
            Roles role)
        {
            Id = id;
            Role = role;
            Surname = surname;
            Login = login;
            Password = password;
            FirstName = firstName;
            Patronymic = patronymic;
            DateCreation = dateCreation;
            DateOfBirth = dateOfBirth;
        }
    }
}
