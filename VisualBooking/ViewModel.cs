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
        public ObservableCollection<Table> Bookings2 { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public ViewModel()
        {
            AddCommand = new RelayCommand(Add);
            SaveCommand = new RelayCommand(Save);
        }

        public void Add()
        {
            Bookings2.Add(new Booking(Date, StartTime, PhoneNr, Name, Patrons));
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