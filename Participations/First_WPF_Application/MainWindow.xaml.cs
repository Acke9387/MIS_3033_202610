using System.DirectoryServices.ActiveDirectory;
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

namespace First_WPF_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            student.Name = txtName.Text;
            student.Birthdate = DateTime.Parse(txtBirthdate.Text);
            lstStudents.Items.Add(student);
            MessageBox.Show($"You are {student.CalculateAge()} years old.");

            // Clear input fields
            txtName.Clear();
            txtBirthdate.Text = string.Empty;
            txtBirthdate.Clear();
            txtName.Focus();
        }

        private void btnCalculate_MouseEnter(object sender, MouseEventArgs e)
        {
            wndMain.Background = Brushes.LightBlue;
        }

        private void btnCalculate_MouseLeave(object sender, MouseEventArgs e)
        {
            wndMain.Background = Brushes.DarkRed;
        }
    }
}