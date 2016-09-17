namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invContrabandType
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long factionID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long typeID { get; set; }

        [Column(TypeName = "real")]
        public double? standingLoss { get; set; }

        [Column(TypeName = "real")]
        public double? confiscateMinSec { get; set; }

        [Column(TypeName = "real")]
        public double? fineByValue { get; set; }

        [Column(TypeName = "real")]
        public double? attackMinSec { get; set; }
    }
}
