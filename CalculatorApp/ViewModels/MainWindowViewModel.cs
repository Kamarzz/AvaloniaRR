using System;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;

namespace CalculatorApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _expression = "";
        private double _currentValue = 0;
        private string _currentOperation = "";
        private bool _isOperationClicked = false;

        public string Expression
        {
            get => _expression;
            set => this.RaiseAndSetIfChanged(ref _expression, value);
        }

        public ReactiveCommand<string, Unit> InsertNumberCommand { get; }
        public ReactiveCommand<string, Unit> OperationCommand { get; }
        public ReactiveCommand<Unit, Unit> CalculateCommand { get; }
        public ReactiveCommand<Unit, Unit> ClearCommand { get; }

        public MainWindowViewModel()
        {
            InsertNumberCommand = ReactiveCommand.Create<string>(InsertNumber);
            OperationCommand = ReactiveCommand.Create<string>(PerformOperation);
            CalculateCommand = ReactiveCommand.Create(Calculate);
            ClearCommand = ReactiveCommand.Create(Clear);
        }

        private void InsertNumber(string number)
        {
            if (_isOperationClicked)
            {
                Expression = "";
                _isOperationClicked = false;
            }

            Expression += number;
        }

        private void PerformOperation(string operation)
        {
            if (!_isOperationClicked)
            {
                _currentValue = double.Parse(Expression);
                _isOperationClicked = true;
            }
            
            _currentOperation = operation;
        }

        private void Calculate()
        {
            double newValue = double.Parse(Expression);
            switch (_currentOperation)
            {
                case "Add":
                    _currentValue += newValue;
                    break;
                case "Subtract":
                    _currentValue -= newValue;
                    break;
                case "Multiply":
                    _currentValue *= newValue;
                    break;
                case "Divide":
                    _currentValue /= newValue;
                    break;
            }

            Expression = _currentValue.ToString();
            _isOperationClicked = false;
        }

        private void Clear()
        {
            _expression = "";
            _currentValue = 0;
            _currentOperation = "";
            _isOperationClicked = false;
        }
    }
}
