namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long itemID { get; set; }

        public long typeID { get; set; }

        public long ownerID { get; set; }

        public long locationID { get; set; }

        public long flagID { get; set; }

        public long quantity { get; set; }
    }
}
