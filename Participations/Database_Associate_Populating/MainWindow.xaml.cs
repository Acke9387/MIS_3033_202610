using Database_Associate_Populating.Models;
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

namespace Database_Associate_Populating
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            var db = new DB_128040_fullaccessContext();

            foreach (var owner in db.Owners)
            {
                lstOwners.Items.Add(owner);
            }

        }

        private void btnAddOwner_Click(object sender, RoutedEventArgs e)
        {
            string image = txtImage.Text;
            string name = txtName.Text;
            //int id = Convert.ToInt32(txtId.Text);

            Owner newOwner = new Owner();
            //newOwner.Id = id;
            newOwner.Name = name;
            newOwner.Image = image;

            var db = new DB_128040_fullaccessContext();
            db.Owners.Add(newOwner);
            db.SaveChanges();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Get selected owner from listbox and make sure there is a selected item
            Owner selectedOwner = (Owner)lstOwners.SelectedItem;
            if (selectedOwner != null)
            {
                var db = new DB_128040_fullaccessContext();
                db.Owners.Remove(selectedOwner);
                db.SaveChanges();
                lstOwners.Items.Remove(selectedOwner);
            }
        }
    }
}