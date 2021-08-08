using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Xml.Serialization;
using Castle.Core.Logging;

namespace EndlessModding.EndlessSpace2.Common.Files
{
    class ImportMods
    {
        ILogger _logger;
        Data _data;

        HashSet<string> _modFiles;
        ConcurrentBag<Classes.Amplitude_Localisation.LocalizationPair> LocalizationPairs = new ConcurrentBag<Classes.Amplitude_Localisation.LocalizationPair>();

        public ImportMods(ILogger logger, Data data)
        {
            logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _logger = logger;
            _data = data;
        }
        public void LoadMods(string dir)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _data.RuntimeModules.Clear();
            _modFiles = Directory.GetFiles(dir, "*.xml", SearchOption.AllDirectories).ToHashSet<string>();
            //Get Mods and load in the mod configs
            LoadMods(_data.RuntimeModules, "RuntimeModule");
        }
        private void LoadMods(ObservableConcurrentCollection<Classes.Amplitude_Runtime.RuntimeModule> input, string Node)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            var bag = new ConcurrentBag<Classes.Amplitude_Runtime.RuntimeModule>();

            Parallel.ForEach(_modFiles, file =>
            {
                try
                {
                    XElement document = XElement.Load(file);

                    var definitions = document.Elements(Node)
                        .Select(SerialiseFunc<Classes.Amplitude_Runtime.RuntimeModule>)
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
        private void LoadPlugins(Classes.Amplitude_Runtime.RuntimePlugin[] input, string fileDirectory)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            Action<Classes.Amplitude_Runtime.RuntimePlugin> pluginSorterFunc = plugin =>
            {
                try
                {
                    if (plugin is Classes.Amplitude_Runtime.RegistryPlugin)//RegistryPlugin
                    {
                        var tmp = (Classes.Amplitude_Runtime.RegistryPlugin)plugin;
                        string[] files = tmp.FilePath;
                        Type tmp2 = GetTypeOfFile(tmp.Type);
                        plugin.Type = tmp2 == null ? "" : tmp2.Name;
                        plugin.Contents = string.Join(" ,", files);
                        plugin.Enabled = true;
                        plugin.ExtraTypesString = tmp.ExtraTypesString;
                    }
                    else if (plugin is Classes.Amplitude_Runtime.LocalizationPlugin)//LocalizationPlugin
                    {
                        var tmp = (Classes.Amplitude_Runtime.LocalizationPlugin)plugin;
                        string[] directories = tmp.Directory;
                        Type tmp2 = GetTypeOfFile(tmp.Type);
                        plugin.Type = tmp2 == null ? "" : tmp2.Name;
                        plugin.Contents = string.Join(" ,", tmp.Directory);
                        plugin.Enabled = true;
                        LoadNodes(fileDirectory, directories);
                    }
                    else if (plugin is Classes.Amplitude_Runtime.AIPlugin)//AIPlugin
                    {
                        var tmp = (Classes.Amplitude_Runtime.AIPlugin)plugin;
                        string[] files = tmp.AssemblyPath;
                        Type tmp2 = GetTypeOfFile(tmp.Type);
                        plugin.Type = tmp2 == null ? "" : tmp2.Name;
                        plugin.Contents = string.Join(" ,", files);
                        plugin.Enabled = true;
                        plugin.ExtraTypesString = tmp.ExtraTypesString;
                    }
                    else if (plugin is Classes.Amplitude_Runtime.DatabasePlugin)//DatabasePlugin
                    {
                        string Contents = "";
                        var tmp = (Classes.Amplitude_Runtime.DatabasePlugin)plugin;
                        string[] files = tmp.FilePath;
                        Type tmp2 = GetTypeOfFile(tmp.DataType);
                        plugin.Type = tmp2 == null ? "" : tmp2.Name;
                        Debug.Write(tmp2);
                        if (tmp.ExtraTypes != null && tmp.ExtraTypes.Length > 0)
                        {
                            plugin.ExtraTypesString = string.Join(",", tmp.ExtraTypes.Select(x => x.DataType.Replace(", Assembly-CSharp", "")).ToArray());
                            foreach (var item in tmp.ExtraTypes)
                            {
                                var alttmp2 = GetTypeOfFile(item.DataType);
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
                }
                catch (Exception e)
                {
                    _logger.Error($"Failed to load plugins: {mod}: {e.Message}");
                }
            }
            Application.Current.Dispatcher.BeginInvoke(new Action(() => LoadHeroGUIElements(fileDirectory + "\\")));
        }
        private bool MatchTypes(FieldInfo arg, Type tmp3)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
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
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            ConcurrentBag<object> bag = new ConcurrentBag<object>();

            foreach (var file in Files)
            {
                try
                {
                    XElement document = XElement.Load(FilePath + "\\" + file);

                    var definitions = document.Elements(Node.Name)
                        .Select(x => SerialiseModule(x, Node))
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
                //enable the custom attribute
                if (item is EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition) //TODO make generic has custom attribute
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
                    _ = method.Invoke(input, new object[] { item });
                }


            }
        }
        private void LoadNodes(string FilePath, string[] Files)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");

            foreach (var file in Files)
            {
                var subfiles = Directory.GetFiles(FilePath + "\\" + file + "\\english\\", "*.xml", SearchOption.AllDirectories);
                foreach (var xmls in subfiles)
                {
                    try
                    {
                        XElement document = XElement.Load(xmls);

                        var definitions = document.Elements(typeof(Classes.Amplitude_Localisation.LocalizationPair).Name)
                            .Select(SerialiseFunc<Classes.Amplitude_Localisation.LocalizationPair>)
                            .ToArray();
                        _logger.Info($"Load file: {file}");

                        foreach (var item in definitions)
                        {
                            LocalizationPairs.Add((Classes.Amplitude_Localisation.LocalizationPair)item);
                        }

                    }
                    catch (Exception e)
                    {
                        _logger.Error($"Failed to load file: {file}: {e.Message}");
                    }
                }
            };
        }
        private void LoadModImage(string FilePath, EndlessSpace2.Common.Classes.Amplitude_Runtime.RuntimeModule Mod)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
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
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
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
                if (splits.Length > 1)
                {
                    var lookfor = $"{splits[splits.Count() - 2]}_{splits[splits.Count() - 1]}";
                    if (output.Where(x => x.FullName.IndexOf(lookfor) >= 0).Count() == 1)
                    {
                        return output.First(x => x.FullName.IndexOf(lookfor) >= 0);
                    }
                }
                else if (output.Where(x => x.FullName.IndexOf($"{NewType}.{NewType}")>= 0).Count() == 1)
                {
                    return output.First(x => x.FullName.IndexOf($"{NewType}.{NewType}") >= 0);
                }
                else
                {
                    throw new NotSupportedException($"Fix me - tried to find {Type} in the assembly, but I couldn't find it, did Cali name it wrong?");
                }
            }
            //get the largest file
            return output.FirstOrDefault();
        }
        private void LoadHeroGUIElements(string FilePath)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            var CustomHeros = _data.HeroDefinitions.Where(x => x.Custom);

            foreach (var item in CustomHeros)
            {
                var gui = _data.HeroGUIElements.Where(x => x.Name == item.Name).FirstOrDefault();
                item.RealName = gui?.Title;
                item.Description = gui?.Description;

                var tmp = LocalizationPairs.FirstOrDefault(x => x.Name == item.RealName);
                if (tmp != null) item.RealName = tmp.Value;

                tmp = LocalizationPairs.FirstOrDefault(x => x.Name == item.Description);
                if (tmp != null) item.Description = tmp.Value;

                if (gui != null)
                {
                    LoadHeroImage(FilePath, item, gui);
                }
            }
        }
        private void LoadHeroImage(string FilePath, EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition hero, EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement.HeroGuiElement guielements)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
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
        object SerialiseModule(XElement xml, Type Node)
        {
            try
            {
                XmlSerializer serialist = new XmlSerializer(Node);
                var reader = xml.CreateReader();
                object tmp = serialist.Deserialize(reader);
                reader.Dispose();
                return tmp;
            }
            catch (Exception e)
            {
                _logger.Error($"Failed to load item: {xml.Name}: {e.Message}");
                return null;
            }
        }
    }
}