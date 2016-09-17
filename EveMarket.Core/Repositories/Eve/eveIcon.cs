namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class eveIcon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eveIcon()
        {
            invCategories = new HashSet<invCategory>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long iconID { get; set; }

        [StringLength(500)]
        public string iconFile { get; set; }

        [StringLength(2147483647)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invCategory> invCategories { get; set; }
    }
}
