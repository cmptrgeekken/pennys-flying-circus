namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class agtAgent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long agentID { get; set; }

        public long? divisionID { get; set; }

        public long? corporationID { get; set; }

        public long? locationID { get; set; }

        public long? level { get; set; }

        public long? quality { get; set; }

        public long? agentTypeID { get; set; }

        public bool? isLocator { get; set; }
    }
}
