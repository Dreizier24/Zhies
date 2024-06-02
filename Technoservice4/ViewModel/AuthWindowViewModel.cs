using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Technoservice4.Core;
using Technoservice4.View;

namespace Technoservice4.ViewModel
{
    public class AuthWindowViewModel:BaseViewModel
    {
        private string _login;
        private string _password;

        public string Login
        {
            get => _login; 
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public void Check()
        {
            var valid = new Validate();
            var res = valid.Valid(_login, _password);
            if(res != null)
            {
                var wind = new MainWindow(res);
                wind.Show();
                foreach(Window window in App.Current.Windows)
                {
                    if(window is AuthWindow)
                    {
                        window.Close();
                    }
                }
            }
        }
    }
}
