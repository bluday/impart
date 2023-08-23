namespace BluDay.Impart.ViewModels
{
    public sealed class ShellViewModel : Common.Domain.ViewModels.ViewModel
    {
        private string _title;

        public string Title
        {
            get         => _title;
            private set => SetProperty(ref _title, value);
        }
    }
}