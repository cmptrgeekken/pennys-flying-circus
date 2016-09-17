namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class staStationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public staStationType()
        {
            staStations = new HashSet<staStation>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staStation> staStations { get; set; }
    }
}
