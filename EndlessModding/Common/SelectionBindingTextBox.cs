﻿using System.Windows;
using System.Windows.Controls;

namespace EndlessModding.Common
{
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