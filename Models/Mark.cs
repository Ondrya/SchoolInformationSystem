using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolInformationSystem.Models
{

    public class Mark
    {
        /// <summary>
        /// Идентификатор оценки
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Ученик, которому поставлена оценка
        /// </summary>
        public Guid Studet { get; set; }
        /// <summary>
        /// Предмет, по которому выставлена оценка
        /// </summary>
        public Guid Subject { get; set; }
        /// <summary>
        /// Оценка
        /// </summary>
        public short Value { get; set; }
        /// <summary>
        /// Дата выставления оценки
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Конструктор для новой оценки
        /// </summary>
        /// <param name="studet"></param>
        /// <param name="subject"></param>
        /// <param name="value"></param>
        public Mark(Guid studet, Guid subject, short value)
        {
            Studet = studet;
            Subject = subject;
            Value = value;
            Id = Guid.NewGuid();
            DateCreation = DateTime.Now;
        }

        /// <summary>
        /// Конструктор для существующей оценки
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studet"></param>
        /// <param name="subject"></param>
        /// <param name="value"></param>
        /// <param name="dateCreation"></param>
        public Mark(Guid id, Guid studet, Guid subject, short value, DateTime dateCreation)
        {
            Id = id;
            Studet = studet;
            Subject = subject;
            Value = value;
            DateCreation = dateCreation;
        }
    }
}
