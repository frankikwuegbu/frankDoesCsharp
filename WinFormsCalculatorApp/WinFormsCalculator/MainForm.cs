using System.Text.RegularExpressions;
using WinFormsCalculator.Logic;

namespace WinFormsCalculator;

public partial class MainForm : Form
{
    private CalculatorEngine calculatorEngine;

    public MainForm()
    {
        InitializeComponent();

        //mapping Tag to enum Members
        addbtn.Tag = Operator.Add;
        subtractbtn.Tag = Operator.Subtract;
        mulbtn.Tag = Operator.Multiply;
        divbtn.Tag = Operator.Divide;

        //class instantiation
        calculatorEngine = new CalculatorEngine();
    }

    //event handlers
    private void screenNumbers(object sender, EventArgs e)
    {
        Button pressedButton = (Button)sender;
        string numberOnScreen = pressedButton.Text;
        calculatorEngine.HoldValues(numberOnScreen);
        calculatorScreen.Text += pressedButton.Text;
    }

    private void clickOperator(object sender, EventArgs e)
    {
        calculatorEngine.OneOperatorRule(sender, calculatorScreen);
    }

    private void clickEvaluate(object sender, EventArgs e)
    {
        var result = calculatorEngine.Calculations();
        calculatorScreen.Text = result.ToString();
        calculatorEngine.FirstValue = result;
        calculatorEngine.SecondValue = 0;
    }

    private void clickClear(object sender, EventArgs e)
    {
        calculatorEngine.ClearMemory(calculatorScreen);
    }
}
