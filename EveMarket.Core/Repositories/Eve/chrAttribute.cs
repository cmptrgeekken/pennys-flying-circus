namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class chrAttribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long attributeID { get; set; }

        [StringLength(100)]
        public string attributeName { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        public long? iconID { get; set; }

        [StringLength(500)]
        public string shortDescription { get; set; }

        [StringLength(500)]
        public string notes { get; set; }
    }
}
