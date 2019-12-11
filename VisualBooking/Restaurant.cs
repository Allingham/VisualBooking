using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBooking
{
    class Restaurant
    {
        public List<Table> Tables { get; set; }
        public static int Count { get; set; }
        public int Nr { get; set; }
        public int Bord { get; set; }

        public Restaurant(int nr, int bord)
        {
            Nr = Count++;
            Bord = bord;
        }

        public override string ToString()
        {
            return $"Nr: {Nr}, Bord: {Bord}";
        }
    }
}
