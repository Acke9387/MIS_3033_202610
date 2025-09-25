using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_And_Files
{
    public class Toy
    {
        /// <summary>
        /// Properties of the Toy class.
        /// </summary>

        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        private string Aisle;

        /// <summary>
        /// Default constructor for the Toy class.
        /// </summary>
        public Toy()
        {
            Manufacturer = string.Empty;
            Name = string.Empty;
            Price = 0;
            Image = string.Empty;
            Aisle = string.Empty;
        }


        /// <summary>
        /// Method to generate the aisle code based on the first letter of the manufacturer and the price.
        /// </summary>
        /// <returns>The aisle of the toy</returns>
        public string GetAisle()
        {
            Aisle = Manufacturer.ToUpper()[0].ToString() + Price.ToString().Replace(".","");
            return Aisle;
        }

        public override string ToString()
        {
            return $"{Manufacturer} - {Name}";
        }
    }
}
