using System;
using System.Collections.Generic;

namespace SchoolInformationSystem.Models
{
    /// <summary>
    /// Класс учеников
    /// </summary>
    public class Group
    {
        /// <summary>
        /// уникальный номер класса
        /// </summary>
        Guid Id { get; set; }
        /// <summary>
        /// цифра класса
        /// </summary>
        int Rang { get; set; }
        /// <summary>
        /// Буква класса
        /// </summary>
        char Letter { get; set; }
        /// <summary>
        /// Список учеников данного класса/группы
        /// </summary>
        List<int> Students { get; set; }

        /// <summary>
        /// Конструктор для нового класса
        /// </summary>
        /// <param name="rang"></param>
        /// <param name="letter"></param>
        /// <param name="students"></param>
        public Group(int rang, char letter, List<int> students)
        {
            Id = Guid.NewGuid();
            Rang = rang;
            Letter = letter;
            Students = students;
        }

        /// <summary>
        /// Конструктор для существующего класса
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rang"></param>
        /// <param name="letter"></param>
        /// <param name="students"></param>
        public Group(Guid id, int rang, char letter, List<int> students)
        {
            Id = id;
            Rang = rang;
            Letter = letter;
            Students = students;
        }
    }
}