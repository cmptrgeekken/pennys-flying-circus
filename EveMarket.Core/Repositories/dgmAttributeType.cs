namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dgmAttributeType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long attributeID { get; set; }

        [StringLength(100)]
        public string attributeName { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        public long? iconID { get; set; }

        [Column(TypeName = "real")]
        public double? defaultValue { get; set; }

        public bool? published { get; set; }

        [StringLength(150)]
        public string displayName { get; set; }

        public long? unitID { get; set; }

        public bool? stackable { get; set; }

        public bool? highIsGood { get; set; }

        public long? categoryID { get; set; }
    }
}
