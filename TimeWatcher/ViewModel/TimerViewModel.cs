using System;
using System.Threading.Tasks;
using TimeWatcher.Internal;
using TimeWatcher.Model;
using TimeWatcher.View;

namespace TimeWatcher.ViewModel
{
    public class TimerViewModel
    {
        private Command? _startTimer = null;
        private Command? _openSettings;
        private TimeWatcher.Model.Timer _timer = new TimeWatcher.Model.Timer();
        private System.Windows.Threading.DispatcherTimer _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private AppSettings _appSettings = new AppSettings();

        public TimeWatcher.Model.Timer Timer
        {
            get => _timer;
        }
        
        public AppSettings AppSettings
        {
            get => _appSettings;
        }

        public Command StartTimer
        {
            get => _startTimer ?? (_startTimer = new Command(
                obj =>
                {
                    _dispatcherTimer.Tick += new EventHandler(AddSecondToTimer);
                    Task.Delay(1000-DateTime.Now.Millisecond).Wait();
                    _dispatcherTimer.Interval = new TimeSpan(0, 0, 0,0,300);
                    _dispatcherTimer.Start();
                }
                )
                );
        }

        public Command OpenSettings
        {
            get => _openSettings ?? (_openSettings = new Command(
                obj =>
                {
                    SettingsWindow settingsWindow = new SettingsWindow();
                    if(obj != null)
                    {
                        settingsWindow.DataContext = obj;
                    }
                    settingsWindow.Show();
                }
                ));
        }

        private void AddSecondToTimer(object? sender, EventArgs e) => this.Timer.AddSecond();
    }
}
