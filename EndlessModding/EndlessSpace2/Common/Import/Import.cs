using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Xml.Serialization;
using Castle.Core.Logging;
using EndlessModding.Common.Import;

namespace EndlessModding.EndlessSpace2.Common.Import
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

    class ImportMods
    {
        ILogger _logger;
        Data _data;

        HashSet<string> _modFiles;

        public ImportMods(ILogger logger, Data data)
        {
            _logger = logger;
            _data = data;
        }
        public void LoadMods(string dir)
        {
            _data.RuntimeModules.Clear();
            _modFiles = Directory.GetFiles(dir, "*.xml", SearchOption.AllDirectories).ToHashSet<string>();
            //Get Mods and load in the mod configs
            LoadMods(_data.RuntimeModules, "RuntimeModule");
        }
        private void LoadMods(ObservableConcurrentCollection<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule> input, string Node)
        {
            var bag = new ConcurrentBag<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule>();
            XmlSerializer serialist = new XmlSerializer(typeof(EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule));

            Func<XElement, EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule> SerialiseFunc = xml =>
            {
                try
                {
                    var reader = xml.CreateReader();
                    EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule tmp = (EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule)serialist.Deserialize(reader);
                    reader.Dispose();
                    _logger.Info($"Loaded item: {xml.Name}");
                    return tmp;
                }
                catch (Exception e)
                {
                    _logger.Error($"Failed to load item: {xml.Name}: {e.Message}");
                    return null;
                }
            };

            Parallel.ForEach(_modFiles, file =>
            {
                try
                {
                    XElement document = XElement.Load(file);

                    var definitions = document.Elements(Node)
                        .Select(SerialiseFunc)
                        .ToArray();
                    _logger.Info($"Load file: {file}");

                    foreach (var item in definitions)
                    {
                        var filedir = new FileInfo(file).Directory.FullName;

                        //load the mod icon
                        LoadModImage(filedir, item);

                        //add to the bag
                        bag.Add(item);

                        //loop through the mods and try load in the plugins (what they actually add into the game)
                        LoadPlugins(item.Plugins, filedir);
                    }
                }
                catch (Exception e)
                {
                    _logger.Error($"Failed to load file: {file}: {e.Message}");
                }
            });

            var tmpcont = bag.OrderBy(i => (string)i.GetType().GetProperties().Where(x => x.Name == "Name").First().GetValue(i)).ToList();

            input.AddFromEnumerable(tmpcont);
        }
        private void LoadPlugins(EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimePlugin[] input, string fileDirectory)
        {
            Action<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimePlugin> pluginSorterFunc = plugin =>
            {
                try
                {
                    if (plugin is EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RegistryPlugin)//RegistryPlugin
                    {
                        var tmp = (EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RegistryPlugin)plugin;
                        string[] files = tmp.FilePath;
                        Type tmp2 = GetTypeOfFile(tmp.Type);
                        plugin.Type = tmp2 == null ? "" : tmp2.Name;
                        plugin.Contents = string.Join(" ,", files);
                        plugin.Enabled = true;
                        plugin.ExtraTypes = tmp.ExtraTypes;
                    }
                    else if (plugin is EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.LocalizationPlugin)//LocalizationPlugin
                    {
                        var tmp = (EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.LocalizationPlugin)plugin;
                        string[] files = tmp.Directory;
                        Type tmp2 = GetTypeOfFile(tmp.Type);
                        plugin.Type = tmp2 == null ? "" : tmp2.Name;
                        plugin.Contents = string.Join(" ,", files);
                        plugin.Enabled = true;
                        plugin.ExtraTypes = tmp.ExtraTypes;
                    }
                    else if (plugin is EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.AIPlugin)//AIPlugin
                    {
                        var tmp = (EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.AIPlugin)plugin;
                        string[] files = tmp.AssemblyPath;
                        Type tmp2 = GetTypeOfFile(tmp.Type);
                        plugin.Type = tmp2 == null ? "" : tmp2.Name;
                        plugin.Contents = string.Join(" ,", files);
                        plugin.Enabled = true;
                        plugin.ExtraTypes = tmp.ExtraTypes;
                    }
                    else if (plugin is EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.DatabasePlugin)//DatabasePlugin
                    {
                        string Contents = "";
                        var tmp = (EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.DatabasePlugin)plugin;
                        string[] files = tmp.FilePath;
                        Type tmp2 = GetTypeOfFile(tmp.DataType);
                        plugin.Type = tmp2 == null ? "" : tmp2.Name;
                        Debug.Write(tmp2);
                        if (tmp.ExtraTypes != null && tmp.ExtraTypes.Length > 0)
                        {
                            foreach (var item in tmp.ExtraTypes)
                            {
                                var alttmp2 = GetTypeOfFile(item.DataType);
                                plugin.ExtraTypes += alttmp2.Name;
                                var altproperties = _data.GetType().GetFields().ToList();
                                var altfield = altproperties.FirstOrDefault(x => MatchTypes(x, alttmp2));
                                if (altfield != null)
                                {
                                    //now that i've found the type of the mod, I need to find out which list they go into and add them
                                    var tmp3 = altfield.GetValue(_data);
                                    LoadNodes(tmp3, fileDirectory, files, alttmp2, altfield.FieldType, out string tmpName);
                                    Contents += tmpName;
                                }
                            }
                            plugin.ExtraContents = Contents;
                        }

                        var properties = _data.GetType().GetFields().ToList();
                        var field = properties.FirstOrDefault(x => MatchTypes(x, tmp2));
                        if (field != null)
                        {
                            //now that i've found the type of the mod, I need to find out which list they go into and add them
                            var tmp3 = field.GetValue(_data);
                            LoadNodes(tmp3, fileDirectory, files, tmp2, field.FieldType, out string Core);
                            plugin.Contents = Core;
                        }
                        plugin.Enabled = true;
                    }

                    _logger.Info($"Loaded item: {plugin}");
                }
                catch (Exception e)
                {
                    _logger.Error($"Failed to load item: {plugin}: {e.Message}");
                }
            };

            foreach (var mod in input)
            {
                try
                {
                    pluginSorterFunc(mod);
                    _logger.Info($"Loaded plugins: {mod}");
                }
                catch (Exception e)
                {
                    _logger.Error($"Failed to load plugins: {mod}: {e.Message}");
                }
            }
            Application.Current.Dispatcher.BeginInvoke(new Action(() => LoadHeroImages(fileDirectory + "\\")));
        }
        private bool MatchTypes(FieldInfo arg, Type tmp3)
        {
            var argtype = arg.FieldType.GetGenericTypeDefinition();
            if (argtype == typeof(ObservableConcurrentCollection<object>).GetGenericTypeDefinition())
            {
                var argparam = arg.FieldType.GetGenericArguments()[0];
                if (argparam == tmp3)
                {
                    return true;
                }
            }
            return false;
        }
        private void LoadNodes(object input, string FilePath, string[] Files, Type Node, Type FieldType, out string Name)
        {
            ConcurrentBag<object> bag = new ConcurrentBag<object>();
            XmlSerializer serialist = new XmlSerializer(Node);

            Func<XElement, object> SerialiseFunc = xml =>
            {
                try
                {
                    var reader = xml.CreateReader();
                    object tmp = serialist.Deserialize(reader);
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

            foreach (var file in Files)
            {
                try
                {
                    XElement document = XElement.Load(FilePath + "\\" + file);

                    var definitions = document.Elements(Node.Name)
                        .Select(SerialiseFunc)
                        .ToArray();
                    _logger.Info($"Load file: {file}");

                    foreach (var item in definitions)
                    {
                        bag.Add(item);
                    }

                }
                catch (Exception e)
                {
                    _logger.Error($"Failed to load file: {file}: {e.Message}");
                }
            };

            var tmpcont = bag.OrderBy(i => (string)i.GetType().GetProperties().Where(x => x.Name == "Name").First().GetValue(i)).ToList();
            Name = string.Join(", ", bag.Select(i => (string)i.GetType().GetProperties().Where(x => x.Name == "Name").First().GetValue(i)));



            foreach (var item in tmpcont)
            {
                if (item is EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition)
                {
                    var hero = (EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition)item;
                    hero.Custom = true;

                    var type = input.GetType();
                    var method = type.GetMethod("TryAdd", BindingFlags.NonPublic | BindingFlags.Instance);
                    method.Invoke(input, new object[] { hero });
                }
                else
                {

                    var type = input.GetType();
                    var method = type.GetMethod("TryAdd", BindingFlags.NonPublic | BindingFlags.Instance);
                    _ = method.Invoke(input, new object[] {  item });
                }


            }
        }
        private void LoadModImage(string FilePath, EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule Mod)
        {
            var images = Directory.GetFiles($"{FilePath}", "*.png", SearchOption.TopDirectoryOnly).ToHashSet<string>();
            foreach (var item in images)
            {
                var imagename = item.Split('\\').Last().Split('.').First();
                if (imagename != null)
                {
                    if (Mod.PreviewImageFile.Split('/').Last().Split('.').First() == imagename)
                    {
                        Mod.Image = EndlessModding.Common.Import.Import.LoadImage(item);
                        Mod.Image.Freeze();
                    }
                }
            }
        }

        Type GetTypeOfFile(string Type)
        {
            if (string.IsNullOrEmpty(Type))
            {
                return null;
            }

            Type = Type.Split(',').FirstOrDefault();
            string NewType = Type.Split('.').LastOrDefault();

            //get all classes with type from assembly
            var name = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(ass => ass.GetName().Name == "EndlessModding");
            var assembly = Assembly.Load(name.FullName);
            var exported = assembly.GetExportedTypes();
            var output = exported.Where(x => x.Name == NewType).ToList();

            if (output.Count != 1)
            {
                var splits = Type.Split('.');
                var lookfor = $"{splits[splits.Count() - 2]}_{splits[splits.Count() - 1]}";
                if (output.Where(x => x.FullName.IndexOf(lookfor) >= 0).Count() == 1)
                {
                    return output.First(x => x.FullName.IndexOf(lookfor) >= 0);
                }
                else
                {
                    throw new NotSupportedException($"Fix me - tried to find {Type} in the assembly, but I couldn't find it, did Cali name it wrong?");
                }
            }
            //get the largest file
            return output.FirstOrDefault();
        }
        private void LoadHeroImages(string FilePath)
        {
            var CustomHerosWithoutImages = _data.HeroDefinitions.Where(x => x.Custom && x.LargeImage == null);

            foreach (var item in CustomHerosWithoutImages)
            {
                var gui = _data.HeroGUIElements.Where(x => x.Name == item.Name).FirstOrDefault();
                if (gui != null)
                {
                    LoadHeroImage(FilePath, item, gui);
                }
            }
        }
        private void LoadHeroImage(string FilePath, EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition hero, EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.HeroGuiElement guielements)
        {
            var images = Directory.GetFiles(FilePath, "*.png", SearchOption.AllDirectories).ToHashSet<string>();
            foreach (var item in images)
            {
                var imagename = item.Split('\\').Last().Split('.').First();
                if (imagename != null)
                {
                    var mood = guielements.Icons.Icon.First(x => x.Size == "Mood").Path.Split('\\').Last();
                    var med = guielements.Icons.Icon.First(x => x.Size == "Medium").Path.Split('\\').Last();
                    var large = guielements.Icons.Icon.First(x => x.Size == "Large").Path.Split('\\').Last();
                    if (guielements.Icons.Icon.First(x => x.Size == "Mood").Path.Split('/').Last() == imagename)
                    {
                        hero.MoodImage = EndlessModding.Common.Import.Import.LoadImage(item);
                        hero.MoodImage.Freeze();
                    }
                    else if (guielements.Icons.Icon.First(x => x.Size == "Medium").Path.Split('/').Last() == imagename)
                    {
                        hero.MediumImage = EndlessModding.Common.Import.Import.LoadImage(item);
                        hero.MediumImage.Freeze();
                    }
                    else if (guielements.Icons.Icon.First(x => x.Size == "Large").Path.Split('/').Last() == imagename)
                    {
                        hero.LargeImage = EndlessModding.Common.Import.Import.LoadImage(item);
                        hero.LargeImage.Freeze();
                    }
                }
            }
        }

    }

    public class Data
    {
        //Hero
        public ObservableConcurrentCollection<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition> HeroDefinitions = new ObservableConcurrentCollection<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition>();
        public ObservableConcurrentCollection<EndlessSpace2.Common.Classes.HeroClassDefinitions.HeroClassDefinition> HeroClassDefinitions = new ObservableConcurrentCollection<EndlessSpace2.Common.Classes.HeroClassDefinitions.HeroClassDefinition>();
        public ObservableConcurrentCollection<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition> HeroAffinityDefinitions = new ObservableConcurrentCollection<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition>();
        public ObservableConcurrentCollection<EndlessSpace2.Common.Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition> HeroPoliticsDefinitions = new ObservableConcurrentCollection<EndlessSpace2.Common.Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition>();
        public ObservableConcurrentCollection<EndlessSpace2.Common.Classes.ShipDesignDefinitions.ShipDesignDefinition> ShipDesignDefinitions = new ObservableConcurrentCollection<EndlessSpace2.Common.Classes.ShipDesignDefinitions.ShipDesignDefinition>();
        public ObservableConcurrentCollection<EndlessSpace2.Common.Classes.MajorFactions.MajorFaction> MajorFactions = new ObservableConcurrentCollection<EndlessSpace2.Common.Classes.MajorFactions.MajorFaction>();
        public ObservableConcurrentCollection<EndlessSpace2.Common.Classes.HeroSkillDefinition.HeroSkillDefinition> HeroSkillDefinitions = new ObservableConcurrentCollection<EndlessSpace2.Common.Classes.HeroSkillDefinition.HeroSkillDefinition>();
        public ObservableConcurrentCollection<EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition> HeroSkillTreeDefinitions = new ObservableConcurrentCollection<EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition>();
        //Mods
        public ObservableConcurrentCollection<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.GuiElement> GUIElements = new ObservableConcurrentCollection<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.GuiElement>();
        public ObservableConcurrentCollection<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.HeroGuiElement> HeroGUIElements = new ObservableConcurrentCollection<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.HeroGuiElement>();
        public ObservableConcurrentCollection<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.ExtendedGuiElement> ExtendedGUIElements = new ObservableConcurrentCollection<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.ExtendedGuiElement>();
        public ObservableConcurrentCollection<EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule> RuntimeModules = new ObservableConcurrentCollection<EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule>();
    }
}
