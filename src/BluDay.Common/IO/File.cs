using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace BluDay.Common.IO
{
    public static class File
    {
        public static async Task<string> ReadFromAssemblyAsync(string relativePath)
        {
            BluValidator.NotWhitespace(relativePath, nameof(relativePath));

            var uri = new Uri(BluConstants.APP_RESOURCE_PATH_PREFIX + relativePath, UriKind.Absolute);

            if (!uri.IsWellFormedOriginalString())
            {
                return null;
            }

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(uri);

            return await System.IO.File.ReadAllTextAsync(file.Path);
        }

        public static string ReadFromAssembly(string relativePath)
        {
            var task = Task.Run(async () => await ReadFromAssemblyAsync(relativePath));

            task.Wait();

            return task.Result;
        }
    }
}