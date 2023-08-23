using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace BluDay.Common.Services
{
    public interface IBluDialogService
    {
        Task<ContentDialogResult> ShowDialogAsync(
            string                      title,
            string                      content,
            (string, ICommand, object)? primaryButton,
            (string, ICommand, object)? secondaryButton,
            (string, ICommand, object)? closeButton
        );
    }
}