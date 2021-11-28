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
using MedicalLaboratoryN20.Util;

namespace MedicalLaboratoryN20.Windows.Accountant
{
    /// <summary>
    /// Interaction logic for AccountantWindow.xaml
    /// </summary>
    public partial class AccountantWindow : Window
    {
        public AccountantWindow()
        {
            InitializeComponent();
            FioTB.Text = AppData.LoginUser.FirstName + " " + AppData.LoginUser.LastName;
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

        private void InsuranceAccountFormation(object sender, RoutedEventArgs e)
        {
            
        }

        private void SendReport(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
