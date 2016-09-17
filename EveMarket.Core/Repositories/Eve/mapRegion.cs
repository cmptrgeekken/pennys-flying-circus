namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mapRegion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mapRegion()
        {
            mapConstellations = new HashSet<mapConstellation>();
            mapSolarSystems = new HashSet<mapSolarSystem>();
            stations = new HashSet<staStation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long regionID { get; set; }

        [StringLength(100)]
        public string regionName { get; set; }

        [Column(TypeName = "real")]
        public double? x { get; set; }

        [Column(TypeName = "real")]
        public double? y { get; set; }

        [Column(TypeName = "real")]
        public double? z { get; set; }

        [Column(TypeName = "real")]
        public double? xMin { get; set; }

        [Column(TypeName = "real")]
        public double? xMax { get; set; }

        [Column(TypeName = "real")]
        public double? yMin { get; set; }

        [Column(TypeName = "real")]
        public double? yMax { get; set; }

        [Column(TypeName = "real")]
        public double? zMin { get; set; }

        [Column(TypeName = "real")]
        public double? zMax { get; set; }

        public long? factionID { get; set; }

        [Column(TypeName = "real")]
        public double? radius { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mapConstellation> mapConstellations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mapSolarSystem> mapSolarSystems { get; set; }

        public virtual ICollection<staStation> stations { get; set; }
    }
}
