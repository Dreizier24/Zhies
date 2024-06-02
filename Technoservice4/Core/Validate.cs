using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Technoservice4.DbSingletone;

namespace Technoservice4.Core
{
    public class Validate
    {
        public User Valid(string login, string password)
        {
            var res = DbSingletone.DbSingletone.Db.User.FirstOrDefault(a => a.Login == login && a.Password == password);
            if (res != null) 
            {
                MessageBox.Show("Авторизация прошла успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                return res;
            }
            else
            {
                MessageBox.Show("Произошла ошибка авторизации", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
                return null;
            }
        }
    }
}
