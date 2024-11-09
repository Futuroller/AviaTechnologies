using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Kursovoi_final
{
    public partial class AddZakaz : Window
    {
        private Entities.b_Zakazi _currentZakaz;
        private bool _isEditing;

        public AddZakaz()
        {
            InitializeComponent();
            _isEditing = false;
            TextBlockZagolovok.Text = "Добавление заказа";
            LoadZapchasti();
            LoadSotrudniki();
        }

        public AddZakaz(Entities.b_Zakazi zakaz) : this()
        {
            _currentZakaz = zakaz;
            _isEditing = true;
            FillFormWithZakazData(zakaz);
            TextBlockZagolovok.Text = $"Редактирование заказа {zakaz.ID_zakaza}";
        }

        private void LoadZapchasti()
        {
            var zapchasti = App.Context.b_Zapchasti.ToList();
            ComboBoxZapchasti.ItemsSource = zapchasti;
        }

        private void LoadSotrudniki()
        {
            var sotrudniki = App.Context.b_Sotrudniki.ToList();
            ComboBoxSotrudniki.ItemsSource = sotrudniki;
        }

        private void FillFormWithZakazData(Entities.b_Zakazi zakaz)
        {
            ComboBoxZapchasti.SelectedItem = App.Context.b_Zapchasti.FirstOrDefault(z => z.ID_zapchasti == zakaz.ID_zapchasti);
            TextBoxKolichestvo.Text = zakaz.Kolichestvo.ToString();
            DatePickerDataZakaza.SelectedDate = zakaz.Data_zakaza;
            ComboBoxStatusZakaza.SelectedItem = ComboBoxStatusZakaza.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == zakaz.Status_zakaza);
            ComboBoxSotrudniki.SelectedItem = App.Context.b_Sotrudniki.FirstOrDefault(s => s.ID_sotrudnika == zakaz.ID_sotrudnika);
        }

        private void ButtonSohr_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (_isEditing)
            {
                UpdateZakaz();
            }
            else
            {
                AddNewZakaz();
            }

            MessageBox.Show("Заказ успешно сохранен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
            this.Close();
        }

        private void AddNewZakaz()
        {
            var selectedZapchast = ComboBoxZapchasti.SelectedItem as Entities.b_Zapchasti;
            var selectedSotrudnik = ComboBoxSotrudniki.SelectedItem as Entities.b_Sotrudniki;
            var selectedStatus = (ComboBoxStatusZakaza.SelectedItem as ComboBoxItem).Content.ToString();

            var newZakaz = new Entities.b_Zakazi
            {
                ID_zapchasti = selectedZapchast.ID_zapchasti,
                Kolichestvo = int.Parse(TextBoxKolichestvo.Text),
                Data_zakaza = DatePickerDataZakaza.SelectedDate.Value,
                Status_zakaza = selectedStatus,
                ID_sotrudnika = selectedSotrudnik.ID_sotrudnika
            };

            App.Context.b_Zakazi.Add(newZakaz);
            App.Context.SaveChanges();
        }

        private void UpdateZakaz()
        {
            var selectedZapchast = ComboBoxZapchasti.SelectedItem as Entities.b_Zapchasti;
            var selectedSotrudnik = ComboBoxSotrudniki.SelectedItem as Entities.b_Sotrudniki;
            var selectedStatus = (ComboBoxStatusZakaza.SelectedItem as ComboBoxItem).Content.ToString();

            _currentZakaz.ID_zapchasti = selectedZapchast.ID_zapchasti;
            _currentZakaz.Kolichestvo = int.Parse(TextBoxKolichestvo.Text);
            _currentZakaz.Data_zakaza = DatePickerDataZakaza.SelectedDate.Value;
            _currentZakaz.Status_zakaza = selectedStatus;
            _currentZakaz.ID_sotrudnika = selectedSotrudnik.ID_sotrudnika;

            App.Context.SaveChanges();
        }

        private bool ValidateFields()
        {
            if (ComboBoxZapchasti.SelectedItem == null ||
                string.IsNullOrEmpty(TextBoxKolichestvo.Text) ||
                DatePickerDataZakaza.SelectedDate == null ||
                ComboBoxStatusZakaza.SelectedItem == null ||
                ComboBoxSotrudniki.SelectedItem == null)
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