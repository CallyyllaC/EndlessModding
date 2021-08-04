using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Castle.Core.Logging;
using System.Xml.Serialization;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Gui_GuiElement;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime;
using Microsoft.Win32;

namespace EndlessModding.EndlessSpace2.Common.Files
{
    class Export
    {
        private ILogger _logger;
        public Export(ILogger _logger)
        {
            _logger = _logger;
        }
        public async void SaveMod(RuntimeModule ModToSave, object[] modules, string BaseDir)
        {
            var outputdir = BaseDir + ModToSave.Name + "\\";
            //Loop through the modules
                foreach (var mods in modules)
                {
                    //work out what the module is
                    if (mods is Classes.HeroDefinition.HeroDefinition)
                    {
                        var Hero = mods as Classes.HeroDefinition.HeroDefinition;
                        //Add Required Plugins To Mod
                        var plugins = ModToSave.Plugins.ToList();
                        //Add the Hero
                        plugins.Add(new DatabasePlugin()
                        {
                            DataType = "HeroDefinition, Assembly-CSharp",
                            FilePath = new string[] { $"{outputdir}Simulation\\{Hero.Name}.xml" }
                        });
                        //Add the hero GUI
                        plugins.Add(new DatabasePlugin() {
                            DataType = "Amplitude.Unity.Gui.GuiElement, Assembly-CSharp-firstpass",
                            ExtraTypes = new XmlExtraType[]
                            {
                                new XmlExtraType() { DataType = "HeroGuiElement, Assembly-CSharp" },
                                new XmlExtraType() { DataType = "Amplitude.Unity.Gui.ExtendedGuiElement, Assembly-CSharp-firstpass" }
                            },
                            FilePath = new string[] { $"{outputdir}Gui\\{Hero.Name}GuiElements.xml" } });

                        //save to the mod
                        ModToSave.Plugins = plugins.ToArray();
                        //Save Files
                        SaveHero(Hero, outputdir);
                        var guiElement = new Classes.Amplitude_Gui_GuiElement.HeroGuiElement()
                        {
                            Title = Hero.RealName,
                            Description = Hero.Description,
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
                        SaveGUIElements(guiElement, $"{outputdir}Gui\\{Hero.Name}GuiElements.xml");
                    }
                }

                //Save the mod
                SaveMod(ModToSave, outputdir);
        }

        private void SaveHero(Classes.HeroDefinition.HeroDefinition Hero, string FileDir)
        {
            //Save Hero XML
            SaveXML(Hero, $"{FileDir}Simulation\\{Hero.Name}.xml");
            //Save Images
            SaveImage(Hero.MoodImage, $"{FileDir}Resources\\Gui\\{Hero.Name}Mood.png");
            SaveImage(Hero.MediumImage, $"{FileDir}Resources\\Gui\\{Hero.Name}Medium.png");
            SaveImage(Hero.LargeImage, $"{FileDir}Resources\\Gui\\{Hero.Name}Large.png");
        }
        private async void SaveGUIElements(Classes.Amplitude_Gui_GuiElement.GuiElement GUI, string FileDir)
        {
            //Save GUI XML
            SaveXML(GUI, FileDir);
        }
        private async void SaveMod(RuntimeModule Mod, string FileDir)
        {
            //Save Mod XML
            SaveXML(Mod, FileDir + Mod.Name);
            //Save Image
            SaveImage(Mod.Image, FileDir + "ModIcon.png");
        }

        private void SaveImage(WriteableBitmap Image, string FileName)
        {
            using (FileStream stream = new FileStream(FileName, FileMode.Create))
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(Image));
                encoder.Save(stream);
            }
        }

        private void SaveXML(object obj, string FileName)
        {


        }
    }
}
