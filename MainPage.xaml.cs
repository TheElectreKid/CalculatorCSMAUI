using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;


namespace MauiAppCalculator;

public partial class MainPage : ContentPage 
{
	public MainPage() 
    {
		InitializeComponent();
        CalcKeys = new RelayCommand<string>(OnKeyClicked);
        BindingContext = this;
	}
//================================================================================

public ICommand CalcKeys {get; }

private void OnKeyClicked(string parameter) 
{
    //Key presses
switch (parameter)
    {
        case "NumKey7":
            CalculatorService.CalcNumKey("7");
        break;

        case "NumKey8":
            CalculatorService.CalcNumKey("8");
        break;

        case "NumKey9":
            CalculatorService.CalcNumKey("9");
        break;

        case "NumKey4":
            CalculatorService.CalcNumKey("4");
        break;

        case "NumKey5":
            CalculatorService.CalcNumKey("5");
        break;

        case "NumKey6":
            CalculatorService.CalcNumKey("6");
        break;

        case "NumKey1":
            CalculatorService.CalcNumKey("1");
        break;

        case "NumKey2":
            CalculatorService.CalcNumKey("2");
        break;

        case "NumKey3":
            CalculatorService.CalcNumKey("3");
        break;

        case "NumKey0":
            CalculatorService.CalcNumKey("0");
        break;

        case "OpDiv":
            CalculatorService.SetOperator((int)CalculatorService.Operators.Division);
        break;

        case "OpMul":
            CalculatorService.SetOperator((int)CalculatorService.Operators.Multplication);
        break;

        case "OpSub":
            CalculatorService.SetOperator((int)CalculatorService.Operators.Subtraction);
        break;

        case "OpAdd":
            CalculatorService.SetOperator((int)CalculatorService.Operators.Addition);
        break;

        case "ActionClear":
            CalculatorService.AllClear();
        break;

        case "ActionCalc":
            CalculatorService.CalculateTotal();
        break;

    }
    DisplayBox.Text = CalculatorService.InputBuffer;
}



}
