namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long categoryID { get; set; }

        [StringLength(100)]
        public string categoryName { get; set; }

        public long? iconID { get; set; }

        public bool? published { get; set; }

        public virtual ICollection<invGroup> invGroups { get; set; }
    }
}
