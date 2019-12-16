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
        public ObservableCollection<Booking> Bookings { get; set; }
        public int PosY { get; set; }
        public int PosX { get; set; }
        public int MaxPatrons { get; set; }
        public String TableName { get; set; }

        public Table(int posY, int posX, int maxPatrons, String tableName)
        {
            PosY = posY;
            PosX = posX;
            MaxPatrons = maxPatrons;
            TableName = tableName;
            Bookings = new ObservableCollection<Booking>();
            AddBooking(DateTimeOffset.Now, "12345678", "Lars", 2);
        }

        public bool Available(DateTime date, int patrons)
        {
            foreach (Booking b in Bookings)
            {
                if (patrons > MaxPatrons && patrons >= MaxPatrons * 0.60)
                {
                    if (date < b.Date.AddHours(2) && date > b.Date.AddHours(-2))
                    {
                        return false;
                    }

                    return true;
                }

                return false;
            }

            return true;
        }

        public void AddBooking(DateTimeOffset date, string phoneNr, string name, int patrons)
        {
            Bookings.Add(new Booking(date, phoneNr, name, patrons));
        }

        public override string ToString()
        {
            return $"Bookings: {Bookings}, PosY: {PosY}, PosX: {PosX}, MaxPatrons: {MaxPatrons}";
        }
    }
}