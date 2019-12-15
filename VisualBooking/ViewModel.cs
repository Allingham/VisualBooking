using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Store.Preview.InstallControl;

namespace VisualBooking
{
    class ViewModel : INotifyPropertyChanged
    {
        private DateTimeOffset _date;
        private string _name;
        private string _phoneNr;
        private string _phonePrefix;

        public DateTimeOffset Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged("Date"); }
        }

        public string PhoneNr
        {
            get => _phoneNr;
            set { _phoneNr = PhonePrefix + value; OnPropertyChanged("PhoneNr"); OnPropertyChanged("PhonePrefix");}
        }

        public string PhonePrefix
        {
            get => _phonePrefix;
            set { _phonePrefix = value; OnPropertyChanged("PhonePrefix"); OnPropertyChanged("PhoneNr");}
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged("Name");}
        }

        public DateTimeOffset Time { get; set; }
        public int Patrons { get; set; }
        public int Index { get; set; }
        public DateTimeOffset SelectedDate { get; set; }
        public ObservableCollection<Table> Bookings2 { get; set; }
        public ObservableCollection<Booking> Bookings1 { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public ICommand AddTime17 { get; set; }
        public ICommand AddTime1730 { get; set; }

        public ViewModel()
        {
            Bookings1 = new ObservableCollection<Booking>();
            {

            }
            AddCommand = new RelayCommand(Add);
            SaveCommand = new RelayCommand(Save);
            Date = DateTime.Today;

            AddTime17 = new RelayCommand(AddT17);
            AddTime1730 = new RelayCommand(AddT1730);
        }

        public void Add()
        {
            PhoneNr = PhonePrefix + PhoneNr;
            Bookings2[Index].AddBooking(SelectedDate, PhoneNr, Name, Patrons);
        }

        public void Save()
        {
            PersistencyService.SaveNotesAsJsonAsync(Bookings2);
        }

        public void AddT17()
        {
            //Time = DateTimeOffset.Date;
            Time = Time.AddHours(17);
        }

        public void AddT1730() {
            //Time = DateTimeOffset.Date;
            Time = Time.AddHours(17);
            Time = Time.AddMinutes(30);
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