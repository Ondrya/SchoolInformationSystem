﻿using System;
using System.Collections.Generic;

namespace SchoolInformationSystem.Models
{
    /// <summary>
    /// Учебный предмет
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// уникальный идентификатор предмета
        /// </summary>
        Guid Id { get; set; }
        /// <summary>
        /// Название предмета
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// список классов (цифр, в которых данный предмет доступен для преподавания)
        /// </summary>
        List<int> GroupRanges { get; set; }

        /// <summary>
        /// Конструктор для нового предмета
        /// </summary>
        /// <param name="name"></param>
        /// <param name="groupRanges"></param>
        public Subject(string name, List<int> groupRanges)
        {
            Id = Guid.NewGuid();
            Name = name;
            GroupRanges = groupRanges;
        }

        /// <summary>
        /// Конструктор для существующего класса
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="groupRanges"></param>
        public Subject(Guid id, string name, List<int> groupRanges)
        {
            Id = id;
            Name = name;
            GroupRanges = groupRanges;
        }
    }
}