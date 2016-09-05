namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dgmExpression
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long expressionID { get; set; }

        public long? operandID { get; set; }

        public long? arg1 { get; set; }

        public long? arg2 { get; set; }

        [StringLength(100)]
        public string expressionValue { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        [StringLength(500)]
        public string expressionName { get; set; }

        public long? expressionTypeID { get; set; }

        public long? expressionGroupID { get; set; }

        public long? expressionAttributeID { get; set; }
    }
}
