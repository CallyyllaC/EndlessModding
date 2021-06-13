using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EndlessModding.Common.Import
{
    public class Import
    {
        HashSet<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition> HeroDefinitions = new HashSet<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition>();
        HashSet<EndlessSpace2.Common.Classes.HeroClassDefinition.HeroClassDefinition> HeroClassDefinitions = new HashSet<EndlessSpace2.Common.Classes.HeroClassDefinition.HeroClassDefinition>();
        HashSet<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition> HeroAffinityDefinitions = new HashSet<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition>();
        HashSet<string> files;
        public void ImportAll(string GameDir)
        {
            //clear all of the current comboboxes



            //get all the useful xml data
            files = Directory.GetFiles($"{GameDir}Public\\Simulation\\", "*.xml", SearchOption.AllDirectories).ToHashSet<string>();


            //Get Hero Mastery Definitions

            //Get Encounter Play Definitions

            //Get Hero Affinity Definitions
            HeroAffinityDefinitions = LoadNodes<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition>("HeroAffinityDefinitions", "HeroAffinityDefinition");

            //Get Hero Class Definitions
            HeroDefinitions = LoadNodes<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition>("HeroDefinitions", "HeroDefinition");

            //Get Hero Definitions
            HeroClassDefinitions = LoadNodes<EndlessSpace2.Common.Classes.HeroClassDefinition.HeroClassDefinition>("HeroClassDefinitions", "HeroClassDefinition");

            //Get Hero Politic Definitions

            //Get Hero Simulation Descriptors

            //Get Hero Skill Definitions

            //Get Hero Skill Tree Definitions

            //Get Level up Rule Definitions

            //Get Mastery Level Definitions

            //Get Hero Skill Definitions

            //Get Hero Skill Definitions

            //Get Modifiers



            //add the data to the correct ui element
        }

        private HashSet<T> LoadNodes<T>(string Mask, string Node)
        {
            ConcurrentBag<T> bag = new ConcurrentBag<T>();
            XmlSerializer serialist = new XmlSerializer(typeof(T));

            Func<XElement, T> SerialiseFunc = xml =>
            {
                var reader = xml.CreateReader();
                T tmp = (T)serialist.Deserialize(reader);
                reader.Dispose();
                return tmp;
            };

            Parallel.ForEach(files.Where(x => x.Contains(Mask)), file =>
            {
                XElement document = XElement.Load(file);

                var definitions = document.Elements(Node)
                    .Select(SerialiseFunc)
                    .ToArray();

                Parallel.ForEach(definitions, item => bag.Add(item));
            });

            return bag.ToHashSet();
        }
    }
}
