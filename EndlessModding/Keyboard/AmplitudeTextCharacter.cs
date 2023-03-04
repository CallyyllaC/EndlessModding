using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EndlessModding.Keyboard
{
    public class AmplitudeTextCharacter
    {
        //https://steamcommunity.com/sharedfiles/filedetails/?id=1413567299
        public static Dictionary<string, int> lookup = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase)
        {
            //Alphabet
            { "A", 57954},
            { "B", 57955},
            { "C", 57956},
            { "D", 57957},
            { "E", 57958},
            { "F", 57959},
            { "G", 57960},
            { "H", 57961},
            { "I", 57962},
            { "J", 57963},
            { "K", 57964},
            { "L", 57965},
            { "M", 57966},
            { "N", 57967},
            { "O", 57968},
            { "P", 57969},
            { "Q", 57970},
            { "R", 57971},
            { "S", 57972},
            { "T", 57973},
            { "U", 57974},
            { "V", 57975},
            { "W", 57976},
            { "X", 57977},
            { "Y", 57978},
            { "Z", 57979},
            { "moins", 57980},

            //Major Factions
            { "Custom00", 57837},
            { "Custom01", 57838},
            { "Custom02", 57839},
            { "Custom03", 57840},
            { "Custom04", 57841},
            { "Custom05", 57842},
            { "Custom06", 57843},
            { "Custom07", 57844},
            { "Custom08", 57845},
            { "Custom09", 57846},
            { "Custom10", 57847},
            { "Custom11", 57848},
            {"Sophons",57408},
            {"Cravers",57409},
            {"Vampirilis",57410},
            {"Venetians",57411},
            {"Terrans",57412},
            {"Horatio",57413},
            {"Timelords",57414},
            {"Unfallen",57415},
            {"Sheredyn",57437},
            {"Mezari",57438},
            {"Vaulters",57440},
            {"VaultersMilitary",57459},
            {"VaultersScience",57460},


            //Minor Factions
            {"MajorHisshos",-1},
            {"illo",-1},
            {"Haroshems",57416},
            {"Pulsos",57418},
            {"Eyders",57419},
            {"Kalgeros",57420},
            {"Niris",57421},
            {"Gnashasts",57422},
            {"Remnants",57423},
            {"Epistis",57424},
            {"Mavros",57425},
            {"Pilgrims",57426},
            {"Zvalis",57427},
            {"Deuyivans",57428},
            {"Tikanans",57429},
            {"Bhagabas",57430},
            {"Amoebas",57431},
            {"Hisshos",57464},
            {"sistersOfMercy",-1},

            //Luxuries
            {"Lux00Luxury",57510},
            {"Lux01Redsang",57486},
            {"Lux02Jadonyx",57487},
            {"Lux03Dustciduous",57488},
            {"Lux04Bluecap",57489},
            {"Lux05EdenIncense",57490},
            {"Lux06Transvine",57491},
            {"Lux07DarkGlitter",57492},
            {"Lux08Uberspuds",57493},
            {"Lux09Hydromiel",57494},
            {"Lux10VoidStone",57495},
            {"Lux11ProtoOrchid",57496},
            {"Lux12IonicCristal",57497},
            {"Lux13GigaLattice",57498},
            {"Lux14LostCities",57499},
            {"Lux15Amianthoid",57500},
            {"Lux16Gossamer",57501},
            {"Lux17Mercurite",57502},
            {"Lux18EndlessFoundries",57503},
            {"Lux19DustWater",57504},
            {"Lux20ProtoSpores",57505},
            {"Lux21MetaEntactogen",57506},
            {"Lux22BenthicGems",57507},
            {"Lux23VirtualArtifacts",57508},
            {"Lux24Driftbuds",57509},

            //Strategics
            {"Strat00Strategic",57453},
            {"Strat01TitaniumColored",57447},
            {"Strat01Titanium",57447},
            {"Strat02HyperiumColored",57448},
            {"Strat02Hyperium",57448},
            {"Strat03AdamantianColored",57449},
            {"Strat03Adamantian",57449},
            {"Strat04Anti-matterColored",57450},
            {"Strat04Anti-matter",57450},
            {"Strat05OrichalcixColored",57451},
            {"Strat05Orichalcix",57451},
            {"Strat06QuadrinixColored",57452},
            {"Strat06Quadrinix",57452},

            //System + Planets
            {"happiness",-1},
            {"happinessColored",-1},
            {"temperatureHot",-1},
            {"temperatureCold",-1},
            {"temperatureTemperate",-1},
            {"rich",-1},
            {"poor",-1},
            {"growth",-1},
            {"buyout",-1},
            {"population",-1},
            {"populationUncolored",-1},
            {"GoldenAge",-1},
            {"improvement",-1},
            {"humidityGas",-1},
            {"branch",-1},
            {"catalyst",-1},
            {"Terraformation",-1},
            {"hq",-1},
            {"OverPopulation",-1},
            {"lifeforceUpkeep",-1},
            {"influenceUpkeepColored",-1},
            {"influenceupkeep",-1},



            //Politics and FIDSI
            {"warExhaust",-1},
            {"pressure",-1},
            {"politics",-1},
            {"industrialistColored",-1},
            {"industrialist",-1},
            {"scientistColored",-1},
            {"scientist",-1},
            {"pacifistColored",-1},
            {"pacifist",-1},
            {"ecologistColored",-1},
            {"ecologist",-1},
            {"religiousColored",-1},
            {"religious",-1},
            {"militaristColored",-1},
            {"militarist",-1},
            {"industryColored",-1},
            {"industry",-1},
            {"foodColored",-1},
            {"food",-1},
            {"dustColored",-1},
            {"dust",-1},
            {"scienceColored",-1},
            {"science",-1},
            {"prestigeColored",-1},
            {"prestige",-1},
            {"upkeepColored",-1},
            {"upkeep",-1},
            {"FIDSI",-1},
            {"FIDS",-1},

            //Battle + Ship
            {"warPoint",-1},
            {"infantry",-1},
            {"tank",-1},
            {"plane",-1},
            {"shipCrew",-1},
            {"shipCrewColored",-1},
            {"manPower",-1},
            {"manPowerColored",-1},
            {"bomber",-1},
            {"fighter",-1},
            {"colonizer",-1},
            {"superColonizer",-1},
            {"explorer",-1},
            {"hero",-1},
            {"attacker",-1},
            {"support",-1},
            {"carrier",-1},
            {"Battleship",-1},
            {"mothership",-1},
            {"citadelDefense",-1},
            {"systemDefense",-1},
            {"systemDefenseColored",-1},
            {"lifeforce",-1},
            {"lifeforceColored",-1},
            {"level",-1},
            {"Level {1}",-1},
            {"commandPoint",-1},
            {"LongRange",-1},
            {"MediumRange",-1},
            {"ShortRange",-1},
            {"defense",-1},
            {"shield",-1},
            {"plating",-1},
            {"move",-1},
            {"defeat",-1},
            {"victory",-1},
            {"duel",-1},
            {"ship",-1},
            {"privateers",-1},
            {"mercenaries",-1},
            {"DamageApplied",-1},
            {"DamageReveived",-1},
            {"role",-1},
            {"size",-1},
            {"defensiveMilitaryPower",-1},
            {"juggernaut",-1},

            //Hero
            {"Adventurer",-1},
            {"Administrator",-1},
            {"Admiral",-1},
            {"Corporate",-1},

            //Diplomacy

            {"TBD",-1},
            {"chemical oxygen iridium laser",-1},
            {"productionColored",-1},
            {"turn",-1},
            {"pi",-1},
            {"sum",-1},
            {"derivate",-1},
            {"offensiveMilitaryPower",-1},
            {"green",-1},
            {"citadel",-1},
            {"honorColored",-1},
            {"quadrantScienceAndExploration",-1},
            {"quadrantEconomyAndTrade",-1},
            {"quadrantEmpireDevelopment",-1},
            {"quadrantMilitary",-1},
            {"obedienceColored",-1},
            {"turnColored",-1},
            {"health",-1},
            {"efficiency",-1},
            {"pink",-1},
            {"guardians",-1},
            {"greenman",-1},
            {"sefaloros",-1},
            {"galvrans",-1},
            {"kaltikmas",-1},
            {"anomaly",-1},
            {"sowers",-1},
            {"traitor",-1},
            {"umbralChoir",-1},
            {"kalmat",-1},
            {"processingPower",-1},
            {"backdoor",-1},
            {"Obliterator",-1},
            {"hackingOperation",-1},
            {"defensiveProgram",-1},
            {"offensiveProgram",-1},
            {"templar",-1},
            {"relicColored",-1},
            {"oracular",-1},
            {"technology",-1},
            {"This trait should not appear",-1},
            {"OverColonization",-1},
            {"humidityDry",-1},
            {"humidityWater",-1},
            {"gray",-1},
            {"TBD by SEGA legal",-1},
            {"affinity",-1},
            {"heroClass",-1},
            {"masteryCommand",-1},
            {"masteryCuriosity",-1},
            {"masteryLabour",-1},
            {"masteryWit",-1},
            {"red",-1},
            {"DEPRECATED",-1},
            {"Debug",-1},
            {"blue-gray",-1},
            {"reward",-1},
            {"{0}/{1}",-1},
            {"Aurora-waves",-1},
            {"Details",-1},
            {"Forest",-1},
            {"Husk",-1},
            {"Story",-1},
            {"10\\^ 24\\^Kg",-1},
            {"10\\^ 6\\^km",-1},
            {"10\\^3\\^kg/m\\^ 3\\^",-1},
            {"m/s\\^ 2\\^",-1},
            {"km/s",-1},
            {"Atoll",-1},
            {"Jenes",-1},
            {"Hekim",-1},
            {"Terran",-1},
            {"Koyasil",-1},
            {"Tchinomy",-1},
            {"Tundra",-1},
            {"currentTurn",-1},
            {"Beginner",-1},
            {"colonization",-1},
            {"basryxo",-1},
            {"bots",-1},
            {"superGuardians",-1},
            {"harmony",-1},
            {"Metafolding",-1},
            {"random",-1},
            {"eyder",-1},
            {"academy",-1},
            {"  KEY  ",-1},
            {"medal",-1},
            {"merchant",-1},
            {"tradeEfficiency",-1},
            {"honor",-1},
            {"obedience",-1},
            {"hackingSpeed",-1},
            {"relic",-1},
            {"scavenger",-1},
            {"Resource",-1},
            {"Type",-1},
            {"JB",-1},
            {"Tables",-1},


            //Misc
            { "RightClick", 57620},
            { "LeftClick", 57621},
            { "Disclaimer", 57622},
            { "Event", 57625},
            { "Crown", 57628},
            { "StarSystem", 57629},
            { "PositiveImpact", 57623},
            { "pirate", 57624},//Needs the Vaulter DLC to be used
            { "Quest", 57626},
            { "NegativeImpact", 57627},

        };

        public string Value { get; }

        public string Character
        {
            get
            {
                //Add Capitalisation and Spacing
                return $"{AddSpacesToSentence(Value)}";
            }
        }
        public string Icon
        {
            get
            {
                //if (lookup.ContainsKey(Value))
                if (lookup.TryGetValue(Value, out int me) && me != -1)
                {
                    return $"{Convert.ToChar(me)}";
                }

                return $"";
            }
        }

        public AmplitudeTextCharacter(string value)
        {
            Value = value;
        }
        private static string AddSpacesToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }

            text = Regex.Replace(text, "([a-z])([A-Z])", "$1 $2");
            text = Regex.Replace(text, "([a-z])([0-9])", "$1 $2");
            text = Regex.Replace(text, "([0-9])([a-z])", "$1 $2");
            text = Regex.Replace(text, "([0-9])([A-Z])", "$1 $2");

            StringBuilder newText = new StringBuilder(text.Length);
            newText.Append(text[0].ToString().ToUpper());

            for (int i = 1; i < text.Length; i++)
            {
                if (!char.IsUpper(text[i]) && char.IsWhiteSpace(text[i - 1]))
                {
                    newText.Append(text[i].ToString().ToUpper());
                }
                else if (!char.IsUpper(text[i]) && char.IsPunctuation(text[i - 1]))
                {
                    newText.Append(text[i].ToString().ToUpper());
                }
                else
                {
                    newText.Append(text[i]);
                }
            }
            return newText.ToString();
        }
    }
}