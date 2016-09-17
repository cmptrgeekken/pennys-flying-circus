namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mapLandmark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long landmarkID { get; set; }

        [StringLength(100)]
        public string landmarkName { get; set; }

        [StringLength(2147483647)]
        public string description { get; set; }

        public long? locationID { get; set; }

        [Column(TypeName = "real")]
        public double? x { get; set; }

        [Column(TypeName = "real")]
        public double? y { get; set; }

        [Column(TypeName = "real")]
        public double? z { get; set; }

        public long? iconID { get; set; }
    }
}
