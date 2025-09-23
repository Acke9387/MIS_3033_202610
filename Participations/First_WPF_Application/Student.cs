using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_WPF_Application
{
    /// <summary>
    /// Represents a student with a name and birthdate.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// The name of the student.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The birthdate of the student.
        /// </summary>
        public DateTime? Birthdate { get; set; }

        /// <summary>
        /// Initializes a new instance of the Student class with default values.
        /// </summary>
        public Student()
        {
            Name = "";
            Birthdate = null;
        }

        /// <summary>
        /// Returns a string representation of the student.
        /// </summary>
        /// <returns>A string representation of a student</returns>
        public override string ToString()
        {
            return $"{Name} ({Birthdate?.ToShortDateString() ?? "N/A"})";
        }

        /// <summary>
        /// Calculates the age of the student based on the Birthdate property.
        /// </summary>
        /// <returns>The age of the student</returns>
        public int CalculateAge()
        {
            if (Birthdate == null)
                return 0;
            var today = DateTime.Today;
            var age = today.Year - Birthdate.Value.Year;

            if (Birthdate.Value.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }


    }
}
