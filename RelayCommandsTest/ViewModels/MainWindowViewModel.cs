using RelayCommandsTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using WpfMVVM.Commands;
using System.Linq;

namespace RelayCommandsTest.ViewModels
{
    class MainWindowViewModel
    {
        public RelayCommand AddDogCommand { get; private set; }
        public RelayCommand ImportDataCommand { get; private set; }
        public RelayCommand FilterCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<object> testData;
        public ObservableCollection<object> TestData
        {
            get
            {
                return testData;
            }
            set
            {
                testData = value;
                OnPropertyChanged(nameof(TestData));
            }
        }

        private string pathForGender;
        public string PathForGender
        {
            get
            {
                return pathForGender;
            }
            set
            {
                pathForGender = value;
                OnPropertyChanged(nameof(PathForGender));
            }
        }

        private string pathForAge;
        public string PathForAge
        {
            get
            {
                return pathForAge;
            }
            set
            {
                pathForAge = value;
                OnPropertyChanged(nameof(PathForAge));
            }
        }

        private string pathForRace;
        public string PathForRace
        {
            get
            {
                return pathForRace;
            }
            set
            {
                pathForRace = value;
                OnPropertyChanged(nameof(PathForRace));
            }
        }

        private string filterValuePath;
        public string FilterValuePath
        {
            get
            {
                return filterValuePath;
            }
            set
            {
                filterValuePath = value;
                OnPropertyChanged(nameof(FilterValuePath));
            }
        }

        public MainWindowViewModel()
        {
            testData = new ObservableCollection<object>();
            AddDogCommand = new RelayCommand(AddDog, CanAdd);
            ImportDataCommand = new RelayCommand(ImportData, CanImportData);
            FilterCommand = new RelayCommand(FilterData, CanFilterData);
        }

        public void ImportData(object parameter)
        {
            var dog1 = new Dog() { Race = "Bulldog", Age = "2", Gender = "Male" };
            var dog2 = new Dog() { Race = "German Shepherd", Age = "5", Gender = "Male" };
            var dog3 = new Dog() { Race = "Golden Retriever", Age = "1", Gender = "Female" };
            testData.Add(dog1);
            testData.Add(dog2);
            testData.Add(dog3);
        }

        public bool CanImportData(object parameter)
        {
            return true;
        }

        public void AddDog(object parameter)
        {
            var dog = new Dog() { Race = pathForRace, Age = pathForAge, Gender = pathForGender };
            testData.Add(dog);
        }

        public bool CanAdd(object parameter)
        {
            return true;
        }

        public void FilterData(object parameter)
        {
            var q =
                from a in testData
                where a.ToString().Contains(FilterValuePath)
                select a;
            testData = q;
        }

        public bool CanFilterData(object parameter)
        {
            return true;
        }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
