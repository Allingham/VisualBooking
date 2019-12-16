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
        private DateTimeOffset _selectedDate;

        public DateTimeOffset Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged("Date"); }
        }

        public DateTimeOffset SelectedDate
        {
            get => _selectedDate;
            set { _selectedDate = value; OnPropertyChanged("SelectedDate");}
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

        public int Patrons { get; set; }
        public int Index { get; set; }

        public ObservableCollection<Table> Bookings2 { get; set; }
        public ObservableCollection<Booking> Bookings1 { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public ICommand AddTime17 { get; set; }
        public ICommand AddTime1730 { get; set; }
        public ICommand AddTime18 { get; set; }
        public ICommand AddTime1830 { get; set; }
        public ICommand AddTime19 { get; set; }
        public ICommand AddTime1930 { get; set; }
        public ICommand AddTime20 { get; set; }
        public ICommand AddTime2030 { get; set; }

        public ViewModel()
        {
            Bookings1 = new ObservableCollection<Booking>();
            {

            }
            AddCommand = new RelayCommand(Add);
            SaveCommand = new RelayCommand(Save);
            Date = DateTime.Today;

            AddTime17 = new RelayCommand(AddS17);
            AddTime1730 = new RelayCommand(AddS1730);
            AddTime18 = new RelayCommand(AddS18);
            AddTime1830 = new RelayCommand(AddS1830);
            AddTime19 = new RelayCommand(AddS19);
            AddTime1930 = new RelayCommand(AddS1930);
            AddTime20 = new RelayCommand(AddS20);
            AddTime2030 = new RelayCommand(AddS2030);
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

        public void AddS17()
        {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(17);
            OnPropertyChanged("SelectedDate");
        }

        public void AddS1730() {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(17).AddMinutes(30);
            OnPropertyChanged("SelectedDate");
        }

        public void AddS18() {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(18);
            OnPropertyChanged("SelectedDate");
        }

        public void AddS1830() {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(18).AddMinutes(30);
            OnPropertyChanged("SelectedDate");
        }

        public void AddS19() {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(19);
            OnPropertyChanged("SelectedDate");
        }

        public void AddS1930() {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(19).AddMinutes(30);
            OnPropertyChanged("SelectedDate");
        }

        public void AddS20() {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(20);
            OnPropertyChanged("SelectedDate");
        }

        public void AddS2030() {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(20).AddMinutes(30);
            OnPropertyChanged("SelectedDate");
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