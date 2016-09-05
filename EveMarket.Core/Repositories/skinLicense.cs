namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("skinLicense")]
    public partial class skinLicense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long licenseTypeID { get; set; }

        public long? duration { get; set; }

        public long? skinID { get; set; }
    }
}
