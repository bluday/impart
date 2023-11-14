using BluDay.Common.Extensions;
using BluDay.Common.Services;
using BluDay.Impart.Events;

namespace BluDay.Impart.Services
{
    public class ImpartUserService : BluService, IImpartUserService
    {
        private Models.UserModel _currentUser;

        public Models.UserModel CurrentUser
        {
            get => _currentUser;
            private set
            {
                Notify(new CurrentUserUpdatingEvent(value));

                _currentUser = value;

                Notify(new CurrentUserUpdatedEvent(value));

                Logger.LogDebug("Sample user set.");
            }
        }

        public ImpartUserService(IBluCommonServices commonServices) : base(commonServices) { }

        private void OnSampleUserLoaded(SampleUserLoadedEvent e)
        {
            CurrentUser = e.User;
        }

        protected override void ConfigureSubscriptions()
        {
            Subscribe<SampleUserLoadedEvent>(OnSampleUserLoaded);
        }
    }
}