namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class eveUnit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long unitID { get; set; }

        [StringLength(100)]
        public string unitName { get; set; }

        [StringLength(50)]
        public string displayName { get; set; }

        [StringLength(1000)]
        public string description { get; set; }
    }
}
