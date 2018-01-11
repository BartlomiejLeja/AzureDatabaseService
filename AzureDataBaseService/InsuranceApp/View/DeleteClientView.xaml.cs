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
    /// Logika interakcji dla klasy DeleteClientView.xaml
    /// </summary>
    public partial class DeleteClientView : UserControl
    {
        public DeleteClientView()
        {
            InitializeComponent();
            displayClients();

        }
        List<Client> items = new List<Client>();

        private void DeleteClient(object sender, RoutedEventArgs e)
        {
            RestSharpHandler handler = new RestSharpHandler();


            if (IDToRemove.Text != "" )
            { 
            handler.RemoveClient(int.Parse(IDToRemove.Text));

            items.Clear();
            displayClients();
            IDToRemove.Clear();
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
