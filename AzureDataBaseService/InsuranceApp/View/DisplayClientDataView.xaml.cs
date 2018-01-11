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
    /// Logika interakcji dla klasy DisplayClientDataView.xaml
    /// </summary>
    public partial class DisplayClientDataView : UserControl
    {
        List<Client> items = new List<Client>();

        public DisplayClientDataView()
        {
            InitializeComponent();
            displayClients();
          //  testList();
        }

        private void displayClients()
        {
            RestSharpHandler handler = new RestSharpHandler();
            Client tempClient = new Client();

            for(int i =32; i< 35; i++)
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



                RestData.Document.Blocks.Add(new Paragraph(new Run("Zniżka: " + tempClient.Discount.ValueOfDiscount + "%")));
            }

            String insurance = "";

            //foreach (RealEstateInsurance r in tempClient.Insurances.RealEstateInsurance)
            //    insurance += r.ToString();



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
