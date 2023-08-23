using BluDay.Common;
using BluDay.Common.DependencyInjection;
using BluDay.Common.Domain.ViewModels;
using System;
using System.Collections.Generic;

namespace BluDay.Common.ViewManagement
{
    public sealed class BluViewModelFactory
    {
        private readonly IBluServiceProvider _provider;

        private readonly Dictionary<Type, Func<IBluViewModel>> _factoriesMap =
            new Dictionary<Type, Func<IBluViewModel>>();

        public BluViewModelFactory(IBluServiceProvider provider)
        {
            _provider = provider;

            CreateFactories();
        }

        private void CreateFactories()
        {
            foreach (var viewModelType in BluReflector.GetDerivedConcreteClassTypes<IBluViewModel>())
            {
                // Create or "preload" and cache all factories.

                _factoriesMap.Add(viewModelType, () => new object() as IBluViewModel);
            }
        }

        public IBluViewModel Create(Type viewModelType)
        {
            BluValidator.ValidateViewModelType(viewModelType);

            if (_factoriesMap.TryGetValue(viewModelType, out Func<IBluViewModel> factory))
            {
                throw new ArgumentException(
                    $"Factory for view model type {viewModelType} was not found."
                );
            }

            return factory();
        }

        public TView Create<TView>() where TView : IBluViewModel
        {
            return (TView)Create(typeof(TView));
        }
    }
}