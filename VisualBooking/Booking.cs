using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualBooking
{
    class Booking
    {
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public string PhoneNr { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Patrons { get; set; }

        public Booking(DateTime date, DateTime startTime, string phoneNr, string name, int patrons) {
            Date = date;
            StartTime = startTime;
            PhoneNr = phoneNr;
            Name = name;
            Patrons = patrons;
        }

        public override string ToString() {
            return $"Date: {Date}, StartTime: {StartTime}, PhoneNr: {PhoneNr}, Name: {Name}, Patrons: {Patrons}";
        }
    }
}