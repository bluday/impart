using BluDay.Common.UI;
using BluDay.Common.DependencyInjection;
using System;
using System.Collections.Generic;

namespace BluDay.Common.ViewManagement
{
    public sealed class BluViewFactory
    {
        private readonly IBluServiceProvider _provider;

        private readonly Dictionary<Type, Func<IBluView>> _factoriesMap =
            new Dictionary<Type, Func<IBluView>>();

        public BluViewFactory(IBluServiceProvider provider)
        {
            _provider = provider;

            CreateFactories();
        }

        private void CreateFactories()
        {
            foreach (var viewType in BluReflector.GetDerivedConcreteClassTypes<IBluView>())
            {
                // Create or "preload" and cache all factories.

                _factoriesMap.Add(viewType, () => new object() as IBluView);
            }
        }

        public IBluView Create(Type viewType)
        {
            BluValidator.ValidateViewType(viewType);

            if (_factoriesMap.TryGetValue(viewType, out Func<IBluView> factory))
            {
                throw new ArgumentException($"Factory for view type {viewType} was not found.");
            }

            return factory();
        }

        public TView Create<TView>() where TView : IBluView
        {
            return (TView)Create(typeof(TView));
        }
    }
}