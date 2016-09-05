namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class certCert
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long certID { get; set; }

        [StringLength(2147483647)]
        public string description { get; set; }

        public long? groupID { get; set; }

        [StringLength(255)]
        public string name { get; set; }
    }
}
