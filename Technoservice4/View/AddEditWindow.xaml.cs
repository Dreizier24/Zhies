using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Technoservice4.DbSingletone;
using Technoservice4.ViewModel;

namespace Technoservice4.View
{
    /// <summary>
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        private Request _request;
        public AddEditWindow(User user, Request request)
        {
            InitializeComponent();
            comboBox.ItemsSource = DbSingletone.DbSingletone.Db.EquipmentType.ToList();
            foreach(var item in App.Current.Windows)
            {
                if(item is MainWindow)
                {
                    this.Owner = item as Window;
                }
            }
            if(request != null)
            {
                _request = request;
            }
            else
            {
                _request = new Request();
            }
            _request.StatusId = 1;
            _request.ClientId = user.UserId;
            _request.StartDate = DateTime.Now;
            this.DataContext = _request;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(var Db = new TecnoserviceEntities())
            {
                try
                {
                    Db.Request.AddOrUpdate(_request);
                    Db.SaveChanges();
                    (Owner as MainWindow).RefreshData();
                    Owner.Focus();
                    MessageBox.Show("Данные сохранены!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
        }
    }
}
