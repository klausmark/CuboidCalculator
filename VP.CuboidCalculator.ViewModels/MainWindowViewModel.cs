using System;
using VP.CuboidCalculator.Model;

namespace VP.CuboidCalculator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string CuboidHeight { get { return GetFieldWhereDefaultValueIs(""); } set { SetField(value); } }
        public string CuboidWidth { get { return GetFieldWhereDefaultValueIs(""); } set { SetField(value); } }
        public string CuboidLength { get { return GetFieldWhereDefaultValueIs(""); } set { SetField(value); } }
        public string CuboidVolume { get { return GetFieldWhereDefaultValueIs(""); } set { SetField(value); } }
        public string CuboidArea { get { return GetFieldWhereDefaultValueIs(""); } set { SetField(value); } }

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
            CuboidArea = $"{_cuboid.GetArea() / (100 * 100)}m² {_cuboid.GetArea()}cm²";
            CuboidVolume = $"{_cuboid.GetVolume()/(100*100*100)}m³ {_cuboid.GetVolume()/(10*10*10)}(dm³)L {_cuboid.GetVolume()}cm³";
        }

        private void ParseInput()
        {
            _cuboid = Cuboid.FromStrings(CuboidWidth, CuboidHeight, CuboidLength);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            CalculateCube();
        }
    }
}
