using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Technoservice4.DbSingletone;
using Technoservice4.View;
using Technoservice4.ViewModel;

namespace Technoservice4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User _user;
        public MainWindow(User user)
        {
            InitializeComponent();
            this.DataContext = new MainWindowVIewModel();
            _user = user;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowVIewModel).DeleteRequest();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var wind = new AddEditWindow(_user, null);
            wind.ShowDialog();
        }

        public void RefreshData()
        {
            (DataContext as MainWindowVIewModel).LoadData();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            var wind = new AddEditWindow(_user, (DataContext as MainWindowVIewModel).SelectedRequest);
            wind.ShowDialog();
        }
    }
}
