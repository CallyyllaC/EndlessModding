using EndlessModding.EndlessSpace2.Common.Classes.HeroAffinityDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.HeroClassDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.HeroPoliticsDefinitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime;
using EndlessModding.EndlessSpace2.SimulationModifierDescriptors;
using SteamKit2.Internal;

namespace EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime
{
    public interface IExportable
    {
        [XmlIgnore]
        bool Enabled { get; set; }
        [XmlIgnore]
        string Type { get; set; }
    }
    public partial class RuntimeModule : INotifyPropertyChanged
    {
        [NonSerialized(), XmlIgnore]
        public WriteableBitmap Image = null;

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    public partial class RuntimePlugin : INotifyPropertyChanged
    {
        [XmlIgnore]
        public bool Enabled { get; set; } = true;
        [XmlIgnore]
        public bool Details
        {
            get => _details;
            set
            {
                _details = value;
                RaisePropertyChanged();
                RaisePropertyChanged("ExtraContents");
                RaisePropertyChanged("Contents");
                RaisePropertyChanged("ExtraTypesString");
            }
        }
        [XmlIgnore]
        public string Type { get; set; }
        [XmlIgnore]
        public string ExtraTypesString
        {
            get
            {
                if (!Details)
                {
                    return _extraTypesString.Substring(0, 7) + "...";
                }
                else
                {
                    return _extraTypesString;
                }
            }
            set
            {
                _extraContents = value;
                RaisePropertyChanged();
            }

        }
        [XmlIgnore]
        public string Contents
        {
            get
            {
                if (!Details)
                {
                    return _contents.Substring(0, 7) + "...";
                }
                else
                {
                    return _contents;
                }
            }
            set
            {
                _contents = value;
                RaisePropertyChanged();
            }

        }
        [XmlIgnore]
        public string ExtraContents
        {
            get
            {
                if (!Details)
                {
                    return _extraContents.Substring(0, 7) + "...";
                }
                else
                {
                    return _extraContents;
                }
            }
            set
            {
                _extraContents = value;
                RaisePropertyChanged();
            }

        }


        [NonSerialized(), XmlIgnore]
        private string _extraContents = "";
        [NonSerialized(), XmlIgnore]
        private string _contents = "";
        [NonSerialized(), XmlIgnore]
        private string _extraTypesString = "";
        [NonSerialized(), XmlIgnore]
        private bool _details;



        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    public partial class Tags
    {
        public override string ToString()
        {
            return Value;
        }
    }
}

namespace EndlessModding.EndlessSpace2.Common.Classes.HeroSkillDefinition
{
    public partial class HeroSkillDefinition : INotifyPropertyChanged, IExportable
    {
        [XmlIgnore]
        public bool Custom { get; set; } = false;
        [XmlIgnore]
        public bool Enabled { get; set; } = false;

        [XmlIgnore]
        public int LevelCount
        {
            get
            {
                return SkillLevel.Length;
            }
        }

        [XmlIgnore]
        public string Type { get; set; } = "HeroSkill";

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;


        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

namespace EndlessModding.EndlessSpace2.Common.Classes.HeroDefinition
{
    public partial class HeroDefinition : INotifyPropertyChanged, IExportable
    {
        [NonSerialized(), XmlIgnore]
        public WriteableBitmap MoodImage = null;
        [NonSerialized(), XmlIgnore]
        public WriteableBitmap LargeImage = null;
        [NonSerialized(), XmlIgnore]
        public WriteableBitmap MediumImage = null;
        [NonSerialized(), XmlIgnore]
        public string Description;
        [NonSerialized(), XmlIgnore]
        public string RealName;
        [NonSerialized(), XmlIgnore]
        public string ModelPath;
        [XmlIgnore]
        public bool Custom { get; set; } = false;
        [XmlIgnore]
        public bool Enabled { get; set; } = false;

        [XmlIgnore]
        public string Type { get; set; } = "Hero";

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;


        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    public partial class XmlNamedReference : IComparable
    {
        public override string ToString()
        {
            return Name.Replace("HeroAffinity", "");
        }

        public int CompareTo(object obj)
        {
            return String.Compare(this.ToString(), obj.ToString(), StringComparison.OrdinalIgnoreCase);
        }
    }
}

namespace EndlessModding.EndlessSpace2.Common.Classes.HeroAffinityDefinitions
{
    public partial class HeroAffinityDefinition
    {
        public override string ToString()
        {
            return Name.Replace("HeroAffinity", "");
        }
    }
}

namespace EndlessModding.EndlessSpace2.Common.Classes.HeroClassDefinitions
{
    public partial class HeroClassDefinition
    {
        public override string ToString()
        {
            return Name.Replace("HeroClass", "");
        }
    }
    public partial class XmlNamedReference
    {

    }

}

namespace EndlessModding.EndlessSpace2.Common.Classes.ShipDesignDefinitions
{
    public partial class ShipDesignDefinition
    {
        public override string ToString()
        {
            return Name;
        }
    }
    public partial class XmlNamedReference
    {
        public override string ToString()
        {
            return Name;
        }
    }

}

namespace EndlessModding.EndlessSpace2.Common.Classes.HeroPoliticsDefinitions
{
    public partial class HeroPoliticsDefinition
    {
        public override string ToString()
        {
            string output = "Error Converting";
            switch (Politics)
            {
                case "Politics01":
                    output = "Industrialist";
                    break;
                case "Politics02":
                    output = "Scientists";
                    break;
                case "Politics03":
                    output = "Pacifists";
                    break;
                case "Politics04":
                    output = "Ecologists";
                    break;
                case "Politics05":
                    output = "Religious";
                    break;
                case "Politics06":
                    output = "Militarist";
                    break;
                default:
                    break;
            }
            return output;
        }
    }
    public partial class XmlNamedReference
    {
        public override string ToString()
        {
            return Name;
        }
    }
}

namespace EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Simulator
{
    public partial class SimulationDescriptor
    {
        [XmlIgnore]
        public bool Custom { get; set; } = false;
        public override string ToString()
        {
            return $"{this.Custom} {this.Name} Items:{this.Items?.Length} Items1:{this.Items1?.Length}";
        }
    }
    public partial class SimulationPropertyDescriptor
    {
        [XmlIgnore]
        public bool Custom { get; set; } = false;

        [XmlIgnore]
        private bool _proportional = false;

        [XmlIgnore]
        public bool Proportional
        {
            get
            {
                if (this is SimulationPropertyDescriptor_Proportional)
                {
                    return true;
                }

                return false;
            }
            private set => _proportional = value;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public partial class SimulationPropertyDescriptor_Proportional
    {
        public override string ToString()
        {
            return Name;
        }
    }
    public partial class SimulationModifierDescriptor
    {
        [XmlIgnore]
        public string Name = "null";

        [XmlIgnore]
        public bool Custom { get; set; } = false;

        private string GetName()
        {
            string output = $"Unknown: {TargetProperty} {Operation}";

            if (Custom)
            {
                output = "C: " + output;
            }

            return output;
        }

        public override string ToString()
        {
            Name = GetName();
            return Name;
        }
    }
    public partial class BinarySimulationModifierDescriptor
    {
        [XmlIgnore]
        public ModifierEnum ModifierType { get; } = ModifierEnum.Binary;
        private string GetName()
        {
            string output = $"Binary: {TargetProperty} {Operation} {BinaryOperation}";

            if (Custom)
            {
                output = "C: " + output;
            }

            return output;
        }

        public override string ToString()
        {
            Name = GetName();
            return Name;
        }
    }
    public partial class CountSimulationModifierDescriptor
    {
        [XmlIgnore]
        public ModifierEnum ModifierType { get; } = ModifierEnum.Count;
        private string GetName()
        {
            string output = $"Count: {TargetProperty} {Operation} {Multiplier}";

            if (Custom)
            {
                output = "C: " + output;
            }

            return output;
        }

        public override string ToString()
        {
            Name = GetName();
            return Name;
        }
    }
    public partial class SingleSimulationModifierDescriptor
    {
        [XmlIgnore]
        public new string Name = null;
        [XmlIgnore]
        public ModifierEnum ModifierType { get; } = ModifierEnum.Single;
        private string GetName()
        {
            string output = $"Single: {TargetProperty} {Operation} {Value}";

            if (Custom)
            {
                output = "C: " + output;
            }

            return output;
        }

        public override string ToString()
        {
            Name = GetName();
            return Name;
        }
    }
}
