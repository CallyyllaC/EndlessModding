using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
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
        public BindingList<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition> HeroDefinitions = new BindingList<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition>();
        public BindingList<EndlessSpace2.Common.Classes.HeroClassDefinition.HeroClassDefinition> HeroClassDefinitions = new BindingList<EndlessSpace2.Common.Classes.HeroClassDefinition.HeroClassDefinition>();
        public BindingList<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition> HeroAffinityDefinitions = new BindingList<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition>();
        public BindingList<EndlessSpace2.Common.Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition> HeroPoliticsDefinitions = new BindingList<EndlessSpace2.Common.Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition>();
        public BindingList<EndlessSpace2.Common.Classes.ShipDesignDefinitions.ShipDesignDefinition> ShipDesignDefinitions = new BindingList<EndlessSpace2.Common.Classes.ShipDesignDefinitions.ShipDesignDefinition>();
        public BindingList<EndlessSpace2.Common.Classes.MajorFactions.MajorFaction> MajorFactions = new BindingList<EndlessSpace2.Common.Classes.MajorFactions.MajorFaction>();
        public BindingList<EndlessSpace2.Common.Classes.HeroSkillDefinition.HeroSkillDefinition> HeroSkillDefinitions = new BindingList<EndlessSpace2.Common.Classes.HeroSkillDefinition.HeroSkillDefinition>();
        public BindingList<EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition> HeroSkillTreeDefinitions = new BindingList<EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition>();
        HashSet<string> files;
        public void ImportAll(string GameDir)
        {
            //clear all of the current comboboxes
            HeroDefinitions.Clear();
            HeroClassDefinitions.Clear();
            HeroAffinityDefinitions.Clear();
            HeroPoliticsDefinitions.Clear();
            ShipDesignDefinitions.Clear();
            MajorFactions.Clear();
            HeroSkillDefinitions.Clear();
            HeroSkillTreeDefinitions.Clear();
            //get all the useful xml data
            files = Directory.GetFiles($"{GameDir}Public\\Simulation\\", "*.xml", SearchOption.AllDirectories).ToHashSet<string>();


            //Get Hero Mastery Definitions

            //Get Encounter Play Definitions

            //Get Hero Affinity Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroAffinityDefinitions.HeroAffinityDefinition>(HeroAffinityDefinitions, "HeroAffinityDefinitions", "HeroAffinityDefinition");

            //Get Hero Class Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroDefinition.HeroDefinition>(HeroDefinitions, "HeroDefinitions", "HeroDefinition");

            //Get Hero Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroClassDefinition.HeroClassDefinition>(HeroClassDefinitions, "HeroClassDefinitions", "HeroClassDefinition");

            //Get Hero Politic Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroPoliticsDefinitions.HeroPoliticsDefinition>(HeroPoliticsDefinitions, "HeroPoliticsDefinitions", "HeroPoliticsDefinition");
            //Get Hero Simulation Descriptors

            //Get Hero Skill Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroSkillDefinition.HeroSkillDefinition>(HeroSkillDefinitions, "HeroSkillDefinitions", "HeroSkillDefinition");
            //Get Hero Skill Tree Definitions
            LoadNodes<EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition>(HeroSkillTreeDefinitions, "HeroSkillTreeDefinitions", "HeroSkillTreeDefinition");
            //Get Level up Rule Definitions

            //Get Mastery Level Definitions

            //Get Ship Definitions
            LoadNodes<EndlessSpace2.Common.Classes.ShipDesignDefinitions.ShipDesignDefinition>(ShipDesignDefinitions, "ShipDesignDefinitions", "ShipDesignDefinition");
            //Get Hero Skill Definitions

            //Get Modifiers

            //Get Major Factions
            LoadNodes<EndlessSpace2.Common.Classes.MajorFactions.MajorFaction>(MajorFactions, "Factions", "MajorFaction");


            //add the data to the correct ui element
        }

        private void LoadNodes<T>(BindingList<T> input, string Mask, string Node)
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

            foreach( var item in bag)
            {
                input.Add(item);
            }
        }
    }
}
