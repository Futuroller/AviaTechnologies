using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kursovoi_final.Entities;

namespace Kursovoi_final
{
    public partial class MaintenanceManagement : Window
    {
        private List<b_Tehnicheskoe_obsl> _maintenances;

        public MaintenanceManagement()
        {
            InitializeComponent();
            LoadMaintenances();
        }

        private void LoadMaintenances()
        {
            _maintenances = App.Context.b_Tehnicheskoe_obsl.ToList();
            MaintenanceListBox.ItemsSource = _maintenances;
        }

        private void AddMaintenanceButton_Click(object sender, RoutedEventArgs e)
        {
            var addMaintenanceWindow = new AddEditMaintenanceWindow(null);
            addMaintenanceWindow.ShowDialog();
            LoadMaintenances();
        }

        private void ButtonVihod_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterMaintenances();
        }

        private void ClearSearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = string.Empty;
            FilterMaintenances();
        }

        private void FilterMaintenances()
        {
            var searchText = SearchTextBox.Text.ToLower();

            var filteredMaintenances = _maintenances
                .Where(m => m.Opisanie.ToLower().Contains(searchText))
                .ToList();

            MaintenanceListBox.ItemsSource = filteredMaintenances;
        }
    }
}