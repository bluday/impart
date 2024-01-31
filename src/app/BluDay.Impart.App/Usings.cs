global using BluDay.Common.Domain.Models;
global using BluDay.Common.Domain.ViewModels;
global using BluDay.Common.Extensions;
global using BluDay.Impart.App.Core.Domain.Models;
global using BluDay.Impart.App.Core.Domain.ViewModels;
global using BluDay.Impart.App.UI.Interactions;
global using BluDay.Impart.App.UI.Navigation;
global using BluDay.Impart.App.UI.WindowManagement;
global using CommunityToolkit.Mvvm.ComponentModel;
global using System.ComponentModel.DataAnnotations;

global using IViewModelProvider = BluDay.Common.Extensions.DependencyInjection.IImplementationProvider<BluDay.Common.Domain.ViewModels.IViewModel>;

global using ViewModelProvider = BluDay.Common.Extensions.DependencyInjection.ImplementationProvider<BluDay.Common.Domain.ViewModels.IViewModel>;