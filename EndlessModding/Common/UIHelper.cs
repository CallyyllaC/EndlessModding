using System.Windows;
using System.Windows.Media;

namespace EndlessModding.Common
{
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
}