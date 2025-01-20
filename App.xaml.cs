using EvaluacionP3JT.ListPageJT;
using EvaluacionP3JT.ViewModelJT;

namespace EvaluacionP3JT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "carjt.db3");
            var carDatabase = new ServicesJT.CarDatabaseJT(dbPath);
            var viewModel = new ApiListViewModelJT();
        }
    }
}