namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class translationTable
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(200)]
        public string sourceTable { get; set; }

        [StringLength(200)]
        public string destinationTable { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string translatedKey { get; set; }

        public long? tcGroupID { get; set; }

        public long? tcID { get; set; }
    }
}
