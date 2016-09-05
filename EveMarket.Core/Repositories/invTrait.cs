namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invTrait
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long traitID { get; set; }

        public long? typeID { get; set; }

        public long? skillID { get; set; }

        [Column(TypeName = "real")]
        public double? bonus { get; set; }

        [StringLength(2147483647)]
        public string bonusText { get; set; }

        public long? unitID { get; set; }
    }
}
