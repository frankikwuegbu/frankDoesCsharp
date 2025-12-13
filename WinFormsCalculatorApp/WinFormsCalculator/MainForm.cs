using WinFormsCalculator.Logic;

namespace WinFormsCalculator;

public partial class MainForm : Form
{
    private CalculatorEngine calculatorEngine;
    private FirstValueHolder holdFirstValue;

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
        holdFirstValue = new FirstValueHolder(calculatorEngine);
    }

    //digit buttons event handler
    private void screenNumbers(object sender, EventArgs e)
    {
        Button pressedButton = (Button)sender;
        calculatorScreen.Text += pressedButton.Text;
    }

    //operator buttons event handler
    private void clickOperator(object sender, EventArgs e)
    {
        holdFirstValue.SetFirstValueSetOperator(sender, calculatorScreen);
    }

    //= button event handler
    private void clickEvaluate(object sender, EventArgs e)
    {
        calculatorEngine.SecondValue = double.Parse(calculatorScreen.Text);
        calculatorEngine.Calculations();
        calculatorScreen.Text = calculatorEngine.Calculations().ToString();
    }

    //clear button event handler
    private void clickClear(object sender, EventArgs e)
    {
        calculatorEngine.FirstValue = 0;
        calculatorEngine.SecondValue = 0;
        calculatorScreen.Clear();
    }
}
