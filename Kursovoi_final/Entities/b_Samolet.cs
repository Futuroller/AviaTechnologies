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
    
    public partial class b_Samolet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public b_Samolet()
        {
            this.b_Tehnicheskoe_obsl = new HashSet<b_Tehnicheskoe_obsl>();
        }
    
        public int ID_samoleta { get; set; }
        public string Nazvanie { get; set; }
        public string Model { get; set; }
        public Nullable<int> God_proizvodstva { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<b_Tehnicheskoe_obsl> b_Tehnicheskoe_obsl { get; set; }
    }
}
