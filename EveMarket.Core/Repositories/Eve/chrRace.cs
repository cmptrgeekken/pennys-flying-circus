namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class chrRace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long raceID { get; set; }

        [StringLength(100)]
        public string raceName { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        public long? iconID { get; set; }

        [StringLength(500)]
        public string shortDescription { get; set; }
    }
}
