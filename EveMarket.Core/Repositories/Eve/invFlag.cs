namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invFlag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long flagID { get; set; }

        [StringLength(200)]
        public string flagName { get; set; }

        [StringLength(100)]
        public string flagText { get; set; }

        public long? orderID { get; set; }
    }
}
