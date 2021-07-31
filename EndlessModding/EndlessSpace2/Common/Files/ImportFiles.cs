using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Castle.Core.Logging;
using EndlessModding.Common.Import;

namespace EndlessModding.EndlessSpace2.Common.Files
{
    class ImportFiles
    {
        HashSet<string> _files;

        ILogger _logger;
        Data _data;

        HashSet<string> _modFiles;

        public ImportFiles(ILogger logger, Data data)
        {
            _logger = logger;
            _data = data;
        }

        public void ImportAll(string GameDir)
        {
            //clear all of the current editables
            _data.HeroDefinitions.Clear();
            _data.HeroClassDefinitions.Clear();
            _data.HeroAffinityDefinitions.Clear();
            _data.HeroPoliticsDefinitions.Clear();
            _data.ShipDesignDefinitions.Clear();
            _data.MajorFactions.Clear();
            _data.HeroSkillDefinitions.Clear();
            _data.HeroSkillTreeDefinitions.Clear();

            //get all the useful xml data
            _files = Directory.GetFiles($"{GameDir}Public\\Simulation\\", "*.xml", SearchOption.AllDirectories).ToHashSet<string>();


            //Get Hero Mastery Definitions

            //Get Encounter Play Definitions

            //Get Hero Affinity Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition>(_data.HeroAffinityDefinitions, "HeroAffinityDefinitions", "HeroAffinityDefinition");

            //Get Hero Class Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition>(_data.HeroDefinitions, "HeroDefinitions", "HeroDefinition");

            //Get Hero Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroClassDefinitions.HeroClassDefinition>(_data.HeroClassDefinitions, "HeroClassDefinitions", "HeroClassDefinition");

            //Get Hero Politic Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition>(_data.HeroPoliticsDefinitions, "HeroPoliticsDefinitions", "HeroPoliticsDefinition");

            //Get Hero Simulation Descriptors

            //Get Hero Skill Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroSkillDefinition.HeroSkillDefinition>(_data.HeroSkillDefinitions, "HeroSkillDefinitions", "HeroSkillDefinition");

            //Get Hero Skill Tree Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition>(_data.HeroSkillTreeDefinitions, "HeroSkillTreeDefinitions", "HeroSkillTreeDefinition");

            //Get Mastery Level Definitions

            //Get Ship Definitions
            LoadNodes<EndlessSpace2.Common.Classes.ShipDesignDefinitions.ShipDesignDefinition>(_data.ShipDesignDefinitions, "ShipDesignDefinitions", "ShipDesignDefinition");

            //Get Major Factions
            LoadNodes<EndlessSpace2.Common.Classes.MajorFactions.MajorFaction>(_data.MajorFactions, "Factions", "MajorFaction");

            //Dont GUI Definitions, we dont need them?
            //LoadNodes<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.HeroGuiElement>(HeroGUIElements);
            //LoadNodes<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.ExtendedGuiElement>(ExtendedGUIElements);

        }

        private void LoadNodes<T>(ObservableConcurrentCollection<T> input, string Mask, string Node)
        {
            ConcurrentBag<T> bag = new ConcurrentBag<T>();
            XmlSerializer serialist = new XmlSerializer(typeof(T));

            Func<XElement, T> SerialiseFunc = xml =>
            {
                try
                {
                    var reader = xml.CreateReader();
                    T tmp = (T)serialist.Deserialize(reader);
                    reader.Dispose();
                    _logger.Info($"Loaded item: {xml.Name}");
                    return tmp;
                }
                catch (Exception e)
                {
                    _logger.Error($"Failed to load item: {xml.Name}: {e.Message}");
                    return default;
                }
            };
            foreach (var file in _files.Where(x => x.Contains(Mask)))
            {
                try
                {
                    XElement document = XElement.Load(file);

                    var definitions = document.Elements(Node)
                        .Select(SerialiseFunc)
                        .ToArray();
                    _logger.Info($"Load file: {file}");

                    Parallel.ForEach(definitions, item => bag.Add(item));
                }
                catch (Exception e)
                {
                    _logger.Error($"Failed to load file: {file}: {e.Message}");
                }
            };

            var tmpcont = bag.OrderBy(i => (string)i.GetType().GetProperties().Where(x => x.Name == "Name").First().GetValue(i)).ToList();

            input.AddFromEnumerable(tmpcont);
        }
    }
}
