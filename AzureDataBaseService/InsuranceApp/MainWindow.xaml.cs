using InsuranceApp.Models;
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
            //var restSharpHandler = new RestSharpHandler();
            //RestData.Content= restSharpHandler.GetClientdata();
            var client = new Client();
            var clientData = new ClientData();
            client.FirstName = "BArtek";
            client.ClientData = clientData;
        }
    }
}
