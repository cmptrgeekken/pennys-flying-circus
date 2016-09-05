namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mapCelestialStatistic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long celestialID { get; set; }

        [Column(TypeName = "real")]
        public double? temperature { get; set; }

        [StringLength(10)]
        public string spectralClass { get; set; }

        [Column(TypeName = "real")]
        public double? luminosity { get; set; }

        [Column(TypeName = "real")]
        public double? age { get; set; }

        [Column(TypeName = "real")]
        public double? life { get; set; }

        [Column(TypeName = "real")]
        public double? orbitRadius { get; set; }

        [Column(TypeName = "real")]
        public double? eccentricity { get; set; }

        [Column(TypeName = "real")]
        public double? massDust { get; set; }

        [Column(TypeName = "real")]
        public double? massGas { get; set; }

        public bool? fragmented { get; set; }

        [Column(TypeName = "real")]
        public double? density { get; set; }

        [Column(TypeName = "real")]
        public double? surfaceGravity { get; set; }

        [Column(TypeName = "real")]
        public double? escapeVelocity { get; set; }

        [Column(TypeName = "real")]
        public double? orbitPeriod { get; set; }

        [Column(TypeName = "real")]
        public double? rotationRate { get; set; }

        public bool? locked { get; set; }

        public long? pressure { get; set; }

        public long? radius { get; set; }

        public long? mass { get; set; }
    }
}
