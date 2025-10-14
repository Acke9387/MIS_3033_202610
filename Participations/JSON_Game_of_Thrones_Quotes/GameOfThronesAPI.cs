using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Game_of_Thrones_Quotes
{
    public class GameOfThronesAPI
    {

        public string sentence { get; set; }

        public Character character { get; set; }

        public override string ToString()
        {
            return $"\"{sentence}\"\n\t-{character.name}";
        }
    }

    public class Character
    {
        public string name { get; set; }
    }
}
