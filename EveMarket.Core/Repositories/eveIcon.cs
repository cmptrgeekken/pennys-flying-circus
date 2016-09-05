namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class eveIcon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long iconID { get; set; }

        [StringLength(500)]
        public string iconFile { get; set; }

        [StringLength(2147483647)]
        public string description { get; set; }
    }
}
