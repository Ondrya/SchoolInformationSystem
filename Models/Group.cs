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
        public Guid Id { get; set; }
        /// <summary>
        /// цифра класса
        /// </summary>
        public int Rang { get; set; }
        /// <summary>
        /// Буква класса
        /// </summary>
        public char Letter { get; set; }

        public Group() { }

        /// <summary>
        /// Конструктор для нового класса
        /// </summary>
        /// <param name="rang"></param>
        /// <param name="letter"></param>
        public Group(int rang, char letter)
        {
            Id = Guid.NewGuid();
            Rang = rang;
            Letter = letter;
        }

        /// <summary>
        /// Конструктор для существующего класса
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rang"></param>
        /// <param name="letter"></param>
        public Group(Guid id, int rang, char letter)
        {
            Id = id;
            Rang = rang;
            Letter = letter;
        }

        public override string ToString()
        {
            return $"\n\tId: {Id}\n\tНомер класса: {Rang}\n\tБуква класса: {Letter}";
        }
    }
}