using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage;

namespace BluDay.Common.Services
{
    public sealed class BluFilePickerService : BluService, IBluFilePickerService
    {
        public IReadOnlyList<string> AllowedFileTypes { get; }

        public BluFilePickerService(IBluCommonServices commonServices) : base(commonServices) { }

        public async Task<StorageFile> OpenFileAsync()
        {
            var picker = new FileOpenPicker();

            foreach (string fileType in AllowedFileTypes)
            {
                picker.FileTypeFilter.Add(fileType);
            }

            return await picker.PickSingleFileAsync();
        }

        public async Task<StorageFile> SaveFileAsync()
        {
            var picker = new FileSavePicker();

            // :)

            return await picker.PickSaveFileAsync();
        }
    }
}