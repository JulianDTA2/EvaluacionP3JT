using EvaluacionP3JT.ModelsJT;
using EvaluacionP3JT.ServicesJT;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EvaluacionP3JT.ViewModelJT
{
    public class ApiListViewModelJT : BaseViewModelJT
    {
        private readonly CarApiServiceJT _carApiService;
        public ObservableCollection<CarsJT> Cars { get; set; } = new ObservableCollection<CarsJT>();
        private string _modelInput;
        private CarsJT _selectedCar;

        public string ModelInput
        {
            get => _modelInput;
            set => SetProperty(ref _modelInput, value);
        }

        public CarsJT SelectedCar
        {
            get => _selectedCar;
            set => SetProperty(ref _selectedCar, value);
        }

        public ICommand LoadCarsCommand { get; }
        public ICommand SelectCarCommand { get; }
        public ICommand SaveCarCommand { get; }

        public ApiListViewModelJT()
        {
            _carApiService = new CarApiServiceJT();
            LoadCarsCommand = new Command(async () => await LoadCarsAsync());
            SelectCarCommand = new Command(async () => await NavigateToCarDetailPage());
            SaveCarCommand = new Command(async () => await SaveCarToDatabase());
        }

        private async Task LoadCarsAsync()
        {
            if (string.IsNullOrWhiteSpace(ModelInput))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a car model", "OK");
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

        private async Task NavigateToCarDetailPage()
        {
            if (SelectedCar != null)
            {
                await Shell.Current.GoToAsync(nameof(CarsDetailPageJT)); 
            }
        }

        private async Task SaveCarToDatabase()
        {
            if (SelectedCar != null)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Car saved to database", "OK");
            }
        }
    }
}
