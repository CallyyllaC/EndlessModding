using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml;
using System.Xml.Linq;
using Castle.Core.Logging;
using System.Xml.Serialization;
using EndlessModding.Common;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime;
using Microsoft.Win32;

namespace EndlessModding.EndlessSpace2.Common.Files
{
    class Export
    {
        private ILogger _logger;
        public Export(ILogger logger)
        {
            _logger = logger;
        }
        public void SaveMod(RuntimeModule Mod, object[] modules, string BaseDir)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            var Locales = new List<Classes.Amplitude_Localisation.LocalizationPair>();
            var AssetLocales = new List<Classes.Amplitude_Localisation.LocalizationPair>();
            var outputdir = BaseDir + "\\" + Mod.Name + "\\";

            if (Mod.Image != null && string.IsNullOrEmpty(Mod.PreviewImageFile))
            {
                Mod.PreviewImageFile = "ModIcon.png";
            }
            if (string.IsNullOrEmpty(Mod.Homepage))
            {
                Mod.Homepage = "https://github.com/CallyyllaC/EndlessModding";
            }

            //set plugins
            if (Mod.Plugins == null)
            {
                Mod.Plugins = new RuntimePlugin[0];
            }
            else
            {
                Mod.Plugins = Mod.Plugins.Where(x => x.Enabled).ToArray();
            }

            //Loop through the modules
            foreach (var mods in modules)
            {
                //work out what the module is
                if (mods is Classes.HeroDefinition.HeroDefinition)
                {
                    var Hero = mods as Classes.HeroDefinition.HeroDefinition;

                    //Update database plugins
                    AddHeroToMod(Mod, Hero);

                    //Save Files
                    SaveHero(Mod, Hero, outputdir, Locales);
                }
            }

            //Do localisation
            var list = Mod.Plugins.ToList();
            list.Add(new LocalizationPlugin()
            {
                Directory = new string[] { "Localization" },
                DefaultLanguage = "english"
            });
            Mod.Plugins = list.ToArray();
            SaveLocalisation(Locales.ToArray(), $"{outputdir}Localization\\english\\");
            SaveLocalisation(AssetLocales.ToArray(), $"{outputdir}Localization\\english\\", true);

            //Save the mod
            SaveMod(Mod, outputdir);
        }

        private void AddHeroToMod(RuntimeModule Mod, Classes.HeroDefinition.HeroDefinition Hero)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            //Add Required Plugins To Mod
            var plugins = Mod.Plugins.ToList();
            //Add the Hero
            plugins.Add(new DatabasePlugin()
            {
                DataType = "HeroDefinition, Assembly-CSharp",
                FilePath = new string[] { $"Simulation\\{Hero.Name}.xml" }
            });
            //Add the hero GUI
            plugins.Add(new DatabasePlugin()
            {
                DataType = "Amplitude.Unity.Gui.GuiElement, Assembly-CSharp-firstpass",
                ExtraTypes = new XmlExtraType[]
                {
                    new XmlExtraType() { DataType = "HeroGuiElement, Assembly-CSharp" },
                    new XmlExtraType() { DataType = "Amplitude.Unity.Gui.ExtendedGuiElement, Assembly-CSharp-firstpass" }
                },
                FilePath = new string[] { $"Gui\\{Hero.Name}GuiElements.xml" }
            });

            //save to the mod
            Mod.Plugins = plugins.ToArray();
        }
        private void SaveHero(RuntimeModule Mod, Classes.HeroDefinition.HeroDefinition Hero, string FileDir, List<Classes.Amplitude_Localisation.LocalizationPair> Locales)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            //Save Hero XML
            SaveXML(Hero, typeof(Classes.HeroDefinition.HeroDefinition), $"{FileDir}Simulation\\{Hero.Name}.xml");
            //Save Images
            SaveImage(Hero.MoodImage, $"{FileDir}Resources\\Gui\\{Hero.Name}Mood.png");
            SaveImage(Hero.MediumImage, $"{FileDir}Resources\\Gui\\{Hero.Name}Medium.png");
            SaveImage(Hero.LargeImage, $"{FileDir}Resources\\Gui\\{Hero.Name}Large.png");

            //localisation
            Locales.Add(GetLocalisation($"%{Hero.Name}Title", Hero.RealName));
            Locales.Add(GetLocalisation($"%{Hero.Name}Description", Hero.Description));

            //gui element
            var guiElement = new Classes.Amplitude_Gui_GuiElement.HeroGuiElement()
            {
                Name = Hero.Name,
                Title = $"%{Hero.Name}Title",
                Description = $"%{Hero.Name}Description",
                Icons = new GuiElementIconCollection()
                {
                    Icon = new IconDefinition[]
                    {
                        new IconDefinition(){Size = "Mood", Path = $"Gui\\{Hero.Name}Mood.png"},
                        new IconDefinition(){Size = "Medium", Path = $"Gui\\{Hero.Name}Medium.png"},
                        new IconDefinition(){Size = "Large", Path = $"Gui\\{Hero.Name}Large.png"}
                    }
                }
            };
            SaveGUIElements(guiElement, $"{FileDir}Gui\\{Hero.Name}GuiElements.xml");
        }
        private void SaveGUIElements(Classes.Amplitude_Gui_GuiElement.GuiElement GUI, string FileDir)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            //Save GUI XML
            SaveXML(GUI, GUI.GetType(), FileDir);
        }
        private void SaveMod(RuntimeModule Mod, string FileDir)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            //Save Mod XML
            SaveXML(Mod, typeof(RuntimeModule), $"{FileDir}{Mod.Name}.xml");
            //Save Image
            SaveImage(Mod.Image, FileDir + "ModIcon.png");
        }

        private void SaveImage(WriteableBitmap Image, string FileName)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Image == null)
            {
                return;
            }

            try
            {
                new FileInfo(FileName).Directory?.Create();
                using (FileStream stream = new FileStream(FileName, FileMode.Create))
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(Image));
                    encoder.Save(stream);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        private void SaveXML(object obj, Type type, string FileName)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            try
            {
            XmlSerializer serialist = new XmlSerializer(type);
            new FileInfo(FileName).Directory?.Create();
            using (StringWriterWithEncoding textWriter = new StringWriterWithEncoding(Encoding.UTF8))
            {
                serialist.Serialize(textWriter, obj);
                //can you tell I dont know what I'm doing?
                var stringy = textWriter.ToString().Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "").Replace("xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "").Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "").Replace("</ArrayOfLocalizationPair>", "").Replace("<ArrayOfLocalizationPair  >", "");
                var output = $"<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<Datatable xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\n{stringy}\n</Datatable>";
                File.WriteAllText(FileName, output, Encoding.UTF8);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        private Classes.Amplitude_Localisation.LocalizationPair GetLocalisation(string key, string value)
        {
            return new Classes.Amplitude_Localisation.LocalizationPair() { Name = key, Value = value };
        }
        private void SaveLocalisation(Classes.Amplitude_Localisation.LocalizationPair[] input, string dir, bool asset = false)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (input.Length < 1)
            {
                return;
            }
            SaveXML(input, typeof(Classes.Amplitude_Localisation.LocalizationPair[]), $"{dir}\\{(asset ? "ES2_Localization_Assets_Locales" : "ES2_Localization_Locales")}.xml");
        }
    }
    public sealed class StringWriterWithEncoding : StringWriter
    {
        private readonly Encoding encoding;

        public StringWriterWithEncoding() { }

        public StringWriterWithEncoding(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public override Encoding Encoding
        {
            get { return encoding; }
        }
    }
}
