//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfAppPM02.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Spec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Spec()
        {
            this.Quire = new HashSet<Quire>();
        }
    
        public int IdSpec { get; set; }
        public Nullable<int> Rol_Id { get; set; }
        public string FIo { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public Nullable<bool> Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quire> Quire { get; set; }
        public virtual Roli Roli { get; set; }
    }
}
