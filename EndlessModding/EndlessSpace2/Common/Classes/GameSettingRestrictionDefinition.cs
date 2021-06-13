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
namespace EndlessModding.EndlessSpace2.Common.Classes.GameSettingRestrictionDefinition
{

    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RestrictionValue
    {

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
    public partial class RestrictionSet
    {

        private RestrictionValue[] ifField;

        private RestrictionValue[] disableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("If", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RestrictionValue[] If
        {
            get
            {
                return this.ifField;
            }
            set
            {
                this.ifField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Disable", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RestrictionValue[] Disable
        {
            get
            {
                return this.disableField;
            }
            set
            {
                this.disableField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class KeyValuePair
    {

        private string keyField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ItemDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GameSettingDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GameSettingRestrictionDefinition))]
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
    public partial class ItemDefinition : DatatableElement
    {

        private KeyValuePair[] keyValuePairField;

        private bool isRecommendedField;

        public ItemDefinition()
        {
            this.isRecommendedField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KeyValuePair", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public KeyValuePair[] KeyValuePair
        {
            get
            {
                return this.keyValuePairField;
            }
            set
            {
                this.keyValuePairField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool IsRecommended
        {
            get
            {
                return this.isRecommendedField;
            }
            set
            {
                this.isRecommendedField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameSettingDefinition : DatatableElement
    {

        private string editableValueField;

        private CounterIncrementer[] incrementCountField;

        private AccessibilitySetter visibleField;

        private AccessibilitySetter enableField;

        private ItemDefinition[] itemDefinitionField;

        private string typeField;

        private string defaultField;

        private string isEditableField;

        private string sessionSpecificField;

        private bool notNullOrEmptyField;

        public GameSettingDefinition()
        {
            this.notNullOrEmptyField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string EditableValue
        {
            get
            {
                return this.editableValueField;
            }
            set
            {
                this.editableValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IncrementCount", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CounterIncrementer[] IncrementCount
        {
            get
            {
                return this.incrementCountField;
            }
            set
            {
                this.incrementCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AccessibilitySetter Visible
        {
            get
            {
                return this.visibleField;
            }
            set
            {
                this.visibleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AccessibilitySetter Enable
        {
            get
            {
                return this.enableField;
            }
            set
            {
                this.enableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemDefinition", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ItemDefinition[] ItemDefinition
        {
            get
            {
                return this.itemDefinitionField;
            }
            set
            {
                this.itemDefinitionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Default
        {
            get
            {
                return this.defaultField;
            }
            set
            {
                this.defaultField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IsEditable
        {
            get
            {
                return this.isEditableField;
            }
            set
            {
                this.isEditableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SessionSpecific
        {
            get
            {
                return this.sessionSpecificField;
            }
            set
            {
                this.sessionSpecificField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool NotNullOrEmpty
        {
            get
            {
                return this.notNullOrEmptyField;
            }
            set
            {
                this.notNullOrEmptyField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CounterIncrementer
    {

        private GameSettingCondition[] ifField;

        private string nameField;

        private string operatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("If", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GameSettingCondition[] If
        {
            get
            {
                return this.ifField;
            }
            set
            {
                this.ifField = value;
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
        public string Operator
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameSettingCondition
    {

        private string gameSettingField;

        private string valueField;

        private string countField;

        private string lowerEqualField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string GameSetting
        {
            get
            {
                return this.gameSettingField;
            }
            set
            {
                this.gameSettingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Count
        {
            get
            {
                return this.countField;
            }
            set
            {
                this.countField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LowerEqual
        {
            get
            {
                return this.lowerEqualField;
            }
            set
            {
                this.lowerEqualField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AccessibilitySetter
    {

        private GameSettingCondition[] ifField;

        private string valueField;

        private string operatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("If", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GameSettingCondition[] If
        {
            get
            {
                return this.ifField;
            }
            set
            {
                this.ifField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Operator
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class GameSettingRestrictionDefinition : DatatableElement
    {

        private GameSettingDefinition restrictingSettingField;

        private GameSettingDefinition restrictedSettingField;

        private RestrictionSet[] restrictionSetField;

        private string restrictingSetting1Field;

        private string restrictedSetting1Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GameSettingDefinition RestrictingSetting
        {
            get
            {
                return this.restrictingSettingField;
            }
            set
            {
                this.restrictingSettingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public GameSettingDefinition RestrictedSetting
        {
            get
            {
                return this.restrictedSettingField;
            }
            set
            {
                this.restrictedSettingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RestrictionSet", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RestrictionSet[] RestrictionSet
        {
            get
            {
                return this.restrictionSetField;
            }
            set
            {
                this.restrictionSetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("RestrictingSetting")]
        public string RestrictingSetting1
        {
            get
            {
                return this.restrictingSetting1Field;
            }
            set
            {
                this.restrictingSetting1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("RestrictedSetting")]
        public string RestrictedSetting1
        {
            get
            {
                return this.restrictedSetting1Field;
            }
            set
            {
                this.restrictedSetting1Field = value;
            }
        }
    }
}