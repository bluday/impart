namespace BluDay.Impart.ViewModels
{
    public sealed class SetupViewModel : Common.Domain.ViewModels.ViewModel
    {
        private string _username;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public SetupViewModel(Common.Services.IBluCommonServices commonServices)
            : base(commonServices) { }
    }
}