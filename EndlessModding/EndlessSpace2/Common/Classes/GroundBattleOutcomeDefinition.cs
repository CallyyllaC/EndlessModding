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

namespace EndlessModding.EndlessSpace2.Common.Classes.GroundBattleOutcomeDefinition
{
    // 
    // This source code was auto-generated by xsd, Version=4.8.3928.0.
    // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PopulationTransformationResource
    {

        private object[] formulaTokensField;

        private string[] textField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object[] FormulaTokens
        {
            get
            {
                return this.formulaTokensField;
            }
            set
            {
                this.formulaTokensField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PopulationTransformation
    {

        private PathPrerequisite[] pathPrerequisiteField;

        private PopulationTransformationResource[] resourceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PathPrerequisite", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PathPrerequisite[] PathPrerequisite
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
        [System.Xml.Serialization.XmlElementAttribute("Resource", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PopulationTransformationResource[] Resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
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
    public partial class GameSettingPrerequisite : Prerequisite
    {
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
    public partial class LootablePopulation
    {

        private object[] formulaTokensField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object[] FormulaTokens
        {
            get
            {
                return this.formulaTokensField;
            }
            set
            {
                this.formulaTokensField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LootableResource
    {

        private object[] formulaTokensField;

        private string[] textField;

        private string nameField;

        private bool stealFromOtherEmpireField;

        public LootableResource()
        {
            this.stealFromOtherEmpireField = true;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object[] FormulaTokens
        {
            get
            {
                return this.formulaTokensField;
            }
            set
            {
                this.formulaTokensField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
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
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool StealFromOtherEmpire
        {
            get
            {
                return this.stealFromOtherEmpireField;
            }
            set
            {
                this.stealFromOtherEmpireField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundBattleOutcomeDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundBattleOutcomeRazeGhostDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundBattleOutcomeRazeDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundBattleOutcomeCreateGhostDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundBattleOutcomeLootDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundBattleOutcomeCaptureDefinition))]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundBattleOutcomeRazeGhostDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundBattleOutcomeRazeDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundBattleOutcomeCreateGhostDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundBattleOutcomeLootDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundBattleOutcomeCaptureDefinition))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class GroundBattleOutcomeDefinition : DatatableElement
    {

        private Prerequisite[] prerequisitesField;

        private Prerequisite[] fleetPrerequisitesField;

        private string minimumImprovementsLossFormulaField;

        private string maximumImprovementsLossFormulaField;

        private string minimumPopulationsLossFormulaField;

        private string maximumPopulationsLossFormulaField;

        private XmlNamedReference warPointsRewardReferenceField;

        private XmlNamedReference temporaryEffectReferenceField;

        private XmlNamedReference diplomaticPressureEffectReferenceField;

        private string empireHonorChangeField;

        private int priorityField;

        private bool requiresFleetField;

        private float ownershipLossField;

        public GroundBattleOutcomeDefinition()
        {
            this.empireHonorChangeField = "";
            this.requiresFleetField = false;
            this.ownershipLossField = ((float)(0F));
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(typeof(DatePrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        [System.Xml.Serialization.XmlArrayItemAttribute(typeof(GameSettingPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        [System.Xml.Serialization.XmlArrayItemAttribute(typeof(InterpreterPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        [System.Xml.Serialization.XmlArrayItemAttribute(typeof(PathPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        [System.Xml.Serialization.XmlArrayItemAttribute(typeof(TechnologyPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public Prerequisite[] Prerequisites
        {
            get
            {
                return this.prerequisitesField;
            }
            set
            {
                this.prerequisitesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(typeof(InterpreterPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        [System.Xml.Serialization.XmlArrayItemAttribute(typeof(PathPrerequisite), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public Prerequisite[] FleetPrerequisites
        {
            get
            {
                return this.fleetPrerequisitesField;
            }
            set
            {
                this.fleetPrerequisitesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MinimumImprovementsLossFormula
        {
            get
            {
                return this.minimumImprovementsLossFormulaField;
            }
            set
            {
                this.minimumImprovementsLossFormulaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MaximumImprovementsLossFormula
        {
            get
            {
                return this.maximumImprovementsLossFormulaField;
            }
            set
            {
                this.maximumImprovementsLossFormulaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MinimumPopulationsLossFormula
        {
            get
            {
                return this.minimumPopulationsLossFormulaField;
            }
            set
            {
                this.minimumPopulationsLossFormulaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MaximumPopulationsLossFormula
        {
            get
            {
                return this.maximumPopulationsLossFormulaField;
            }
            set
            {
                this.maximumPopulationsLossFormulaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference WarPointsRewardReference
        {
            get
            {
                return this.warPointsRewardReferenceField;
            }
            set
            {
                this.warPointsRewardReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference TemporaryEffectReference
        {
            get
            {
                return this.temporaryEffectReferenceField;
            }
            set
            {
                this.temporaryEffectReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XmlNamedReference DiplomaticPressureEffectReference
        {
            get
            {
                return this.diplomaticPressureEffectReferenceField;
            }
            set
            {
                this.diplomaticPressureEffectReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string EmpireHonorChange
        {
            get
            {
                return this.empireHonorChangeField;
            }
            set
            {
                this.empireHonorChangeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Priority
        {
            get
            {
                return this.priorityField;
            }
            set
            {
                this.priorityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool RequiresFleet
        {
            get
            {
                return this.requiresFleetField;
            }
            set
            {
                this.requiresFleetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(typeof(float), "0")]
        public float OwnershipLoss
        {
            get
            {
                return this.ownershipLossField;
            }
            set
            {
                this.ownershipLossField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class GroundBattleOutcomeCaptureDefinition : GroundBattleOutcomeDefinition
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class GroundBattleOutcomeLootDefinition : GroundBattleOutcomeDefinition
    {

        private LootableResource[] resourceLootField;

        private LootablePopulation populationLootField;

        private bool captureTraitorsField;

        public GroundBattleOutcomeLootDefinition()
        {
            this.captureTraitorsField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResourceLoot", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public LootableResource[] ResourceLoot
        {
            get
            {
                return this.resourceLootField;
            }
            set
            {
                this.resourceLootField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public LootablePopulation PopulationLoot
        {
            get
            {
                return this.populationLootField;
            }
            set
            {
                this.populationLootField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool CaptureTraitors
        {
            get
            {
                return this.captureTraitorsField;
            }
            set
            {
                this.captureTraitorsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundBattleOutcomeCreateGhostDefinition))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class GroundBattleOutcomeRazeDefinition : GroundBattleOutcomeDefinition
    {

        private SimulationDescriptorReference[] lostSystemSimulationDescriptorReferenceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LostSystemSimulationDescriptorReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SimulationDescriptorReference[] LostSystemSimulationDescriptorReference
        {
            get
            {
                return this.lostSystemSimulationDescriptorReferenceField;
            }
            set
            {
                this.lostSystemSimulationDescriptorReferenceField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class GroundBattleOutcomeRazeGhostDefinition : GroundBattleOutcomeDefinition
    {

        private string minimumPopulationCaptureFormulaField;

        private string maximumPopulationCaptureFormulaField;

        private PopulationTransformation[] populationTransformationsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MinimumPopulationCaptureFormula
        {
            get
            {
                return this.minimumPopulationCaptureFormulaField;
            }
            set
            {
                this.minimumPopulationCaptureFormulaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MaximumPopulationCaptureFormula
        {
            get
            {
                return this.maximumPopulationCaptureFormulaField;
            }
            set
            {
                this.maximumPopulationCaptureFormulaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PopulationTransformations", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PopulationTransformation[] PopulationTransformations
        {
            get
            {
                return this.populationTransformationsField;
            }
            set
            {
                this.populationTransformationsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class GroundBattleOutcomeCreateGhostDefinition : GroundBattleOutcomeRazeDefinition
    {
    }
}