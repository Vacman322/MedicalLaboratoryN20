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
using System.Windows.Threading;
using MedicalLaboratoryN20.EF;
using MedicalLaboratoryN20.Util;
using MedicalLaboratoryN20.Windows.Accountant;
using MedicalLaboratoryN20.Windows.Admin;
using MedicalLaboratoryN20.Windows.Laborant;
using MedicalLaboratoryN20.Windows.LaborantResearcher;

namespace MedicalLaboratoryN20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Captcha _captcha = new Captcha();
        bool _isLoginEabled = true;

        public LoginWindow()
        {
            InitializeComponent();
            var dialog = new PrintDialog();
        }

        /// <summary>
        /// Показывает пароль
        /// </summary>
        private void ShowPasswordChecked(object sender, RoutedEventArgs e)
        {
            PasswordPB.Visibility = Visibility.Collapsed;
            PasswordTB.Visibility = Visibility.Visible;
            PasswordTB.Text = PasswordPB.Password;

            PasswordTB.Focus();
        }

        /// /// <summary>
        /// Скрывает пароль
        /// </summary>
        private void ShowPasswordUnchecked(object sender, RoutedEventArgs e)
        {
            PasswordPB.Visibility = Visibility.Visible;
            PasswordTB.Visibility = Visibility.Collapsed;
            PasswordPB.Password = PasswordTB.Text;

            PasswordPB.Focus();
        }

        /// <summary>
        /// Обработка нажатия на кнопку входа
        /// </summary>
        private void Login(object sender, RoutedEventArgs e)
        {
            if (!_isLoginEabled || AppData.EnableLoginDate > DateTime.Now)
            {
                MessageBox.Show("Вход временно заблокирован!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var login = LoginTB.Text;
            var password = PasswordPB.Visibility == Visibility.Collapsed ? PasswordTB.Text : PasswordPB.Password;

            if (!ValidateLogin(login, password))
            {
                if (CapthcaGB.Visibility != Visibility.Visible)
                    CapthcaGB.Visibility = Visibility.Visible;
                GenerateCaptcha();
                CreateNewEnterHistoryRecord(login, false);
                DisableLogin(new TimeSpan(0, 0, 10).Ticks);
                return;
            }

            var user = Db.Context.User.FirstOrDefault(r => r.Login == login);
            AppData.LoginUser = user;
            var roleID = user.TypeID;
            CreateNewEnterHistoryRecord(login, true);
            user.LastEnter = DateTime.Now;
            Db.Context.SaveChanges();
            switch (roleID)
            {
                //лаборант
                case 1:
                    new LaborantWindow().Show();
                    break;
                //лаборант-исследователь 
                case 2:
                    new LaborantResearcherWindow().Show();
                    break;
                //бухгалтер
                case 3:
                    new AccountantWindow().Show();
                    break;
                //администратор
                case 4:
                    new AdminWindow().Show();
                    break;
            }
            Close();
        }

        /// <summary>
        /// Запрещает вход на 10 секунд
        /// </summary>
        private void DisableLogin(long ticks)
        {
            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(ticks);
            timer.Tick += new EventHandler(EnableLogin);
            _isLoginEabled = false;
            this.IsEnabled = false;
            timer.Start();
        }

        /// <summary>
        /// Разрешает вход и отключает таймер
        /// </summary>
        private void EnableLogin(object sender, EventArgs e)
        {
            var timer = (DispatcherTimer)sender;
            timer.Stop();
            _isLoginEabled = true;
            this.IsEnabled = true;
        }

        /// <summary>
        /// Создание новой записи для истории входов
        /// </summary>
        private static void CreateNewEnterHistoryRecord(string login, bool isSuccess)
        {
            var eh = new EnterHistory
            {
                UserLogin = login,
                Time = DateTime.Now,
                IsSuccess = isSuccess
            };
            Db.Context.EnterHistory.Add(eh);
            Db.Context.SaveChanges();
        }

        /// <summary>
        /// Проверка введённых данных
        /// </summary>
        private bool ValidateLogin(string login, string password)
        {
            var user = Db.Context.User.FirstOrDefault(r => r.Login == login);

            if (string.IsNullOrWhiteSpace(LoginTB.Text) ||
                (PasswordTB.Visibility == Visibility.Visible && string.IsNullOrWhiteSpace(PasswordTB.Text)) ||
                (PasswordPB.Visibility == Visibility.Visible && string.IsNullOrWhiteSpace(PasswordPB.Password)))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (user is null)
            {
                MessageBox.Show("Неверный логин!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (user.Password != password)
            {
                MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            if (CapthcaGB.Visibility != Visibility.Collapsed && EnteredCaptcha.Text != _captcha.Value)
            {
                MessageBox.Show("Неверная капча!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Обновление капчи
        /// </summary>
        private void GenerateCaptcha()
        {
            _captcha.Generate();
            Captcha1.Text = _captcha.Value[0].ToString();
            Captcha2.Text = _captcha.Value[1].ToString();
            Captcha3.Text = _captcha.Value[2].ToString();
            Captcha4.Text = _captcha.Value[3].ToString();
        }

        private void RefreshCaptcha(object sender, RoutedEventArgs e)
        {
            GenerateCaptcha();
        }
    }
}
