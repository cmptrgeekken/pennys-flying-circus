namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class skin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long skinID { get; set; }

        [StringLength(70)]
        public string internalName { get; set; }

        public long? skinMaterialID { get; set; }
    }
}
