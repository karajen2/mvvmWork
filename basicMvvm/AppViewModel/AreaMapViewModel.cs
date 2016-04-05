using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppModel;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AppViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public List<Area> _listOfArea = new List<Area>();
        public List<People> _listOfPeople = new List<People>();
        List<People> localList = new List<People>();
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Area> ListOfArea 
        {
            get
            {
                return _listOfArea;
            }
        }

        public List<People> LocalListOfPeople
        {
            get
            {
                return localList;
            }
            set
            {
                localList = value;
                OnPropertyChanged("LocalListOfPeople");
            }
        }

        private Area _selectedArea = null;

        public Area SelectedArea
        {
            get
            {
                return _selectedArea;
            }
            set
            {
                _selectedArea = value;
                LocalListOfPeople = AreaPeople();
                OnPropertyChanged("SelectedArea");
            }
        }

        private List<People> AreaPeople()
        {
            var result = _listOfPeople.Where(s => s.Area == SelectedArea.AreaName);
            localList = new List<People>();
            foreach (People item in result)
            {
                localList.Add(item);
            }
            return localList;
        }

        public AppViewModel()
        {
            _listOfArea = new List<Area>()
            {
                new Area(){AreaName="chennai"},
                new Area(){AreaName="mumbai"},
                new Area(){AreaName="delhi"},
                new Area(){AreaName="kolkata"},
            };

            _listOfPeople = new List<People>()
            {
                new People(){Name="kumar", PhoneNumber="111111", Area="chennai"},
                new People(){Name="arun", PhoneNumber="222222", Area="mumbai"},
                new People(){Name="selva", PhoneNumber="333333", Area="chennai"},
                new People(){Name="baby", PhoneNumber="444444", Area="delhi"},
                new People(){Name="pinky", PhoneNumber="55555", Area="delhi"},
                new People(){Name="pete", PhoneNumber="999999", Area="chennai"},
                new People(){Name="ram", PhoneNumber="66666", Area="kolkata"},
                new People(){Name="vicky", PhoneNumber="888888", Area="mumbai"},
            };
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
