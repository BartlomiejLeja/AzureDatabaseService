using InsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logika interakcji dla klasy ModifyClientView.xaml
    /// </summary>
    public partial class ModifyClientView : UserControl
    {
        public ModifyClientView()
        {
            InitializeComponent();
            displayClients();
        }
        List<Client> items = new List<Client>();

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            RestSharpHandler handler = new RestSharpHandler();



            if (ModifyFirstName.Text != "" && ModifySecondName.Text != "" && ModifyBirthDate.SelectedDate != null && ModifyPeselNumber.Text != "")
            {
                handler.ModifyClient(int.Parse(IDToModify.Text));

                items.Clear();
                displayClients();
                ModifyFirstName.Clear();
                ModifyPeselNumber.Clear();
                ModifySecondName.Clear();
                IDToModify.Clear();
                ModifyBirthDate.SelectedDate = null;
            }
        }
        private void displayClients()
        {
            RestSharpHandler handler = new RestSharpHandler();
            Client tempClient = new Client();

            for (int i = 32; i < 35; i++)
            {
                tempClient = handler.GetClient(i);


                if (tempClient != null)
                {
                    items.Add(tempClient);
                }

            }
            clientsList.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(clientsList.ItemsSource);
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("SecondName", ListSortDirection.Ascending));

        }
    }
}
