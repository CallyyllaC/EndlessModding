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
namespace EndlessModding.EndlessSpace2.Common.Classes.ForeignAffairsConstructibles
{
    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Datatable
    {

        private DatatableDiplomaticTermResourceExchangeDefinition diplomaticTermResourceExchangeDefinitionField;

        /// <remarks/>
        public DatatableDiplomaticTermResourceExchangeDefinition DiplomaticTermResourceExchangeDefinition
        {
            get
            {
                return this.diplomaticTermResourceExchangeDefinitionField;
            }
            set
            {
                this.diplomaticTermResourceExchangeDefinitionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DatatableDiplomaticTermResourceExchangeDefinition
    {

        private DatatableDiplomaticTermResourceExchangeDefinitionDiplomaticRelationStatePrerequisite diplomaticRelationStatePrerequisiteField;

        private DatatableDiplomaticTermResourceExchangeDefinitionDiplomaticRelationStateEmpirePrerequisite[] diplomaticRelationStateEmpirePrerequisiteField;

        private DatatableDiplomaticTermResourceExchangeDefinitionDiplomaticCustomCost diplomaticCustomCostField;

        private DatatableDiplomaticTermResourceExchangeDefinitionTradableResourceList tradableResourceListField;

        private string nameField;

        private string propositionMethodField;

        private string applicationMethodField;

        private string categoryField;

        private string alignmentField;

        private bool isAcademyProviderField;

        /// <remarks/>
        public DatatableDiplomaticTermResourceExchangeDefinitionDiplomaticRelationStatePrerequisite DiplomaticRelationStatePrerequisite
        {
            get
            {
                return this.diplomaticRelationStatePrerequisiteField;
            }
            set
            {
                this.diplomaticRelationStatePrerequisiteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DiplomaticRelationStateEmpirePrerequisite")]
        public DatatableDiplomaticTermResourceExchangeDefinitionDiplomaticRelationStateEmpirePrerequisite[] DiplomaticRelationStateEmpirePrerequisite
        {
            get
            {
                return this.diplomaticRelationStateEmpirePrerequisiteField;
            }
            set
            {
                this.diplomaticRelationStateEmpirePrerequisiteField = value;
            }
        }

        /// <remarks/>
        public DatatableDiplomaticTermResourceExchangeDefinitionDiplomaticCustomCost DiplomaticCustomCost
        {
            get
            {
                return this.diplomaticCustomCostField;
            }
            set
            {
                this.diplomaticCustomCostField = value;
            }
        }

        /// <remarks/>
        public DatatableDiplomaticTermResourceExchangeDefinitionTradableResourceList TradableResourceList
        {
            get
            {
                return this.tradableResourceListField;
            }
            set
            {
                this.tradableResourceListField = value;
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
        public string PropositionMethod
        {
            get
            {
                return this.propositionMethodField;
            }
            set
            {
                this.propositionMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ApplicationMethod
        {
            get
            {
                return this.applicationMethodField;
            }
            set
            {
                this.applicationMethodField = value;
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
        public string Alignment
        {
            get
            {
                return this.alignmentField;
            }
            set
            {
                this.alignmentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool IsAcademyProvider
        {
            get
            {
                return this.isAcademyProviderField;
            }
            set
            {
                this.isAcademyProviderField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DatatableDiplomaticTermResourceExchangeDefinitionDiplomaticRelationStatePrerequisite
    {

        private string flagsField;

        private bool invertedField;

        private string responsibleField;

        private string valueField;

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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        public string Responsible
        {
            get
            {
                return this.responsibleField;
            }
            set
            {
                this.responsibleField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DatatableDiplomaticTermResourceExchangeDefinitionDiplomaticRelationStateEmpirePrerequisite
    {

        private DatatableDiplomaticTermResourceExchangeDefinitionDiplomaticRelationStateEmpirePrerequisitePathPrerequisite pathPrerequisiteField;

        private string flagsField;

        private string responsibleField;

        /// <remarks/>
        public DatatableDiplomaticTermResourceExchangeDefinitionDiplomaticRelationStateEmpirePrerequisitePathPrerequisite PathPrerequisite
        {
            get
            {
                return this.pathPrerequisiteField;
            }
            set
            {
                this.pathPrerequisiteField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Responsible
        {
            get
            {
                return this.responsibleField;
            }
            set
            {
                this.responsibleField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DatatableDiplomaticTermResourceExchangeDefinitionDiplomaticRelationStateEmpirePrerequisitePathPrerequisite
    {

        private bool invertedField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DatatableDiplomaticTermResourceExchangeDefinitionDiplomaticCustomCost
    {

        private string responsibleField;

        private string resourceNameField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Responsible
        {
            get
            {
                return this.responsibleField;
            }
            set
            {
                this.responsibleField = value;
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
        public byte Value
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DatatableDiplomaticTermResourceExchangeDefinitionTradableResourceList
    {

        private DatatableDiplomaticTermResourceExchangeDefinitionTradableResourceListTradableResourceReference tradableResourceReferenceField;

        /// <remarks/>
        public DatatableDiplomaticTermResourceExchangeDefinitionTradableResourceListTradableResourceReference TradableResourceReference
        {
            get
            {
                return this.tradableResourceReferenceField;
            }
            set
            {
                this.tradableResourceReferenceField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DatatableDiplomaticTermResourceExchangeDefinitionTradableResourceListTradableResourceReference
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
}