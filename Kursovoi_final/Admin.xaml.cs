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
using System.Data;
using System.Data.SqlClient;
using Kursovoi_final.Entities;

namespace Kursovoi_final
{
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            LoadRoles();
            LoadSotrudniki();
        }

        private void LoadRoles()
        {
            var roles = App.Context.b_role.ToList();
            roles.Insert(0, new b_role { ID_role = -1, Nazvanie = "Все роли" });
            CmbRoles.ItemsSource = roles;
            CmbRoles.SelectedIndex = 0; // Выбираем "Все роли" по умолчанию
        }

        private void LoadSotrudniki()
        {
            var sotrudniki = App.Context.b_Sotrudniki.Include("b_role").ToList();
            LstBoxSotrudniki.ItemsSource = sotrudniki;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedSotrudnik = (sender as Button).DataContext as Entities.b_Sotrudniki;

            if (selectedSotrudnik == null)
            {
                MessageBox.Show("Выберите сотрудника для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var sotrudnikToEdit = App.Context.b_Sotrudniki.FirstOrDefault(s => s.ID_sotrudnika == selectedSotrudnik.ID_sotrudnika);

            if (sotrudnikToEdit != null)
            {
                var addEditWindow = new AddSotrudnik(sotrudnikToEdit);
                bool? result = addEditWindow.ShowDialog();

                if (result == true)
                {
                    LoadSotrudniki();
                }
            }
            else
            {
                MessageBox.Show("Сотрудник не найден в базе данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonDobavit_Click(object sender, RoutedEventArgs e)
        {
            var addSotrudnikWindow = new AddSotrudnik();
            addSotrudnikWindow.Closed += (s, args) => LoadSotrudniki();
            addSotrudnikWindow.ShowDialog();
        }

        private void ButtonVihod_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите выйти из аккаунта?", "Внимание",
MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Window MainWindow = new MainWindow();
                    MainWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void ButtonUdalit_Click(object sender, RoutedEventArgs e)
        {
            var selectedSotrudnik = LstBoxSotrudniki.SelectedItem as Entities.b_Sotrudniki;

            if (selectedSotrudnik == null)
            {
                MessageBox.Show("Выберите сотрудника для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Подтверждение удаления
            var result = MessageBox.Show("Вы уверены, что хотите удалить выбранного сотрудника?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                // Удаляем сотрудника из базы данных
                App.Context.b_Sotrudniki.Remove(selectedSotrudnik);
                App.Context.SaveChanges();

                // Обновляем список сотрудников
                LoadSotrudniki();
            }
        }

        private void CmbRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRole = CmbRoles.SelectedItem as b_role;

            if (selectedRole != null)
            {
                if (selectedRole.ID_role == -1)
                {
                    LoadSotrudniki(); // Сброс фильтра
                }
                else
                {
                    var sotrudniki = App.Context.b_Sotrudniki.Include("b_role").Where(s => s.ID_role == selectedRole.ID_role).ToList();
                    LstBoxSotrudniki.ItemsSource = sotrudniki;
                }
            }
        }
    }
}