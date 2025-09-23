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

        
        public string GetAisle()
        {
            //
            //Aisle = ... logic to determine aisle
            ///
            return Aisle;
        }

    }
}
