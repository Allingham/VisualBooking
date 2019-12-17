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
            //AddBooking(DateTimeOffset.Now, "12345678", "Lars", 2);
            //AddBooking(DateTimeOffset.Now, "12345678", "Johannes", 2);
        }

        public bool Available(DateTimeOffset date, int patrons)
        {
            if (Bookings != null)
            {
                foreach (Booking b in Bookings)
                {
                    if (patrons > MaxPatrons && patrons >= MaxPatrons * 0.60)
                    {
                        return false;
                    }
                    else if (b.Date < date.AddHours(2) && b.Date > date.AddHours(-2))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;
        }

        public override string ToString()
        {
            return $"Bookings: {Bookings}, PosY: {PosY}, PosX: {PosX}, MaxPatrons: {MaxPatrons}";
        }
    }
}