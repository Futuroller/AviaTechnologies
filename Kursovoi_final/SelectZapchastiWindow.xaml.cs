using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kursovoi_final.Entities;

namespace Kursovoi_final
{
    public partial class SelectZapchastiWindow : Window
    {
        private b_Tehnicheskoe_obsl _selectedTehnicheskoeObsl;

        public SelectZapchastiWindow(b_Tehnicheskoe_obsl selectedTehnicheskoeObsl)
        {
            InitializeComponent();
            _selectedTehnicheskoeObsl = selectedTehnicheskoeObsl ?? throw new ArgumentNullException(nameof(selectedTehnicheskoeObsl));
            LoadZapchasti();
            LoadSotrudnik();
        }

        private void LoadZapchasti()
        {
            var zapchast = _selectedTehnicheskoeObsl.b_Zapchasti_dla_obslygivania.FirstOrDefault()?.b_Zapchasti;
            if (zapchast != null)
            {
                TextBoxZapchasti.Text = zapchast.Nazvanie;
            }
            else
            {
                TextBoxZapchasti.Text = "Деталь не указана";
            }
        }

        private void LoadSotrudnik()
        {
            var sotrudnik = _selectedTehnicheskoeObsl.b_Sotrudniki;
            if (sotrudnik != null)
            {
                TextBlockSotrudnik.Text = $"{sotrudnik.Familia} {sotrudnik.Name} {sotrudnik.Otchestvo}";
            }
            else
            {
                TextBlockSotrudnik.Text = "Сотрудник не указан";
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            var selectedZapchast = _selectedTehnicheskoeObsl.b_Zapchasti_dla_obslygivania.FirstOrDefault()?.b_Zapchasti;

            var newZapchastiDlaObslygivania = new b_Zapchasti_dla_obslygivania
            {
                ID_tehnicheskoe_obsl = _selectedTehnicheskoeObsl.ID_tehnicheskoe_obsl,
                ID_zapchasti = selectedZapchast.ID_zapchasti
            };

            App.Context.b_Zapchasti_dla_obslygivania.Add(newZapchastiDlaObslygivania);
            _selectedTehnicheskoeObsl.IsOrdered = true; // Устанавливаем флаг IsOrdered
            App.Context.SaveChanges();

            MessageBox.Show("Запчасть добавлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
            this.Close();
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(TextBoxZapchasti.Text) || TextBoxZapchasti.Text == "Деталь не указана")
            {
                MessageBox.Show("Запчасть не выбрана.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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