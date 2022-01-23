using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Castle.Core.Logging;
using EndlessModding.Common.Import;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Localisation;

namespace EndlessModding.EndlessSpace2.Common.Files
{
    class ImportFiles
    {
        HashSet<string> _files;
        HashSet<string> _localfiles;
        HashSet<string> _guifiles;

        ILogger _logger;
        Data _data;

        HashSet<string> _modFiles;
        ConcurrentDictionary<string, string> Locales = new ConcurrentDictionary<string, string>();

        public ImportFiles(ILogger logger, Data data)
        {
            logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _logger = logger;
            _data = data;
        }

        public void ImportAll(string GameDir)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            //clear all of the current editables
            _data.HeroDefinitions.Clear();
            _data.HeroClassDefinitions.Clear();
            _data.HeroAffinityDefinitions.Clear();
            _data.HeroPoliticsDefinitions.Clear();
            _data.ShipDesignDefinitions.Clear();
            _data.MajorFactions.Clear();
            _data.HeroSkillDefinitions.Clear();
            _data.HeroSkillTreeDefinitions.Clear();
            _data.SimulationDescriptorDefinitions.Clear();
            _data.EncounterPlayDefinitions.Clear();
            _data.MasteryLevelDefinitions.Clear();

            //get all the useful xml data
            _files = Directory.GetFiles($"{GameDir}Public\\Simulation\\", "*.xml", SearchOption.AllDirectories).ToHashSet<string>();
            _localfiles = Directory.GetFiles($"{GameDir}Public\\Localization\\english\\", "*.xml", SearchOption.AllDirectories).ToHashSet<string>();
            _guifiles = Directory.GetFiles($"{GameDir}Public\\Gui\\", "*.xml", SearchOption.AllDirectories).ToHashSet<string>();

            //Get Locales
            LoadLocales();

            //Get Simulation Descriptors
            LoadNodes<EndlessSpace2.Common.Classes.Amplitude_Simulator.SimulationDescriptor>(_data.SimulationDescriptorDefinitions, "SimulationDescriptors", "SimulationDescriptor");

            LoadNodes<EndlessSpace2.Common.Classes.Amplitude_Simulator.SimulationDescriptor>(_data.SimulationDescriptorDefinitions, "SimulationDescriptors", "SimulationDescriptor");
            LoadNodes<EndlessSpace2.Common.Classes.Amplitude_Simulator.SimulationDescriptor>(_data.SimulationDescriptorDefinitions, "SimulationDescriptors", "SimulationDescriptor");

            //Get Encounter Play Definitions
            LoadNodes<EndlessSpace2.Common.Classes.EncounterPlayDefinition.EncounterPlayDefinition>(_data.EncounterPlayDefinitions, "EncounterPlayDefinitions", "EncounterPlayDefinition");

            //Get Hero Mastery Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroMasteryDefinitions.HeroMasteryDefinition>(_data.MasteryLevelDefinitions, "HeroMasteryDefinitions", "HeroMasteryDefinition");

            //Get Hero Affinity Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition>(_data.HeroAffinityDefinitions, "HeroAffinityDefinitions", "HeroAffinityDefinition");


            //Get Hero Definitions
            HashSet<Classes.Amplitude_Gui_GuiElement.HeroGuiElement> _heroFiles = new HashSet<HeroGuiElement>();
            LoadGuiElements<Classes.Amplitude_Gui_GuiElement.HeroGuiElement>(_heroFiles, "Heroes");
            LoadNodes<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition>(_data.HeroDefinitions, "HeroDefinitions", "HeroDefinition");
            _data.HeroDefinitions.AsParallel().ForAll((item) =>
            {
                var gui = _heroFiles.Where(x => x.Name == item.Name).FirstOrDefault();
                item.RealName = gui.Title;
                item.Description = gui.Description;
                item.ModelPath = gui.ModelPath;

                if (Locales.TryGetValue(item.RealName, out string name))
                {
                    item.RealName = name;
                }
                if (Locales.TryGetValue(item.Description, out string description))
                {
                    item.Description = description;
                }
            });
            //Get Hero Class Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroClassDefinitions.HeroClassDefinition>(_data.HeroClassDefinitions, "HeroClassDefinitions", "HeroClassDefinition");

            //Get Hero Politic Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition>(_data.HeroPoliticsDefinitions, "HeroPoliticsDefinitions", "HeroPoliticsDefinition");


            //Get Hero Skill Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroSkillDefinition.HeroSkillDefinition>(_data.HeroSkillDefinitions, "HeroSkillDefinitions", "HeroSkillDefinition");

            //Get Hero Skill Tree Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition>(_data.HeroSkillTreeDefinitions, "HeroSkillTreeDefinitions", "HeroSkillTreeDefinition");

            //Get Ship Definitions
            LoadNodes<EndlessSpace2.Common.Classes.ShipDesignDefinitions.ShipDesignDefinition>(_data.ShipDesignDefinitions, "ShipDesignDefinitions", "ShipDesignDefinition");

            //Get Major Factions
            LoadNodes<EndlessSpace2.Common.Classes.MajorFactions.MajorFaction>(_data.MajorFactions, "Factions", "MajorFaction");

        }

        private void LoadLocales()
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            foreach (var file in _localfiles)
            {
                try
                {
                    XElement document = XElement.Load(file);

                    var definitions = document.Elements(typeof(Classes.Amplitude_Localisation.LocalizationPair).Name)
                        .Select(SerialiseFunc<Classes.Amplitude_Localisation.LocalizationPair>)
                        .ToArray();

                    Parallel.ForEach(definitions, item => Locales.TryAdd(item.Name, item.Value));
                }
                catch (Exception e)
                {
                    _logger.Error($"Failed to load file: {file}: {e.Message}");
                }
            };
        }
        private void LoadNodes<T>(ObservableConcurrentCollection<T> input, string Mask, string Node)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            ConcurrentBag<T> bag = new ConcurrentBag<T>();

            foreach (var file in _files.Where(x => x.Contains(Mask)))
            {
                try
                {
                    XElement document = XElement.Load(file);

                    var definitions = document.Elements(Node)
                        .Select(SerialiseFunc<T>)
                        .ToArray();

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
        private void LoadGuiElements<T>(HashSet<T> input, string Mask)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            ConcurrentBag<T> bag = new ConcurrentBag<T>();

            foreach (var file in _guifiles.Where(x => x.Contains(Mask)))
            {
                try
                {
                    XElement document = XElement.Load(file);

                    var definitions = document.Elements(typeof(T).Name)
                        .Select(SerialiseFunc<T>)
                        .ToArray();

                    Parallel.ForEach(definitions, item => bag.Add(item));
                }
                catch (Exception e)
                {
                    _logger.Error($"Failed to load file: {file}: {e.Message}");
                }
            };

            foreach (var item in bag)
            {
                input.Add(item);
            }
        }
        private void LoadFromObject<T>(ObservableConcurrentCollection<T> output, ObservableConcurrentCollection<T> input)
        {
            Parallel.ForEach(input, item =>
            {
                System.Reflection.PropertyInfo[] properties = item.GetType().GetProperties(BindingFlags.Public);
                var tmp = properties.Where(x => x.PropertyType == T[]).ToList();
            });
        }
        T SerialiseFunc<T>(XElement xml)
        {
            try
            {
                XmlSerializer serialist = new XmlSerializer(typeof(T));
                var reader = xml.CreateReader();
                T tmp = (T)serialist.Deserialize(reader);
                reader.Dispose();
                return tmp;
            }
            catch (Exception e)
            {
                _logger.Error($"Failed to load item: {xml.Name}: {e.Message}");
                return default;
            }
        }
    }
}
