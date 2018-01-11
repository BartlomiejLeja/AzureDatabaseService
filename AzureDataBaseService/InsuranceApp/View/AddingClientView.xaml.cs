using System;
using System.Windows;
using System.Windows.Controls;

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

          restSharpHandler.CreateClient(FirstName.Text,SecondName.Text, BirthDate.SelectedDate, Int32.Parse(PeselNumber.Text));
        
        }
    }
}
