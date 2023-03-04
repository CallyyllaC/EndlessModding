using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using EndlessModding.Keyboard;
using Microsoft.Xaml.Behaviors;

namespace EndlessModding.Common
{
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
}