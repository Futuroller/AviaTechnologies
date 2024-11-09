using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Kursovoi_final
{
    public partial class AddZakazObsl : Window
    {
        private Entities.b_Zapchasti_dla_obslygivania _selectedZapchast;
        private Entities.b_Sotrudniki _currentUser;

        public AddZakazObsl(Entities.b_Zapchasti_dla_obslygivania selectedZapchast, Entities.b_Sotrudniki currentUser)
        {
            InitializeComponent();
            _selectedZapchast = selectedZapchast ?? throw new ArgumentNullException(nameof(selectedZapchast));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            LoadZapchasti();
            LoadSotrudniki();
            FillFormWithZapchastData(selectedZapchast, currentUser);
        }

        private void LoadZapchasti()
        {
            ComboBoxZapchasti.ItemsSource = App.Context.b_Zapchasti.ToList();
        }

        private void LoadSotrudniki()
        {
            ComboBoxSotrudniki.ItemsSource = App.Context.b_Sotrudniki.ToList();
        }

        private void FillFormWithZapchastData(Entities.b_Zapchasti_dla_obslygivania zapchast, Entities.b_Sotrudniki currentUser)
        {
            ComboBoxZapchasti.SelectedItem = zapchast.b_Zapchasti;
            TextBoxKolichestvo.Text = "1"; // Установите нужное количество
            DatePickerDataZakaza.SelectedDate = DateTime.Now;
            ComboBoxSotrudniki.SelectedItem = currentUser;
        }

        private void ButtonSohr_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            var selectedZapchast = ComboBoxZapchasti.SelectedItem as Entities.b_Zapchasti;

            var newZakaz = new Entities.b_Zakazi
            {
                ID_zapchasti = selectedZapchast.ID_zapchasti,
                Kolichestvo = int.Parse(TextBoxKolichestvo.Text),
                Data_zakaza = DatePickerDataZakaza.SelectedDate.Value,
                Status_zakaza = "Новый", // Установите нужный статус
                ID_sotrudnika = _currentUser.ID_sotrudnika
            };

            App.Context.b_Zakazi.Add(newZakaz);
            App.Context.SaveChanges();

            MessageBox.Show("Заказ успешно сохранен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
            this.Close();
        }

        private bool ValidateFields()
        {
            if (ComboBoxZapchasti.SelectedItem == null ||
                string.IsNullOrEmpty(TextBoxKolichestvo.Text) ||
                DatePickerDataZakaza.SelectedDate == null)
            {
                MessageBox.Show("Все поля должны быть заполнены.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}