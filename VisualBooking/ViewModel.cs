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
        private DateTimeOffset _selectedDate;
        private string _name;
        private string _phoneNr;
        private string _phonePrefix;

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

        public ObservableCollection<Table> TableList { get; set; }

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
            Date = DateTime.Today;

            AddCommand = new RelayCommand(Add);
            SaveCommand = new RelayCommand(Save);

            TableList = new ObservableCollection<Table>();
            //TableList.Add(new Table(1,2,5, "1"));
            Index = 0;
            Patrons = 4;

            //GetTables();

            AddTime17 = new RelayCommand(AddT17);
            AddTime1730 = new RelayCommand(AddT1730);
            AddTime18 = new RelayCommand(AddT18);
            AddTime1830 = new RelayCommand(AddT1830);
            AddTime19 = new RelayCommand(AddT19);
            AddTime1930 = new RelayCommand(AddT1930);
            AddTime20 = new RelayCommand(AddT20);
            AddTime2030 = new RelayCommand(AddT2030);
        }

        public void Add()
        {
            TableList[0].Bookings.Add(new Booking(SelectedDate, PhoneNr, Name, Patrons));
        }

        public void Save()
        {
            PersistencyService.SaveNotesAsJsonAsync(TableList);
        }

        public async void GetTables()
        {
            var tables = await PersistencyService.LoadNotesFromJsonAsync();
            int max = 0;
            foreach (var table in tables)
            {
                TableList.Add(table);
                
            }
           
        }

        #region AddTimeMethods
        public void AddT17()
        {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(17);
        }

        public void AddT1730() {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(17).AddMinutes(30);
        }

        public void AddT18() {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(18);
        }

        public void AddT1830() {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(18).AddMinutes(30);
        }

        public void AddT19() {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(19);
        }

        public void AddT1930() {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(19).AddMinutes(30);
        }

        public void AddT20() {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(20);
        }

        public void AddT2030() {
            SelectedDate = Date.Date;
            SelectedDate = SelectedDate.AddHours(20).AddMinutes(30);
        }
        #endregion

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