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

namespace JSON_Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PokemonInfoAPI info = null;
        string WhichSideToShow = "Front";
        bool shouldShowFront = true;


        public MainWindow()
        {
            InitializeComponent();

            string url = "https://pokeapi.co/api/v2/pokemon?offset=0&limit=1400";
            PokemonAPI api;
            using (var client = new HttpClient())
            {

                string response = client.GetStringAsync(url).Result;

                api = JsonConvert.DeserializeObject<PokemonAPI>(response);

            }

            foreach (var item in api.results)
            {
                cboPokemon.Items.Add(item);
            }

        }


        private void cboPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResultItem selected = (ResultItem)cboPokemon.SelectedItem;

            string url = selected.url;
            using (var client = new HttpClient())
            {

                string response = client.GetStringAsync(url).Result;

                info = JsonConvert.DeserializeObject<PokemonInfoAPI>(response);

            }

            txtName.Text = info.name;
            txtHeight.Text = info.height.ToString();
            txtWeight.Text = info.weight.ToString();

            imgPokemon.Source = new BitmapImage(new Uri(info.sprites.front_default));
            shouldShowFront = false;
            btnDance.IsEnabled = true;
        }

        private void btnDance_Click(object sender, RoutedEventArgs e)
        {
            if (info == null)
            {
                MessageBox.Show("Please select a Pokemon first.");
                return;
            }
            if (shouldShowFront)
            {
                imgPokemon.Source = new BitmapImage(new Uri(info.sprites.front_default));
                shouldShowFront = false;
            }
            else
            {
                imgPokemon.Source = new BitmapImage(new Uri(info.sprites.back_default));
                shouldShowFront = true;
            }


        }
    }
}