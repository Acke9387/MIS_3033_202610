using Newtonsoft.Json;
using System.Net.Http;
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

namespace JSON_Rick_and_Morty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string url = "https://rickandmortyapi.com/api/character";

            string json = "";

            HttpClient client = new HttpClient();
            json = client.GetStringAsync(url).Result;

            RickAndMortyAPI api = JsonConvert.DeserializeObject<RickAndMortyAPI>(json);

            foreach(Result result in api.results)
            {
                cboCharacters.Items.Add(result);
            }
        }

        private void cboCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Result selectedItem = (Result)cboCharacters.SelectedItem;
            txtName.Text = selectedItem.name;
            txtURL.Text = selectedItem.url;
            imgPicture.Source = new BitmapImage(new Uri(selectedItem.image));
        }
    }
}