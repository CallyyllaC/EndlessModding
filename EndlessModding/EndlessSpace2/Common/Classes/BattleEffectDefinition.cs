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

namespace EndlessModding.EndlessSpace2.Common.Classes.BattleEffectDefinition
{
    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BattleEffect))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BattleEffect_EmpireReward_SpawnShips))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BattleEffect_EmpireReward_Resource))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BattleEffect_SetStatus))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BattleEffect_SetPropertyValue))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BattleEffect_ApplyDescriptor))]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RealizationEventByState
    {

        private BattleEffectState stateField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public BattleEffectState State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum BattleEffectState
    {

        /// <remarks/>
        Undefined,

        /// <remarks/>
        Started,

        /// <remarks/>
        Running,

        /// <remarks/>
        Reset,

        /// <remarks/>
        Finished,
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PathPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InterpreterPrerequisite))]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EncounterEntityFilterDefinition
    {

        private Prerequisite[] itemsField;

        private EncounterEntityType entityTypeField;

        private EncounterEntityTags entityTagsField;

        public EncounterEntityFilterDefinition()
        {
            this.entityTypeField = EncounterEntityType.Undefined;
            this.entityTagsField = EncounterEntityTags.None;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InterpreterPrerequisite", typeof(InterpreterPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("PathPrerequisite", typeof(PathPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(EncounterEntityType.Undefined)]
        public EncounterEntityType EntityType
        {
            get
            {
                return this.entityTypeField;
            }
            set
            {
                this.entityTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(EncounterEntityTags.None)]
        public EncounterEntityTags EntityTags
        {
            get
            {
                return this.entityTagsField;
            }
            set
            {
                this.entityTagsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum EncounterEntityType
    {

        /// <remarks/>
        Arena,

        /// <remarks/>
        EffectArea,

        /// <remarks/>
        Group,

        /// <remarks/>
        Flotilla,

        /// <remarks/>
        Ship,

        /// <remarks/>
        ShipSection,

        /// <remarks/>
        Module,

        /// <remarks/>
        Salvo,

        /// <remarks/>
        Citadel,

        /// <remarks/>
        CitadelModule,

        /// <remarks/>
        CitadelSalvo,

        /// <remarks/>
        Undefined,
    }

    /// <remarks/>
    [System.FlagsAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum EncounterEntityTags
    {

        /// <remarks/>
        None = 1,

        /// <remarks/>
        Me = 2,

        /// <remarks/>
        Other = 4,

        /// <remarks/>
        SameShip = 8,

        /// <remarks/>
        OtherShip = 16,

        /// <remarks/>
        SameFlotilla = 32,

        /// <remarks/>
        OtherFlotilla = 64,

        /// <remarks/>
        SameGroup = 128,

        /// <remarks/>
        OtherGroup = 256,

        /// <remarks/>
        EffectInitiator = 512,

        /// <remarks/>
        EffectTarget = 1024,

        /// <remarks/>
        Alive = 2048,

        /// <remarks/>
        Deactivated = 4096,

        /// <remarks/>
        Destroyed = 8192,

        /// <remarks/>
        SameModule = 16384,

        /// <remarks/>
        OtherModule = 32768,

        /// <remarks/>
        Arena = 65536,

        /// <remarks/>
        Reinforcement = 131072,

        /// <remarks/>
        Inactive = 262144,

        /// <remarks/>
        MyMainTarget = 524288,

        /// <remarks/>
        SameCitadel = 1048576,

        /// <remarks/>
        OtherCitadel = 2097152,

        /// <remarks/>
        SameCitadelModule = 4194304,

        /// <remarks/>
        OtherCitadelModule = 8388608,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EncounterEventPrerequisiteDefinition
    {

        private EncounterEntityFilterDefinition eventInitiatorFilterField;

        private EncounterEntityFilterDefinition eventTargetFilterField;

        private EncounterEventType eventTypeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EncounterEntityFilterDefinition EventInitiatorFilter
        {
            get
            {
                return this.eventInitiatorFilterField;
            }
            set
            {
                this.eventInitiatorFilterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EncounterEntityFilterDefinition EventTargetFilter
        {
            get
            {
                return this.eventTargetFilterField;
            }
            set
            {
                this.eventTargetFilterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public EncounterEventType EventType
        {
            get
            {
                return this.eventTypeField;
            }
            set
            {
                this.eventTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum EncounterEventType
    {

        /// <remarks/>
        BattleStart,

        /// <remarks/>
        BattleStart_GroupInteraction,

        /// <remarks/>
        BattleEnd,

        /// <remarks/>
        PhaseStart,

        /// <remarks/>
        PhaseEnd,

        /// <remarks/>
        FirstPhaseStart,

        /// <remarks/>
        LastPhaseStart,

        /// <remarks/>
        PostPhaseStart,

        /// <remarks/>
        Spawned,

        /// <remarks/>
        Attack_Preparation,

        /// <remarks/>
        Attack_Start,

        /// <remarks/>
        Attack_PrepareSalvoLaunched,

        /// <remarks/>
        Attack_SalvoLaunched,

        /// <remarks/>
        Attack_PostSalvoLaunched,

        /// <remarks/>
        Attack_HitShield,

        /// <remarks/>
        Attack_PrepareHitTarget,

        /// <remarks/>
        Attack_HitTarget,

        /// <remarks/>
        Attack_PostHitTarget,

        /// <remarks/>
        Attack_Miss,

        /// <remarks/>
        Attack_TargetLost,

        /// <remarks/>
        Attack_End,

        /// <remarks/>
        EnterArea,

        /// <remarks/>
        ExitArea,

        /// <remarks/>
        MedalGained,

        /// <remarks/>
        ComputeEndBattleStatus,

        /// <remarks/>
        Healing_Prepare,

        /// <remarks/>
        Healing,

        /// <remarks/>
        BattleFinalization,

        /// <remarks/>
        Deactivation,

        /// <remarks/>
        Destruction,

        /// <remarks/>
        DestructionComplete,

        /// <remarks/>
        Squadron_MatchCreated_Duel,

        /// <remarks/>
        Squadron_MatchCreated_Chase,

        /// <remarks/>
        Squadron_MatchCreated_Assault,

        /// <remarks/>
        Squadron_MatchImminent_Duel,

        /// <remarks/>
        Squadron_MatchImminent_Chase,

        /// <remarks/>
        Squadron_MatchImminent_Assault,

        /// <remarks/>
        Squadron_MatchAction_PrepareAttack,

        /// <remarks/>
        Squadron_MatchAction_Attack,

        /// <remarks/>
        Squadron_MatchAction_Hit,

        /// <remarks/>
        Squadron_MatchAction_PostAttack,

        /// <remarks/>
        CitadelAttack_SalvoLaunched,

        /// <remarks/>
        CitadelAttack_HitShield,

        /// <remarks/>
        CitadelAttack_PrepareHitTarget,

        /// <remarks/>
        CitadelAttack_HitTarget,

        /// <remarks/>
        CitadelAttack_PostHitTarget,
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BattleEffect_EmpireReward_SpawnShips))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BattleEffect_EmpireReward_Resource))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BattleEffect_SetStatus))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BattleEffect_SetPropertyValue))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BattleEffect_ApplyDescriptor))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class BattleEffect : DatatableElement
    {

        private EncounterEventPrerequisiteDefinition[] cancellationEventPrerequisiteField;

        private RealizationEventByState[] realizationEventField;

        private string durationField;

        private float frequencyField;

        private StackingBehaviourType stackingBehaviourField;

        public BattleEffect()
        {
            this.durationField = "0";
            this.frequencyField = ((float)(-1F));
            this.stackingBehaviourField = StackingBehaviourType.Ignore;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CancellationEventPrerequisite", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EncounterEventPrerequisiteDefinition[] CancellationEventPrerequisite
        {
            get
            {
                return this.cancellationEventPrerequisiteField;
            }
            set
            {
                this.cancellationEventPrerequisiteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RealizationEvent", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RealizationEventByState[] RealizationEvent
        {
            get
            {
                return this.realizationEventField;
            }
            set
            {
                this.realizationEventField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("0")]
        public string Duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(typeof(float), "-1")]
        public float Frequency
        {
            get
            {
                return this.frequencyField;
            }
            set
            {
                this.frequencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(StackingBehaviourType.Ignore)]
        public StackingBehaviourType StackingBehaviour
        {
            get
            {
                return this.stackingBehaviourField;
            }
            set
            {
                this.stackingBehaviourField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum StackingBehaviourType
    {

        /// <remarks/>
        Stack,

        /// <remarks/>
        Reset,

        /// <remarks/>
        Ignore,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class BattleEffect_ApplyDescriptor : BattleEffect
    {

        private SimulationDescriptorReference[] simulationDescriptorReferenceField;

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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class BattleEffect_SetPropertyValue : BattleEffect
    {

        private string propertyNameField;

        private OperationType operationField;

        private string interpreterFormulaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PropertyName
        {
            get
            {
                return this.propertyNameField;
            }
            set
            {
                this.propertyNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public OperationType Operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string InterpreterFormula
        {
            get
            {
                return this.interpreterFormulaField;
            }
            set
            {
                this.interpreterFormulaField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum OperationType
    {

        /// <remarks/>
        Set,

        /// <remarks/>
        Addition,

        /// <remarks/>
        Subtraction,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class BattleEffect_SetStatus : BattleEffect
    {

        private EncounterEntityStatus statusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public EncounterEntityStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum EncounterEntityStatus
    {

        /// <remarks/>
        Alive,

        /// <remarks/>
        Deactivated,

        /// <remarks/>
        Destroyed,

        /// <remarks/>
        Inactive,

        /// <remarks/>
        Resurrected,

        /// <remarks/>
        Eliminated,

        /// <remarks/>
        Unset,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class BattleEffect_EmpireReward_Resource : BattleEffect
    {

        private string resourceNameField;

        private string interpreterFormulaField;

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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string InterpreterFormula
        {
            get
            {
                return this.interpreterFormulaField;
            }
            set
            {
                this.interpreterFormulaField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class BattleEffect_EmpireReward_SpawnShips : BattleEffect
    {

        private string shipDesignNameField;

        private string interpreterFormulaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ShipDesignName
        {
            get
            {
                return this.shipDesignNameField;
            }
            set
            {
                this.shipDesignNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string InterpreterFormula
        {
            get
            {
                return this.interpreterFormulaField;
            }
            set
            {
                this.interpreterFormulaField = value;
            }
        }
    }
}