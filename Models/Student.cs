﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolInformationSystem.Models
{
    /// <summary>
    /// Ученик
    /// </summary>
    public class Student : User
    {
        /// <summary>
        /// Класс, в котором состояит ученик
        /// </summary>
        public Guid Group { get; set; }

        public Student() { }

        /// <summary>
        /// Конструктор для создания нового
        /// </summary>
        /// <param name="group">идентификатор класса, учебной группы</param>
        public Student(
            Guid group, 
            string login, string password, 
            string surname, string firstName, string patronymic, 
            DateTime dateOfBirth,
            Roles role = Roles.Student)
            : base(login, password, surname, firstName, patronymic, dateOfBirth, role)
        {
            Group = group;
        }

        /// <summary>
        /// Конструктор для существующих студентов
        /// </summary>
        /// <param name="group"></param>
        /// <param name="id"></param>
        /// <param name="role"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="surname"></param>
        /// <param name="firstName"></param>
        /// <param name="patronymic"></param>
        /// <param name="dateCreation"></param>
        /// <param name="dateOfBirth"></param>
        public Student(
            Guid group, 
            Guid id, 
            string login, string password,
            string surname, string firstName, string patronymic,
            DateTime dateCreation,
            DateTime dateOfBirth,
            Roles role = Roles.Student)
            : base(id, login, password, surname, firstName, patronymic, dateCreation, dateOfBirth, role)
        {
            Group = group;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"\n\tId: {this.Id}");
            sb.Append($"\n\tФамилия:  {this.Surname}");
            sb.Append($"\n\tИмя:      {this.FirstName}");
            sb.Append($"\n\tОтчество: {this.Patronymic}");
            sb.Append($"\n\tЛогин:    {this.Login}");
            sb.Append($"\n\tПароль:   {this.Password}");
            sb.Append($"\n\tДата рождения: {this.DateOfBirth.ToString().Split(" ")[0]}"); //YYYY-MM-DD
            sb.Append($"\n\tДата создания: {this.DateCreation}");

            return sb.ToString();
        }
    }
}
