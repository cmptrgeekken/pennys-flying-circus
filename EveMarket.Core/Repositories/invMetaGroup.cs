namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invMetaGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long metaGroupID { get; set; }

        [StringLength(100)]
        public string metaGroupName { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        public long? iconID { get; set; }
    }
}
