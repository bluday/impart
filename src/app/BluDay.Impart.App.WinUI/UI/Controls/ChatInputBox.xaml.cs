using Microsoft.UI.Xaml.Input;
using System.Windows.Input;

namespace BluDay.Impart.App.WinUI.UI.Controls;

public sealed partial class ChatInputBox : UserControl
{
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(ChatInputBox),
            new PropertyMetadata(defaultValue: null)
        );

    public static readonly DependencyProperty AttachCommandProperty =
        DependencyProperty.Register(
            nameof(AttachCommand),
            typeof(ICommand),
            typeof(ChatInputBox),
            new PropertyMetadata(defaultValue: null)
        );

    public static readonly DependencyProperty SendCommandProperty =
        DependencyProperty.Register(
            nameof(SendCommand),
            typeof(ICommand),
            typeof(ChatInputBox),
            new PropertyMetadata(defaultValue: null)
        );

    public string? Text
    {
        get => GetValue(TextProperty) as string;
        set => SetValue(TextProperty, value);
    }

    public ICommand? AttachCommand
    {
        get => GetValue(AttachCommandProperty) as ICommand;
        set => SetValue(AttachCommandProperty, value);
    }

    public ICommand? SendCommand
    {
        get => GetValue(SendCommandProperty) as ICommand;
        set => SetValue(SendCommandProperty, value);
    }

    public ChatInputBox() => InitializeComponent();

    private void TextBox_GettingFocus(UIElement sender, GettingFocusEventArgs args)
    {
        ((Control)sender).Height = double.NaN;
    }

    private void TextBox_LosingFocus(UIElement sender, LosingFocusEventArgs args)
    {
        var textBox = (Control)sender;

        textBox.Height = textBox.MinHeight;
    }

    private void TextBox_KeyUp(object sender, KeyRoutedEventArgs args)
    {
        // args.Handled = InputHelper.IsShiftDown || args.Key != VirtualKey.Enter;
    }

    private void TextBox_PreviewKeyDown(object sender, KeyRoutedEventArgs args)
    {
        // args.Handled = !InputHelper.IsShiftDown && args.Key == VirtualKey.Enter;
    }
}