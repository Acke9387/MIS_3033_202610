using System.IO;
using System.Security.Policy;
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
using static System.Net.Mime.MediaTypeNames;

namespace Classes_And_Files
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Toy> toys = new List<Toy>();
        public MainWindow()
        {
            InitializeComponent();

            //read in Toys.csv
            string[] lines = File.ReadAllLines("Toys.csv");

            foreach (var line in lines.Skip(1)) //skip the header line
            {                
                //     0        1      2      3
                //Manufacturer,Name,Price,Image

                //split the line into parts
                string[] parts = line.Split(',');
                string manufacturer = parts[0];
                string name = parts[1];
                double price = double.Parse(parts[2]);
                string image = parts[3];

                Toy t = new Toy()
                {
                    Manufacturer = manufacturer,
                    Name = name,
                    Price = price,
                    Image = image
                };

                //t.Manufacturer = manufacturer;
                //t.Name = name;
                //t.Price = price;
                //t.Image = image;

                toys.Add(t);
                //lstToys.Items.Add(t);
            }
            lstToys.ItemsSource = toys;

        }

        private void btnAddToy_Click(object sender, RoutedEventArgs e)
        {
            string manufacturer = txtManufacturer.Text;
            string name = txtName.Text;
            string image = txtImageUrl.Text;
            string priceText = txtPrice.Text;

            // Validate that manufacturer, name, image are not empty and priceText is actually a number
            if (string.IsNullOrWhiteSpace(manufacturer) ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(image) ||
                !double.TryParse(priceText, out double price))
            {
                MessageBox.Show("Please enter valid values for all fields.");
                return;
            }
            Toy t = new Toy()
            {
                Manufacturer = manufacturer,
                Name = name,
                Price = price,
                Image = image
            };

            toys.Add(t);
            lstToys.Items.Refresh();
            //clear the textboxes
            txtManufacturer.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtImageUrl.Clear();
            txtManufacturer.Focus();


        }

        private void lstToys_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = lstToys.SelectedItem as Toy;
            if (selectedItem != null)
            {
                MessageBox.Show($"Aisle: {selectedItem.GetAisle()}");
                var uri = new Uri(selectedItem.Image);
                var img = new BitmapImage(uri);
                //Update a property on your Image control (Source) on your GUI to be 'img'
                imgToy.Source = img;

                // Problem does not call for this,
                // but if we wanted to populate the textboxes with the selected toy's info, we could do this:

                //txtImageUrl.Text = selectedItem.Image;
                //txtManufacturer.Text = selectedItem.Manufacturer;
                //txtName.Text = selectedItem.Name;
                //txtPrice.Text = selectedItem.Price.ToString();
            }
        }
    }
}