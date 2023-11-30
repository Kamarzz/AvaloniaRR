using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using ReactiveUI;

namespace WordsSearch.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();
    private ObservableCollection<Item> _searchedItems = new ObservableCollection<Item>();

    private string _text = "";
    public string Text
    {
        get => _text;
        set
        {
            this.RaiseAndSetIfChanged(ref _text, value); 
            this.RaisePropertyChanged(nameof(SearchedItems));
        }
    }

    public MainWindowViewModel()
    {
        Items.Add(new Item() { Value = "abc" });
        Items.Add(new Item() { Value = "bca" });
        Items.Add(new Item() { Value = "cbc" });
        Items.Add(new Item() { Value = "acb" });
    }
    
    public ObservableCollection<Item> SearchedItems
    {
        get => search(_text);
    }

    private ObservableCollection<Item> search(string text)
    {
        ObservableCollection<Item> searchedItems = new ObservableCollection<Item>();

        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Value.StartsWith(text))
            {
                searchedItems.Add(Items[i]);
            }
        }

        return searchedItems;
    }

}

public class Item : ViewModelBase
{
    private string _value;

    public string Value
    {
        get => _value;
        set => this.RaiseAndSetIfChanged(ref _value, value);
    }
}