using System;
using System.IO;
using ReactiveUI;

namespace PrintFile.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _fileContent = "";
    private string _filePath = "";

    public string FileContent
    {
        get => GetContent(_filePath);
    }

    public string FilePath
    {
        get => _filePath;
        set
        {
            this.RaiseAndSetIfChanged(ref _filePath, value);
            this.RaisePropertyChanged(nameof(FileContent));
        }
    }


    private string GetContent(string path)
    {
        return File.ReadAllText(path);
    }
}