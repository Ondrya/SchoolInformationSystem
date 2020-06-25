using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolInformationSystem.Models
{
    /// <summary>
    /// Пункт меню
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Идентификатор пользователя, предмета, класса, оценки...
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Текст пункта меню
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Конструктор пункта меню
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Menu(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
