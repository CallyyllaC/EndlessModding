using System.Collections.Concurrent;
using System.Linq;
using EndlessModding.Common.DataStructures;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Localisation;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime;


namespace EndlessModding.EndlessSpace2.Common.Files
{
    public class Data
    {
        //Hero
        public EndlessObservableConcurrentCollection<Classes.HeroDefinition.HeroDefinition> HeroDefinitions = new EndlessObservableConcurrentCollection<Classes.HeroDefinition.HeroDefinition>();
        public EndlessObservableConcurrentCollection<Classes.HeroClassDefinitions.HeroClassDefinition> HeroClassDefinitions = new EndlessObservableConcurrentCollection<Classes.HeroClassDefinitions.HeroClassDefinition>();
        public EndlessObservableConcurrentCollection<Classes.HeroAffinityDefinitions.HeroAffinityDefinition> HeroAffinityDefinitions = new EndlessObservableConcurrentCollection<Classes.HeroAffinityDefinitions.HeroAffinityDefinition>();
        public EndlessObservableConcurrentCollection<Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition> HeroPoliticsDefinitions = new EndlessObservableConcurrentCollection<Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition>();
        public EndlessObservableConcurrentCollection<Classes.ShipDesignDefinitions.ShipDesignDefinition> ShipDesignDefinitions = new EndlessObservableConcurrentCollection<Classes.ShipDesignDefinitions.ShipDesignDefinition>();
        public EndlessObservableConcurrentCollection<Classes.MajorFactions.MajorFaction> MajorFactions = new EndlessObservableConcurrentCollection<Classes.MajorFactions.MajorFaction>();
        public EndlessObservableConcurrentCollection<Classes.HeroSkillDefinition.HeroSkillDefinition> HeroSkillDefinitions = new EndlessObservableConcurrentCollection<Classes.HeroSkillDefinition.HeroSkillDefinition>();
        public EndlessObservableConcurrentCollection<Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition> HeroSkillTreeDefinitions = new EndlessObservableConcurrentCollection<Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition>();
        public EndlessObservableConcurrentCollection<Classes.Amplitude_Simulator.SimulationDescriptor> SimulationDescriptorDefinitions = new EndlessObservableConcurrentCollection<Classes.Amplitude_Simulator.SimulationDescriptor>();
        public EndlessObservableConcurrentCollection<Classes.Amplitude_Simulator.SimulationPropertyDescriptor> SimulationPropertyDescriptorDefinitions = new EndlessObservableConcurrentCollection<Classes.Amplitude_Simulator.SimulationPropertyDescriptor>();
        public EndlessObservableConcurrentCollection<Classes.Amplitude_Simulator.SimulationModifierDescriptor> SimulationModifierDescriptorDefinitions = new EndlessObservableConcurrentCollection<Classes.Amplitude_Simulator.SimulationModifierDescriptor>();
        public EndlessObservableConcurrentCollection<Classes.EncounterPlayDefinition.EncounterPlayDefinition> EncounterPlayDefinitions = new EndlessObservableConcurrentCollection<Classes.EncounterPlayDefinition.EncounterPlayDefinition>();
        public EndlessObservableConcurrentCollection<Classes.HeroMasteryDefinitions.HeroMasteryDefinition> MasteryLevelDefinitions = new EndlessObservableConcurrentCollection<Classes.HeroMasteryDefinitions.HeroMasteryDefinition>();
        //Mods
        public EndlessObservableConcurrentCollection<Classes.Amplitude_Gui_GuiElement.GuiElement> GUIElements = new EndlessObservableConcurrentCollection<Classes.Amplitude_Gui_GuiElement.GuiElement>();
        public EndlessObservableConcurrentCollection<Classes.Amplitude_Gui_GuiElement.HeroGuiElement> HeroGUIElements = new EndlessObservableConcurrentCollection<Classes.Amplitude_Gui_GuiElement.HeroGuiElement>();
        public EndlessObservableConcurrentCollection<Classes.Amplitude_Gui_GuiElement.ExtendedGuiElement> ExtendedGUIElements = new EndlessObservableConcurrentCollection<Classes.Amplitude_Gui_GuiElement.ExtendedGuiElement>();
        public EndlessObservableConcurrentCollection<Classes.Amplitude_Runtime.RuntimeModule> RuntimeModules = new EndlessObservableConcurrentCollection<Classes.Amplitude_Runtime.RuntimeModule>();

        public EndlessObservableConcurrentCollection<IExportable> ExportableData = new EndlessObservableConcurrentCollection<IExportable>();
        public void GetExportableData()
        {
            ExportableData.Clear();

            //Add Heros
            ExportableData.AddRange(GetExportableHeros());
        }
        public Classes.HeroDefinition.HeroDefinition[] GetExportableHeros()
        {
            return HeroDefinitions.AsParallel().Where(x => x.Custom).OrderBy(x => x.Name).ToArray();
        }
    }
}