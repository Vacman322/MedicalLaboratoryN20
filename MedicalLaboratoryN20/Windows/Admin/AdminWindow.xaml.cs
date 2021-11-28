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
using MedicalLaboratoryN20.EF;

namespace MedicalLaboratoryN20.Windows.Admin
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private bool sortAscending = true;
        public AdminWindow()
        {
            InitializeComponent();
            HistoryLV.ItemsSource = Db.Context.EnterHistory.ToList();
        }

        /// <summary>
        /// Обновление таблицы с историей с учётом всех фильтров и сортировок
        /// </summary>
        private void UpdateHistoryLV()
        {
            var result = Db.Context.EnterHistory.ToList();

            if (!string.IsNullOrWhiteSpace(LoginSearchTB.Text))
            {
                result = result
                    .Where(r => r.UserLogin.Contains(LoginSearchTB.Text))
                    .ToList();
            }

            if (sortAscending)
            {
                result = result
                    .OrderBy(r => r.Time)
                    .ToList();
            }
            else
            {
                result = result
                    .OrderByDescending(r => r.Time)
                    .ToList();
            }

            HistoryLV.ItemsSource = result;
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

        /// <summary>
        /// Обработка события изменения текста в блоке поиска
        /// </summary>
        private void LoginSearchTBTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateHistoryLV();
        }

        /// <summary>
        /// Обработка события нажатия на кнопку сортировать по дате
        /// </summary>
        private void SortForDateClick(object sender, RoutedEventArgs e)
        {
            sortAscending = !sortAscending;
            UpdateHistoryLV();
        }
    }
}
