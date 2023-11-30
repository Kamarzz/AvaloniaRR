using Avalonia.Controls;
using isAdult.ViewModels;

namespace isAdult.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnDataChange(object? sender, DatePickerSelectedValueChangedEventArgs e)
    {
        if (sender is DatePicker dtp && dtp.SelectedDate != null)
        {
            var selDate = dtp.SelectedDate.Value.LocalDateTime;
            if (DataContext is MainWindowViewModel mVM)
            {
                mVM.Date = selDate;
                mVM.IsAdult = mVM.isAdultFunc(selDate);
            }
        }
    }
}