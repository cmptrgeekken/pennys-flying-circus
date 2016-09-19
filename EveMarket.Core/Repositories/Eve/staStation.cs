namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class staStation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long stationID { get; set; }

        public double security { get; set; }

        [Column(TypeName = "real")]
        public double dockingCostPerVolume { get; set; }

        [Column(TypeName = "real")]
        public double maxShipVolumeDockable { get; set; }

        public long? officeRentalCost { get; set; }

        public long? operationID { get; set; }

        public long? stationTypeID { get; set; }

        public long? corporationID { get; set; }

        public long? solarSystemID { get; set; }

        public long? constellationID { get; set; }

        public long? regionID { get; set; }

        [StringLength(100)]
        public string stationName { get; set; }

        [Column(TypeName = "real")]
        public double? x { get; set; }

        [Column(TypeName = "real")]
        public double? y { get; set; }

        [Column(TypeName = "real")]
        public double? z { get; set; }

        [Column(TypeName = "real")]
        public double? reprocessingEfficiency { get; set; }

        [Column(TypeName = "real")]
        public double? reprocessingStationsTake { get; set; }

        public long? reprocessingHangarFlag { get; set; }
        public virtual staOperation staOperation { get; set; }
        public virtual staStationType staStationType { get; set; }
        public virtual mapSolarSystem mapSolarSystem { get; set; }
        public virtual mapConstellation mapConstellation { get; set; }
        public virtual mapRegion mapRegion { get; set; }
    }
}
