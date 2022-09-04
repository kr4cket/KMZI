using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMZI_LAB_1
{
    public class Letter
    {
        public char letter { get; set; }
        public int id { get; set; }
        public Letter(char letter, int id)
        {
            this.letter = letter;
            this.id = id;
        }
    }
}
