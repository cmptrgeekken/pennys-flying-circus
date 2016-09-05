using System.Linq;
using EveMarket.Core.Enums;

namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invType
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long typeID { get; set; }

        public invGroup group { get; set; }
        public long? groupID { get; set; }

        [StringLength(100)]
        public string typeName { get; set; }

        [StringLength(2147483647)]
        public string description { get; set; }

        [Column(TypeName = "real")]
        public double? mass { get; set; }

        [Column(TypeName = "real")]
        public double volume { get; set; }

        [Column(TypeName = "real")]
        public double? capacity { get; set; }

        public long? portionSize { get; set; }

        public long? raceID { get; set; }

        public decimal? basePrice { get; set; }

        public bool? published { get; set; }

        public long? marketGroupID { get; set; }

        public long? iconID { get; set; }

        public long? soundID { get; set; }

        public long? graphicID { get; set; }

        public virtual ICollection<invTypeMaterial> typeMaterials { get; set; }
        public virtual ICollection<invTypeMaterial> materialTypes { get; set; }
        [NotMapped]
        public virtual long this[string key]
        {
            get
            {
                return typeMaterials.Where(t => t.materialType.typeName == key).Select(t => t.quantity).FirstOrDefault();
            }
        }
        [NotMapped]
        public virtual long this[MineralType key] => this[key.ToString()];
    }
}
