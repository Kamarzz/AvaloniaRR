using System;
using Avalonia.Media.TextFormatting.Unicode;
using ReactiveUI;

namespace FirstNonEqualSymbol.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _text1 = "";
    private string _text2 = "";
    private string _result = "";

    public string Text1
    {
        get => _text1;
        set
        {
            this.RaiseAndSetIfChanged(ref _text1, value);
            this.RaisePropertyChanged(nameof(Result));
        }
    }

    public string Text2
    {
        get => _text2;
        set
        {
            this.RaiseAndSetIfChanged(ref _text2, value);
            this.RaisePropertyChanged(nameof(Result));
        } 
    }
    
    public string Result => firstMatchSymbol(_text1, _text2);

    private string firstMatchSymbol(String text1, String text2)
    {
        int len = text1.Length > text2.Length ? text1.Length : text2.Length;
        for (int i = 0; i < len; i++)
        {
            if (text1[i].Equals(text2[i]))
            {
                return text1[i].ToString();
            }
        }

        return "";
    }
}