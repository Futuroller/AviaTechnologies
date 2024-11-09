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
using System.Data.SqlClient;

namespace Kursovoi_final
{
    public partial class AddSotrudnik : Window
    {
        private Entities.b_Sotrudniki _currentSotrudnik;
        private bool _isEditing;

        public AddSotrudnik()
        {
            InitializeComponent();
            LoadRoles();
            _isEditing = false;
            TextBlockZagolovok.Text = "Добавление сотрудника";
        }

        public AddSotrudnik(Entities.b_Sotrudniki sotrudnik) : this()
        {
            _currentSotrudnik = sotrudnik;
            _isEditing = true;
            FillFormWithSotrudnikData(sotrudnik);
            TextBlockZagolovok.Text = $"Редактирование сотрудника {sotrudnik.ID_sotrudnika}";
        }

        private void LoadRoles()
        {
            var roles = App.Context.b_role.ToList();
            ComboBoxRole.ItemsSource = roles;
            ComboBoxRole.DisplayMemberPath = "Nazvanie";
            ComboBoxRole.SelectedValuePath = "ID_role";
            ComboBoxRole.SelectedIndex = 0;
        }

        private void FillFormWithSotrudnikData(Entities.b_Sotrudniki sotrudnik)
        {
            TextBoxFamilia.Text = sotrudnik.Familia;
            TextBoxName.Text = sotrudnik.Name;
            TextBoxOtchestvo.Text = sotrudnik.Otchestvo;
            TextBoxDolgnost.Text = sotrudnik.Dolgnost;
            TextBoxLogin.Text = sotrudnik.Login;
            TextBoxPassword.Text = sotrudnik.Password;
            ComboBoxRole.SelectedValue = sotrudnik.ID_role;
        }

        private void ButtonSohr_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (_isEditing)
            {
                UpdateSotrudnik();
            }
            else
            {
                AddNewSotrudnik();
            }

            MessageBox.Show("Сотрудник успешно сохранен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
            this.Close();
        }

        private void AddNewSotrudnik()
        {
            var newSotrudnik = new Entities.b_Sotrudniki
            {
                Familia = TextBoxFamilia.Text,
                Name = TextBoxName.Text,
                Otchestvo = TextBoxOtchestvo.Text,
                Dolgnost = TextBoxDolgnost.Text,
                Login = TextBoxLogin.Text,
                Password = TextBoxPassword.Text,
                ID_role = (int)ComboBoxRole.SelectedValue
            };

            App.Context.b_Sotrudniki.Add(newSotrudnik);
            App.Context.SaveChanges();
        }

        private void UpdateSotrudnik()
        {
            _currentSotrudnik.Familia = TextBoxFamilia.Text;
            _currentSotrudnik.Name = TextBoxName.Text;
            _currentSotrudnik.Otchestvo = TextBoxOtchestvo.Text;
            _currentSotrudnik.Dolgnost = TextBoxDolgnost.Text;
            _currentSotrudnik.Login = TextBoxLogin.Text;
            _currentSotrudnik.Password = TextBoxPassword.Text;
            _currentSotrudnik.ID_role = (int)ComboBoxRole.SelectedValue;

            App.Context.SaveChanges();
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(TextBoxFamilia.Text) ||
                string.IsNullOrEmpty(TextBoxName.Text) ||
                string.IsNullOrEmpty(TextBoxOtchestvo.Text) ||
                string.IsNullOrEmpty(TextBoxDolgnost.Text) ||
                string.IsNullOrEmpty(TextBoxLogin.Text) ||
                string.IsNullOrEmpty(TextBoxPassword.Text) ||
                ComboBoxRole.SelectedValue == null)
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