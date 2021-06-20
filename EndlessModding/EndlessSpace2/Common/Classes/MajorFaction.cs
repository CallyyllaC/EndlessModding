﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

namespace EndlessModding.EndlessSpace2.Common.Classes.MajorFactions
{
    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class StartingPopulation {

        private string affinityField;

        private int countField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Affinity {
            get {
                return this.affinityField;
            }
            set {
                this.affinityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Count {
            get {
                return this.countField;
            }
            set {
                this.countField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class StartingFleetData {

        private int priorityField;

        private string valueField;

        public StartingFleetData() {
            this.priorityField = 0;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int Priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FactionTrait))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FactionTraitStartingSenate))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Faction))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MajorFaction))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DatatableElement {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FactionTraitStartingSenate))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FactionTrait : DatatableElement {

        private Command[] commandField;

        private XmlNamedReference[] outpostImprovementReferenceField;

        private XmlNamedReference[] colonyImprovementReferenceField;

        private XmlNamedReference[] subTraitField;

        private SimulationDescriptorReference[] simulationDescriptorReferenceField;

        private SimulationDescriptorReference[] fakeSimulationDescriptorReferenceField;

        private FactionTraitTooltipOverride factionTraitTooltipOverrideField;

        private string prerequisitesField;

        private StartingFleetData startingFleetField;

        private AbstractToShipDesignPair[] shipDesignField;

        private string unlockedAbstractShipDesignsField;

        private int costField;

        private string familyField;

        private bool hiddenField;

        private bool customField;

        private bool hiddenOnFailPrerequisitesField;

        private bool validWithAtLeastOnePrerequisiteField;

        private float levelField;

        private string rootField;

        private bool ignoreForTraitsCountField;

        private string subCategoryField;

        private string traitCategoryField;

        private string traitSubCategoryField;

        public FactionTrait() {
            this.costField = 0;
            this.hiddenField = true;
            this.customField = false;
            this.hiddenOnFailPrerequisitesField = false;
            this.validWithAtLeastOnePrerequisiteField = false;
            this.levelField = ((float)(0F));
            this.ignoreForTraitsCountField = false;
            this.traitCategoryField = "";
            this.traitSubCategoryField = "";
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Command", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Command[] Command {
            get {
                return this.commandField;
            }
            set {
                this.commandField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OutpostImprovementReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] OutpostImprovementReference {
            get {
                return this.outpostImprovementReferenceField;
            }
            set {
                this.outpostImprovementReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ColonyImprovementReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] ColonyImprovementReference {
            get {
                return this.colonyImprovementReferenceField;
            }
            set {
                this.colonyImprovementReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SubTrait", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] SubTrait {
            get {
                return this.subTraitField;
            }
            set {
                this.subTraitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SimulationDescriptorReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SimulationDescriptorReference[] SimulationDescriptorReference {
            get {
                return this.simulationDescriptorReferenceField;
            }
            set {
                this.simulationDescriptorReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FakeSimulationDescriptorReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SimulationDescriptorReference[] FakeSimulationDescriptorReference {
            get {
                return this.fakeSimulationDescriptorReferenceField;
            }
            set {
                this.fakeSimulationDescriptorReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FactionTraitTooltipOverride FactionTraitTooltipOverride {
            get {
                return this.factionTraitTooltipOverrideField;
            }
            set {
                this.factionTraitTooltipOverrideField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Prerequisites {
            get {
                return this.prerequisitesField;
            }
            set {
                this.prerequisitesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public StartingFleetData StartingFleet {
            get {
                return this.startingFleetField;
            }
            set {
                this.startingFleetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ShipDesign", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AbstractToShipDesignPair[] ShipDesign {
            get {
                return this.shipDesignField;
            }
            set {
                this.shipDesignField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string UnlockedAbstractShipDesigns {
            get {
                return this.unlockedAbstractShipDesignsField;
            }
            set {
                this.unlockedAbstractShipDesignsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int Cost {
            get {
                return this.costField;
            }
            set {
                this.costField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Family {
            get {
                return this.familyField;
            }
            set {
                this.familyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool Hidden {
            get {
                return this.hiddenField;
            }
            set {
                this.hiddenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Custom {
            get {
                return this.customField;
            }
            set {
                this.customField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool HiddenOnFailPrerequisites {
            get {
                return this.hiddenOnFailPrerequisitesField;
            }
            set {
                this.hiddenOnFailPrerequisitesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool ValidWithAtLeastOnePrerequisite {
            get {
                return this.validWithAtLeastOnePrerequisiteField;
            }
            set {
                this.validWithAtLeastOnePrerequisiteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(typeof(float), "0")]
        public float Level {
            get {
                return this.levelField;
            }
            set {
                this.levelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Root {
            get {
                return this.rootField;
            }
            set {
                this.rootField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool IgnoreForTraitsCount {
            get {
                return this.ignoreForTraitsCountField;
            }
            set {
                this.ignoreForTraitsCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SubCategory {
            get {
                return this.subCategoryField;
            }
            set {
                this.subCategoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string TraitCategory {
            get {
                return this.traitCategoryField;
            }
            set {
                this.traitCategoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string TraitSubCategory {
            get {
                return this.traitSubCategoryField;
            }
            set {
                this.traitSubCategoryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Command {

        private string nameField;

        private string argumentsField;

        private int priorityField;

        public Command() {
            this.priorityField = 0;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Arguments {
            get {
                return this.argumentsField;
            }
            set {
                this.argumentsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int Priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class XmlNamedReference {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SimulationDescriptorReference : ValueType {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SimulationDescriptorReference))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ValueType {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FactionTraitTooltipOverride {

        private OverrideType typeField;

        private string overrideNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public OverrideType Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OverrideName {
            get {
                return this.overrideNameField;
            }
            set {
                this.overrideNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum OverrideType {

        /// <remarks/>
        Constructible,

        /// <remarks/>
        Technology,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AbstractToShipDesignPair {

        private string abstractField;

        private string shipDesignField;

        private int priorityField;

        public AbstractToShipDesignPair() {
            this.priorityField = 0;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Abstract {
            get {
                return this.abstractField;
            }
            set {
                this.abstractField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ShipDesign {
            get {
                return this.shipDesignField;
            }
            set {
                this.shipDesignField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int Priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FactionTraitStartingSenate : FactionTrait {

        private XmlNamedReference governmentField;

        private PoliticsWeight[] politicsWeightField;

        private int priorityField;

        public FactionTraitStartingSenate() {
            this.priorityField = 0;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference Government {
            get {
                return this.governmentField;
            }
            set {
                this.governmentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PoliticsWeight", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PoliticsWeight[] PoliticsWeight {
            get {
                return this.politicsWeightField;
            }
            set {
                this.politicsWeightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int Priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PoliticsWeight {

        private string politicsField;

        private float weightField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Politics {
            get {
                return this.politicsField;
            }
            set {
                this.politicsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public float Weight {
            get {
                return this.weightField;
            }
            set {
                this.weightField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MajorFaction))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Faction : DatatableElement {

        private XmlNamedReference affinityField;

        private XmlNamedReference[] traitField;

        private FactionTraitStartingSenate traitStartingSenateField;

        private XmlNamedReference[] bailiffField;

        private StartingPopulation majorPopulationField;

        private StartingPopulation[] minorPopulationField;

        private string localizedDescriptionField;

        private string localizedNameField;

        private string authorField;

        private bool hiddenField;

        private bool standardField;

        private short priorityField;

        private string difficultyField;

        private string difficultyAgainstField;

        private string lipsyncAffinityMappingOverrideField;

        public Faction() {
            this.authorField = "";
            this.hiddenField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference Affinity {
            get {
                return this.affinityField;
            }
            set {
                this.affinityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Trait", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] Trait {
            get {
                return this.traitField;
            }
            set {
                this.traitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FactionTraitStartingSenate TraitStartingSenate {
            get {
                return this.traitStartingSenateField;
            }
            set {
                this.traitStartingSenateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Bailiff", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] Bailiff {
            get {
                return this.bailiffField;
            }
            set {
                this.bailiffField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public StartingPopulation MajorPopulation {
            get {
                return this.majorPopulationField;
            }
            set {
                this.majorPopulationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MinorPopulation", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public StartingPopulation[] MinorPopulation {
            get {
                return this.minorPopulationField;
            }
            set {
                this.minorPopulationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LocalizedDescription {
            get {
                return this.localizedDescriptionField;
            }
            set {
                this.localizedDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LocalizedName {
            get {
                return this.localizedNameField;
            }
            set {
                this.localizedNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Author {
            get {
                return this.authorField;
            }
            set {
                this.authorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Hidden {
            get {
                return this.hiddenField;
            }
            set {
                this.hiddenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Standard {
            get {
                return this.standardField;
            }
            set {
                this.standardField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public short Priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Difficulty {
            get {
                return this.difficultyField;
            }
            set {
                this.difficultyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DifficultyAgainst {
            get {
                return this.difficultyAgainstField;
            }
            set {
                this.difficultyAgainstField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LipsyncAffinityMappingOverride {
            get {
                return this.lipsyncAffinityMappingOverrideField;
            }
            set {
                this.lipsyncAffinityMappingOverrideField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class MajorFaction : Faction {
    }
}