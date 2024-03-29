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

namespace EndlessModding.EndlessSpace2.Common.Classes.VictoryConditionDefinition
{
    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(VictoryConditionDefinition))]
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
    public partial class VictoryDefinitionFormula
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InterpreterBasedVictoryConditionEvaluatorDefinition))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class VictoryConditionEvaluatorDefinition
    {

        private VictoryConditionAlert[] alertField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Alert", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public VictoryConditionAlert[] Alert
        {
            get
            {
                return this.alertField;
            }
            set
            {
                this.alertField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class VictoryConditionAlert
    {

        private string nameField;

        private bool repeatField;

        private string valueField;

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
        public bool Repeat
        {
            get
            {
                return this.repeatField;
            }
            set
            {
                this.repeatField = value;
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
    public partial class InterpreterBasedVictoryConditionEvaluatorDefinition : VictoryConditionEvaluatorDefinition
    {

        private VictoryDefinitionFormula scoreFormulaField;

        private VictoryDefinitionFormula progressFormulaField;

        private VictoryDefinitionFormula discreteProgressFormulaField;

        private VictoryDefinitionFormula discreteObjectiveFormulaField;

        private string victoryExpressionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public VictoryDefinitionFormula ScoreFormula
        {
            get
            {
                return this.scoreFormulaField;
            }
            set
            {
                this.scoreFormulaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public VictoryDefinitionFormula ProgressFormula
        {
            get
            {
                return this.progressFormulaField;
            }
            set
            {
                this.progressFormulaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public VictoryDefinitionFormula DiscreteProgressFormula
        {
            get
            {
                return this.discreteProgressFormulaField;
            }
            set
            {
                this.discreteProgressFormulaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public VictoryDefinitionFormula DiscreteObjectiveFormula
        {
            get
            {
                return this.discreteObjectiveFormulaField;
            }
            set
            {
                this.discreteObjectiveFormulaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string VictoryExpression
        {
            get
            {
                return this.victoryExpressionField;
            }
            set
            {
                this.victoryExpressionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EmpirePerformanceTracker
    {

        private string[] variableField;

        private string nameField;

        private PerformanceType typeField;

        private bool hiddenField;

        public EmpirePerformanceTracker()
        {
            this.hiddenField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Variable", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string[] Variable
        {
            get
            {
                return this.variableField;
            }
            set
            {
                this.variableField = value;
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
        public PerformanceType Type
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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum PerformanceType
    {

        /// <remarks/>
        SingleValue,

        /// <remarks/>
        MinMax,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class VictoryConditionDefinition : DatatableElement
    {

        private EmpirePerformanceTracker[] performanceTrackerField;

        private InterpreterBasedVictoryConditionEvaluatorDefinition soloEvaluatorField;

        private InterpreterBasedVictoryConditionEvaluatorDefinition allianceEvaluatorField;

        private bool activeField;

        private string settingNameField;

        private RankIndicator rankIndicatorField;

        private bool hiddenField;

        public VictoryConditionDefinition()
        {
            this.activeField = true;
            this.settingNameField = "True";
            this.rankIndicatorField = RankIndicator.Progress;
            this.hiddenField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PerformanceTracker", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public EmpirePerformanceTracker[] PerformanceTracker
        {
            get
            {
                return this.performanceTrackerField;
            }
            set
            {
                this.performanceTrackerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public InterpreterBasedVictoryConditionEvaluatorDefinition SoloEvaluator
        {
            get
            {
                return this.soloEvaluatorField;
            }
            set
            {
                this.soloEvaluatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public InterpreterBasedVictoryConditionEvaluatorDefinition AllianceEvaluator
        {
            get
            {
                return this.allianceEvaluatorField;
            }
            set
            {
                this.allianceEvaluatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool Active
        {
            get
            {
                return this.activeField;
            }
            set
            {
                this.activeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("True")]
        public string SettingName
        {
            get
            {
                return this.settingNameField;
            }
            set
            {
                this.settingNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(RankIndicator.Progress)]
        public RankIndicator RankIndicator
        {
            get
            {
                return this.rankIndicatorField;
            }
            set
            {
                this.rankIndicatorField = value;
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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum RankIndicator
    {

        /// <remarks/>
        Progress,

        /// <remarks/>
        Score,
    }
}