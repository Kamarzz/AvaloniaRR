using System;
using ReactiveUI;

namespace WordsCount.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    private string _text = "";
    private string _wordsCount = "";

    public string Text
    {
        get => _text;
        set
        {
            this.RaiseAndSetIfChanged(ref _text, value); 
            this.RaisePropertyChanged(nameof(WordsCount));
        }
    }
    
    public string WordsCount => WordsCounter(_text).ToString();
    
    private int WordsCounter(String text)
    {

        bool wordStart = true;
        int res = 0;
        
        foreach (var symbol in text)
        {
            if (wordStart && symbol != ' ')
            {
                res++;
                wordStart = false;
            }
            if (symbol == ' ')
            {
                wordStart = true;
            }
        }
        return res;
    }
}