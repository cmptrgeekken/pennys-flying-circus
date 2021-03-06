namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ramAssemblyLineTypeDetailPerGroup")]
    public partial class ramAssemblyLineTypeDetailPerGroup
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long assemblyLineTypeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long groupID { get; set; }

        [Column(TypeName = "real")]
        public double? timeMultiplier { get; set; }

        [Column(TypeName = "real")]
        public double? materialMultiplier { get; set; }

        [Column(TypeName = "real")]
        public double? costMultiplier { get; set; }
    }
}
