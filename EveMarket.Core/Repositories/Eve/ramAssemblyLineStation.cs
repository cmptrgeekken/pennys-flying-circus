namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ramAssemblyLineStation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long stationID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long assemblyLineTypeID { get; set; }

        public long? quantity { get; set; }

        public long? stationTypeID { get; set; }

        public long? ownerID { get; set; }

        public long? solarSystemID { get; set; }

        public long? regionID { get; set; }
    }
}
