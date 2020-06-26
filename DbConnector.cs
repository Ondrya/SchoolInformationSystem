using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using SchoolInformationSystem.Models;

namespace SchoolInformationSystem
{
    public class DbConnector
    {
        #region Перечень файлов

        private static string path = Directory.GetCurrentDirectory();

        private static string UserAdmins    = $"{path}\\Data\\UserAdmins.txt";
        private static string UserTeachers  = $"{path}\\Data\\UserTeachers.txt";
        private static string UserStudents  = $"{path}\\Data\\UserStudents.txt";
        private static string Groups        = $"{path}\\Data\\Groups.txt";
        private static string Subjects      = $"{path}\\Data\\Subjects.txt";
        private static string Marks         = $"{path}\\Data\\Marks.txt";
        #endregion

        #region Работа с файлами
        /// <summary>
        /// Прочитать текст из файла
        /// </summary>
        /// <param name="path">куда пишем</param>
        /// <returns></returns>
        internal static string FileRead(string path)
        {
            try
            {
                string result = String.Empty;
                using (var sr = new StreamReader(path))
                {
                    result = sr.ReadToEnd();
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Запись текста в файл
        /// </summary>
        /// <param name="path">куда пишем</param>
        /// <param name="data">что пишем</param>
        internal static void FileWrite(string path, string data)
        {
            try
            {
                using (var sw = new StreamWriter(path, false))
                {
                    sw.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            Console.WriteLine($"/*****************************/");
            Console.WriteLine($"/** Запись данных завершена **/");
            Console.WriteLine($"/*****************************/");
        }
        #endregion

        #region Считывание данных

        /// <summary>
        /// Считать список администраторов
        /// </summary>
        /// <returns></returns>
        public static List<Admin> GetAdmins()
        {
            var json = FileRead(UserAdmins);
            var res = new List<Admin>();
            var defaultItem = new Admin("admin", "admin", "Фамилия", "Имя", "Отчество", Convert.ToDateTime("1900/1/1"));
            if (json == "")
            {
                res.Add(defaultItem);
            }
            else
            {
                var temp = JsonConvert.DeserializeObject<List<Admin>>(json);
                if (temp.Count == 0) res.Union(temp); 
            }
            return res;
        }

        /// <summary>
        /// Считать преподавателей из БД
        /// </summary>
        /// <returns></returns>
        public static List<Teacher> GetTeachers()
        {
            var json = FileRead(UserAdmins);
            var res = new List<Teacher>();
            var defaultItem = new Teacher("t", "t", "Фамилия", "Имя", "Отчество", Convert.ToDateTime("1995/2/2"), null, null);
            if (json == "")
            {
                res.Add(defaultItem);
            }
            else
            {
                var temp = JsonConvert.DeserializeObject<List<Teacher>>(json);
                if (temp.Count == 0) res.Union(temp);
            }
            return res;
        }

        /// <summary>
        /// Считать список учеников из БД
        /// </summary>
        /// <returns></returns>
        public static List<Student> GetStudents()
        {
            var json = FileRead(UserStudents);
            return json != "" ? JsonConvert.DeserializeObject<List<Student>>(json) : new List<Student>();
        }

        /// <summary>
        /// Считать список предметов из БД
        /// </summary>
        /// <returns></returns>
        public static List<Subject> GetSubjects()
        {
            var json = FileRead(Subjects);
            return json != "" ? JsonConvert.DeserializeObject<List<Subject>>(json) : new List<Subject>();
        }

        /// <summary>
        /// Считать список классов из БД
        /// </summary>
        /// <returns></returns>
        public static List<Group> GetGroups()
        {
            var json = FileRead(Groups);
            return json != "" ? JsonConvert.DeserializeObject<List<Group>>(json) : new List<Group>();
        }
        #endregion

        #region Запись данных

        /// <summary>
        /// Сохранить учебные классы
        /// </summary>
        /// <param name="items"></param>
        public static void SaveGroups(List<Group> items)
        {
            var json = JsonConvert.SerializeObject(items);
            try
            {
                FileWrite(Groups, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        
        /// <summary>
        /// Сохранить оценки
        /// </summary>
        /// <param name="items"></param>
        public static void SaveMarks(List<Mark> items)
        {
            var json = JsonConvert.SerializeObject(items);
            try
            {
                FileWrite(Marks, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        
        /// <summary>
        /// Сохранить предметы
        /// </summary>
        /// <param name="items"></param>
        public static void SaveSubjects(List<Subject> items)
        {
            var json = JsonConvert.SerializeObject(items);
            try
            {
                FileWrite(Subjects, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Созранить преподавателей
        /// </summary>
        /// <param name="items"></param>
        public static void SaveTeachers(List<Teacher> items)
        {
            var json = JsonConvert.SerializeObject(items);
            try
            {
                FileWrite(UserTeachers, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Сохранить учеников
        /// </summary>
        /// <param name="items"></param>
        public static void SaveStudents(List<Student> items)
        {
            var json = JsonConvert.SerializeObject(items);
            try
            {
                FileWrite(UserStudents, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion
    }
}
