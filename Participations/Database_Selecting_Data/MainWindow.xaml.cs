using Database_Selecting_Data.Models;
using Microsoft.EntityFrameworkCore;
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

namespace Database_Selecting_Data
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var db = new DB_128040_practiceContext();

            foreach (var student in db.Students.OrderBy(x => x.StudentId).Include(x=>x.Registrations))
            {
                lstStudents.Items.Add(student);
            }

            foreach (var course in db.Courses)
            {
                lstCourses.Items.Add(course);
            }

        }

        private void lstStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Student selectedStudent = (Student)lstStudents.SelectedItem;

            StudentDetailsWindow detailsWindow = new StudentDetailsWindow();
            // 1 way to load details
            //detailsWindow.student = selectedStudent;
            //detailsWindow.LoadDetails();

            // another way to load details
            detailsWindow.LoadDetailsViaParameter(selectedStudent);

            detailsWindow.Show();
        }

        private void lstCourses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Course selectedCourse = (Course)lstCourses.SelectedItem;

            MessageBox.Show($"Course: {selectedCourse}\n" +
                $"Number of Registrations: {selectedCourse.Registrations.Count}");
        }
    }
}