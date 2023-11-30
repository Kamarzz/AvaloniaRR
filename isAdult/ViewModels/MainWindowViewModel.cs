using System;
using ReactiveUI;

namespace isAdult.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    
    private DateTime _date = DateTime.Today;
    public DateTime Date
    {
        get => _date;
        set
        {
            this.RaiseAndSetIfChanged(ref _date, value);
        }
    }

    private string _isAdult;

    public string IsAdult
    {
        get => _isAdult;
        set => this.RaiseAndSetIfChanged(ref _isAdult, value);
    }

    public string isAdultFunc(DateTime date)
    {
        return date.AddYears(18) < DateTime.Now ? "Adult" : "Not adult";
    }
}