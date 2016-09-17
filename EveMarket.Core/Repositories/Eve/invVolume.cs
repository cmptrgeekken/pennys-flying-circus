namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invVolume
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long typeid { get; set; }

        public long? volume { get; set; }
    }
}
