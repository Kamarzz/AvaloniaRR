using ReactiveUI;

namespace Sum.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    private string _value1 = "0";
    private string _value2 = "0";

    private string _result = "";

    public string Value1
    {
        get => _value1;
        set
        {
            this.RaiseAndSetIfChanged(ref _value1, value); 
            this.RaisePropertyChanged(nameof(Result));
        }
    }

    public string Value2
    {
        get => _value2;
        set
        {
            this.RaiseAndSetIfChanged(ref _value2, value); 
            this.RaisePropertyChanged(nameof(Result));
        }
    }

    public string Result
    {
        get
        {
            int.TryParse(_value1, out int val1);
            int.TryParse(_value2, out int val2);
            return (val1 + val2).ToString();
        }
    }
}