using InsuranceApp.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace InsuranceApp.View
{

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

            for (int i = 32; i < 60; i++)
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
