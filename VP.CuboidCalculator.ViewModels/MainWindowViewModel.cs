using System;
using VP.CuboidCalculator.Model;

namespace VP.CuboidCalculator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string CubeHeight { get { return GetFieldWhereDefaultValueIs(""); } set { SetField(value); } }
        public string CubeWidth { get { return GetFieldWhereDefaultValueIs(""); } set { SetField(value); } }
        public string CubeLength { get { return GetFieldWhereDefaultValueIs(""); } set { SetField(value); } }
        public string CubeVolume { get { return GetFieldWhereDefaultValueIs(""); } set { SetField(value); } }
        public string CubeArea { get { return GetFieldWhereDefaultValueIs(""); } set { SetField(value); } }

        private Cube _cube;

        private void CalculateCube()
        {
            try
            {
                ParseInput();
            }
            catch (FormatException)
            {
                return;
            }
            catch (ArgumentNullException)
            {
                return;
            }
            catch (OverflowException)
            {
                return;
            }
            CubeArea = $"{_cube.GetArea() / (100 * 100)}m² {_cube.GetArea()}cm²";
            CubeVolume = $"{_cube.GetVolume()/(100*100*100)}m³ {_cube.GetVolume()/(10*10*10)}(dm³)L {_cube.GetVolume()}cm³";
        }

        private void ParseInput()
        {
            _cube = Cube.FromStrings(CubeWidth, CubeHeight, CubeLength);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            CalculateCube();
        }
    }
}
