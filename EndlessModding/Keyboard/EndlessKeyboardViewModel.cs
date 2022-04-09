using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using EndlessModding.Common;
using Microsoft.Xaml.Behaviors;
using DataGrid = System.Windows.Controls.DataGrid;
using ListBox = System.Windows.Controls.ListBox;
using TextBox = System.Windows.Controls.TextBox;

namespace EndlessModding.Keyboard
{
    public class EndlessKeyboardViewModel : INotifyPropertyChanged
    {
        public FontFamily AmplitudeFont { get; } = new FontFamily("AmplitudeFont");
        public ICommand AddFont { get; }
        public ICommand CopyFont { get; }
        public ICommand AddText { get; }
        public ICommand AddColour { get; }
        public ICommand CopyText { get; }
        public Color? Colour { get; set; }
        public int Caret { get; set; }
        public int SelectionStart { get; set; }
        public int SelectionLength { get; set; }
        public string FontText
        {
            get => _fontText;

            set
            {
                if (_fontText != value)
                {
                    _fontText = value;
                    RaisePropertyChanged();
                }
            }

        }
        private string _textText = "";
        public string TextText
        {
            get => _textText;

            set
            {
                if (_textText != value)
                {
                    _textText = value;
                    RaisePropertyChanged();
                }
            }

        }
        private string _fontText = "";
        public AmplitudeFontCharacter SelectedFont { get; set; } = null;
        public AmplitudeTextCharacter SelectedText { get; set; } = null;
        public BindingList<AmplitudeFontCharacter> Characters { get; set; } = new BindingList<AmplitudeFontCharacter>();
        public BindingList<AmplitudeTextCharacter> Texts { get; set; } = new BindingList<AmplitudeTextCharacter>();
        public EndlessKeyboardViewModel()
        {
            var typefaces = AmplitudeFont.GetTypefaces();
            foreach (Typeface typeface in typefaces)
            {
                GlyphTypeface glyph;
                typeface.TryGetGlyphTypeface(out glyph);
                IDictionary<int, ushort> characterMap = glyph.CharacterToGlyphMap;

                Characters.Clear();

                foreach (KeyValuePair<int, ushort> kvp in characterMap)
                {
                    if (kvp.Key > 57330 && kvp.Key < 58000)
                    {
                        Characters.Add(new AmplitudeFontCharacter(kvp.Key));
                    }
                }

            }

            AddText = new RelayCommand(canAddTextChar, AddTextChar);
            CopyText = new RelayCommand(canCopyTextText, CopyTextText);
            AddFont = new RelayCommand(canAddFontChar, AddFontChar);
            CopyFont = new RelayCommand(canCopyFontText, CopyFontText);
            AddColour = new RelayCommand(canAddColourText, AddColourText);

            foreach (var item in AmplitudeTextCharacter.lookup)
            {
                Texts.Add(new AmplitudeTextCharacter(item.Key));
            }
        }

        private void AddColourText(object obj)
        {
            var str = Colour.Value.ToString();
            str = str.Substring(3, str.Length - 3);
            if (SelectionLength <= 0)
            {
                if (SelectionStart == 0)
                {
                    SelectionStart = TextText.Length;
                }
                TextText = TextText.Insert(SelectionStart, $"#{str}# MY TEXT #REVERT#");
            }
            else
            {
                TextText = TextText.Insert(SelectionStart + SelectionLength, "#REVERT#")
                    .Insert(SelectionStart, $"#{str}#");
            }
        }

        private bool canAddColourText(object obj)
        {
            if (Colour != null)
            {
                return true;
            }

            return false;
        }

        private void CopyFontText(object obj)
        {
            Clipboard.SetText(FontText);
        }

        private bool canCopyFontText(object obj)
        {
            if (FontText.Length > 0)
            {
                return true;
            }
            return false;
        }
        private void AddFontChar(object obj)
        {
            FontText += $"{Convert.ToChar(SelectedFont.Key)}";
        }

        private bool canAddFontChar(object obj)
        {
            return SelectedFont != null;
        }
        private void CopyTextText(object obj)
        {
            Clipboard.SetText(TextText);
        }

        private bool canCopyTextText(object obj)
        {
            if (TextText.Length > 0)
            {
                return true;
            }
            return false;
        }
        private void AddTextChar(object obj)
        {
            if (SelectionLength <= 0 && SelectionStart == 0)
            {
                SelectionStart = TextText.Length;
            }
            TextText = TextText.Insert(SelectionStart, $"[{SelectedText.Value}]");
        }

        private bool canAddTextChar(object obj)
        {
            return SelectedText != null;
        }

        #region INotifyPropertyChanged
        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="propertyName">Name of the property.</param>
        private void RaisePropertyChanged(object target, string propertyName)
        {
            PropertyChanged?.Invoke(target, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public class AmplitudeFontCharacter
    {
        public int Key
        {
            get;
        }
        public string Character
        {
            get => $"{Convert.ToChar(Key)}";
        }

        public AmplitudeFontCharacter(int key)
        {
            Key = key;
        }
    }
    public class AmplitudeTextCharacter
    {
        public static Dictionary<string, int> lookup = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase)
        {
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
            {"Unfallen",57415},
            {"Sheredyn",57437},
            {"Mezari",57438},
            {"Vaulters",57440},
            {"VaultersMilitary",57459},
            {"VaultersScience",57460},


            //Minor Factions
            {"haroshems",-1},
            {"kalgeros",-1},
            {"epistis",-1},
            {"deuyivans",-1},
            {"amoebas",-1},
            {"hisshos",-1},
            {"mavros",-1},
            {"pilgrims",-1},
            {"zvalis",-1},
            {"tikanans",-1},
            {"gnashasts",-1},
            {"eyders",-1},
            {"niris",-1},
            {"bhagabas",-1},
            {"Remnants",-1},
            {"Pulsos",-1},

            {"TBD",-1},
            {"commandPoint",-1},
            {"lifeforceColored",-1},
            {"population",-1},
            {"foodColored",-1},
            {"move",-1},
            {"chemical oxygen iridium laser",-1},
            {"productionColored",-1},
            {"dustColored",-1},
            {"scienceColored",-1},
            {"prestigeColored",-1},
            {"OverPopulation",-1},
            {"happinessColored",-1},
            {"timelords",-1},
            {"manPower",-1},
            {"FIDSI",-1},
            {"industryColored",-1},
            {"industrialistColored",-1},
            {"scientistColored",-1},
            {"pacifistColored",-1},
            {"ecologistColored",-1},
            {"religiousColored",-1},
            {"militaristColored",-1},
            {"turn",-1},
            {"Strat01titaniumColored",-1},
            {"Strat02hyperiumColored",-1},
            {"Strat03adamantianColored",-1},
            {"Strat04anti-matterColored",-1},
            {"Strat05orichalcixColored",-1},
            {"Strat06quadrinixColored",-1},
            {"manPowerColored",-1},
            {"hq",-1},
            {"pi",-1},
            {"sum",-1},
            {"derivate",-1},
            {"offensiveMilitaryPower",-1},
            {"green",-1},
            {"citadel",-1},
            {"honorColored",-1},
            {"quadrantScienceAndExploration",-1},
            {"juggernaut",-1},
            {"quadrantEconomyAndTrade",-1},
            {"quadrantEmpireDevelopment",-1},
            {"quadrantMilitary",-1},
            {"fids",-1},
            {"carrier",-1},
            {"Battleship",-1},
            {"mothership",-1},
            {"citadelDefense",-1},
            {"MajorHisshos",-1},
            {"obedienceColored",-1},
            {"illo",-1},
            {"upkeep",-1},
            {"turnColored",-1},
            {"improvement",-1},
            {"health",-1},
            {"efficiency",-1},
            {"defensiveMilitaryPower",-1},
            {"pink",-1},
            {"guardians",-1},
            {"shipCrewColored",-1},
            {"ship",-1},
            {"temperatureHot",-1},
            {"greenman",-1},
            {"sefaloros",-1},
            {"poor",-1},
            {"galvrans",-1},
            {"kaltikmas",-1},
            {"anomaly",-1},
            {"sowers",-1},
            {"Lux00Luxury",-1},
            {"traitor",-1},
            {"umbralChoir",-1},
            {"kalmat",-1},
            {"processingPower",-1},
            {"backdoor",-1},
            {"Strat00Strategic",-1},
            {"populationUncolored",-1},
            {"Obliterator",-1},
            {"systemDefenseColored",-1},
            {"hackingOperation",-1},
            {"defensiveProgram",-1},
            {"offensiveProgram",-1},
            {"scientist",-1},
            {"religious",-1},
            {"templar",-1},
            {"relicColored",-1},
            {"oracular",-1},
            {"rich",-1},
            {"technology",-1},
            {"fighter",-1},
            {"dust",-1},
            {"colonizer",-1},
            {"explorer",-1},
            {"hero",-1},
            {"support",-1},
            {"pressure",-1},
            {"This trait should not appear",-1},
            {"buyout",-1},
            {"OverColonization",-1},
            {"humidityDry",-1},
            {"humidityWater",-1},
            {"growth",-1},
            {"upkeepColored",-1},
            {"gray",-1},
            {"TBD by SEGA legal",-1},
            {"affinity",-1},
            {"heroClass",-1},
            {"level",-1},
            {"masteryCommand",-1},
            {"masteryCuriosity",-1},
            {"masteryLabour",-1},
            {"masteryWit",-1},
            {"politics",-1},
            {"role",-1},
            {"size",-1},
            {"red",-1},
            {"DEPRECATED",-1},
            {"Debug",-1},
            {"blue-gray",-1},
            {"reward",-1},
            {"Terraformation",-1},
            {"attacker",-1},
            {"{0}/{1}",-1},
            {"Aurora-waves",-1},
            {"Details",-1},
            {"Forest",-1},
            {"Husk",-1},
            {"Story",-1},
            {"10\\\\^ 24\\\\^Kg",-1},
            {"10\\\\^ 6\\\\^km",-1},
            {"10\\\\^3\\\\^kg/m\\\\^ 3\\\\^",-1},
            {"m/s\\\\^ 2\\\\^",-1},
            {"km/s",-1},
            {"Atoll",-1},
            {"Jenes",-1},
            {"Hekim",-1},
            {"Terran",-1},
            {"Koyasil",-1},
            {"Tchinomy",-1},
            {"Tundra",-1},
            {"prestige",-1},
            {"Level {1}",-1},
            {"temperatureCold",-1},
            {"temperatureTemperate",-1},
            {"currentTurn",-1},
            {"Lux05EdenIncense",-1},
            {"Lux06Transvine",-1},
            {"Lux07DarkGlitter",-1},
            {"Lux08Uberspuds",-1},
            {"Beginner",-1},
            {"colonization",-1},
            {"shipCrew",-1},
            {"basryxo",-1},
            {"bots",-1},
            {"happiness",-1},
            {"superGuardians",-1},
            {"systemDefense",-1},
            {"humidityGas",-1},
            {"harmony",-1},
            {"sistersOfMercy",-1},
            {"Metafolding",-1},
            {"catalyst",-1},
            {"random",-1},
            {"eyder",-1},
            {"academy",-1},
            {"  KEY  ",-1},
            {"industry",-1},
            {"science",-1},
            {"influenceUpkeepColored",-1},
            {"influenceupkeep",-1},
            {"lifeforce",-1},
            {"lifeforceUpkeep",-1},
            {"medal",-1},
            {"industrialist",-1},
            {"merchant",-1},
            {"pacifist",-1},
            {"ecologist",-1},
            {"militarist",-1},
            {"tradeEfficiency",-1},
            {"shield",-1},
            {"warPoint",-1},
            {"branch",-1},
            {"warExhaust",-1},
            {"honor",-1},
            {"obedience",-1},
            {"hackingSpeed",-1},
            {"relic",-1},
            {"infantry",-1},
            {"tank",-1},
            {"plane",-1},
            {"scavenger",-1},
            {"Adventurer",-1},
            {"Administrator",-1},
            {"Admiral",-1},
            {"Corporate",-1},
            {"Lux01Redsang",-1},
            {"Lux02Jadonyx",-1},
            {"Lux03Dustciduous",-1},
            {"Lux04Bluecap",-1},
            {"Lux09Hydromiel",-1},
            {"Lux10VoidStone",-1},
            {"Lux11ProtoOrchid",-1},
            {"Lux12IonicCristal",-1},
            {"Lux13GigaLattice",-1},
            {"Lux14LostCities",-1},
            {"Lux15Amianthoid",-1},
            {"Lux16Gossamer",-1},
            {"Lux17Mercurite",-1},
            {"Lux18EndlessFoundries",-1},
            {"Lux19DustWater",-1},
            {"Lux20ProtoSpores",-1},
            {"Lux21MetaEntactogen",-1},
            {"Lux22BenthicGems",-1},
            {"Lux23VirtualArtifacts",-1},
            {"Lux24Driftbuds",-1},
            {"Strat01titanium",-1},
            {"Strat02hyperium",-1},
            {"Strat03adamantian",-1},
            {"Strat04anti-matter",-1},
            {"Strat05orichalcix",-1},
            {"Strat06quadrinix",-1},
            {"defense",-1},
            {"Resource",-1},
            {"Type",-1},
            {"JB",-1},
            {"superColonizer",-1},
            {"bomber",-1},
            {"Tables",-1},
            //https://steamcommunity.com/sharedfiles/filedetails/?id=1413567299

            //Minor Factions

            //Luxuries

            //Strategics

            //System + Planets

            //Politics and FIDSI

            //Battle + Ship

            //Hero

            //Diplomacy

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
                var newValue = Regex.Replace(Value, "([a-z])([A-Z])", "$1 $2");
                newValue = Regex.Replace(newValue, "([a-z])([0-9])", "$1 $2");
                return $"{newValue}";
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
    }
    public static class UIHelper
    {
        public static T FindParent<T>(this DependencyObject child, bool debug = false) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            if (parentObject is T parent)
                return parent;
            else
                return FindParent<T>(parentObject);
        }
    }
    public class ItemDoubleClickBehavior : Behavior<ListBox>
    {
        #region Properties
        MouseButtonEventHandler Handler;
        #endregion

        #region Methods

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PreviewMouseDoubleClick += Handler = (s, e) =>
            {
                e.Handled = true;
                if (!(e.OriginalSource is DependencyObject source)) return;

                ListBoxItem sourceItem = source is ListBoxItem ? (ListBoxItem)source :
                    source.FindParent<ListBoxItem>();

                if (sourceItem == null) return;

                foreach (var binding in AssociatedObject.InputBindings.OfType<MouseBinding>())
                {
                    if (binding.MouseAction != MouseAction.LeftDoubleClick) continue;

                    ICommand command = binding.Command;
                    object parameter = binding.CommandParameter;

                    if (command.CanExecute(parameter))
                        command.Execute(parameter);
                }
            };
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewMouseDoubleClick -= Handler;
        }

        #endregion
    }
    public class SelectionBindingTextBox : TextBox
    {
        public static readonly DependencyProperty BindableSelectionStartProperty =
            DependencyProperty.Register(
            "BindableSelectionStart",
            typeof(int),
            typeof(SelectionBindingTextBox),
            new PropertyMetadata(OnBindableSelectionStartChanged));

        public static readonly DependencyProperty BindableSelectionLengthProperty =
            DependencyProperty.Register(
            "BindableSelectionLength",
            typeof(int),
            typeof(SelectionBindingTextBox),
            new PropertyMetadata(OnBindableSelectionLengthChanged));

        private bool changeFromUI;

        public SelectionBindingTextBox() : base()
        {
            this.SelectionChanged += this.OnSelectionChanged;
        }

        public int BindableSelectionStart
        {
            get
            {
                return (int)this.GetValue(BindableSelectionStartProperty);
            }

            set
            {
                this.SetValue(BindableSelectionStartProperty, value);
            }
        }

        public int BindableSelectionLength
        {
            get
            {
                return (int)this.GetValue(BindableSelectionLengthProperty);
            }

            set
            {
                this.SetValue(BindableSelectionLengthProperty, value);
            }
        }

        private static void OnBindableSelectionStartChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var textBox = dependencyObject as SelectionBindingTextBox;

            if (!textBox.changeFromUI)
            {
                int newValue = (int)args.NewValue;
                textBox.SelectionStart = newValue;
            }
            else
            {
                textBox.changeFromUI = false;
            }
        }

        private static void OnBindableSelectionLengthChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var textBox = dependencyObject as SelectionBindingTextBox;

            if (!textBox.changeFromUI)
            {
                int newValue = (int)args.NewValue;
                textBox.SelectionLength = newValue;
            }
            else
            {
                textBox.changeFromUI = false;
            }
        }

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (this.BindableSelectionStart != this.SelectionStart)
            {
                this.changeFromUI = true;
                this.BindableSelectionStart = this.SelectionStart;
            }

            if (this.BindableSelectionLength != this.SelectionLength)
            {
                this.changeFromUI = true;
                this.BindableSelectionLength = this.SelectionLength;
            }
        }
    }
}
