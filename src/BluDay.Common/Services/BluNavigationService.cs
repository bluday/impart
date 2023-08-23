using BluDay.Common.Events;
using BluDay.Common.Extensions;
using BluDay.Common.Navigation;
using BluDay.Common.UI.Xaml.Controls;
using BluDay.Common.ViewManagement;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace BluDay.Common.Services
{
    public sealed class BluNavigationService : Service, IBluNavigationService
    {
        private readonly Dictionary<BluViewInfo, BluNavigationContext> _contextsMap =
            new Dictionary<BluViewInfo, BluNavigationContext>();

        private BluNavigationContext _currentContext;

        private BluViewInfo _defaultView;

        private BluShell Shell => Window.Current?.Content as BluShell;

        public bool CanGoBack { get; private set; }

        public bool CanGoForward { get; private set; }

        public bool PreloadContexts { get; }

        public IReadOnlyList<Type> CurrentViewStack { get; }

        public BluNavigationService(IBluCommonServices commonServices) : base(commonServices) { }

        private void OnDefaultViewNavigationRequest(DefaultViewNavigationRequestEvent e)
        {
            Navigate(_defaultView);
        }

        private void OnDefaultViewUpdate(DefaultViewUpdateEvent e)
        {
            _defaultView = e.View;
        }

        private void OnNavigationRequest(NavigationRequestEvent e)
        {
            Navigate(e.ViewPropertyValue);
        }

        protected override void ConfigureSubscriptions()
        {
            Subscribe<DefaultViewNavigationRequestEvent>(OnDefaultViewNavigationRequest);
            Subscribe<DefaultViewUpdateEvent>(OnDefaultViewUpdate);
            Subscribe<NavigationRequestEvent>(OnNavigationRequest);
        }

        public bool GoBack() => throw new NotImplementedException();

        public bool GoForward() => throw new NotImplementedException();

        public bool Navigate(BluViewInfo view)
        {
            if (view is null) return false;

            Logger.LogDebug(view);

            // ( 0 _ o )

            return true;
        }

        public bool Navigate(object viewPropertyValue)
        {
            // ( 0 _ o )

            return false;
        }

        public bool Navigate<TViewPropertyValue>()
        {
            return Navigate(typeof(TViewPropertyValue));
        }
    }
}