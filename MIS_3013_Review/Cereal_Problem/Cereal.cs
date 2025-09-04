using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cereal_Problem
{
    public class Cereal
    {
        //private string Manufacturer;
        //public string GetManufacturer()
        //{
        //    return Manufacturer;
        //}
        //private void SetManufacturer (string manufacturer)
        //{
        //    Manufacturer = manufacturer;
        //}

        public string Manufacturer { get; set; }

        public string Name { get; set; }

        public double Calories { get; set; }

        /// <summary>
        /// Number of cups in a serving
        /// </summary>
        public double Cups { get; set; }

        private double Squirrel;

        /// <summary>
        /// Default/Empty Constructor to create a new object
        /// </summary>
        public Cereal()
        {
            Manufacturer = "";
            Name = string.Empty;
            Calories = 0;
            Cups = 0;
            Squirrel = 0;
        }

        public Cereal(string line) //: this()
        {
            Manufacturer = line;
            Name = string.Empty;
            Calories = 0;
            Cups = 0;
        }

        public override string ToString()
        {
            return $"{Name} created by {Manufacturer} has {Calories} calories per {Cups} cup";
        }
    }
}
