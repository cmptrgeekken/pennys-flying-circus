//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EveMarket.Core.Repositories.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class ImportItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImportItem()
        {
            this.MarketOrders = new HashSet<MarketOrder>();
        }
    
        public long TypeId { get; set; }
        public long RegionId { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public System.Guid Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarketOrder> MarketOrders { get; set; }
    }
}
