using WinFormsCalculator.Logic;

namespace WinFormsCalculator;

public partial class MainForm : Form
{
    private CalculatorEngine calculatorEngine;
    private FirstValueHolder holdFirstValue;

    public MainForm()
    {
        InitializeComponent();

        addbtn.Tag = Operator.Add;
        subtractbtn.Tag = Operator.Subtract;
        mulbtn.Tag = Operator.Multiply;
        divbtn.Tag = Operator.Divide;

        calculatorEngine = new CalculatorEngine();
        holdFirstValue = new FirstValueHolder(calculatorEngine);
    }

    private void screenNumbers(object sender, EventArgs e)
    {
        Button pressedButton = (Button)sender;
        calculatorScreen.Text += pressedButton.Text;
    }

    private void clickOperator(object sender, EventArgs e)
    {
        holdFirstValue.FirstValueCalculation(sender, calculatorScreen);
    }

    private void clickEvaluate(object sender, EventArgs e)
    {
        calculatorEngine.SecondValue = double.Parse(calculatorScreen.Text);
        calculatorEngine.Calculations();
        calculatorScreen.Text = calculatorEngine.Calculations().ToString();
        calculatorEngine.FirstValue = calculatorEngine.Result;
    }

    private void clickClear(object sender, EventArgs e)
    {
        calculatorEngine.FirstValue = 0;
        calculatorEngine.SecondValue = 0;
        calculatorScreen.Clear();
    }
}
