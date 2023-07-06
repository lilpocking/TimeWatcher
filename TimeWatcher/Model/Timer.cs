using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimeWatcher.Model
{
    public class Timer : INotifyPropertyChanged
    {
        private DateTime _time = DateTime.Now;
        private bool _isSecondVisible = Settings.Default.IsSecondVisible;

        public int Hour
        {
            get => _time.Hour;
        }
        public int Minute
        {
            get => _time.Minute;
        }
        public int Second
        {
            get => _time.Second;
        }
        public int Millisecond
        {
            get => _time.Millisecond;
        }

        public bool IsSecondVisible
        {
            get => _isSecondVisible;
            set
            {
                _isSecondVisible = value;
                Settings.Default.IsSecondVisible = value;
                Settings.Default.Save();
                OnPropertyChanged();
            }
        }

        public void AddSecond()
        {
            _time = DateTime.Now;
            OnPropertyChanged(nameof(Hour));
            OnPropertyChanged(nameof(Minute));
            OnPropertyChanged(nameof(Second));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
