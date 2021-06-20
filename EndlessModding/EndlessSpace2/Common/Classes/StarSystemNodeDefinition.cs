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

namespace EndlessModding.EndlessSpace2.Common.Classes.StarSystemNodeDefinitions
{
    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StarSystemNodeDefinition))]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ResourceDepositDefinitionWithSize))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PlanetDefinition))]
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
    public partial class ResourceDepositDefinitionWithSize : ValueType
    {

        private XmlNamedReference definitionReferenceField;

        private XmlNamedReference sizeDescriptorReferenceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference DefinitionReference
        {
            get
            {
                return this.definitionReferenceField;
            }
            set
            {
                this.definitionReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference SizeDescriptorReference
        {
            get
            {
                return this.sizeDescriptorReferenceField;
            }
            set
            {
                this.sizeDescriptorReferenceField = value;
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
    public partial class PlanetDefinition : ValueType
    {

        private XmlNamedReference[] simulationDescriptorReferenceField;

        private XmlNamedReference[] anomalyReferenceField;

        private XmlNamedReference[] curiosityReferenceField;

        private ResourceDepositDefinitionWithSize[] resourceDepositField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SimulationDescriptorReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] SimulationDescriptorReference
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
        [System.Xml.Serialization.XmlElementAttribute("AnomalyReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] AnomalyReference
        {
            get
            {
                return this.anomalyReferenceField;
            }
            set
            {
                this.anomalyReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CuriosityReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] CuriosityReference
        {
            get
            {
                return this.curiosityReferenceField;
            }
            set
            {
                this.curiosityReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResourceDeposit", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ResourceDepositDefinitionWithSize[] ResourceDeposit
        {
            get
            {
                return this.resourceDepositField;
            }
            set
            {
                this.resourceDepositField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class StarSystemNodeDefinition : DatatableElement
    {

        private XmlNamedReference[] simulationDescriptorReferenceField;

        private PlanetDefinition[] planetDefinitionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SimulationDescriptorReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference[] SimulationDescriptorReference
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
        [System.Xml.Serialization.XmlElementAttribute("PlanetDefinition", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PlanetDefinition[] PlanetDefinition
        {
            get
            {
                return this.planetDefinitionField;
            }
            set
            {
                this.planetDefinitionField = value;
            }
        }
    }
}