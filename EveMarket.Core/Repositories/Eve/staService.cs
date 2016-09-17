namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class staService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long serviceID { get; set; }

        [StringLength(100)]
        public string serviceName { get; set; }

        [StringLength(1000)]
        public string description { get; set; }
    }
}
