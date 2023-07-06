using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using TimeWatcher.Internal;

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

            this.Foreground = new SolidColorBrush(new Color()
            {
                A = Settings.Default.TextColor.A,
                R = Settings.Default.TextColor.R,
                B = Settings.Default.TextColor.B,
                G = Settings.Default.TextColor.G
            });

            this.DataContext = timer;
        }

        private void MenuCloseItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
