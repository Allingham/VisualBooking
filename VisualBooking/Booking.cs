using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBooking
{
    class Booking
    {
        public DateTimeOffset Date { get; set; }
        public string PhoneNr { get; set; }
        public string Name { get; set; }
        public int Patrons { get; set; }

        public Booking(DateTimeOffset date, string phoneNr, string name, int patrons) {
            Date = date;
            PhoneNr = phoneNr;
            Name = name;
            Patrons = patrons;
        }

        public override string ToString() {
            return $"Date: {Date}, PhoneNr: {PhoneNr}, Name: {Name}, Patrons: {Patrons}";
        }
    }
}