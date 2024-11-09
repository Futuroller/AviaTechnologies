using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Kursovoi_final
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Entities.user31_dbEntities Context { get; } = new Entities.user31_dbEntities();
        public static Entities.b_Sotrudniki CurrentUser = null;
    }
}
