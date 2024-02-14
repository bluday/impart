global using BluDay.Common.Parsing;
global using BluDay.Common.Infrastructure.Models;
global using BluDay.Common.Infrastructure.ViewModels;
global using BluDay.Common.Services;
global using BluDay.Common.UI;
global using BluDay.Common.UI.Navigation;
global using BluDay.Common.UI.WindowManagement;
global using BluDay.Impart.App.Domain.Models;
global using BluDay.Impart.App.Domain.ViewModels;
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Messaging;
global using System.ComponentModel.DataAnnotations;

global using IViewModelProvider = BluDay.Common.Extensions.DependencyInjection.IImplementationProvider<BluDay.Common.Infrastructure.ViewModels.IViewModel>;

global using ViewModelProvider = BluDay.Common.Extensions.DependencyInjection.ImplementationProvider<BluDay.Common.Infrastructure.ViewModels.IViewModel>;