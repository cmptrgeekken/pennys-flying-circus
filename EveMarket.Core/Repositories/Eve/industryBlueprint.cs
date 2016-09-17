namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class industryBlueprint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long typeID { get; set; }

        public long? maxProductionLimit { get; set; }

        public virtual invType invType { get; set; }
    }
}
