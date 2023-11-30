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
    public string IsAdult => isAdult(_date);

    private static string isAdult(DateTime date)
    {
        return date.AddYears(18) < DateTime.Now ? "Adult" : "Not adult";
    }
}