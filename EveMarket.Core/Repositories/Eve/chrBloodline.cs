namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class chrBloodline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long bloodlineID { get; set; }

        [StringLength(100)]
        public string bloodlineName { get; set; }

        public long? raceID { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        [StringLength(1000)]
        public string maleDescription { get; set; }

        [StringLength(1000)]
        public string femaleDescription { get; set; }

        public long? shipTypeID { get; set; }

        public long? corporationID { get; set; }

        public long? perception { get; set; }

        public long? willpower { get; set; }

        public long? charisma { get; set; }

        public long? memory { get; set; }

        public long? intelligence { get; set; }

        public long? iconID { get; set; }

        [StringLength(500)]
        public string shortDescription { get; set; }

        [StringLength(500)]
        public string shortMaleDescription { get; set; }

        [StringLength(500)]
        public string shortFemaleDescription { get; set; }
    }
}
