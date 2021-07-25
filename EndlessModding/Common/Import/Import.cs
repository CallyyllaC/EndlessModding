using Castle.Core.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EndlessModding.Common.Import
{
    public class Import
    {
        ILogger _logger;

        //Editable
        public BindingList<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition> HeroDefinitions = new BindingList<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition>();
        public BindingList<EndlessSpace2.Common.Classes.HeroClassDefinitions.HeroClassDefinition> HeroClassDefinitions = new BindingList<EndlessSpace2.Common.Classes.HeroClassDefinitions.HeroClassDefinition>();
        public BindingList<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition> HeroAffinityDefinitions = new BindingList<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition>();
        public BindingList<EndlessSpace2.Common.Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition> HeroPoliticsDefinitions = new BindingList<EndlessSpace2.Common.Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition>();
        public BindingList<EndlessSpace2.Common.Classes.ShipDesignDefinitions.ShipDesignDefinition> ShipDesignDefinitions = new BindingList<EndlessSpace2.Common.Classes.ShipDesignDefinitions.ShipDesignDefinition>();
        public BindingList<EndlessSpace2.Common.Classes.MajorFactions.MajorFaction> MajorFactions = new BindingList<EndlessSpace2.Common.Classes.MajorFactions.MajorFaction>();
        public BindingList<EndlessSpace2.Common.Classes.HeroSkillDefinition.HeroSkillDefinition> HeroSkillDefinitions = new BindingList<EndlessSpace2.Common.Classes.HeroSkillDefinition.HeroSkillDefinition>();
        public BindingList<EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition> HeroSkillTreeDefinitions = new BindingList<EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition>();

        public BindingList<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.GuiElement> GUIElements = new BindingList<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.GuiElement>();

        public BindingList<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.HeroGuiElement> HeroGUIElements = new BindingList<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.HeroGuiElement>();
        public BindingList<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.ExtendedGuiElement> ExtendedGUIElements = new BindingList<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.ExtendedGuiElement>();



        public BindingList<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule> RuntimeModules = new BindingList<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule>();

        //Backups
        public HashSet<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition> OriginalHeroDefinitions = new HashSet<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition>();
        public HashSet<EndlessSpace2.Common.Classes.HeroClassDefinitions.HeroClassDefinition> OriginalHeroClassDefinitions = new HashSet<EndlessSpace2.Common.Classes.HeroClassDefinitions.HeroClassDefinition>();
        public HashSet<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition> OriginalHeroAffinityDefinitions = new HashSet<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition>();
        public HashSet<EndlessSpace2.Common.Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition> OriginalHeroPoliticsDefinitions = new HashSet<EndlessSpace2.Common.Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition>();
        public HashSet<EndlessSpace2.Common.Classes.ShipDesignDefinitions.ShipDesignDefinition> OriginalShipDesignDefinitions = new HashSet<EndlessSpace2.Common.Classes.ShipDesignDefinitions.ShipDesignDefinition>();
        public HashSet<EndlessSpace2.Common.Classes.MajorFactions.MajorFaction> OriginalMajorFactions = new HashSet<EndlessSpace2.Common.Classes.MajorFactions.MajorFaction>();
        public HashSet<EndlessSpace2.Common.Classes.HeroSkillDefinition.HeroSkillDefinition> OriginalHeroSkillDefinitions = new HashSet<EndlessSpace2.Common.Classes.HeroSkillDefinition.HeroSkillDefinition>();
        public HashSet<EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition> OriginalHeroSkillTreeDefinitions = new HashSet<EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition>();

        public HashSet<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule> OriginalRuntimeModules = new HashSet<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule>();

        HashSet<string> files;
        HashSet<string> modfiles;

        public Import(ILogger Logger)
        {
            _logger = Logger;
        }


        public void ImportAll(string GameDir)
        {
            //clear all of the current editables
            HeroDefinitions.Clear();
            HeroClassDefinitions.Clear();
            HeroAffinityDefinitions.Clear();
            HeroPoliticsDefinitions.Clear();
            ShipDesignDefinitions.Clear();
            MajorFactions.Clear();
            HeroSkillDefinitions.Clear();
            HeroSkillTreeDefinitions.Clear();

            //clear all of the current backups
            OriginalHeroDefinitions.Clear();
            OriginalHeroClassDefinitions.Clear();
            OriginalHeroAffinityDefinitions.Clear();
            OriginalHeroPoliticsDefinitions.Clear();
            OriginalShipDesignDefinitions.Clear();
            OriginalMajorFactions.Clear();
            OriginalHeroSkillDefinitions.Clear();
            OriginalHeroSkillTreeDefinitions.Clear();

            //get all the useful xml data
            files = Directory.GetFiles($"{GameDir}Public\\Simulation\\", "*.xml", SearchOption.AllDirectories).ToHashSet<string>();


            //Get Hero Mastery Definitions

            //Get Encounter Play Definitions

            //Get Hero Affinity Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition>(HeroAffinityDefinitions, "HeroAffinityDefinitions", "HeroAffinityDefinition");

            //Get Hero Class Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition>(HeroDefinitions, "HeroDefinitions", "HeroDefinition");

            //Get Hero Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroClassDefinitions.HeroClassDefinition>(HeroClassDefinitions, "HeroClassDefinitions", "HeroClassDefinition");

            //Get Hero Politic Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition>(HeroPoliticsDefinitions, "HeroPoliticsDefinitions", "HeroPoliticsDefinition");

            //Get Hero Simulation Descriptors

            //Get Hero Skill Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroSkillDefinition.HeroSkillDefinition>(HeroSkillDefinitions, "HeroSkillDefinitions", "HeroSkillDefinition");

            //Get Hero Skill Tree Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition>(HeroSkillTreeDefinitions, "HeroSkillTreeDefinitions", "HeroSkillTreeDefinition");

            //Get Mastery Level Definitions

            //Get Ship Definitions
            LoadNodes<EndlessSpace2.Common.Classes.ShipDesignDefinitions.ShipDesignDefinition>(ShipDesignDefinitions, "ShipDesignDefinitions", "ShipDesignDefinition");

            //Get Major Factions
            LoadNodes<EndlessSpace2.Common.Classes.MajorFactions.MajorFaction>(MajorFactions, "Factions", "MajorFaction");

            //Dont GUI Definitions, we dont need them?
            //LoadNodes<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.HeroGuiElement>(HeroGUIElements);
            //LoadNodes<EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.ExtendedGuiElement>(ExtendedGUIElements);

        }
        public void LoadMods(string dir)
        {
            modfiles = Directory.GetFiles(dir, "*.xml", SearchOption.AllDirectories).ToHashSet<string>();
            //Get Mods and load in the mod configs
            LoadMods(RuntimeModules, "RuntimeModule");
        }
        private void LoadMods(BindingList<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule> input, string Node)
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

            Parallel.ForEach(modfiles, file =>
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

            foreach (var item in tmpcont)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() => input.Add(item)));
            }
        }
        private void LoadPlugins(EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimePlugin[] input, string FileDirectory)
        {
            Action<EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimePlugin> PluginSorterFunc = plugin =>
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
                                var altproperties = this.GetType().GetFields().ToList();
                                var altfield = altproperties.First(x => MatchTypes(x, alttmp2));
                                if (altfield != null)
                                {
                                    //now that i've found the type of the mod, I need to find out which list they go into and add them
                                    var tmp3 = (IBindingList)altfield.GetValue(this);
                                    LoadNodes(tmp3, FileDirectory, files, alttmp2, out string tmpName);
                                    Contents += tmpName;
                                }
                            }
                            plugin.ExtraContents = Contents;
                        }

                        var properties = this.GetType().GetFields().ToList();
                        var field = properties.First(x => MatchTypes(x, tmp2));
                        if (field != null)
                        {
                            //now that i've found the type of the mod, I need to find out which list they go into and add them
                            var tmp3 = (IBindingList)field.GetValue(this);
                            LoadNodes(tmp3, FileDirectory, files, tmp2, out string Core);
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
                    PluginSorterFunc(mod);
                    _logger.Info($"Loaded plugins: {mod}");
                }
                catch (Exception e)
                {
                    _logger.Error($"Failed to load plugins: {mod}: {e.Message}");
                }
            }
            Application.Current.Dispatcher.BeginInvoke(new Action(() => LoadHeroImages(FileDirectory + "\\")));
        }
        private bool MatchTypes(FieldInfo arg, Type tmp3)
        {
            var argtype = arg.FieldType.GetGenericTypeDefinition();
            if (argtype == typeof(BindingList<>).GetGenericTypeDefinition())
            {
                var argparam = arg.FieldType.GetGenericArguments()[0];
                if (argparam == tmp3)
                {
                    return true;
                }
            }
            return false;
        }
        private void LoadNodes<T>(BindingList<T> input, string Mask, string Node)
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
            foreach (var file in files.Where(x => x.Contains(Mask)))
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

            foreach (var item in tmpcont)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() => input.Add(item)));
            }
        }
        private void LoadNodes(IBindingList input, string FilePath, string[] Files, Type Node, out string Name)
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
                    Application.Current.Dispatcher.BeginInvoke(new Action(() => input.Add(hero)));
                }
                else
                    Application.Current.Dispatcher.BeginInvoke(new Action(() => input.Add(item)));
            }
        }
        private void LoadHeroImages(string FilePath)
        {
            var CustomHerosWithoutImages = HeroDefinitions.Where(x => x.Custom && x.LargeImage == null);

            foreach (var item in CustomHerosWithoutImages)
            {
                var gui = HeroGUIElements.Where(x => x.Name == item.Name).FirstOrDefault();
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
                        hero.MoodImage = LoadImage(item);
                        hero.MoodImage.Freeze();
                    }
                    else if (guielements.Icons.Icon.First(x => x.Size == "Medium").Path.Split('/').Last() == imagename)
                    {
                        hero.MediumImage = LoadImage(item);
                        hero.MediumImage.Freeze();
                    }
                    else if (guielements.Icons.Icon.First(x => x.Size == "Large").Path.Split('/').Last() == imagename)
                    {
                        hero.LargeImage = LoadImage(item);
                        hero.LargeImage.Freeze();
                    }
                }
            }
        }
        private WriteableBitmap LoadImage(string filename)
        {
            BitmapSource img = new BitmapImage(new Uri(filename, UriKind.Absolute));
            return new WriteableBitmap(img);
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
                        Mod.Image = LoadImage(item);
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


        static IBindingList createGenericList(Type typeInList)
        {
            var genericListType = typeof(List<>).MakeGenericType(new[] { typeInList });
            return (IBindingList)Activator.CreateInstance(genericListType);
        }
    }
}
