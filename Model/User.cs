using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace AVT241LentaNovostey.Model
{
    public class User
    {
        private string login;
        private string password;
        private bool isAdmin;

        public string Login
        {
            get { return login; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Логин пользователя не может быть пустым!");
                }
                else if (!Regex.IsMatch(value, @"^[a-zA-Z0-9]+$"))
                {
                    throw new ArgumentException("Логин пользователя должен содержать только символы латиницы и цифры!");
                }
                else
                {
                    login = value;
                }
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Пароль пользователя не может быть пустым!");
                }
                else if (!Regex.IsMatch(value, @"^[a-zA-Z0-9]+$"))
                {
                    throw new ArgumentException("Пароль пользователя должен содержать только символы латиницы и цифры!");
                }
                else
                {
                    password = value;
                }
            }
        }
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }
    }
}
