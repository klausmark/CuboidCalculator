using VP.CuboidCalculator.ViewModels;

namespace VP.CuboidCalculator.View.Helpers
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel { get; }

        public ViewModelLocator()
        {
            MainWindowViewModel = new MainWindowViewModel();
        }
    }
}
