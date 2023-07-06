using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TimeWatcher.Internal;

namespace TimeWatcher.Model
{
    public class WindowStartupLocation : INotifyPropertyChanged
    {
        private StartupLocation _startupLocation;
        private double _left = 0;
        private double _top = 0;
        private double _width = Settings.Default.Width;
        private double _height = Settings.Default.Height;

        public WindowStartupLocation()
        {
            _startupLocation = (StartupLocation)Settings.Default.StartupLocation;
            Configure();
        }

        public Array StartupLocations
        {
            get => Enum.GetValues(typeof(StartupLocation));
        }
        public StartupLocation StartupLocation
        {
            get {
                return _startupLocation;
            }
            set {
                _startupLocation = value;
                Settings.Default.StartupLocation = (int)_startupLocation;
                Settings.Default.Save();
                Configure();
                OnPropertyChanged();
            }
        }

        public double Left
        {
            get => _left;
            set
            {
                _left = value;
                OnPropertyChanged();
            }
        }
        public double Top
        {
            get => _top;
            set
            {
                _top = value;
                OnPropertyChanged();
            }
        }
        public double Width
        {
            get => _width;
        }
        public double Height
        {
            get => _height;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void Configure()
        {
            switch ((StartupLocation)Settings.Default.StartupLocation)
            {
                case Internal.StartupLocation.LeftTop:
                    this.Left = 0;
                    this.Top = 0;
                    break;
                case Internal.StartupLocation.RightTop:
                    this.Left = SystemParameters.FullPrimaryScreenWidth - this.Width;
                    this.Top = 0;
                    break;
                case Internal.StartupLocation.LeftBottom:
                    this.Left = 0;
                    this.Top = SystemParameters.PrimaryScreenHeight - this.Height;
                    break;
                case Internal.StartupLocation.RightBottom:
                    this.Top = SystemParameters.PrimaryScreenHeight - this.Height;
                    this.Left = SystemParameters.FullPrimaryScreenWidth - this.Width;
                    break;
            }
        }
    }
}
