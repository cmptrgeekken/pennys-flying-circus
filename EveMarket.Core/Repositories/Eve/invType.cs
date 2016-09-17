using System.Linq;
using EveMarket.Core.Enums;

namespace EveMarket.Core.Repositories.Eve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public invType()
        {
            industryActivities = new HashSet<industryActivity>();
            industryActivityMaterials = new HashSet<industryActivityMaterial>();
            industryActivityMaterials1 = new HashSet<industryActivityMaterial>();
            industryActivityProbabilities = new HashSet<industryActivityProbability>();
            industryActivityProbabilities1 = new HashSet<industryActivityProbability>();
            industryActivityProducts = new HashSet<industryActivityProduct>();
            activityProducts = new HashSet<industryActivityProduct>();
            typeSkills = new HashSet<industryActivitySkill>();
            activitySkills = new HashSet<industryActivitySkill>();
            typeMaterials = new HashSet<invTypeMaterial>();
            materialTypes = new HashSet<invTypeMaterial>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long typeID { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<industryActivity> industryActivities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<industryActivityMaterial> industryActivityMaterials { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<industryActivityMaterial> industryActivityMaterials1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<industryActivityProbability> industryActivityProbabilities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<industryActivityProbability> industryActivityProbabilities1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<industryActivityProduct> industryActivityProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<industryActivityProduct> activityProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<industryActivitySkill> typeSkills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<industryActivitySkill> activitySkills { get; set; }

        public virtual industryBlueprint industryBlueprint { get; set; }

        public virtual invGroup invGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invTypeMaterial> typeMaterials { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
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
