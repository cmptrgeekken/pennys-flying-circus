namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invControlTowerResource
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long controlTowerTypeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long resourceTypeID { get; set; }

        public long? purpose { get; set; }

        public long? quantity { get; set; }

        [Column(TypeName = "real")]
        public double? minSecurityLevel { get; set; }

        public long? factionID { get; set; }
    }
}
