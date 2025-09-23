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

namespace Classes_And_Files
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            }
        }
    }
}