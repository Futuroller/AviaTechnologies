using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kursovoi_final.Entities;

namespace Kursovoi_final
{
    public partial class Mechanic : Window
    {
        private List<b_Zapchasti> _parts;
        private List<b_Proizvoditeli> _manufacturers;

        public Mechanic()
        {
            InitializeComponent();
            LoadParts();
            LoadManufacturers();
        }

        private void LoadParts()
        {
            _parts = App.Context.b_Zapchasti.ToList();
            PartsListBox.ItemsSource = _parts;
        }

        private void LoadManufacturers()
        {
            _manufacturers = App.Context.b_Proizvoditeli.ToList();
            _manufacturers.Insert(0, new b_Proizvoditeli { ID_proizvoditela = 0, Nazvanie = "Все" });
            ManufacturerComboBox.ItemsSource = _manufacturers;
            ManufacturerComboBox.DisplayMemberPath = "Nazvanie";
            ManufacturerComboBox.SelectedValuePath = "ID_proizvoditela";
            ManufacturerComboBox.SelectedIndex = 0;
        }

        private void AddToRequestButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedParts = _parts.Where(p => p.IsSelected).ToList();
            if (selectedParts.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один товар.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var requestWindow = new PartsRequestWindow(selectedParts);
            requestWindow.ShowDialog();
        }

        private void ButtonVihod_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите выйти из аккаунта?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
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

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterParts();
        }

        private void ManufacturerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterParts();
        }

        private void ClearSearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = string.Empty;
            ManufacturerComboBox.SelectedIndex = 0;
            FilterParts();
        }

        private void FilterParts()
        {
            var searchText = SearchTextBox.Text.ToLower();
            var selectedManufacturerId = (int)ManufacturerComboBox.SelectedValue;

            var filteredParts = _parts
                .Where(p => p.Nazvanie.ToLower().Contains(searchText) &&
                            (selectedManufacturerId == 0 || p.ID_proizvoditela == selectedManufacturerId))
                .ToList();

            PartsListBox.ItemsSource = filteredParts;
        }

        private void ManageMaintenancesButton_Click(object sender, RoutedEventArgs e)
        {
            var maintenanceManagementWindow = new MaintenanceManagement();
            maintenanceManagementWindow.ShowDialog();
        }

        private void AddMaintenanceButton_Click(object sender, RoutedEventArgs e)
        {
            var addMaintenanceWindow = new AddEditMaintenanceWindow(null);
            addMaintenanceWindow.ShowDialog();
        }
    }
}