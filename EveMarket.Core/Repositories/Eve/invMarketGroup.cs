namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invMarketGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public invMarketGroup()
        {
            childGroups = new HashSet<invMarketGroup>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long marketGroupID { get; set; }

        public long? parentGroupID { get; set; }

        [StringLength(100)]
        public string marketGroupName { get; set; }

        [StringLength(3000)]
        public string description { get; set; }

        public long? iconID { get; set; }

        public bool? hasTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invMarketGroup> childGroups { get; set; }

        public virtual invMarketGroup parentGroup { get; set; }
    }
}
