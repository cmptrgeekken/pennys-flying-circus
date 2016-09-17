namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class staOperation
    {
        public long? activityID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long operationID { get; set; }

        [StringLength(100)]
        public string operationName { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        public long? fringe { get; set; }

        public long? corridor { get; set; }

        public long? hub { get; set; }

        public long? border { get; set; }

        public long? ratio { get; set; }

        public long? caldariStationTypeID { get; set; }

        public long? minmatarStationTypeID { get; set; }

        public long? amarrStationTypeID { get; set; }

        public long? gallenteStationTypeID { get; set; }

        public long? joveStationTypeID { get; set; }
    }
}
