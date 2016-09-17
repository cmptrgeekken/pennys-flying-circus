namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dgmAttributeCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long categoryID { get; set; }

        [StringLength(50)]
        public string categoryName { get; set; }

        [StringLength(200)]
        public string categoryDescription { get; set; }
    }
}
