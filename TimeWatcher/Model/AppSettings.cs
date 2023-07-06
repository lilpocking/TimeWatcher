using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace TimeWatcher.Model
{
    public class AppSettings : INotifyPropertyChanged
    {
        private WindowStartupLocation _startupLocation = new WindowStartupLocation();
        private Color _foreground = Settings.Default.TextColor;
        private Color _background = Settings.Default.BackgroundColor;
        private bool _isBackgroundVisible = Settings.Default.IsBackgroundVisible;

        public WindowStartupLocation StartupLocation
        {
            get => _startupLocation;
        }

        public Color Foreground
        {
            get => _foreground;
            set {
                _foreground = value;
                Settings.Default.TextColor = value;
                Settings.Default.Save();
                OnPropertyChanged();
            }
        }
        public bool IsBackgroundVisible
        {
            get => _isBackgroundVisible;
            set {
                _isBackgroundVisible = value;
                Settings.Default.IsBackgroundVisible = value;
                Settings.Default.Save();
                OnPropertyChanged();
            }
        }
        public Color Background
        {
            get => _background;
            set {
                _background = value;
                Settings.Default.BackgroundColor = value;
                Settings.Default.Save();
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
