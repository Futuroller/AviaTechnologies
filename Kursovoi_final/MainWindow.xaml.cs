using System.Linq;
using System.Windows;
using Kursovoi_final.Entities;

namespace Kursovoi_final
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonVhod_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = App.Context.b_Sotrudniki.FirstOrDefault(p => p.Login == TextBoxLogin.Text && p.Password == TextBoxPassword.Password); //Сравниваем значение текстовых блоков со значениями в таблице User
            if (TextBoxLogin.Text != "" && TextBoxPassword.Password != "")
            {
                if (currentUser != null) //Такой пользователь найден в таблице User
                {
                    App.CurrentUser = currentUser; //ПРИСВАИВАЕМ ЗНАЧЕНИЕ ПЕРЕМЕННОЙ
                    MessageBox.Show("Вы успешно авторизованы!");
                    if (App.CurrentUser.ID_role == 1)
                    {
                        Window Admin = new Admin();
                        Admin.Show();
                        this.Close();
                    }
                    else if (App.CurrentUser.ID_role == 2)
                    {
                        Window Mechanic = new Mechanic();
                        Mechanic.Show();
                        this.Close();
                    }
                    else
                    {
                        Window Manager = new Manager();
                        Manager.Show();
                        this.Close();
                    }
                }
                else //Если пользователя нет
                {
                    MessageBox.Show("Пользователь с такими данными не найден.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните поля!");
            }
        }
    }
}