namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class eveGraphic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long graphicID { get; set; }

        [StringLength(100)]
        public string sofFactionName { get; set; }

        [StringLength(100)]
        public string graphicFile { get; set; }

        [StringLength(100)]
        public string sofHullName { get; set; }

        [StringLength(100)]
        public string sofRaceName { get; set; }

        [StringLength(2147483647)]
        public string description { get; set; }
    }
}
