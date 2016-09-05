namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class agtAgentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long agentTypeID { get; set; }

        [StringLength(50)]
        public string agentType { get; set; }
    }
}
