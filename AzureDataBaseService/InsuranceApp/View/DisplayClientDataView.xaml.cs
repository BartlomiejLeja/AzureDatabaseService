using InsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace InsuranceApp.View
{
    public partial class DisplayClientDataView : UserControl
    {
        List<Client> items = new List<Client>();

        public DisplayClientDataView()
        {
            InitializeComponent();
            displayClients();
        }

        private void displayClients()
        {
            RestSharpHandler handler = new RestSharpHandler();
            Client tempClient = new Client();

            for(int i =32; i< 60; i++)
            {
                tempClient = handler.GetClient(i);
                                
                if(tempClient != null)
                {
                    items.Add(tempClient);
                }

            }
            clientsList.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(clientsList.ItemsSource);
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("SecondName", ListSortDirection.Ascending));

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = sender as ListView;

            Client tempClient = (Client)listView.SelectedItems[0];
            
            if (tempClient.ClientData == null)
            {
                RestData.Document.Blocks.Clear();
                RestData.Document.Blocks.Add(new Paragraph(new Run("No data to display.")));
            }

            else
            {
                RestData.Document.Blocks.Clear();
                RestData.Document.Blocks.Add(new Paragraph(new Run("Imię: " + tempClient.FirstName +
                    "\nNazwisko: " + tempClient.SecondName +
                    "\nData urodzenia: " + tempClient.ClientData.BirthDate +
                    "\nAdres: " + tempClient.ClientData.Adress +
                    "\nPesel: " + tempClient.ClientData.PeselNumber)));



                if(tempClient.Discount!=null)
                 RestData.Document.Blocks.Add(new Paragraph(new Run("Zniżka: " + tempClient.Discount.ValueOfDiscount + "%")));
            }

            String insurance = "";

        }

        private void testList()
        {

            var client = new Client();
            client.FirstName = "Tomasz";
            client.SecondName = "Lenart";
       
            ClientData exampleClientData = new ClientData();
            exampleClientData.Adress = "Wolska 25";
            exampleClientData.PeselNumber = 123456789;
            exampleClientData.BirthDate = DateTime.Now;
            client.ClientData = exampleClientData;
            
            Discount exampleDiscount = new Discount();
            exampleDiscount.ValueOfDiscount = 20;
            
            string Pesel = "123456789";
            
            RealEstateInsurance exampleInsurance = new RealEstateInsurance();
            
            client.Discount = exampleDiscount;
            client.Insurances.RealEstateInsurance.Add(exampleInsurance);
                      
            items.Add(new Client() { FirstName = "John Doe", SecondName = "Kowalski", ClientData = exampleClientData, Discount = exampleDiscount });
            items.Add(new Client() { FirstName = "Bartłomiej", SecondName = "Leja", ClientData = exampleClientData, Discount = exampleDiscount });
            items.Add(new Client() { FirstName = "Magdalena", SecondName = "Migas", ClientData = exampleClientData, Discount = exampleDiscount });
            items.Add(new Client() { FirstName = "Maciej", SecondName = "Latała", ClientData = exampleClientData, Discount = exampleDiscount });

            items.Add(client);

            clientsList.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(clientsList.ItemsSource);
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("SecondName", ListSortDirection.Ascending));
            
        }
    }


}
