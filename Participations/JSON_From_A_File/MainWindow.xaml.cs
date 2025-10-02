using Newtonsoft.Json;
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

namespace JSON_From_A_File
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<CarOwner> data = new List<CarOwner>();
        public MainWindow()
        {
            InitializeComponent();

            string json = File.ReadAllText("Mock_Data_Car_Owners.json");

            data = JsonConvert.DeserializeObject<List<CarOwner>>(json);
            cboColors.Items.Add("All Colors");
            cboColors.SelectedIndex = 0;

            foreach (CarOwner carowner in data)
            {
                // add only unique colors to the cboColors
                if (cboColors.Items.Contains(carowner.Color) == false)
                {
                    cboColors.Items.Add(carowner.Color);
                }

                // Add all the car owners to the list box
                lstData.Items.Add(carowner);
            }

        }

        private void cboColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedColor = cboColors.SelectedItem.ToString();
            lstData.Items.Clear();

            foreach (CarOwner carowner in data)
            {
                if (selectedColor == carowner.Color ||
                    selectedColor == "All Colors")
                {
                    lstData.Items.Add(carowner);
                }
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string selectedColor = cboColors.SelectedItem.ToString();

            string contentsOfListBox = JsonConvert.SerializeObject(lstData.Items, Formatting.Indented);

            File.WriteAllText($"Filtered_Car_Owners_{selectedColor}.json", contentsOfListBox);
            MessageBox.Show("Successfully saved file");
        }
    }
}