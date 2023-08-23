using System;

namespace BluDay.Common.ViewManagement
{
    public sealed class BluViewInfo
    {
        private readonly BluView _viewInfo;

        public string Name => _viewInfo.Name;

        public Guid Id => _viewInfo.Id;

        public Type ViewType => _viewInfo.ViewType;

        public Type ViewModelType => _viewInfo.ViewModelType;

        public BluViewInfo(BluView viewInfo)
        {
            BluValidator.NotNull(viewInfo, nameof(viewInfo));

            _viewInfo = viewInfo;
        }
    }
}