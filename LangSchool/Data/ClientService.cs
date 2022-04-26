//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LangSchool.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientService()
        {
            this.ClientServiceDoc = new HashSet<ClientServiceDoc>();
        }
    
        public int ID { get; set; }
        public Nullable<int> IDClient { get; set; }
        public Nullable<int> IDService { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Service Service { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientServiceDoc> ClientServiceDoc { get; set; }
    }
}
