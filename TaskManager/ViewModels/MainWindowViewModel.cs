using System;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace AvaloniaApplication1.ViewModels;

public class MainWindowViewModel : ViewModelBase
{


    public ObservableCollection<Task> Tasks { get; } = new ObservableCollection<Task>();

    public MainWindowViewModel()
    {
        Tasks.Add(new Task(){TaskDescr = "1"});
        Tasks.Add(new Task(){TaskDescr = "243jr432"});
        Tasks.Add(new Task(){TaskDescr = "cds"});
    }
}


public class Task : ViewModelBase
{
    private string? _taskDescr;
    public string? TaskDescr
    {
        get => _taskDescr;
        set => this.RaiseAndSetIfChanged(ref _taskDescr, value);
    }
}