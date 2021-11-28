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
using System.Windows.Shapes;
using System.Windows.Threading;
using MedicalLaboratoryN20.Util;

namespace MedicalLaboratoryN20.Windows.LaborantResearcher
{
    /// <summary>
    /// Interaction logic for LaborantResearcherWindow.xaml
    /// </summary>
    public partial class LaborantResearcherWindow : Window
    {
        DispatcherTimer timer;
        Time timeLeft;
        public LaborantResearcherWindow()
        {
            InitializeComponent();
            StartTimer();
            FioTB.Text = AppData.LoginUser.FirstName + " " + AppData.LoginUser.LastName;
        }

        /// <summary>
        /// Запуск таймера
        /// </summary>
        private void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 1, 0);
            timer.Tick += new EventHandler(TimerTick);
            timeLeft = new Time(10);
            timer.Start();
            TimerTB.Text = timeLeft.ToString();
        }

        /// <summary>
        /// Событие тика таймера
        /// </summary>
        private void TimerTick(object sender, EventArgs e)
        {
            if (timeLeft.Minutes == 5 && timeLeft.Hours == 0)
            {
                MessageBox.Show("До завершения сеанса осталось 5 минут!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (!timeLeft.NextMinutes())
                TimerEnd();
            TimerTB.Text = timeLeft.ToString();
        }

        /// <summary>
        /// Событие завершения таймера
        /// </summary>
        private void TimerEnd()
        {
            timer.Stop();
            new LoginWindow().Show();
            AppData.EnableLoginDate = DateTime.Now.AddMinutes(1);
            Close();
        }

        /// <summary>
        /// Обработка события нажатия на кнопку выйти
        /// </summary>
        private void ExitClick(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void AnalyzerClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
