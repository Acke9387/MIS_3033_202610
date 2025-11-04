using Database_Selecting_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Database_Selecting_Data
{
    /// <summary>
    /// Interaction logic for StudentDetailsWindow.xaml
    /// </summary>
    public partial class StudentDetailsWindow : Window
    {
        public Student student { get; set; }

        public StudentDetailsWindow()
        {
            InitializeComponent();
        }

        public void LoadDetails()
        {
            lblName.Content = student.FirstName + " " + student.LastName;
            txtFavoriteColor.Text = student.FavoriteColor;
            txtId.Text = student.StudentId.ToString();
            txtFirstname.Text = student.FirstName;
            txtLastname.Text = student.LastName;

            foreach (var reg in student.Registrations)
            {
               lstCourses.Items.Add(reg);
            }

        }

        public void LoadDetailsViaParameter(Student stud)
        {
            lblName.Content = stud.FirstName + " " + stud.LastName;
            txtFavoriteColor.Text = stud.FavoriteColor;
            txtId.Text = stud.StudentId.ToString();
            txtFirstname.Text = stud.FirstName;
            txtLastname.Text = stud.LastName;

            foreach (var reg in student.Registrations)
            {
                lstCourses.Items.Add(reg);
            }
        }

    }
}
