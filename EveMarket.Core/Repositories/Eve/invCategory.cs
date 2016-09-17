namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public invCategory()
        {
            invGroups = new HashSet<invGroup>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long categoryID { get; set; }

        [StringLength(100)]
        public string categoryName { get; set; }

        public long? iconID { get; set; }

        public bool? published { get; set; }

        public virtual eveIcon eveIcon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invGroup> invGroups { get; set; }
    }
}
