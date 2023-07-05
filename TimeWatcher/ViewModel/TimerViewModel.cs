using System;
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
