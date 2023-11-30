using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Watch.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    private string _time = DateTime.Now.ToString("HH:mm:ss");
    public string Time
    {
        get => _time;
        set => this.RaiseAndSetIfChanged(ref _time, value);
    }

    public MainWindowViewModel()
    {
        Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1))
            .Subscribe(_ => Time = DateTime.Now.ToString("HH:mm:ss"));
    }
}