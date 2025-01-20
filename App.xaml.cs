using EvaluacionP3JT.ViewModelJT;

namespace EvaluacionP3JT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "cars.db3");
            var carDatabase = new ServicesJT.CarDatabaseJT(dbPath);

            MainPage = new NavigationPage(new ListPageJT(new ApiListViewModel(carDatabase)));
        }
    }
}
