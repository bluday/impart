namespace BluDay.Common.Domain.ViewModels
{
    public interface IBluViewModel : Types.IBluDisposable
    {
        System.Windows.Input.ICommand NavigateCommand { get; }
    }
}