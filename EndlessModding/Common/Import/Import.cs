using Castle.Core.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EndlessModding.Common.Import
{
    public static class Import
    {
        public static WriteableBitmap LoadImage(string filename)
        {
            BitmapSource img = new BitmapImage(new Uri(filename, UriKind.Absolute));
            return new WriteableBitmap(img);
        }

        public static ObservableConcurrentCollection<object> CreateGenericList(Type typeInList)
        {
            var genericListType = typeof(ObservableConcurrentCollection<>).MakeGenericType(new[] { typeInList });
            return (ObservableConcurrentCollection<object>)Activator.CreateInstance(genericListType);
        }
    }
}
