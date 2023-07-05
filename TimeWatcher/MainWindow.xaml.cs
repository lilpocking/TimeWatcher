using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeWatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TimeWatcher.ViewModel.TimerViewModel timer = new TimeWatcher.ViewModel.TimerViewModel();
            timer.StartTimer.Execute(null);
            TimerView.Foreground = new SolidColorBrush(new Color() { 
                A = Settings.Default.TextColor.A,
                R = Settings.Default.TextColor.R, 
                B = Settings.Default.TextColor.B,
                G = Settings.Default.TextColor.G
            });
            this.Width = Settings.Default.Width;
            this.Height = Settings.Default.Height;

            switch (Settings.Default.StartupLocation)
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

            this.DataContext = timer;
        }
    }
}
