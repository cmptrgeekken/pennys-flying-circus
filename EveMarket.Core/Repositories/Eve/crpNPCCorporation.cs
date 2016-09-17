namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class crpNPCCorporation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long corporationID { get; set; }

        [StringLength(1)]
        public string size { get; set; }

        [StringLength(1)]
        public string extent { get; set; }

        public long? solarSystemID { get; set; }

        public long? investorID1 { get; set; }

        public long? investorShares1 { get; set; }

        public long? investorID2 { get; set; }

        public long? investorShares2 { get; set; }

        public long? investorID3 { get; set; }

        public long? investorShares3 { get; set; }

        public long? investorID4 { get; set; }

        public long? investorShares4 { get; set; }

        public long? friendID { get; set; }

        public long? enemyID { get; set; }

        public long? publicShares { get; set; }

        public long? initialPrice { get; set; }

        [Column(TypeName = "real")]
        public double? minSecurity { get; set; }

        public bool? scattered { get; set; }

        public long? fringe { get; set; }

        public long? corridor { get; set; }

        public long? hub { get; set; }

        public long? border { get; set; }

        public long? factionID { get; set; }

        [Column(TypeName = "real")]
        public double? sizeFactor { get; set; }

        public long? stationCount { get; set; }

        public long? stationSystemCount { get; set; }

        [StringLength(4000)]
        public string description { get; set; }

        public long? iconID { get; set; }
    }
}
