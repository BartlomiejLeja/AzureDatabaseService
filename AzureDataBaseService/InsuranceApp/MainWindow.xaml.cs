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
using InsuranceApp.Models;

namespace InsuranceApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void testList()
        {
            var client = new Client();
            client.FirstName = "Tomek";
            client.SecondName = "atomek";
            string Pesel = "123456789";

            List<Client> items = new List<Client>();
            items.Add(new Client() { FirstName= "John Doe", SecondName = "Kowalski"});
            items.Add(client);
          
            clientsList.ItemsSource = items;




        }


    }
}
