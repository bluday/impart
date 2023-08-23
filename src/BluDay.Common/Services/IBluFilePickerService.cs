using System.Threading.Tasks;
using Windows.Storage;

namespace BluDay.Common.Services
{
    public interface IBluFilePickerService
    {
        System.Collections.Generic.IReadOnlyList<string> AllowedFileTypes { get; }

        Task<StorageFile> OpenFileAsync();

        Task<StorageFile> SaveFileAsync();
    }
}