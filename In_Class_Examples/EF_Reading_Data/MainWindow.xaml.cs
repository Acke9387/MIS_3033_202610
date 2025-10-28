using EF_Reading_Data.Models;
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

namespace EF_Reading_Data
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DB_128040_practiceContext db = new DB_128040_practiceContext();

            //var games = db.FootballSchedules.ToList();

            foreach (var game in db.FootballSchedules.Where(g => g.IsHomeGame == true && g.Season == 2018))
            {
                //if (game.IsHomeGame)
                //{
                //    lstHome.Items.Add(game);

                //}
                lstHome.Items.Add(game);
            }

            foreach (var game in db.FootballSchedules.Where(x => x.IsHomeGame == false && x.Season == 2018))
            {
                lstAway.Items.Add(game);
            }

        }
    }
}