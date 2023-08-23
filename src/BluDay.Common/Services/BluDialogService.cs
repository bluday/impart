using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace BluDay.Common.Services
{
    public sealed class BluDialogService : Service, IBluDialogService
    {
        public BluDialogService(IBluCommonServices commonServices) : base(commonServices) { }

        public async Task<ContentDialogResult> ShowDialogAsync(
            string                      title,
            string                      content,
            (string, ICommand, object)? primaryButton,
            (string, ICommand, object)? secondaryButton,
            (string, ICommand, object)? closeButton)
        {
            var dialog = new ContentDialog
            {
                Title   = title,
                Content = content
            };

            if (!(primaryButton is null))
            {
                var (label, command, parameter) = primaryButton.Value;

                dialog.PrimaryButtonText = label;

                dialog.DefaultButton = ContentDialogButton.Primary;

                if (!(command is null))
                {
                    dialog.PrimaryButtonCommand = command;
                }

                if (!(parameter is null))
                {
                    dialog.PrimaryButtonCommandParameter = parameter;
                }
            }

            if (!(secondaryButton is null))
            {
                var (label, command, parameter) = secondaryButton.Value;

                dialog.SecondaryButtonText = label;

                if (!(command is null))
                {
                    dialog.SecondaryButtonCommand = command;
                }

                if (!(parameter is null))
                {
                    dialog.SecondaryButtonCommandParameter = parameter;
                }
            }

            if (!(closeButton is null))
            {
                var (label, command, parameter) = closeButton.Value;

                dialog.CloseButtonText = label;

                if (!(command is null))
                {
                    dialog.CloseButtonCommand = command;
                }

                if (!(parameter is null))
                {
                    dialog.CloseButtonCommandParameter = parameter;
                }
            }

            return await dialog.ShowAsync();
        }
    }
}