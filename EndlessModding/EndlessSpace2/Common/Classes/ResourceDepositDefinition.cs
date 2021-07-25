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

namespace EndlessModding.EndlessSpace2.Common.Classes.ResourceDepositDefinitions
{
    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ResourceDepositDefinition))]
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
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class ResourceDepositDefinition : DatatableElement
    {

        private SimulationDescriptorReference[] simulationDescriptorReferenceField;

        private string subCategoryField;

        private bool indestructibleField;

        private ResourceRarity rarityField;

        private ResourceFamily familyField;

        private string linkedResourceField;

        public ResourceDepositDefinition()
        {
            this.indestructibleField = false;
            this.familyField = ResourceFamily.None;
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
        public ResourceRarity Rarity
        {
            get
            {
                return this.rarityField;
            }
            set
            {
                this.rarityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(ResourceFamily.None)]
        public ResourceFamily Family
        {
            get
            {
                return this.familyField;
            }
            set
            {
                this.familyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LinkedResource
        {
            get
            {
                return this.linkedResourceField;
            }
            set
            {
                this.linkedResourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum ResourceRarity
    {

        /// <remarks/>
        Common,

        /// <remarks/>
        Uncommon,

        /// <remarks/>
        Rare,

        /// <remarks/>
        Legendary,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum ResourceFamily
    {

        /// <remarks/>
        None,

        /// <remarks/>
        Happiness,

        /// <remarks/>
        Economy,

        /// <remarks/>
        Science,

        /// <remarks/>
        Growth,

        /// <remarks/>
        Production,

        /// <remarks/>
        Prestige,

        /// <remarks/>
        Defense,

        /// <remarks/>
        GroundBattle,
    }
}