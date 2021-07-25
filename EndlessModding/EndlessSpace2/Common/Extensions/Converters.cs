using EndlessModding.EndlessSpace2.Common.Classes.HeroAffinityDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.HeroClassDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.HeroPoliticsDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EndlessModding.EndlessSpace2.Common.Converters
{//RuntimePlugin
    public class PluginToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            string output = value.ToString();

            if (value is RuntimePlugin)
            {
                if (value is AIPlugin)
                {
                    var tmp = (AIPlugin)value;
                    output = "Unsuported AI Plugin";
                }
                if (value is DatabasePlugin)
                {
                    var tmp = (DatabasePlugin)value;
                    output = tmp.DataType + " " + tmp.FilePath;
                }
                if (value is LocalizationPlugin)
                {
                    var tmp = (LocalizationPlugin)value;
                    output = "Unsuported Localization Plugin";
                }
                if (value is RegistryPlugin)
                {
                    var tmp = (RegistryPlugin)value;
                    output = "Unsuported Registry Plugin";
                }
                else
                    output = "Generic Runtime Plugin";
            }

            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception();
        }
    }
    public class StringArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            string output = value.ToString();

            if (value is string[])
            {
                var tmp = (string[])value;
                output = string.Join(", ", tmp);
            }

            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception();
        }
    }
    public class HeroAffinityDefinitionToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            string output = value.ToString();

            if (value is HeroAffinityDefinition)
            {
                var tmp = (HeroAffinityDefinition)value;
                output = tmp.Name.Replace("HeroAffinity", "");
            }
            else if (value is Classes.HeroDefinition.XmlNamedReference)
            {
                var tmp = (Classes.HeroDefinition.XmlNamedReference)value;
                output = tmp.Name.Replace("HeroAffinity", "");
            }

            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception();
        }
    }
    public class HeroClassDefinitionToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            string output = value.ToString();

            if (value is HeroClassDefinition)
            {
                var tmp = (HeroClassDefinition)value;
                output = tmp.Name.Replace("HeroClass", "");
            }
            else if (value is Classes.HeroDefinition.XmlNamedReference)
            {
                var tmp = (Classes.HeroDefinition.XmlNamedReference)value;
                output = tmp.Name.Replace("HeroClass", "");
            }

            return output;
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception();
        }
    }
    public class ShipDesignDefinitionToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            string output = value.ToString();

            if (value is HeroClassDefinition)
            {
                var tmp = (HeroClassDefinition)value;
                output = tmp.Name;
            }
            else if (value is Classes.HeroDefinition.XmlNamedReference)
            {
                var tmp = (Classes.HeroDefinition.XmlNamedReference)value;
                output = tmp.Name;
            }

            return output;
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception();
        }
    }
    public class HeroPoliticsDefinitionToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            string output = value.ToString();

            if (value is HeroPoliticsDefinition)
            {
                var tmp = (HeroPoliticsDefinition)value;
                switch (tmp.Politics)
                {
                    case "HeroPolitics01":
                        output = "Industrialist";
                        break;
                    case "HeroPolitics02":
                        output = "Scientists";
                        break;
                    case "HeroPolitics03":
                        output = "Pacifists";
                        break;
                    case "HeroPolitics04":
                        output = "Ecologists";
                        break;
                    case "HeroPolitics05":
                        output = "Religious";
                        break;
                    case "HeroPolitics06":
                        output = "Militarist";
                        break;
                    default:
                        break;
                }
            }
            else if (value is Classes.HeroDefinition.XmlNamedReference)
            {
                if (value == null)
                {
                    return string.Empty;
                }
                var tmp = (Classes.HeroDefinition.XmlNamedReference)value;
                switch (tmp.Name)
                {
                    case "HeroPolitics01":
                        output = "Industrialist";
                        break;
                    case "HeroPolitics02":
                        output = "Scientists";
                        break;
                    case "HeroPolitics03":
                        output = "Pacifists";
                        break;
                    case "HeroPolitics04":
                        output = "Ecologists";
                        break;
                    case "HeroPolitics05":
                        output = "Religious";
                        break;
                    case "HeroPolitics06":
                        output = "Militarist";
                        break;
                    default:
                        break;
                }
            }

            return output;
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception();
        }
    }
}
