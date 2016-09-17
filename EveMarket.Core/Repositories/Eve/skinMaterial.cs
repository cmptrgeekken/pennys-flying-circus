namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class skinMaterial
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long skinMaterialID { get; set; }

        public long? displayNameID { get; set; }

        public long? materialSetID { get; set; }
    }
}
