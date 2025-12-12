using WinFormsCalculator.Logic;

namespace WinFormsCalculator;

public partial class MainForm : Form
{
    private CalculatorEngine calculatorEngine = new CalculatorEngine();

    public MainForm()
    {
        InitializeComponent();
    }

    private void screenNumbers(object sender, EventArgs e)
    {
        Button pressedButton = (Button)sender;
        calculatorScreen.Text += pressedButton.Text;
    }

    private void clickOperator(object sender, EventArgs e)
    {
        calculatorEngine.FirstValue = double.Parse(calculatorScreen.Text);
        calculatorEngine.Operator = ((Button)sender).Text;
        calculatorScreen.Clear();
    }

    private void clickEvaluate(object sender, EventArgs e)
    {
        calculatorEngine.SecondValue = double.Parse(calculatorScreen.Text);
        calculatorEngine.Calculations();
        calculatorScreen.Text = calculatorEngine.Result.ToString();
    }
}
