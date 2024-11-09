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
using System.Data.Entity;

namespace Kursovoi_final
{
    public partial class Manager : Window
    {
        public Manager()
        {
            InitializeComponent();
            LoadZakazi();
            LoadZapchastiDlaObslygivania();
            ShowZakazi(); // Устанавливаем видимость элементов, связанных с заказами
        }

        private void LoadZakazi()
        {
            var zakazi = App.Context.b_Zakazi
                .Include(z => z.b_Zapchasti)
                .Include(z => z.b_Sotrudniki)
                .ToList();

            LstBoxZakazi.ItemsSource = zakazi;
        }

        private void LoadZapchastiDlaObslygivania()
        {
            var zapchastiDlaObslygivania = App.Context.b_Zapchasti_dla_obslygivania
                .Include(z => z.b_Zapchasti)
                .Include(z => z.b_Tehnicheskoe_obsl.b_Samolet)
                .Include(z => z.b_Tehnicheskoe_obsl.b_Tip_obslygivania)
                .Include(z => z.b_Tehnicheskoe_obsl.b_Sotrudniki)
                .ToList();

            LstBoxZapchastiDlaObslygivania.ItemsSource = zapchastiDlaObslygivania;
        }

        private void ButtonZakazi_Click(object sender, RoutedEventArgs e)
        {
            ShowZakazi();
            TextBlockZakazi.Visibility = Visibility.Visible;
            TextBlockZapchastiDlaObslygivania.Visibility = Visibility.Collapsed;
        }

        private void ButtonZapchastiDlaObslygivania_Click(object sender, RoutedEventArgs e)
        {
            ShowZapchastiDlaObslygivania();
            TextBlockZakazi.Visibility = Visibility.Collapsed;
            TextBlockZapchastiDlaObslygivania.Visibility = Visibility.Visible;
        }

        private void ShowZakazi()
        {
            LstBoxZakazi.Visibility = Visibility.Visible;
            LstBoxZapchastiDlaObslygivania.Visibility = Visibility.Collapsed;
            ButtonDobavit.Visibility = Visibility.Visible;
            ButtonUdalit.Visibility = Visibility.Visible;
            SortComboBox.Visibility = Visibility.Visible;
            TextBlockSort.Visibility = Visibility.Visible;
        }

        private void ShowZapchastiDlaObslygivania()
        {
            LstBoxZakazi.Visibility = Visibility.Collapsed;
            LstBoxZapchastiDlaObslygivania.Visibility = Visibility.Visible;
            ButtonDobavit.Visibility = Visibility.Collapsed;
            ButtonUdalit.Visibility = Visibility.Collapsed;
            SortComboBox.Visibility = Visibility.Collapsed;
            TextBlockSort.Visibility = Visibility.Collapsed;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedZakaz = (sender as Button).DataContext as Entities.b_Zakazi;

            if (selectedZakaz == null)
            {
                MessageBox.Show("Выберите заказ для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var zakazToEdit = App.Context.b_Zakazi.FirstOrDefault(z => z.ID_zakaza == selectedZakaz.ID_zakaza);

            if (zakazToEdit != null)
            {
                var addEditWindow = new AddZakaz(zakazToEdit);
                bool? result = addEditWindow.ShowDialog();

                if (result == true)
                {
                    LoadZakazi();
                }
            }
            else
            {
                MessageBox.Show("Заказ не найден в базе данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonZakaz_Click(object sender, RoutedEventArgs e)
        {
            var selectedZapchast = (sender as Button).DataContext as Entities.b_Zapchasti_dla_obslygivania;

            if (selectedZapchast == null)
            {
                MessageBox.Show("Выберите запчасть для заказа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var zakazWindow = new AddZakazObsl(selectedZapchast, App.CurrentUser);
            zakazWindow.Closed += (s, args) => LoadZapchastiDlaObslygivania();
            zakazWindow.ShowDialog();
        }

        private void ButtonDobavit_Click(object sender, RoutedEventArgs e)
        {
            var addZakazWindow = new AddZakaz();
            addZakazWindow.Closed += (s, args) => LoadZakazi();
            addZakazWindow.ShowDialog();
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
            var selectedZakaz = LstBoxZakazi.SelectedItem as Entities.b_Zakazi;

            if (selectedZakaz == null)
            {
                MessageBox.Show("Выберите заказ для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Подтверждение удаления
            var result = MessageBox.Show("Вы уверены, что хотите удалить выбранный заказ?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                // Удаляем заказ из базы данных
                App.Context.b_Zakazi.Remove(selectedZakaz);
                App.Context.SaveChanges();

                // Обновляем список заказов
                LoadZakazi();
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LstBoxZakazi.Visibility == Visibility.Visible)
            {
                FilterZakazi();
            }
            else if (LstBoxZapchastiDlaObslygivania.Visibility == Visibility.Visible)
            {
                FilterZapchastiDlaObslygivania();
            }
        }

        private void ClearSearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = string.Empty;
            SortComboBox.SelectedIndex = -1; // Сброс сортировки
            if (LstBoxZakazi.Visibility == Visibility.Visible)
            {
                FilterZakazi();
            }
            else if (LstBoxZapchastiDlaObslygivania.Visibility == Visibility.Visible)
            {
                FilterZapchastiDlaObslygivania();
            }
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstBoxZakazi.Visibility == Visibility.Visible)
            {
                FilterZakazi();
            }
            else if (LstBoxZapchastiDlaObslygivania.Visibility == Visibility.Visible)
            {
                FilterZapchastiDlaObslygivania();
            }
        }

        private void FilterZakazi()
        {
            var searchText = SearchTextBox.Text.ToLower();
            var sortOrder = SortComboBox.SelectedIndex;

            var allZakazi = App.Context.b_Zakazi
                .Include(z => z.b_Zapchasti)
                .Include(z => z.b_Sotrudniki)
                .ToList();

            var filteredZakazi = allZakazi
                .Where(z =>
                    z.b_Zapchasti.Nazvanie.ToLower().Contains(searchText) ||
                    z.Kolichestvo.ToString().Contains(searchText) ||
                    z.Data_zakaza.ToString("dd.MM.yyyy").Contains(searchText) ||
                    z.Status_zakaza.ToLower().Contains(searchText) ||
                    (z.b_Sotrudniki.Familia + " " + z.b_Sotrudniki.Name + " " + z.b_Sotrudniki.Otchestvo).ToLower().Contains(searchText)
                )
                .ToList();

            if (sortOrder == 0) // По возрастанию
            {
                filteredZakazi = filteredZakazi.OrderBy(z => z.Kolichestvo).ToList();
            }
            else if (sortOrder == 1) // По убыванию
            {
                filteredZakazi = filteredZakazi.OrderByDescending(z => z.Kolichestvo).ToList();
            }

            LstBoxZakazi.ItemsSource = filteredZakazi;
        }

        private void FilterZapchastiDlaObslygivania()
        {
            var searchText = SearchTextBox.Text.ToLower();

            var allZapchastiDlaObslygivania = App.Context.b_Zapchasti_dla_obslygivania
                .Include(z => z.b_Zapchasti)
                .Include(z => z.b_Tehnicheskoe_obsl.b_Samolet)
                .Include(z => z.b_Tehnicheskoe_obsl.b_Tip_obslygivania)
                .Include(z => z.b_Tehnicheskoe_obsl.b_Sotrudniki)
                .ToList();

            var filteredZapchastiDlaObslygivania = allZapchastiDlaObslygivania
                .Where(z =>
                    z.b_Zapchasti.Nazvanie.ToLower().Contains(searchText) ||
                    z.b_Tehnicheskoe_obsl.Data_obslygivania.ToString("dd.MM.yyyy").Contains(searchText) ||
                    z.b_Tehnicheskoe_obsl.b_Samolet.Nazvanie.ToLower().Contains(searchText) ||
                    z.b_Tehnicheskoe_obsl.b_Tip_obslygivania.Nazvanie.ToLower().Contains(searchText) ||
                    z.b_Tehnicheskoe_obsl.b_Sotrudniki.Familia.ToLower().Contains(searchText) ||
                    z.b_Tehnicheskoe_obsl.b_Sotrudniki.Name.ToLower().Contains(searchText) ||
                    z.b_Tehnicheskoe_obsl.b_Sotrudniki.Otchestvo.ToLower().Contains(searchText)
                )
                .ToList();

            LstBoxZapchastiDlaObslygivania.ItemsSource = filteredZapchastiDlaObslygivania;
        }
    }
}