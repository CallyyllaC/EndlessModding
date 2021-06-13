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

namespace EndlessModding.EndlessSpace2.Common.Classes.AnomalyReductionDefinitions
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ConstructibleElement))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AnomalyReductionDefinition))]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ConstructibleElement))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AnomalyReductionDefinition))]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AnomalyReductionDefinition))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConstructibleElement : UnlockDatatableElement
    {

        private AIGain[] aIGainField;

        private SupervisorGain[] supervisorGainField;

        private Tags tagsField;

        private SimulationDescriptorReference[] inProgressSimulationDescriptorReferenceField;

        private SimulationDescriptorReference[] queuedSimulationDescriptorReferenceField;

        private XmlNamedReference constructionQueueEntityActionReferenceField;

        private CostReductionReference[] costReductionReferenceField;

        private object[] itemsField;

        private Prerequisite[] items1Field;

        private MetaPrerequisite[] metaPrerequisiteField;

        private SimulationDescriptorReference[] simulationDescriptorReferenceField;

        private XmlNamedReference[] populationEventField;

        private float buyoutCostModifierField;

        private bool stackableField;

        private string categoryField;

        private string subCategoryField;

        private string scoreProviderField;

        private bool hiddenField;

        private bool needConfirmField;

        private bool consumeResourceSurplusField;

        public ConstructibleElement()
        {
            this.buyoutCostModifierField = ((float)(0F));
            this.stackableField = false;
            this.hiddenField = false;
            this.needConfirmField = false;
            this.consumeResourceSurplusField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AIGain", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AIGain[] AIGain
        {
            get
            {
                return this.aIGainField;
            }
            set
            {
                this.aIGainField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SupervisorGain", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SupervisorGain[] SupervisorGain
        {
            get
            {
                return this.supervisorGainField;
            }
            set
            {
                this.supervisorGainField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Tags Tags
        {
            get
            {
                return this.tagsField;
            }
            set
            {
                this.tagsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InProgressSimulationDescriptorReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SimulationDescriptorReference[] InProgressSimulationDescriptorReference
        {
            get
            {
                return this.inProgressSimulationDescriptorReferenceField;
            }
            set
            {
                this.inProgressSimulationDescriptorReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("QueuedSimulationDescriptorReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SimulationDescriptorReference[] QueuedSimulationDescriptorReference
        {
            get
            {
                return this.queuedSimulationDescriptorReferenceField;
            }
            set
            {
                this.queuedSimulationDescriptorReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference ConstructionQueueEntityActionReference
        {
            get
            {
                return this.constructionQueueEntityActionReferenceField;
            }
            set
            {
                this.constructionQueueEntityActionReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CostReductionReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CostReductionReference[] CostReductionReference
        {
            get
            {
                return this.costReductionReferenceField;
            }
            set
            {
                this.costReductionReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Cost", typeof(ConstructionCost), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("CustomCost", typeof(CustomConstructionCost), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("InfiniteCost", typeof(InfiniteCost), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object[] Items
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
        [System.Xml.Serialization.XmlElementAttribute("DatePrerequisite", typeof(DatePrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("DownloadableContentPrerequisite", typeof(DownloadableContentPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("GameSettingPrerequisite", typeof(GameSettingPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("InterpreterPrerequisite", typeof(InterpreterPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("PathPrerequisite", typeof(PathPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("SupportPrerequisite", typeof(SupportPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("TechnologyPrerequisite", typeof(TechnologyPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlElementAttribute("MetaPrerequisite", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MetaPrerequisite[] MetaPrerequisite
        {
            get
            {
                return this.metaPrerequisiteField;
            }
            set
            {
                this.metaPrerequisiteField = value;
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
        [System.ComponentModel.DefaultValueAttribute(typeof(float), "0")]
        public float BuyoutCostModifier
        {
            get
            {
                return this.buyoutCostModifierField;
            }
            set
            {
                this.buyoutCostModifierField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Stackable
        {
            get
            {
                return this.stackableField;
            }
            set
            {
                this.stackableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Hidden
        {
            get
            {
                return this.hiddenField;
            }
            set
            {
                this.hiddenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool NeedConfirm
        {
            get
            {
                return this.needConfirmField;
            }
            set
            {
                this.needConfirmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool ConsumeResourceSurplus
        {
            get
            {
                return this.consumeResourceSurplusField;
            }
            set
            {
                this.consumeResourceSurplusField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AIGain
    {

        private string[] tagField;

        private string ressourceNameField;

        private bool invertedField;

        public AIGain()
        {
            this.invertedField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Tag", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string[] Tag
        {
            get
            {
                return this.tagField;
            }
            set
            {
                this.tagField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RessourceName
        {
            get
            {
                return this.ressourceNameField;
            }
            set
            {
                this.ressourceNameField = value;
            }
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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SupervisorGain
    {

        private Tags tagsField;

        private string nameField;

        private float weightField;

        public SupervisorGain()
        {
            this.weightField = ((float)(1F));
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Tags Tags
        {
            get
            {
                return this.tagsField;
            }
            set
            {
                this.tagsField = value;
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
        [System.ComponentModel.DefaultValueAttribute(typeof(float), "1")]
        public float Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Tags
    {

        private string valueField;

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
    public partial class CostReductionReference
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
    public partial class InfiniteCost
    {

        private string resourceNameField;

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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PathPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InterpreterPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PathValidityPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TechnologyPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SupportPrerequisite))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DownloadableContentPrerequisite))]
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
    public partial class SupportPrerequisite : Prerequisite
    {

        private string politicsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Politics
        {
            get
            {
                return this.politicsField;
            }
            set
            {
                this.politicsField = value;
            }
        }
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
    public partial class GameSettingPrerequisite : Prerequisite
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MetaPrerequisite
    {

        private Prerequisite[] itemsField;

        private PrerequisiteOperator operatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DatePrerequisite", typeof(DatePrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("GameSettingPrerequisite", typeof(GameSettingPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("InterpreterPrerequisite", typeof(InterpreterPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("PathPrerequisite", typeof(PathPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("SupportPrerequisite", typeof(SupportPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        public PrerequisiteOperator Operator
        {
            get
            {
                return this.operatorField;
            }
            set
            {
                this.operatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum PrerequisiteOperator
    {

        /// <remarks/>
        Or,

        /// <remarks/>
        And,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class AnomalyReductionDefinition : ConstructibleElement
    {

        private XmlNamedReference baseAnomalyField;

        private XmlNamedReference resultAnomalyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference BaseAnomaly
        {
            get
            {
                return this.baseAnomalyField;
            }
            set
            {
                this.baseAnomalyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference ResultAnomaly
        {
            get
            {
                return this.resultAnomalyField;
            }
            set
            {
                this.resultAnomalyField = value;
            }
        }
    }
}