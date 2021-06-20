using Castle.Core.Logging;
using EndlessModding.Common;
using EndlessModding.Common.Import;
using EndlessModding.EndlessSpace2.Common.Classes.HeroAffinityDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.HeroClassDefinition;
using EndlessModding.EndlessSpace2.Common.Classes.HeroDefinition;
using EndlessModding.EndlessSpace2.Common.Classes.HeroPoliticsDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.ShipDesignDefinitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EndlessModding.EndlessSpace2.Hero
{
    public class HeroViewModel
    {
        //Public View Models
        public EndlessSpace2ViewModel MainWindow { get; set; }
        //properties
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }
        public bool Hidden
        {
            get => _hidden;
            set
            {
                _hidden = value;
                RaisePropertyChanged();
            }
        }
        public string Affinity
        {
            get => _affinity;
            set
            {
                _affinity = value;
                RaisePropertyChanged();
            }
        }
        public string Class
        {
            get => _class;
            set
            {
                _class = value;
                RaisePropertyChanged();
            }
        }
        public string Politic
        {
            get => _politics;
            set
            {
                _politics = value;
                RaisePropertyChanged();
            }
        }
        public string Ship
        {
            get => _ship;
            set
            {
                _ship = value;
                RaisePropertyChanged();
            }
        }
        public string StartingFaction
        {
            get => _startingFaction;
            set
            {
                _startingFaction = value;
                RaisePropertyChanged();
            }
        }
        public BindingList<HeroDefinition> Heros { get; set; }
        public BindingList<HeroAffinityDefinition> Affinities { get; set; }
        public BindingList<HeroClassDefinition> Classes { get; set; }
        public BindingList<HeroPoliticsDefinition> Politics { get; set; }
        public BindingList<ShipDesignDefinition> Ships { get; set; }
        public BindingList<Common.Classes.MajorFactions.MajorFaction> Factions { get; set; }
        public BindingList<Common.Classes.HeroSkillDefinition.HeroSkillDefinition> Skills { get; set; }
        public BindingList<Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition> SkillTrees { get; set; }
        //fields
        private readonly ILogger _logger;
        private Import _import;
        private string _name;
        private bool _hidden;
        private string _affinity;
        private string _class;
        private string _politics;
        private string _ship;
        private string _startingFaction;

        public HeroViewModel(ILogger Logger, Import import)
        {
            _logger = Logger;
            _import = import;
            Heros = _import.HeroDefinitions;
            Affinities = _import.HeroAffinityDefinitions;
            Classes = _import.HeroClassDefinitions;
            Politics = _import.HeroPoliticsDefinitions;
            Ships = _import.ShipDesignDefinitions;
            Factions = _import.MajorFactions;
            Skills = _import.HeroSkillDefinitions;
            SkillTrees = _import.HeroSkillTreeDefinitions;

            RaisePropertyChanged();
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
        #endregion
    }
}
