namespace BluDay.Impart.Services
{
    public interface IImpartSampleDataService
    {
        int CurrentUserIndex { get; }

        Models.UserModel CurrentUser { get; }

        System.Threading.Tasks.Task<bool> LoadAsync(int userIndex);
    }
}