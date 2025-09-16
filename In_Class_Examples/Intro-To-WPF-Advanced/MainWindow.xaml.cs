using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Intro_To_WPF_Advanced
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Sale> Complete_Sales = new List<Sale>();

        public MainWindow()
        {
            InitializeComponent();

            string[] linesOfFile = File.ReadAllLines("SalesJan2009.csv");

            foreach (string line in linesOfFile.Skip(1))
            {
                Sale s = new Sale();
                string[] columns = line.Split(',');
                //       0            1       2      3          4    5    6     7            8            9        10        11
                //Transaction_date,Product,Price,Payment_Type,Name,City,State,Country,Account_Created,Last_Login,Latitude,Longitude
                s.Transaction_date = DateTime.Parse(columns[0]);
                s.Product = columns[1];
                s.Price = double.Parse(columns[2]);
                s.Payment_Type = columns[3];
                s.Name = columns[4];
                s.City = columns[5].Trim();
                s.State = columns[6];
                s.Country = columns[7];
                s.Account_Created = DateTime.Parse(columns[8]);
                s.Last_Login = DateTime.Parse(columns[9]);
                s.Latitude = decimal.Parse(columns[10]);
                s.Longitude = decimal.Parse(columns[11]);

                // Remove all white space characters for City
                //s.City = s.City.Trim();

                Complete_Sales.Add(s);

                // Add each unique payment type to the ComboBox
                if (cboPaymentType.Items.Contains(s.Payment_Type) == false)
                {
                    cboPaymentType.Items.Add(s.Payment_Type);
                }
                lstSales.Items.Add(s);
            }
            lblCount.Content = $"Count: {Complete_Sales.Count}";
            //lstSales.ItemsSource = Complete_Sales;

        }

        private void cboPaymentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string selectedPaymentType = (string)cboPaymentType.SelectedItem.ToString();
            lstSales.Items.Clear();
            if (selectedPaymentType != null)
            {
                foreach (Sale s in Complete_Sales)
                {
                    if (s.Payment_Type == selectedPaymentType)
                    {
                        lstSales.Items.Add(s);
                    }
                }
                lblCount.Content = $"Count: {lstSales.Items.Count}";
            }
            else
            {
                lstSales.ItemsSource = null;
            }

        }
    }
}