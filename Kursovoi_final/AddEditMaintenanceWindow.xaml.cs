using System;
using System.Linq;
using System.Windows;
using Kursovoi_final.Entities;

namespace Kursovoi_final
{
    public partial class AddEditMaintenanceWindow : Window
    {
        private b_Tehnicheskoe_obsl _maintenance;
        private bool _isNew;

        public AddEditMaintenanceWindow(b_Tehnicheskoe_obsl maintenance)
        {
            InitializeComponent();
            _maintenance = maintenance;
            _isNew = maintenance == null;
            LoadAircrafts();
            if (!_isNew)
            {
                DescriptionTextBox.Text = _maintenance.Opisanie;
                MaintenanceDatePicker.SelectedDate = _maintenance.Data_obslygivania;
                AircraftComboBox.SelectedValue = _maintenance.ID_samoleta;
            }
        }

        private void LoadAircrafts()
        {
            var aircrafts = App.Context.b_Samolet.ToList();
            AircraftComboBox.ItemsSource = aircrafts;
            AircraftComboBox.DisplayMemberPath = "Nazvanie";
            AircraftComboBox.SelectedValuePath = "ID_samoleta";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DescriptionTextBox.Text))
            {
                MessageBox.Show("Описание не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_isNew)
            {
                _maintenance = new b_Tehnicheskoe_obsl
                {
                    Opisanie = DescriptionTextBox.Text,
                    Data_obslygivania = MaintenanceDatePicker.SelectedDate ?? DateTime.Now,
                    ID_samoleta = (int)AircraftComboBox.SelectedValue,
                    ID_tipa_obslygivania = 1, // Заглушка, нужно выбрать тип обслуживания
                    ID_sotrudnika = App.CurrentUser.ID_sotrudnika // Текущий пользователь
                };
                App.Context.b_Tehnicheskoe_obsl.Add(_maintenance);
            }
            else
            {
                _maintenance.Opisanie = DescriptionTextBox.Text;
                _maintenance.Data_obslygivania = MaintenanceDatePicker.SelectedDate ?? DateTime.Now;
                _maintenance.ID_samoleta = (int)AircraftComboBox.SelectedValue;
            }

            App.Context.SaveChanges();
            MessageBox.Show("Обслуживание сохранено.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}