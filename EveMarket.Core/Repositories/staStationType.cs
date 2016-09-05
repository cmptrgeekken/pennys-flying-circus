namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class staStationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long stationTypeID { get; set; }

        [Column(TypeName = "real")]
        public double? dockEntryX { get; set; }

        [Column(TypeName = "real")]
        public double? dockEntryY { get; set; }

        [Column(TypeName = "real")]
        public double? dockEntryZ { get; set; }

        [Column(TypeName = "real")]
        public double? dockOrientationX { get; set; }

        [Column(TypeName = "real")]
        public double? dockOrientationY { get; set; }

        [Column(TypeName = "real")]
        public double? dockOrientationZ { get; set; }

        public long? operationID { get; set; }

        public long? officeSlots { get; set; }

        [Column(TypeName = "real")]
        public double? reprocessingEfficiency { get; set; }

        public bool? conquerable { get; set; }
    }
}
