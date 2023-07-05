using System.Windows;
using System.Windows.Media;

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

        private void MenuCloseItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
