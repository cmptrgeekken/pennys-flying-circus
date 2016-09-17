namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ramAssemblyLineType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long assemblyLineTypeID { get; set; }

        [StringLength(100)]
        public string assemblyLineTypeName { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        [Column(TypeName = "real")]
        public double? baseTimeMultiplier { get; set; }

        [Column(TypeName = "real")]
        public double? baseMaterialMultiplier { get; set; }

        [Column(TypeName = "real")]
        public double? baseCostMultiplier { get; set; }

        [Column(TypeName = "real")]
        public double? volume { get; set; }

        public long? activityID { get; set; }

        [Column(TypeName = "real")]
        public double? minCostPerHour { get; set; }
    }
}
