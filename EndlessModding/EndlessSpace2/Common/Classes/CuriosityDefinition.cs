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

namespace EndlessModding.EndlessSpace2.Common.Classes.CuriosityDefinition
{
    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CuriosityDefinition))]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CuriosityEffectDefinition_PlanetAnomaly))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CuriosityEffectDefinition_ResourceDeposit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CuriosityEffectDefinition_Droplist))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CuriosityEffectDefinition_RevealNeighbours))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CuriosityEffectDefinition_RevealCuriosities))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CuriosityEffectDefinition_ShipExperience))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CuriosityEffectDefinition
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CuriosityEffectDefinition_PlanetAnomaly : CuriosityEffectDefinition
    {

        private XmlNamedReference[] anomalyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Anomaly", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] Anomaly
        {
            get
            {
                return this.anomalyField;
            }
            set
            {
                this.anomalyField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CuriosityEffectDefinition_ResourceDeposit : CuriosityEffectDefinition
    {

        private XmlNamedReference[] resourceDepositReferenceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResourceDepositReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] ResourceDepositReference
        {
            get
            {
                return this.resourceDepositReferenceField;
            }
            set
            {
                this.resourceDepositReferenceField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CuriosityEffectDefinition_Droplist : CuriosityEffectDefinition
    {

        private XmlNamedReference[] droplistField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Droplist", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] Droplist
        {
            get
            {
                return this.droplistField;
            }
            set
            {
                this.droplistField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CuriosityEffectDefinition_RevealNeighbours : CuriosityEffectDefinition
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CuriosityEffectDefinition_RevealCuriosities : CuriosityEffectDefinition
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CuriosityEffectDefinition_ShipExperience : CuriosityEffectDefinition
    {

        private CuriosityEffectDefinition[] itemsField;

        private float valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CuriositiesRevealEffectFallback", typeof(CuriosityEffectDefinition_RevealCuriosities), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("DroplistEffectFallback", typeof(CuriosityEffectDefinition_Droplist), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("NeighboursRevealEffectFallback", typeof(CuriosityEffectDefinition_RevealNeighbours), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CuriosityEffectDefinition[] Items
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
    public partial class QuestPrerequisitesDefinition
    {

        private Prerequisite[] itemsField;

        private string targetField;

        private bool anyTargetField;

        private bool anyPrerequisiteField;

        public QuestPrerequisitesDefinition()
        {
            this.anyTargetField = false;
            this.anyPrerequisiteField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DatePrerequisite", typeof(DatePrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("DownloadableContentPrerequisite", typeof(DownloadableContentPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("GameSettingPrerequisite", typeof(GameSettingPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("InterpreterPrerequisite", typeof(InterpreterPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("PathPrerequisite", typeof(PathPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("QuestStatePrerequisite", typeof(QuestStatePrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("StatisticPrerequisite", typeof(StatisticPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Target
        {
            get
            {
                return this.targetField;
            }
            set
            {
                this.targetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool AnyTarget
        {
            get
            {
                return this.anyTargetField;
            }
            set
            {
                this.anyTargetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool AnyPrerequisite
        {
            get
            {
                return this.anyPrerequisiteField;
            }
            set
            {
                this.anyPrerequisiteField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DatePrerequisite : Prerequisite
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(QuestStatePrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DownloadableContentPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StatisticPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InterpreterPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PathPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PathValidityPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TechnologyPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GameSettingPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DatePrerequisite))]
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
    public partial class QuestStatePrerequisite : Prerequisite
    {

        private string questDefinitionNameField;

        private QuestState questStateField;

        private string questStepNameField;

        private QuestState questStepStateField;

        public QuestStatePrerequisite()
        {
            this.questStepNameField = "";
            this.questStepStateField = QuestState.Completed;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string QuestDefinitionName
        {
            get
            {
                return this.questDefinitionNameField;
            }
            set
            {
                this.questDefinitionNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public QuestState QuestState
        {
            get
            {
                return this.questStateField;
            }
            set
            {
                this.questStateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string QuestStepName
        {
            get
            {
                return this.questStepNameField;
            }
            set
            {
                this.questStepNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(QuestState.Completed)]
        public QuestState QuestStepState
        {
            get
            {
                return this.questStepStateField;
            }
            set
            {
                this.questStepStateField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum QuestState
    {

        /// <remarks/>
        NotStarted,

        /// <remarks/>
        InProgress,

        /// <remarks/>
        Completed,

        /// <remarks/>
        Failed,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DownloadableContentPrerequisite : Prerequisite
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class StatisticPrerequisite : Prerequisite
    {

        private float minimumValueField;

        private float maximumValueField;

        public StatisticPrerequisite()
        {
            this.minimumValueField = ((float)(-3.402823E+38F));
            this.maximumValueField = ((float)(3.402823E+38F));
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(typeof(float), "-3.402823E+38")]
        public float MinimumValue
        {
            get
            {
                return this.minimumValueField;
            }
            set
            {
                this.minimumValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(typeof(float), "3.402823E+38")]
        public float MaximumValue
        {
            get
            {
                return this.maximumValueField;
            }
            set
            {
                this.maximumValueField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PathPrerequisite : Prerequisite
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
    public partial class GameSettingPrerequisite : Prerequisite
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class CuriosityDefinition : DatatableElement
    {

        private Prerequisite[] visibilityPrerequisitesField;

        private QuestPrerequisitesDefinition[] questPrerequisitesField;

        private CuriosityEffectDefinition[] itemsField;

        private SimulationDescriptorReference[] simulationDescriptorReferenceField;

        private XmlNamedReference[] populationEventField;

        private string displayedTypeField;

        private string subCategoryField;

        private float difficultyField;

        private bool discoverOnColonizationField;

        private bool indestructibleField;

        private string scoreProviderField;

        public CuriosityDefinition()
        {
            this.discoverOnColonizationField = false;
            this.indestructibleField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(typeof(DatePrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        [System.Xml.Serialization.XmlArrayItemAttribute(typeof(GameSettingPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        [System.Xml.Serialization.XmlArrayItemAttribute(typeof(InterpreterPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        [System.Xml.Serialization.XmlArrayItemAttribute(typeof(PathPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        [System.Xml.Serialization.XmlArrayItemAttribute(typeof(TechnologyPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public Prerequisite[] VisibilityPrerequisites
        {
            get
            {
                return this.visibilityPrerequisitesField;
            }
            set
            {
                this.visibilityPrerequisitesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("QuestPrerequisites", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public QuestPrerequisitesDefinition[] QuestPrerequisites
        {
            get
            {
                return this.questPrerequisitesField;
            }
            set
            {
                this.questPrerequisitesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CuriositiesRevealEffect", typeof(CuriosityEffectDefinition_RevealCuriosities), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("DroplistEffect", typeof(CuriosityEffectDefinition_Droplist), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("NeighboursRevealEffect", typeof(CuriosityEffectDefinition_RevealNeighbours), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("PlanetAnomalyEffect", typeof(CuriosityEffectDefinition_PlanetAnomaly), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("ResourceDepositEffect", typeof(CuriosityEffectDefinition_ResourceDeposit), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("ShipExperienceEffect", typeof(CuriosityEffectDefinition_ShipExperience), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CuriosityEffectDefinition[] Items
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
        [System.Xml.Serialization.XmlElementAttribute("PopulationEvent", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] PopulationEvent
        {
            get
            {
                return this.populationEventField;
            }
            set
            {
                this.populationEventField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DisplayedType
        {
            get
            {
                return this.displayedTypeField;
            }
            set
            {
                this.displayedTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SubCategory
        {
            get
            {
                return this.subCategoryField;
            }
            set
            {
                this.subCategoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public float Difficulty
        {
            get
            {
                return this.difficultyField;
            }
            set
            {
                this.difficultyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool DiscoverOnColonization
        {
            get
            {
                return this.discoverOnColonizationField;
            }
            set
            {
                this.discoverOnColonizationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Indestructible
        {
            get
            {
                return this.indestructibleField;
            }
            set
            {
                this.indestructibleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ScoreProvider
        {
            get
            {
                return this.scoreProviderField;
            }
            set
            {
                this.scoreProviderField = value;
            }
        }
    }
}