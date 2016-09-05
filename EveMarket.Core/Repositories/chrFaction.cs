namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class chrFaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long factionID { get; set; }

        [StringLength(100)]
        public string factionName { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        public long? raceIDs { get; set; }

        public long? solarSystemID { get; set; }

        public long? corporationID { get; set; }

        [Column(TypeName = "real")]
        public double? sizeFactor { get; set; }

        public long? stationCount { get; set; }

        public long? stationSystemCount { get; set; }

        public long? militiaCorporationID { get; set; }

        public long? iconID { get; set; }
    }
}
