using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvaluacionP3JT.ModelsJT;
using System.Windows.Input;
using EvaluacionP3JT.ViewModelJT;


namespace EvaluacionP3JT.ListPageJT
{
    public class CarDetailViewModelJT : BaseViewModelJT
    {
        private readonly ServicesJT.CarDatabaseJT _carDatabase;

        public CarsJT SelectedCar { get; set; }
        public ICommand SaveCarCommand { get; }

        public CarDetailViewModelJT(ServicesJT.CarDatabaseJT carDatabase, CarsJT selectedCar)
        {
            _carDatabase = carDatabase;
            SelectedCar = selectedCar;
            SaveCarCommand = new Command(async () => await SaveCarAsync());
        }

        private async Task SaveCarAsync()
        {
            await _carDatabase.SaveCarAsync(SelectedCar);
            await Application.Current.MainPage.DisplayAlert("Success", "Car saved!", "OK");
        }
    }
}
