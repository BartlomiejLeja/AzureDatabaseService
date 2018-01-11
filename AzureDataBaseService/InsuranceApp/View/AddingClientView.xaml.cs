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

namespace InsuranceApp.View
{
    /// <summary>
    /// Interaction logic for AddingClientView.xaml
    /// </summary>
    public partial class AddingClientView : UserControl
    {
        public AddingClientView()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var restSharpHandler = new RestSharpHandler();
            //restSharpHandler.GetClientdata(20);
          //  restSharpHandler.RemoveClient(26);
           restSharpHandler.CreateClient(FirstName.Text,SecondName.Text, BirthDate.SelectedDate, Int32.Parse(PeselNumber.Text));
        //    FirstName.Text = null;
        //    SecondName.Text = null;
        //    BirthDate.SelectedDate = null;
        //    PeselNumber.Text = null;
        }
        }
}
