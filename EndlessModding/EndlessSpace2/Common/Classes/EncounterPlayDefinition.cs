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

namespace EndlessModding.EndlessSpace2.Common.Classes.EncounterPlayDefinition
{
    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConstructionCost
    {

        private bool instantField;

        private bool instantOnCompletionField;

        private string resourceNameField;

        private float valueField;

        public ConstructionCost()
        {
            this.instantField = false;
            this.instantOnCompletionField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Instant
        {
            get
            {
                return this.instantField;
            }
            set
            {
                this.instantField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool InstantOnCompletion
        {
            get
            {
                return this.instantOnCompletionField;
            }
            set
            {
                this.instantOnCompletionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ResourceName
        {
            get
            {
                return this.resourceNameField;
            }
            set
            {
                this.resourceNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public float Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CustomConstructionCost
    {

        private bool instantField;

        private bool instantOnCompletionField;

        private string resourceNameField;

        private string valueField;

        public CustomConstructionCost()
        {
            this.instantField = false;
            this.instantOnCompletionField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Instant
        {
            get
            {
                return this.instantField;
            }
            set
            {
                this.instantField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool InstantOnCompletion
        {
            get
            {
                return this.instantOnCompletionField;
            }
            set
            {
                this.instantOnCompletionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ResourceName
        {
            get
            {
                return this.resourceNameField;
            }
            set
            {
                this.resourceNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UnlockDatatableElement))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EncounterPlayDefinition))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DatatableElement
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EncounterPlayDefinition))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UnlockDatatableElement : DatatableElement
    {

        private string keyWordsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string KeyWords
        {
            get
            {
                return this.keyWordsField;
            }
            set
            {
                this.keyWordsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EncounterFlotillaSpawnParametersDefinition
    {

        private SimulationDescriptorReference[] simulationDescriptorReferenceField;

        private int phaseIndexField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SimulationDescriptorReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SimulationDescriptorReference[] SimulationDescriptorReference
        {
            get
            {
                return this.simulationDescriptorReferenceField;
            }
            set
            {
                this.simulationDescriptorReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int PhaseIndex
        {
            get
            {
                return this.phaseIndexField;
            }
            set
            {
                this.phaseIndexField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SimulationDescriptorReference : ValueType
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
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
    public partial class ValueType
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ShipSizeQuota
    {

        private string shipSizeField;

        private int quotaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ShipSize
        {
            get
            {
                return this.shipSizeField;
            }
            set
            {
                this.shipSizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Quota
        {
            get
            {
                return this.quotaField;
            }
            set
            {
                this.quotaField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PathPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InterpreterPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PathValidityPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TechnologyPrerequisite))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Prerequisite
    {

        private bool invertedField;

        private string flagsField;

        private string valueField;

        public Prerequisite()
        {
            this.invertedField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Inverted
        {
            get
            {
                return this.invertedField;
            }
            set
            {
                this.invertedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Flags
        {
            get
            {
                return this.flagsField;
            }
            set
            {
                this.flagsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PathPrerequisite : Prerequisite
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class InterpreterPrerequisite : Prerequisite
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TechnologyPrerequisite))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PathValidityPrerequisite : Prerequisite
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TechnologyPrerequisite : PathValidityPrerequisite
    {

        private bool unlockHiddenField;

        public TechnologyPrerequisite()
        {
            this.unlockHiddenField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool UnlockHidden
        {
            get
            {
                return this.unlockHiddenField;
            }
            set
            {
                this.unlockHiddenField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EncounterFlotillaDefinition
    {

        private Prerequisite[] itemsField;

        private Prerequisite[] items1Field;

        private ShipSizeQuota[] shipSizeQuotaField;

        private SimulationDescriptorReference[] simulationDescriptorReferenceField;

        private EncounterPlayStatusModifierDefinition[] playStatusModifierField;

        private XmlNamedReference formationReferenceField;

        private string nameField;

        private string optimalRangeNameField;

        private int commandPointMinField;

        private int commandPointMaxField;

        private int orderOfAppearanceField;

        private int uICommandPointsMinForUnlockField;

        private int uIShipsMinForUnlockField;

        public EncounterFlotillaDefinition()
        {
            this.commandPointMinField = 0;
            this.commandPointMaxField = -1;
            this.orderOfAppearanceField = 0;
            this.uICommandPointsMinForUnlockField = 0;
            this.uIShipsMinForUnlockField = 0;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InterpreterPrerequisite", typeof(InterpreterPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("PathPrerequisite", typeof(PathPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("TechnologyPrerequisite", typeof(TechnologyPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Prerequisite[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ShipInterpreterPrerequisite", typeof(InterpreterPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("ShipPathPrerequisite", typeof(PathPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Prerequisite[] Items1
        {
            get
            {
                return this.items1Field;
            }
            set
            {
                this.items1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ShipSizeQuota", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ShipSizeQuota[] ShipSizeQuota
        {
            get
            {
                return this.shipSizeQuotaField;
            }
            set
            {
                this.shipSizeQuotaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SimulationDescriptorReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SimulationDescriptorReference[] SimulationDescriptorReference
        {
            get
            {
                return this.simulationDescriptorReferenceField;
            }
            set
            {
                this.simulationDescriptorReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PlayStatusModifier", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EncounterPlayStatusModifierDefinition[] PlayStatusModifier
        {
            get
            {
                return this.playStatusModifierField;
            }
            set
            {
                this.playStatusModifierField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference FormationReference
        {
            get
            {
                return this.formationReferenceField;
            }
            set
            {
                this.formationReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OptimalRangeName
        {
            get
            {
                return this.optimalRangeNameField;
            }
            set
            {
                this.optimalRangeNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int CommandPointMin
        {
            get
            {
                return this.commandPointMinField;
            }
            set
            {
                this.commandPointMinField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(-1)]
        public int CommandPointMax
        {
            get
            {
                return this.commandPointMaxField;
            }
            set
            {
                this.commandPointMaxField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int OrderOfAppearance
        {
            get
            {
                return this.orderOfAppearanceField;
            }
            set
            {
                this.orderOfAppearanceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int UICommandPointsMinForUnlock
        {
            get
            {
                return this.uICommandPointsMinForUnlockField;
            }
            set
            {
                this.uICommandPointsMinForUnlockField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int UIShipsMinForUnlock
        {
            get
            {
                return this.uIShipsMinForUnlockField;
            }
            set
            {
                this.uIShipsMinForUnlockField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EncounterPlayStatusModifierDefinition
    {

        private SimulationDescriptorReference[] simulationDescriptorReferenceField;

        private XmlNamedReference[] battleActionReferenceField;

        private int startPhaseIndexField;

        private int endPhaseIndexField;

        private EncounterPlayStatusTags statusTagsField;

        private ApplicationScopeTags applicationScopeTagsField;

        public EncounterPlayStatusModifierDefinition()
        {
            this.startPhaseIndexField = 0;
            this.endPhaseIndexField = -1;
            this.statusTagsField = EncounterPlayStatusTags.Undefined;
            this.applicationScopeTagsField = ApplicationScopeTags.SameGroup;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SimulationDescriptorReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SimulationDescriptorReference[] SimulationDescriptorReference
        {
            get
            {
                return this.simulationDescriptorReferenceField;
            }
            set
            {
                this.simulationDescriptorReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BattleActionReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] BattleActionReference
        {
            get
            {
                return this.battleActionReferenceField;
            }
            set
            {
                this.battleActionReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int StartPhaseIndex
        {
            get
            {
                return this.startPhaseIndexField;
            }
            set
            {
                this.startPhaseIndexField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(-1)]
        public int EndPhaseIndex
        {
            get
            {
                return this.endPhaseIndexField;
            }
            set
            {
                this.endPhaseIndexField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(EncounterPlayStatusTags.Undefined)]
        public EncounterPlayStatusTags StatusTags
        {
            get
            {
                return this.statusTagsField;
            }
            set
            {
                this.statusTagsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(ApplicationScopeTags.SameGroup)]
        public ApplicationScopeTags ApplicationScopeTags
        {
            get
            {
                return this.applicationScopeTagsField;
            }
            set
            {
                this.applicationScopeTagsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class XmlNamedReference
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.FlagsAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum EncounterPlayStatusTags
    {

        /// <remarks/>
        Undefined = 1,

        /// <remarks/>
        Countered = 2,

        /// <remarks/>
        Regular = 4,

        /// <remarks/>
        Counter = 8,
    }

    /// <remarks/>
    [System.FlagsAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum ApplicationScopeTags
    {

        /// <remarks/>
        SameGroup = 1,

        /// <remarks/>
        OtherGroups = 2,

        /// <remarks/>
        AllGroups = 4,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CounterRuleDefinition
    {

        private string familyNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FamilyName
        {
            get
            {
                return this.familyNameField;
            }
            set
            {
                this.familyNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AIBattleSituation
    {

        private string situationField;

        private SituationMode modeField;

        private float valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Situation
        {
            get
            {
                return this.situationField;
            }
            set
            {
                this.situationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public SituationMode Mode
        {
            get
            {
                return this.modeField;
            }
            set
            {
                this.modeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public float Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum SituationMode
    {

        /// <remarks/>
        Use,

        /// <remarks/>
        Against,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class EncounterPlayDefinition : UnlockDatatableElement
    {

        private AIBattleSituation[] aIBattleSituationsField;

        private Prerequisite[] itemsField;

        private CounterRuleDefinition[] counterRuleField;

        private EncounterPlayStatusModifierDefinition[] statusModifierField;

        private EncounterFlotillaDefinition[] flotillaField;

        private EncounterFlotillaDefinition[] reinforcementFlotillaField;

        private EncounterFlotillaSpawnParametersDefinition[] reinforcementSpawnParametersField;

        private object[] items1Field;

        private string familyNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AIBattleSituations", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AIBattleSituation[] AIBattleSituations
        {
            get
            {
                return this.aIBattleSituationsField;
            }
            set
            {
                this.aIBattleSituationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InterpreterPrerequisite", typeof(InterpreterPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("PathPrerequisite", typeof(PathPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("TechnologyPrerequisite", typeof(TechnologyPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Prerequisite[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CounterRule", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CounterRuleDefinition[] CounterRule
        {
            get
            {
                return this.counterRuleField;
            }
            set
            {
                this.counterRuleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StatusModifier", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EncounterPlayStatusModifierDefinition[] StatusModifier
        {
            get
            {
                return this.statusModifierField;
            }
            set
            {
                this.statusModifierField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Flotilla", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EncounterFlotillaDefinition[] Flotilla
        {
            get
            {
                return this.flotillaField;
            }
            set
            {
                this.flotillaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReinforcementFlotilla", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EncounterFlotillaDefinition[] ReinforcementFlotilla
        {
            get
            {
                return this.reinforcementFlotillaField;
            }
            set
            {
                this.reinforcementFlotillaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReinforcementSpawnParameters", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EncounterFlotillaSpawnParametersDefinition[] ReinforcementSpawnParameters
        {
            get
            {
                return this.reinforcementSpawnParametersField;
            }
            set
            {
                this.reinforcementSpawnParametersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Cost", typeof(ConstructionCost), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("CustomCost", typeof(CustomConstructionCost), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object[] Items1
        {
            get
            {
                return this.items1Field;
            }
            set
            {
                this.items1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FamilyName
        {
            get
            {
                return this.familyNameField;
            }
            set
            {
                this.familyNameField = value;
            }
        }
    }
}