using BluDay.Common.Events;
using System;
using System.Collections.Generic;

namespace BluDay.Common.Services
{
    public sealed class BluViewResolverService : Service, IBluViewResolverService
    {
        private readonly Dictionary<Type, Func<UI.IBluView>> _resolvers =
            new Dictionary<Type, Func<UI.IBluView>>();

        public IReadOnlyCollection<Type> ResolvableViewTypes => _resolvers.Keys;

        public BluViewResolverService(IBluCommonServices commonServices) : base(commonServices) { }

        private void OnViewRegistered(ViewRegisteredEvent e) { }

        private void OnViewResolutionRequest(ViewResolutionRequestEvent e) { }

        protected override void ConfigureSubscriptions()
        {
            Subscribe<ViewResolutionRequestEvent>(OnViewResolutionRequest);
            Subscribe<ViewRegisteredEvent>(OnViewRegistered);
        }
    }
}