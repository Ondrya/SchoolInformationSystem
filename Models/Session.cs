using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolInformationSystem.Models
{
    /// <summary>
    /// Текущее соединение
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Id авторизованного пользователя
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Роль авторизованного пользователя
        /// </summary>
        public Roles UserRole { get; set; }

        public Session(Guid userId, Roles userRole)
        {
            UserId = userId;
            UserRole = userRole;
        }

        public override string ToString()
        {
            return $"UserId: {UserId}; UserRole {UserRole}";
        }
    }
}
