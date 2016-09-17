namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ramActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long activityID { get; set; }

        [StringLength(100)]
        public string activityName { get; set; }

        [StringLength(5)]
        public string iconNo { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        public bool? published { get; set; }
    }
}
