﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TimeWatcher.Model
{
    public class Timer : INotifyPropertyChanged
    {
        private DateTime _time = DateTime.Now;

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
