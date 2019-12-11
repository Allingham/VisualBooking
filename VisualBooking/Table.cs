using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace VisualBooking
{
    class Table
    {
        public List<Booking> Bookings;
        public int PosY { get; set; }
        public int PosX { get; set; }
        public int MaxPatrons { get; set; }

        public Table(int posY, int posX, int maxPatrons)
        {
            PosY = posY;
            PosX = posX;
            MaxPatrons = maxPatrons;
        }
/*
        public bool Available(DateTime date, DateTime selectedTime, DateTime selectedDate, int patrons)
        {
            foreach (Booking b in Bookings)
            {
                if (patrons > MaxPatrons && patrons >= MaxPatrons * 0.60)
                {
                    if (selectedTime < b.StartTime - b.Length && selectedTime > b.StartTime + b.Length &&
                        date == selectedDate)
                    {
                        return false;
                    }

                    return true;
                }

                return false;
            }

            return true;
        }
*/
        public void AddBooking(DateTime date, DateTime startTime, string phoneNr, string name, int patrons)
        {
            Bookings.Add(new Booking(date, startTime, phoneNr, name, patrons));
        }
    }
}