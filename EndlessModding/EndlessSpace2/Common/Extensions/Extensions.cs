using EndlessModding.EndlessSpace2.Common.Classes.HeroAffinityDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.HeroClassDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.HeroPoliticsDefinitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
namespace EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime
{
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
        public string Type { get; set; }
        [XmlIgnore]
        public string ExtraTypes { get; set; }
        [XmlIgnore]
        public string Contents { get; set; }
        [XmlIgnore]
        public string ExtraContents { get; set; }

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
namespace EndlessModding.EndlessSpace2.Common.Classes.HeroDefinition
{
    public partial class HeroDefinition : INotifyPropertyChanged
    {
        [NonSerialized(), XmlIgnore]
        public WriteableBitmap MoodImage = null;
        [NonSerialized(), XmlIgnore]
        public WriteableBitmap LargeImage = null;
        [NonSerialized(), XmlIgnore]
        public WriteableBitmap MediumImage = null;
        [NonSerialized(), XmlIgnore]
        public bool Custom = false;

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;


        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
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
    public partial class XmlNamedReference
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
