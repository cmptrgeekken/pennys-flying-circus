namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invPosition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long itemID { get; set; }

        [Column(TypeName = "real")]
        public double x { get; set; }

        [Column(TypeName = "real")]
        public double y { get; set; }

        [Column(TypeName = "real")]
        public double z { get; set; }

        [Column(TypeName = "real")]
        public double? yaw { get; set; }

        [Column(TypeName = "real")]
        public double? pitch { get; set; }

        [Column(TypeName = "real")]
        public double? roll { get; set; }
    }
}
