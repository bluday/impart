using BluDay.Common.IO;
using System.Windows.Input;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace BluDay.Common.UI.Xaml.Controls
{
    public sealed partial class BluChatInputBox : UserControl
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(BluChatInputBox),
                new PropertyMetadata(null)
            );

        public static readonly DependencyProperty AttachCommandProperty =
            DependencyProperty.Register(
                "AttachCommand",
                typeof(ICommand),
                typeof(BluChatInputBox),
                new PropertyMetadata(null)
            );

        public static readonly DependencyProperty SendCommandProperty =
            DependencyProperty.Register(
                "SendCommand",
                typeof(ICommand),
                typeof(BluChatInputBox),
                new PropertyMetadata(null)
            );

        public string Text
        {
            get => GetValue(TextProperty) as string;
            set => SetValue(TextProperty, value);
        }

        public ICommand AttachCommand
        {
            get => GetValue(AttachCommandProperty) as ICommand;
            set => SetValue(AttachCommandProperty, value);
        }

        public ICommand SendCommand
        {
            get => GetValue(SendCommandProperty) as ICommand;
            set => SetValue(SendCommandProperty, value);
        }

        public BluChatInputBox() => InitializeComponent();

        private void TextBox_GettingFocus(UIElement sender, GettingFocusEventArgs args)
        {
            (sender as Control).Height = double.NaN;
        }

        private void TextBox_LosingFocus(UIElement sender, LosingFocusEventArgs args)
        {
            var textBox = sender as Control;

            textBox.Height = textBox.MinHeight;
        }

        private void TextBox_KeyUp(object sender, KeyRoutedEventArgs args)
        {
            args.Handled = Keyboard.IsShiftDown || args.Key != VirtualKey.Enter;
        }

        private void TextBox_PreviewKeyDown(object sender, KeyRoutedEventArgs args)
        {
            args.Handled = !Keyboard.IsShiftDown && args.Key == VirtualKey.Enter;
        }
    }
}