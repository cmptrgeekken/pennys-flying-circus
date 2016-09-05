namespace EveMarket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dgmEffect
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long effectID { get; set; }

        [StringLength(400)]
        public string effectName { get; set; }

        public long? effectCategory { get; set; }

        public long? preExpression { get; set; }

        public long? postExpression { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        [StringLength(60)]
        public string guid { get; set; }

        public long? iconID { get; set; }

        public bool? isOffensive { get; set; }

        public bool? isAssistance { get; set; }

        public long? durationAttributeID { get; set; }

        public long? trackingSpeedAttributeID { get; set; }

        public long? dischargeAttributeID { get; set; }

        public long? rangeAttributeID { get; set; }

        public long? falloffAttributeID { get; set; }

        public bool? disallowAutoRepeat { get; set; }

        public bool? published { get; set; }

        [StringLength(100)]
        public string displayName { get; set; }

        public bool? isWarpSafe { get; set; }

        public bool? rangeChance { get; set; }

        public bool? electronicChance { get; set; }

        public bool? propulsionChance { get; set; }

        public long? distribution { get; set; }

        [StringLength(20)]
        public string sfxName { get; set; }

        public long? npcUsageChanceAttributeID { get; set; }

        public long? npcActivationChanceAttributeID { get; set; }

        public long? fittingUsageChanceAttributeID { get; set; }

        [StringLength(2147483647)]
        public string modifierInfo { get; set; }
    }
}
