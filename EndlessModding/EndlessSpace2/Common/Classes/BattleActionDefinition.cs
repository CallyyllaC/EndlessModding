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

namespace EndlessModding.EndlessSpace2.Common.Classes.BattleActionDefinition
{
    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BattleAction))]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SubEntityFilterDefinition
    {

        private EncounterEntityFilterDefinition entityFilterField;

        private SubEntitySelectionMethod selectionMethodField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EncounterEntityFilterDefinition EntityFilter
        {
            get
            {
                return this.entityFilterField;
            }
            set
            {
                this.entityFilterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public SubEntitySelectionMethod SelectionMethod
        {
            get
            {
                return this.selectionMethodField;
            }
            set
            {
                this.selectionMethodField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EncounterEntityFilterDefinition_BattleActionRole))]
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class InterpreterPrerequisite : Prerequisite
    {
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
    public partial class EncounterEntityFilterDefinition_BattleActionRole : EncounterEntityFilterDefinition
    {

        private BattleActionEntityRole entityRoleField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public BattleActionEntityRole EntityRole
        {
            get
            {
                return this.entityRoleField;
            }
            set
            {
                this.entityRoleField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum BattleActionEntityRole
    {

        /// <remarks/>
        Initiator,

        /// <remarks/>
        InitiatorTarget,

        /// <remarks/>
        Owner,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum SubEntitySelectionMethod
    {

        /// <remarks/>
        First,

        /// <remarks/>
        Random,

        /// <remarks/>
        All,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BattleEffectTargetFilterDefinition
    {

        private EncounterEntityFilterDefinition_BattleActionRole entityFilterField;

        private EncounterEntityFilterDefinition parentEntityFilterField;

        private SubEntityFilterDefinition subEntityFilterField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EncounterEntityFilterDefinition_BattleActionRole EntityFilter
        {
            get
            {
                return this.entityFilterField;
            }
            set
            {
                this.entityFilterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EncounterEntityFilterDefinition ParentEntityFilter
        {
            get
            {
                return this.parentEntityFilterField;
            }
            set
            {
                this.parentEntityFilterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SubEntityFilterDefinition SubEntityFilter
        {
            get
            {
                return this.subEntityFilterField;
            }
            set
            {
                this.subEntityFilterField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BattleEffectApplicationContextDefinition
    {

        private Prerequisite[] itemsField;

        private BattleEffectTargetFilterDefinition targetFilterField;

        private XmlNamedReference[] battleEffectReferenceField;

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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public BattleEffectTargetFilterDefinition TargetFilter
        {
            get
            {
                return this.targetFilterField;
            }
            set
            {
                this.targetFilterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BattleEffectReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] BattleEffectReference
        {
            get
            {
                return this.battleEffectReferenceField;
            }
            set
            {
                this.battleEffectReferenceField = value;
            }
        }
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class BattleAction : DatatableElement
    {

        private EncounterEventPrerequisiteDefinition eventPrerequisiteField;

        private Prerequisite[] itemsField;

        private BattleEffectApplicationContextDefinition[] battleEffectApplicationContextField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EncounterEventPrerequisiteDefinition EventPrerequisite
        {
            get
            {
                return this.eventPrerequisiteField;
            }
            set
            {
                this.eventPrerequisiteField = value;
            }
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
        [System.Xml.Serialization.XmlElementAttribute("BattleEffectApplicationContext", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public BattleEffectApplicationContextDefinition[] BattleEffectApplicationContext
        {
            get
            {
                return this.battleEffectApplicationContextField;
            }
            set
            {
                this.battleEffectApplicationContextField = value;
            }
        }
    }
}