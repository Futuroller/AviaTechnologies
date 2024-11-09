using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Kursovoi_final.Entities;

namespace Kursovoi_final
{
    public partial class PartsRequestWindow : Window
    {
        private List<b_Zapchasti> _selectedParts;
        private List<b_Tehnicheskoe_obsl> _maintenances;

        public PartsRequestWindow(List<b_Zapchasti> selectedParts)
        {
            InitializeComponent();
            _selectedParts = selectedParts;
            SelectedPartsListBox.ItemsSource = _selectedParts;
            LoadMaintenances();
        }

        private void LoadMaintenances()
        {
            _maintenances = App.Context.b_Tehnicheskoe_obsl.ToList();
            MaintenanceComboBox.ItemsSource = _maintenances;
        }

        private void CreateRequestButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedMaintenance = MaintenanceComboBox.SelectedItem as b_Tehnicheskoe_obsl;
            if (selectedMaintenance == null)
            {
                MessageBox.Show("Выберите обслуживание.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (var part in _selectedParts)
            {
                var request = new b_Zapchasti_dla_obslygivania
                {
                    ID_tehnicheskoe_obsl = selectedMaintenance.ID_tehnicheskoe_obsl,
                    ID_zapchasti = part.ID_zapchasti
                };
                App.Context.b_Zapchasti_dla_obslygivania.Add(request);
            }

            App.Context.SaveChanges();
            MessageBox.Show("Заявка создана.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}