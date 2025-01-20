using EvaluacionP3JT.ModelsJT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace EvaluacionP3JT.ViewModelJT
{
    public class ApiListViewModel : INo
    {
        private readonly ServicesJT.CarApiServiceJT _carApiService;
        private readonly ServicesJT.CarDatabaseJT _carDatabase;

        public ObservableCollection<CarsJT> Cars { get; set; } = new ObservableCollection<CarsJT>();
        private string _modelInput;

        public string ModelInput
        {
            get => _modelInput;
            set => SetProperty(ref _modelInput, value);
        }

        public ICommand LoadCarsCommand { get; }
        public ICommand SelectCarCommand { get; }

        public ApiListViewModel(ServicesJT.CarDatabaseJT carDatabase)
        {
            _carApiService = new ServicesJT.CarApiServiceJT();
            _carDatabase = carDatabase;
            LoadCarsCommand = new Command(async () => await LoadCarsAsync());
            SelectCarCommand = new Command<CarsJT>(async (car) => await SelectCarAsync(car));
        }

        private async Task LoadCarsAsync()
        {
            if (string.IsNullOrWhiteSpace(ModelInput))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, ingresa un modelo", "OK");
                return;
            }

            try
            {
                var cars = await _carApiService.GetCarsAsync(ModelInput);
                Cars.Clear();
                foreach (var car in cars)
                {
                    Cars.Add(car);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async Task SelectCarAsync(CarsJT selectedCar)
        {
            // Navegar a la siguiente pantalla y pasar el coche seleccionado
            await Application.Current.MainPage.Navigation.PushAsync(new CarsDetailPageJT(selectedCar));
        }
    }
}

