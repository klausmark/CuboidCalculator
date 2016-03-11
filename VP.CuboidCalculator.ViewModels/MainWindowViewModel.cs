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

        private Cuboid _cuboid;

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
            CubeArea = $"{_cuboid.GetArea() / (100 * 100)}m² {_cuboid.GetArea()}cm²";
            CubeVolume = $"{_cuboid.GetVolume()/(100*100*100)}m³ {_cuboid.GetVolume()/(10*10*10)}(dm³)L {_cuboid.GetVolume()}cm³";
        }

        private void ParseInput()
        {
            _cuboid = Cuboid.FromStrings(CubeWidth, CubeHeight, CubeLength);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            CalculateCube();
        }
    }
}
