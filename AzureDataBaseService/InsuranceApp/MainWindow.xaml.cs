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
using System.ComponentModel;

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


            //            InitializeClientsTable();

            testList();

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = sender as ListView;

            Client tempClient = (Client)listView.SelectedItems[0];




            RestData.Document.Blocks.Clear();
            RestData.Document.Blocks.Add(new Paragraph(new Run("Imię: " + tempClient.FirstName +
                "\nNazwisko: " + tempClient.FirstName +
                "\nData urodzenia: " + tempClient.ClientData.BirthDate+
                "\nAdres: " + tempClient.ClientData.Adress +
                "\nPesel: " + tempClient.ClientData.PeselNumber)));



            RestData.Document.Blocks.Add(new Paragraph(new Run("Zniżka: " + tempClient.Discount.ValueOfDiscount + "%")));


            String insurance = "";

            foreach (RealEstateInsurance r in tempClient.Insurances.RealEstateInsurance)
                insurance += r.ToString();


            RealEstateInsuranceDetailBox.Document.Blocks.Add(new Paragraph(new Run(insurance)));


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


            List<Client> items = new List<Client>();
            items.Add(new Client() { FirstName= "John Doe", SecondName = "Kowalski", ClientData = exampleClientData, Discount = exampleDiscount });
            items.Add(new Client() { FirstName = "Bartłomiej", SecondName = "Leja", ClientData = exampleClientData, Discount = exampleDiscount });
            items.Add(new Client() { FirstName = "Magdalena", SecondName = "Migas", ClientData = exampleClientData, Discount = exampleDiscount });
            items.Add(new Client() { FirstName = "Maciej", SecondName = "Latała", ClientData = exampleClientData, Discount = exampleDiscount });




            items.Add(client);
          
            clientsList.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(clientsList.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("SecondName", ListSortDirection.Ascending));


        }



        private void InitializeClientsTable()
        {
            var restSharpHandler = new RestSharpHandler();

            String s = restSharpHandler.GetClientdata();
            List<Client> clients = restSharpHandler.GetAllClientdata();
            clientsList.ItemsSource = clients;
            

        }
    }
}
