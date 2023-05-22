using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using week12_1.ViewModel;

namespace week12_2.ViewModel
{
    class Car : ViewModelBase
    {
        String _company;
        public String Company
        {
            get { return _company; }
            set
            {
                _company = value;
                OnPropertyChanged("Company");
            }
        }

        String _model;
        public String Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }

        String _year;
        public String Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged("Year");
            }
        }

        Color _carColor;
        public Color CarColor
        {
            get { return _carColor; }   
            set
            {
                _carColor = value;
                OnPropertyChanged("CarColor");
            }
        }

        int _price;
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }


    }





    class MainWindowViewModel : ViewModelBase
    {

        ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get
            {
                return _cars;
            }
        }

        List<Color> _carColors;
        public List<Color> CarColors
        {
            get { return _carColors; }
        }

        Car _newCar=new Car();  
        public Car NewCar
        {
            get
            {
                return _newCar; 
            }
            set
            {
                _newCar = value;
                OnPropertyChanged("newCar");
            }
        }

        RelayCommand _addCar;
        public RelayCommand AddCar
        {
            get
            {
                return _addCar;
            }


        }
        private void AddCarExecute()
        {
            _cars.Add(new Car() { Company=_newCar.Company, Model=_newCar.Model,CarColor=_newCar.CarColor,Price = _newCar.Price});
        }

        Car _selectedCar;
        public Car SelectedCar
        {
            get
            {
                return _selectedCar;
            }
            set
            {
                _selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }

        RelayCommand _deleteCar;
        public RelayCommand DeleteCar
        {
            get
            {
                return _deleteCar;
            }

        }
        private void DeleteCarExecute()
        {
            _cars.Remove(_selectedCar);
        }

        RelayCommand _modifyCar;
        public RelayCommand ModifyCar
        {
            get { return _modifyCar;}
        }

        private void ModifyCarExecute()
        {
            if(_selectedCar == null)
            {
                _selectedCar.CarColor= NewCar.CarColor;
                _selectedCar.Company= NewCar.Company;
                _selectedCar.Model= NewCar.Model; 
                _selectedCar.Price= NewCar.Price;   
            }
        }


        public MainWindowViewModel()
        {
            _deleteCar = new RelayCommand(DeleteCarExecute);
            _addCar=new RelayCommand(AddCarExecute);
            _modifyCar=new RelayCommand(ModifyCarExecute);  

            _cars = new ObservableCollection<Car>();

            _cars.Add(new Car() { Company = "Bentz", Model = "Gle", Year = "1996", CarColor = Colors.Aqua, Price = 2000 });
            _cars.Add(new Car() { Company = "Bmw", Model = "X5", Year = "2011", CarColor = Colors.Blue ,Price= 3000 });
            _cars.Add(new Car() { Company = "Hyundae", Model = "Sonata", Year = "2011", CarColor = Colors.Gold ,Price = 4000});

            _carColors=new List<Color>();

            _carColors.Add(Colors.Aqua);
            _carColors.Add(Colors.Blue);
            _carColors.Add(Colors.Gold);
            _carColors.Add(Colors.Red);
            _carColors.Add(Colors.Beige);
            _carColors.Add(Colors.Azure);
            _carColors.Add(Colors.DarkViolet);




        }
    }

}