using BluDay.Common.Types;
using BluDay.Common.ViewManagement;

namespace BluDay.Common.Services
{
    public interface IBluViewRegistryService
    {
        BluViewInfo DefaultViewInfo { get; }

        System.Collections.Generic.IReadOnlyList<BluViewInfo> ViewInfos { get; }

        void EstablishHierarchies(BluHierarchySection<string>[] sections);

        void SetDefaultView(object viewPropertyValue);

        BluViewInfo GetViewInfoByPropertyValue(object value);
    }
}