using InsuranceApp.Models;
using InsuranceApp.ViewModels;
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
using System.ComponentModel;

namespace InsuranceApp
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddNewClientTab_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new AddingClientViewModel();
        }

        private void DisplayClientTab_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new DisplayClientViewModel();
        }
        
        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new DeleteClientViewModel();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ModifyClientViewModel();
        }
    }
}
