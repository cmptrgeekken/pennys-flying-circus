namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class planetSchematic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long schematicID { get; set; }

        [StringLength(255)]
        public string schematicName { get; set; }

        public long? cycleTime { get; set; }
    }
}
