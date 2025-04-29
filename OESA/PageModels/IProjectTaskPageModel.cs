using CommunityToolkit.Mvvm.Input;
using OESA.Models;

namespace OESA.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}