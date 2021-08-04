using System.Collections.Concurrent;
using System.Linq;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime;

namespace EndlessModding.EndlessSpace2.Common.Files
{
    public class Data
    {
        //Hero
        public ObservableConcurrentCollection<Classes.HeroDefinition.HeroDefinition> HeroDefinitions = new ObservableConcurrentCollection<Classes.HeroDefinition.HeroDefinition>();
        public ObservableConcurrentCollection<Classes.HeroClassDefinitions.HeroClassDefinition> HeroClassDefinitions = new ObservableConcurrentCollection<Classes.HeroClassDefinitions.HeroClassDefinition>();
        public ObservableConcurrentCollection<Classes.HeroAffinityDefinitions.HeroAffinityDefinition> HeroAffinityDefinitions = new ObservableConcurrentCollection<Classes.HeroAffinityDefinitions.HeroAffinityDefinition>();
        public ObservableConcurrentCollection<Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition> HeroPoliticsDefinitions = new ObservableConcurrentCollection<Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition>();
        public ObservableConcurrentCollection<Classes.ShipDesignDefinitions.ShipDesignDefinition> ShipDesignDefinitions = new ObservableConcurrentCollection<Classes.ShipDesignDefinitions.ShipDesignDefinition>();
        public ObservableConcurrentCollection<Classes.MajorFactions.MajorFaction> MajorFactions = new ObservableConcurrentCollection<Classes.MajorFactions.MajorFaction>();
        public ObservableConcurrentCollection<Classes.HeroSkillDefinition.HeroSkillDefinition> HeroSkillDefinitions = new ObservableConcurrentCollection<Classes.HeroSkillDefinition.HeroSkillDefinition>();
        public ObservableConcurrentCollection<Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition> HeroSkillTreeDefinitions = new ObservableConcurrentCollection<Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition>();
        //Mods
        public ObservableConcurrentCollection<Classes.Amplitude_Gui_GuiElement.GuiElement> GUIElements = new ObservableConcurrentCollection<Classes.Amplitude_Gui_GuiElement.GuiElement>();
        public ObservableConcurrentCollection<Classes.Amplitude_Gui_GuiElement.HeroGuiElement> HeroGUIElements = new ObservableConcurrentCollection<Classes.Amplitude_Gui_GuiElement.HeroGuiElement>();
        public ObservableConcurrentCollection<Classes.Amplitude_Gui_GuiElement.ExtendedGuiElement> ExtendedGUIElements = new ObservableConcurrentCollection<Classes.Amplitude_Gui_GuiElement.ExtendedGuiElement>();
        public ObservableConcurrentCollection<Classes.Amplitude_Runtime.RuntimeModule> RuntimeModules = new ObservableConcurrentCollection<Classes.Amplitude_Runtime.RuntimeModule>();

        public ObservableConcurrentCollection<IExportable> ExportableData = new ObservableConcurrentCollection<IExportable>();

        public async void GetExportableData()
        {
            ExportableData.Clear();
            //Add Heros
            ExportableData.AddFromEnumerable(GetExportableHeros());
        }
        public Classes.HeroDefinition.HeroDefinition[] GetExportableHeros()
        {
            return HeroDefinitions.AsParallel().Where(x => x.Custom).OrderBy(x => x.Name).ToArray();
        }



    }
}