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

namespace Intro_to_JSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string fileAsJson = File.ReadAllText("MOCK_DATA.json");

            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(fileAsJson);
            
            lstData.ItemsSource = employees;


            string cSharpToJSON = JsonConvert.SerializeObject(employees, Formatting.Indented);

        }
    }
}