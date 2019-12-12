using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VisualBooking
{
    class ViewModel : INotifyPropertyChanged
    {
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public string PhoneNr { get; set; }
        public string Name { get; set; }
        public int Patrons { get; set; }
        public int Index { get; set; }
        
        public ObservableCollection<Table> Bookings2 { get; set; }
        public ObservableCollection<Booking> Bookings1 { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public ViewModel()
        {
            Bookings1 = new ObservableCollection<Booking>();
            {
                new Booking(DateTime.Now, DateTime.Now, "232322323", "Nicklas", 4);
            }
            AddCommand = new RelayCommand(Add);
            SaveCommand = new RelayCommand(Save);
            Date = DateTime.Now;
        }

        public void Add()
        {
            Bookings2[Index].AddBooking(Date, StartTime, PhoneNr, Name, Patrons);
        }

        public void Save()
        {
            PersistencyService.SaveNotesAsJsonAsync(Bookings2);
        }

        #region PropertyChangeSupport
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}