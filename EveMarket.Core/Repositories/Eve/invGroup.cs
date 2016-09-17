namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public invGroup()
        {
            invTypes = new HashSet<invType>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long groupID { get; set; }

        public long? categoryID { get; set; }

        [StringLength(100)]
        public string groupName { get; set; }

        public long? iconID { get; set; }

        public bool? useBasePrice { get; set; }

        public bool? anchored { get; set; }

        public bool? anchorable { get; set; }

        public bool? fittableNonSingleton { get; set; }

        public bool? published { get; set; }

        public virtual invCategory invCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invType> invTypes { get; set; }
    }
}
