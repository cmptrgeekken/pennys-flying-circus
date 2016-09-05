namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class trnTranslation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long tcID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long keyID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string languageID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string text { get; set; }
    }
}
