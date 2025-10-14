using Newtonsoft.Json;
using System.IO;
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

namespace JSON_Game_of_Thrones_Quotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //set the content to tbQuote to "Press the button to get a quote"
            tbQuote.Text = "Press the button to get a quote";
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            string json = client.GetStringAsync("https://api.gameofthronesquotes.xyz/v1/random").Result;

            GameOfThronesAPI api = JsonConvert.DeserializeObject<GameOfThronesAPI>(json);
            tbQuote.Text = api.ToString();
            lstQuotes.Items.Add(api);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string contentsAsJSON = JsonConvert.SerializeObject(lstQuotes.Items);

            File.WriteAllText("got_quotes.json", contentsAsJSON);

            MessageBox.Show("Quotes saved to got_quotes.json");
        }
    }
}