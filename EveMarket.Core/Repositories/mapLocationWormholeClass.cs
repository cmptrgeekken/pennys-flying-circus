namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mapLocationWormholeClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long locationID { get; set; }

        public long? wormholeClassID { get; set; }
    }
}
