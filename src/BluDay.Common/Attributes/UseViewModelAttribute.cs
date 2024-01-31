namespace BluDay.Common.Attributes;

public sealed class UseViewModelAttribute<TViewModel> : Attribute where TViewModel : IViewModel
{
    public static Type TargetType { get; } = typeof(TViewModel);
}