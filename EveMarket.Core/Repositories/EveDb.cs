using System.Diagnostics.Contracts;

namespace EveMarket.Core.Repositories
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EveDb : DbContext
    {

        public EveDb()
            : base("name=EveDb")
        {
            
        }

        public virtual DbSet<agtAgent> agtAgents { get; set; }
        public virtual DbSet<agtAgentType> agtAgentTypes { get; set; }
        public virtual DbSet<agtResearchAgent> agtResearchAgents { get; set; }
        public virtual DbSet<certCert> certCerts { get; set; }
        public virtual DbSet<chrAncestry> chrAncestries { get; set; }
        public virtual DbSet<chrAttribute> chrAttributes { get; set; }
        public virtual DbSet<chrBloodline> chrBloodlines { get; set; }
        public virtual DbSet<chrFaction> chrFactions { get; set; }
        public virtual DbSet<chrRace> chrRaces { get; set; }
        public virtual DbSet<crpActivity> crpActivities { get; set; }
        public virtual DbSet<crpNPCCorporationDivision> crpNPCCorporationDivisions { get; set; }
        public virtual DbSet<crpNPCCorporationResearchField> crpNPCCorporationResearchFields { get; set; }
        public virtual DbSet<crpNPCCorporation> crpNPCCorporations { get; set; }
        public virtual DbSet<crpNPCCorporationTrade> crpNPCCorporationTrades { get; set; }
        public virtual DbSet<crpNPCDivision> crpNPCDivisions { get; set; }
        public virtual DbSet<dgmAttributeCategory> dgmAttributeCategories { get; set; }
        public virtual DbSet<dgmAttributeType> dgmAttributeTypes { get; set; }
        public virtual DbSet<dgmEffect> dgmEffects { get; set; }
        public virtual DbSet<dgmExpression> dgmExpressions { get; set; }
        public virtual DbSet<dgmTypeAttribute> dgmTypeAttributes { get; set; }
        public virtual DbSet<dgmTypeEffect> dgmTypeEffects { get; set; }
        public virtual DbSet<eveGraphic> eveGraphics { get; set; }
        public virtual DbSet<eveIcon> eveIcons { get; set; }
        public virtual DbSet<eveUnit> eveUnits { get; set; }
        public virtual DbSet<industryActivity> industryActivities { get; set; }
        public virtual DbSet<industryBlueprint> industryBlueprints { get; set; }
        public virtual DbSet<invCategory> invCategories { get; set; }
        public virtual DbSet<invContrabandType> invContrabandTypes { get; set; }
        public virtual DbSet<invControlTowerResourcePurpos> invControlTowerResourcePurposes { get; set; }
        public virtual DbSet<invControlTowerResource> invControlTowerResources { get; set; }
        public virtual DbSet<invFlag> invFlags { get; set; }
        public virtual DbSet<invGroup> invGroups { get; set; }
        public virtual DbSet<invItem> invItems { get; set; }
        public virtual DbSet<invMarketGroup> invMarketGroups { get; set; }
        public virtual DbSet<invMetaGroup> invMetaGroups { get; set; }
        public virtual DbSet<invMetaType> invMetaTypes { get; set; }
        public virtual DbSet<invName> invNames { get; set; }
        public virtual DbSet<invPosition> invPositions { get; set; }
        public virtual DbSet<invTrait> invTraits { get; set; }
        public virtual DbSet<invTypeMaterial> invTypeMaterials { get; set; }
        public virtual DbSet<invTypeReaction> invTypeReactions { get; set; }
        public virtual DbSet<invType> invTypes { get; set; }
        public virtual DbSet<invUniqueName> invUniqueNames { get; set; }
        public virtual DbSet<invVolume> invVolumes { get; set; }
        public virtual DbSet<mapCelestialStatistic> mapCelestialStatistics { get; set; }
        public virtual DbSet<mapConstellationJump> mapConstellationJumps { get; set; }
        public virtual DbSet<mapConstellation> mapConstellations { get; set; }
        public virtual DbSet<mapDenormalize> mapDenormalizes { get; set; }
        public virtual DbSet<mapJump> mapJumps { get; set; }
        public virtual DbSet<mapLandmark> mapLandmarks { get; set; }
        public virtual DbSet<mapLocationScene> mapLocationScenes { get; set; }
        public virtual DbSet<mapLocationWormholeClass> mapLocationWormholeClasses { get; set; }
        public virtual DbSet<mapRegionJump> mapRegionJumps { get; set; }
        public virtual DbSet<mapRegion> mapRegions { get; set; }
        public virtual DbSet<mapSolarSystemJump> mapSolarSystemJumps { get; set; }
        public virtual DbSet<mapSolarSystem> mapSolarSystems { get; set; }
        public virtual DbSet<mapUniverse> mapUniverses { get; set; }
        public virtual DbSet<planetSchematic> planetSchematics { get; set; }
        public virtual DbSet<planetSchematicsPinMap> planetSchematicsPinMaps { get; set; }
        public virtual DbSet<planetSchematicsTypeMap> planetSchematicsTypeMaps { get; set; }
        public virtual DbSet<ramActivity> ramActivities { get; set; }
        public virtual DbSet<ramAssemblyLineStation> ramAssemblyLineStations { get; set; }
        public virtual DbSet<ramAssemblyLineTypeDetailPerCategory> ramAssemblyLineTypeDetailPerCategories { get; set; }
        public virtual DbSet<ramAssemblyLineTypeDetailPerGroup> ramAssemblyLineTypeDetailPerGroups { get; set; }
        public virtual DbSet<ramAssemblyLineType> ramAssemblyLineTypes { get; set; }
        public virtual DbSet<ramInstallationTypeContent> ramInstallationTypeContents { get; set; }
        public virtual DbSet<skinLicense> skinLicenses { get; set; }
        public virtual DbSet<skinMaterial> skinMaterials { get; set; }
        public virtual DbSet<skin> skins { get; set; }
        public virtual DbSet<staOperation> staOperations { get; set; }
        public virtual DbSet<staOperationService> staOperationServices { get; set; }
        public virtual DbSet<staService> staServices { get; set; }
        public virtual DbSet<staStation> staStations { get; set; }
        public virtual DbSet<staStationType> staStationTypes { get; set; }
        public virtual DbSet<translationTable> translationTables { get; set; }
        public virtual DbSet<trnTranslationColumn> trnTranslationColumns { get; set; }
        public virtual DbSet<trnTranslationLanguage> trnTranslationLanguages { get; set; }
        public virtual DbSet<trnTranslation> trnTranslations { get; set; }
        public virtual DbSet<warCombatZone> warCombatZones { get; set; }
        public virtual DbSet<warCombatZoneSystem> warCombatZoneSystems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<invType>()
                .HasRequired(t => t.group)
                .WithMany(g => g.invTypes);

            modelBuilder.Entity<invGroup>()
                .HasRequired(g => g.invCategory)
                .WithMany(c => c.invGroups);

            modelBuilder.Entity<invTypeMaterial>()
                .HasRequired(tm => tm.invType)
                .WithMany(t => t.typeMaterials)
                .HasForeignKey(tm => tm.typeID);

            modelBuilder.Entity<invTypeMaterial>()
                .HasRequired(tm => tm.materialType)
                .WithMany(t => t.materialTypes)
                .HasForeignKey(tm => tm.materialTypeID);

            modelBuilder.Entity<staStation>()
                .HasRequired(s => s.constellation)
                .WithMany(c => c.stations)
                .HasForeignKey(s => s.constellationID);

            modelBuilder.Entity<mapConstellation>()
                .HasRequired(c => c.region)
                .WithMany(r => r.constellations)
                .HasForeignKey(c => c.regionID);

            modelBuilder.Entity<agtAgentType>()
                .Property(e => e.agentType)
                .IsUnicode(false);

            modelBuilder.Entity<certCert>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<chrAncestry>()
                .Property(e => e.ancestryName)
                .IsUnicode(false);

            modelBuilder.Entity<chrAncestry>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<chrAncestry>()
                .Property(e => e.shortDescription)
                .IsUnicode(false);

            modelBuilder.Entity<chrAttribute>()
                .Property(e => e.attributeName)
                .IsUnicode(false);

            modelBuilder.Entity<chrAttribute>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<chrAttribute>()
                .Property(e => e.shortDescription)
                .IsUnicode(false);

            modelBuilder.Entity<chrAttribute>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<chrBloodline>()
                .Property(e => e.bloodlineName)
                .IsUnicode(false);

            modelBuilder.Entity<chrBloodline>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<chrBloodline>()
                .Property(e => e.maleDescription)
                .IsUnicode(false);

            modelBuilder.Entity<chrBloodline>()
                .Property(e => e.femaleDescription)
                .IsUnicode(false);

            modelBuilder.Entity<chrBloodline>()
                .Property(e => e.shortDescription)
                .IsUnicode(false);

            modelBuilder.Entity<chrBloodline>()
                .Property(e => e.shortMaleDescription)
                .IsUnicode(false);

            modelBuilder.Entity<chrBloodline>()
                .Property(e => e.shortFemaleDescription)
                .IsUnicode(false);

            modelBuilder.Entity<chrFaction>()
                .Property(e => e.factionName)
                .IsUnicode(false);

            modelBuilder.Entity<chrFaction>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<chrRace>()
                .Property(e => e.raceName)
                .IsUnicode(false);

            modelBuilder.Entity<chrRace>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<chrRace>()
                .Property(e => e.shortDescription)
                .IsUnicode(false);

            modelBuilder.Entity<crpActivity>()
                .Property(e => e.activityName)
                .IsUnicode(false);

            modelBuilder.Entity<crpActivity>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<crpNPCCorporation>()
                .Property(e => e.size)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<crpNPCCorporation>()
                .Property(e => e.extent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<crpNPCCorporation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<crpNPCDivision>()
                .Property(e => e.divisionName)
                .IsUnicode(false);

            modelBuilder.Entity<crpNPCDivision>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<crpNPCDivision>()
                .Property(e => e.leaderType)
                .IsUnicode(false);

            modelBuilder.Entity<dgmAttributeCategory>()
                .Property(e => e.categoryName)
                .IsUnicode(false);

            modelBuilder.Entity<dgmAttributeCategory>()
                .Property(e => e.categoryDescription)
                .IsUnicode(false);

            modelBuilder.Entity<dgmAttributeType>()
                .Property(e => e.attributeName)
                .IsUnicode(false);

            modelBuilder.Entity<dgmAttributeType>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<dgmAttributeType>()
                .Property(e => e.displayName)
                .IsUnicode(false);

            modelBuilder.Entity<dgmEffect>()
                .Property(e => e.effectName)
                .IsUnicode(false);

            modelBuilder.Entity<dgmEffect>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<dgmEffect>()
                .Property(e => e.guid)
                .IsUnicode(false);

            modelBuilder.Entity<dgmEffect>()
                .Property(e => e.displayName)
                .IsUnicode(false);

            modelBuilder.Entity<dgmEffect>()
                .Property(e => e.sfxName)
                .IsUnicode(false);

            modelBuilder.Entity<dgmExpression>()
                .Property(e => e.expressionValue)
                .IsUnicode(false);

            modelBuilder.Entity<dgmExpression>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<dgmExpression>()
                .Property(e => e.expressionName)
                .IsUnicode(false);

            modelBuilder.Entity<eveGraphic>()
                .Property(e => e.sofFactionName)
                .IsUnicode(false);

            modelBuilder.Entity<eveGraphic>()
                .Property(e => e.graphicFile)
                .IsUnicode(false);

            modelBuilder.Entity<eveGraphic>()
                .Property(e => e.sofHullName)
                .IsUnicode(false);

            modelBuilder.Entity<eveGraphic>()
                .Property(e => e.sofRaceName)
                .IsUnicode(false);

            modelBuilder.Entity<eveIcon>()
                .Property(e => e.iconFile)
                .IsUnicode(false);

            modelBuilder.Entity<eveUnit>()
                .Property(e => e.unitName)
                .IsUnicode(false);

            modelBuilder.Entity<eveUnit>()
                .Property(e => e.displayName)
                .IsUnicode(false);

            modelBuilder.Entity<eveUnit>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<invCategory>()
                .Property(e => e.categoryName)
                .IsUnicode(false);

            modelBuilder.Entity<invControlTowerResourcePurpos>()
                .Property(e => e.purposeText)
                .IsUnicode(false);

            modelBuilder.Entity<invFlag>()
                .Property(e => e.flagName)
                .IsUnicode(false);

            modelBuilder.Entity<invFlag>()
                .Property(e => e.flagText)
                .IsUnicode(false);

            modelBuilder.Entity<invGroup>()
                .Property(e => e.groupName)
                .IsUnicode(false);

            modelBuilder.Entity<invMarketGroup>()
                .Property(e => e.marketGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<invMarketGroup>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<invMetaGroup>()
                .Property(e => e.metaGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<invMetaGroup>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<invName>()
                .Property(e => e.itemName)
                .IsUnicode(false);

            modelBuilder.Entity<invType>()
                .Property(e => e.typeName)
                .IsUnicode(false);

            modelBuilder.Entity<invType>()
                .Property(e => e.basePrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<invUniqueName>()
                .Property(e => e.itemName)
                .IsUnicode(false);

            modelBuilder.Entity<mapCelestialStatistic>()
                .Property(e => e.spectralClass)
                .IsUnicode(false);

            modelBuilder.Entity<mapConstellation>()
                .Property(e => e.constellationName)
                .IsUnicode(false);

            modelBuilder.Entity<mapDenormalize>()
                .Property(e => e.itemName)
                .IsUnicode(false);

            modelBuilder.Entity<mapLandmark>()
                .Property(e => e.landmarkName)
                .IsUnicode(false);

            modelBuilder.Entity<mapRegion>()
                .Property(e => e.regionName)
                .IsUnicode(false);

            modelBuilder.Entity<mapSolarSystem>()
                .Property(e => e.solarSystemName)
                .IsUnicode(false);

            modelBuilder.Entity<mapSolarSystem>()
                .Property(e => e.securityClass)
                .IsUnicode(false);

            modelBuilder.Entity<mapUniverse>()
                .Property(e => e.universeName)
                .IsUnicode(false);

            modelBuilder.Entity<planetSchematic>()
                .Property(e => e.schematicName)
                .IsUnicode(false);

            modelBuilder.Entity<ramActivity>()
                .Property(e => e.activityName)
                .IsUnicode(false);

            modelBuilder.Entity<ramActivity>()
                .Property(e => e.iconNo)
                .IsUnicode(false);

            modelBuilder.Entity<ramActivity>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<ramAssemblyLineType>()
                .Property(e => e.assemblyLineTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<ramAssemblyLineType>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<skin>()
                .Property(e => e.internalName)
                .IsUnicode(false);

            modelBuilder.Entity<staOperation>()
                .Property(e => e.operationName)
                .IsUnicode(false);

            modelBuilder.Entity<staOperation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<staService>()
                .Property(e => e.serviceName)
                .IsUnicode(false);

            modelBuilder.Entity<staService>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<staStation>()
                .Property(e => e.stationName)
                .IsUnicode(false);

            modelBuilder.Entity<translationTable>()
                .Property(e => e.sourceTable)
                .IsUnicode(false);

            modelBuilder.Entity<translationTable>()
                .Property(e => e.destinationTable)
                .IsUnicode(false);

            modelBuilder.Entity<translationTable>()
                .Property(e => e.translatedKey)
                .IsUnicode(false);

            modelBuilder.Entity<trnTranslationColumn>()
                .Property(e => e.tableName)
                .IsUnicode(false);

            modelBuilder.Entity<trnTranslationColumn>()
                .Property(e => e.columnName)
                .IsUnicode(false);

            modelBuilder.Entity<trnTranslationColumn>()
                .Property(e => e.masterID)
                .IsUnicode(false);

            modelBuilder.Entity<trnTranslationLanguage>()
                .Property(e => e.languageID)
                .IsUnicode(false);

            modelBuilder.Entity<trnTranslationLanguage>()
                .Property(e => e.languageName)
                .IsUnicode(false);

            modelBuilder.Entity<trnTranslation>()
                .Property(e => e.languageID)
                .IsUnicode(false);

            modelBuilder.Entity<warCombatZone>()
                .Property(e => e.combatZoneName)
                .IsUnicode(false);

            modelBuilder.Entity<warCombatZone>()
                .Property(e => e.description)
                .IsUnicode(false);
        }
    }
}
