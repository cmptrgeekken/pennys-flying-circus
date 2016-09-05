namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class warCombatZone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long combatZoneID { get; set; }

        [StringLength(100)]
        public string combatZoneName { get; set; }

        public long? factionID { get; set; }

        public long? centerSystemID { get; set; }

        [StringLength(500)]
        public string description { get; set; }
    }
}
