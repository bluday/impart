using BluDay.Common.Types;
using BluDay.Common.ViewManagement;
using BluDay.Common.Extensions;
using System;
using System.Collections.Generic;

namespace BluDay.Common.Services
{
    public class BluViewRegistryService : BluService, IBluViewRegistryService
    {
        private readonly List<BluView> _views = new List<BluView>();

        private BluView _defaultView;

        public BluViewInfo DefaultViewInfo => _defaultView?.Info;

        public IReadOnlyList<BluViewInfo> ViewInfos { get; private set; }

        public BluViewRegistryService(IBluCommonServices commonServices) : base(commonServices)
        {
            RegisterViews();
        }

        private void RegisterViews()
        {
            foreach (var viewType in BluReflector.GetDerivedConcreteClassTypes<UI.IBluView>())
            {
                _views.Add(new BluView(viewType));
            }

            ViewInfos = _views.BluSelect(view => view.Info);

            Logger.LogSuccess(
                message: "Views registered:",
                content: _views.BluToPrintableValue()
            );
        }

        private BluView GetViewByPropertyValue(object value)
        {
            return _views.BluFirst(BluView.GetPredicateByPropertyValue(value));
        }

        public void EstablishHierarchies(BluHierarchySection<string>[] sections)
        {
            BluValidator.NotNull(sections, nameof(sections));

            foreach (var section in sections)
            {
                var view = GetViewByPropertyValue(section.Parent);

                if (view is null) continue;

                view.Children = section.Children.BluSelect(GetViewByPropertyValue);
            }
        }

        public void SetDefaultView(object viewPropertyValue)
        {
            var view = GetViewByPropertyValue(viewPropertyValue);

            if (view is null)
            {
                throw new InvalidOperationException(
                    $"View with property value {viewPropertyValue} was not found."
                );
            }

            _defaultView = view;

            Logger.LogInfo($"Default view: {view?.Name ?? BluConstants.None}");
        }

        public BluViewInfo GetViewInfoByPropertyValue(object value)
        {
            return _views.BluFirst(BluView.GetPredicateByPropertyValue(value))?.Info;
        }
    }
}