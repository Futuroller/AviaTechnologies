//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursovoi_final.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class b_Zakazi
    {
        public int ID_zakaza { get; set; }
        public int ID_zapchasti { get; set; }
        public int Kolichestvo { get; set; }
        public System.DateTime Data_zakaza { get; set; }
        public string Status_zakaza { get; set; }
        public int ID_sotrudnika { get; set; }
    
        public virtual b_Sotrudniki b_Sotrudniki { get; set; }
        public virtual b_Zapchasti b_Zapchasti { get; set; }
    }
}