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

namespace EndlessModding.EndlessSpace2.Common.Classes.Generator_Definitions_Resource
{
    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class PlanetaryResourceDefinition
    {

        private string categoryField;

        private string tierField;

        private string tagField;

        private bool maybeVisibleField;

        private string tagWhenVisibleField;

        private string[] planetFilterMustField;

        private string[] planetFilterAnyField;

        private string[] planetFilterNotField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Tier
        {
            get
            {
                return this.tierField;
            }
            set
            {
                this.tierField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Tag
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool MaybeVisible
        {
            get
            {
                return this.maybeVisibleField;
            }
            set
            {
                this.maybeVisibleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TagWhenVisible
        {
            get
            {
                return this.tagWhenVisibleField;
            }
            set
            {
                this.tagWhenVisibleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PlanetFilterMust", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string[] PlanetFilterMust
        {
            get
            {
                return this.planetFilterMustField;
            }
            set
            {
                this.planetFilterMustField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PlanetFilterAny", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string[] PlanetFilterAny
        {
            get
            {
                return this.planetFilterAnyField;
            }
            set
            {
                this.planetFilterAnyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PlanetFilterNot", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string[] PlanetFilterNot
        {
            get
            {
                return this.planetFilterNotField;
            }
            set
            {
                this.planetFilterNotField = value;
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
}