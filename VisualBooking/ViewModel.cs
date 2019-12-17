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
using Windows.UI.Popups;

namespace VisualBooking
{
    class ViewModel : INotifyPropertyChanged
    {
        private DateTimeOffset _date;
        private DateTimeOffset _selectedDate;
        private string _name;
        private string _phoneNr;
        private string _phonePrefix;
        private ObservableCollection<string> _tableColours;
        private ObservableCollection<Table> _tableList;
        private string _tableColour;
        private int _patrons;
        private int _index;

        public string TableColour
        {
            get => _tableColour;
            set { _tableColour = value; OnPropertyChanged("TableColour");}
        }

        public ObservableCollection<string> TableColours
        {
            get => _tableColours;
            set { _tableColours = value; OnPropertyChanged("TableColours");}
        }

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

        public int Patrons
        {
            get => _patrons;
            set { _patrons = value; OnPropertyChanged("Patrons");}
        }

        public int Index
        {
            get => _index;
            set { _index = value; OnPropertyChanged("Index");}
        }

        public ObservableCollection<Table> TableList
        {
            get => _tableList;
            set { _tableList = value; OnPropertyChanged("TableList");}
        }

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

        public ICommand SetTables { get; set; }
        public ICommand Bord0 { get; set; }
        public ICommand Bord1 { get; set; }
        public ICommand Bord2 { get; set; }
        public ICommand Bord3 { get; set; }
        public ICommand Bord4 { get; set; }

        public ViewModel()
        {
            Date = DateTime.Today;

            AddCommand = new RelayCommand(Add);
            SaveCommand = new RelayCommand(Save);

            TableList = new ObservableCollection<Table>();
            TableColours = new ObservableCollection<string>();

            //TableList.Add(new Table(1,2,5, "1"));
            //Index = 0;
            //Patrons = 4;

            GetTables();
            InitializeTableColours();

            AddTime17 = new RelayCommand(AddT17);
            AddTime1730 = new RelayCommand(AddT1730);
            AddTime18 = new RelayCommand(AddT18);
            AddTime1830 = new RelayCommand(AddT1830);
            AddTime19 = new RelayCommand(AddT19);
            AddTime1930 = new RelayCommand(AddT1930);
            AddTime20 = new RelayCommand(AddT20);
            AddTime2030 = new RelayCommand(AddT2030);
            SetTables = new RelayCommand(SetTableColours);

            Bord0 = new RelayCommand(SetBord0);
            Bord1 = new RelayCommand(SetBord1);
            Bord2 = new RelayCommand(SetBord2);
            Bord3 = new RelayCommand(SetBord3);
            Bord4 = new RelayCommand(SetBord4);

            //TableColour = "#52BE80";
            //TableColours[0] = "#E74C3C";
        }

        public async void Add()
        {
            if (TableList[Index].Available(SelectedDate, Patrons) == true)
            {
                TableList[Index].Bookings.Add(new Booking(SelectedDate, PhoneNr, Name, Patrons));
                Save();
            }
            else
            {
                MessageDialog Advarsel = new MessageDialog("Du har valgt et bord der allerede er booket!", "Overbooking");
                await Advarsel.ShowAsync();
            }
        }

        public void Save()
        {
            PersistencyService.SaveNotesAsJsonAsync(TableList);
        }

        public async void GetTables()
        {
            var tables = await PersistencyService.LoadNotesFromJsonAsync();
            if (tables != null)
            {
                foreach (var table in tables)
                {
                    TableList.Add(table);

                }
            }
            else
            {
                TableList.Add(new Table(0,0,4,"1"));
                TableList.Add(new Table(0,0,6,"2"));
                TableList.Add(new Table(0,0,8,"3"));
                TableList.Add(new Table(0,0,4,"4"));
                TableList.Add(new Table(0,0,2,"5"));
            }

        }

        public void SetTableColours()
        {
            bool available;
            for (int i = 0; i < 5; i++)
            {
                available = TableList[i].Available(SelectedDate, Patrons);
                if (available == false)
                {
                    TableColours[i] = "#E74C3C";
                }
                else
                {
                    TableColours[i] = "#52BE80";
                }
            }
        }

        public void InitializeTableColours()
        {
            for (int i = 0; i < 5; i++)
            {
                TableColours.Add("#52BE80");
            }
        }

        #region TableMethods

        public void SetBord0()
        {
            Index = 0;
        }

        public void SetBord1()
        {
            Index = 1;
        }

        public void SetBord2()
        {
            Index = 2;
        }

        public void SetBord3()
        {
            Index = 3;
        }

        public void SetBord4()
        {
            Index = 4;
        }

        #endregion
        
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