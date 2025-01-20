using EvaluacionP3JT.ListPageJT;
using EvaluacionP3JT.ViewModelJT;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EvaluacionP3JT.ModelsJT
{
    public class SavedCarsViewModel : BaseViewModelJT
    {
        private readonly ServicesJT.CarDatabaseJT _carDatabase;

        public ObservableCollection<CarsJT> SavedCars { get; set; } = new ObservableCollection<CarsJT>();

        public SavedCarsViewModel(ServicesJT.CarDatabaseJT carDatabase)
        {
            _carDatabase = carDatabase;
        }

        public async Task LoadSavedCarsAsync()
        {
            var cars = await _carDatabase.GetCarsAsync();
            SavedCars.Clear();
            foreach (var car in cars)
            {
                SavedCars.Add(car);
            }
        }
    }
}