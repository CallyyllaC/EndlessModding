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
namespace EndlessModding.EndlessSpace2.Common.Classes.MouseCursorRule
{
    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MouseCursorRule))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DatatableElement {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MouseCursorRuleCondition {

        private MouseCursorRuleCondition[] conditionsField;

        private string keyField;

        private bool notField;

        private bool andField;

        public MouseCursorRuleCondition() {
            this.notField = false;
            this.andField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Conditions", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MouseCursorRuleCondition[] Conditions {
            get {
                return this.conditionsField;
            }
            set {
                this.conditionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Not {
            get {
                return this.notField;
            }
            set {
                this.notField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool And {
            get {
                return this.andField;
            }
            set {
                this.andField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class MouseCursorRule : DatatableElement {

        private MouseCursorRuleCondition conditionField;

        private string guiCursorNameField;

        private int priorityField;

        private string accessLevelField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MouseCursorRuleCondition Condition {
            get {
                return this.conditionField;
            }
            set {
                this.conditionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string GuiCursorName {
            get {
                return this.guiCursorNameField;
            }
            set {
                this.guiCursorNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AccessLevel {
            get {
                return this.accessLevelField;
            }
            set {
                this.accessLevelField = value;
            }
        }
    }
}