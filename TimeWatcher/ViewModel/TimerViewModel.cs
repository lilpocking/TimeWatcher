using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using TimeWatcher.Internal;
using TimeWatcher.Model;

namespace TimeWatcher.ViewModel 
{
    public class TimerViewModel
    {
        private Command? _startTimer = null;
        private Timer _timer = new Timer();
        private System.Windows.Threading.DispatcherTimer _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public Timer Timer { 
            get => _timer;
        }

        public Command StartTimer
        {
            get => _startTimer ?? (_startTimer = new Command(
                obj =>
                {
                    _dispatcherTimer.Tick += new EventHandler(AddSecondToTimer);
                    _dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                    _dispatcherTimer.Start();
                }
                )
                );
        }

        private void AddSecondToTimer(object? sender, EventArgs e) => Timer.AddSecond();
    }
}
