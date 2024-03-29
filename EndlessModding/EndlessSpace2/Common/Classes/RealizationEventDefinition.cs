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

namespace EndlessModding.EndlessSpace2.Common.Classes.RealizationEventDefinitions
{
    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RealizationEventDefinition))]
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
    public partial class RealizationEventWeightChangeDefinition
    {

        private string nameField;

        private int weightChangeField;

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
        public int WeightChange
        {
            get
            {
                return this.weightChangeField;
            }
            set
            {
                this.weightChangeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class RealizationEventDefinition : DatatableElement
    {

        private EncounterEntityType[] availableInitiatorTypeField;

        private EncounterEntityType[] availableTargetTypeField;

        private RealizationEventWeightChangeDefinition[] realizationEventWeightChangeField;

        private int defaultWeightField;

        private bool ignoredByDirectorField;

        public RealizationEventDefinition()
        {
            this.defaultWeightField = 0;
            this.ignoredByDirectorField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AvailableInitiatorType", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EncounterEntityType[] AvailableInitiatorType
        {
            get
            {
                return this.availableInitiatorTypeField;
            }
            set
            {
                this.availableInitiatorTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AvailableTargetType", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EncounterEntityType[] AvailableTargetType
        {
            get
            {
                return this.availableTargetTypeField;
            }
            set
            {
                this.availableTargetTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RealizationEventWeightChange", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RealizationEventWeightChangeDefinition[] RealizationEventWeightChange
        {
            get
            {
                return this.realizationEventWeightChangeField;
            }
            set
            {
                this.realizationEventWeightChangeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int DefaultWeight
        {
            get
            {
                return this.defaultWeightField;
            }
            set
            {
                this.defaultWeightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool IgnoredByDirector
        {
            get
            {
                return this.ignoredByDirectorField;
            }
            set
            {
                this.ignoredByDirectorField = value;
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
}