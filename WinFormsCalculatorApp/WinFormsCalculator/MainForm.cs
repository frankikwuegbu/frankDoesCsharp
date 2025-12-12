namespace WinFormsCalculator;

public partial class MainForm : Form
{
    private int firstValue;
    private int secondValue;
    private Button operationButton;

    public MainForm()
    {
        InitializeComponent();
    }

    private void ValueString(object sender, EventArgs e)
    {
        Button pressedButton = (Button)sender;
        calculatorScreen.Text += pressedButton.Text;
    }

    private void calculationButton(object sender, EventArgs e)
    {
        operationButton = (Button)sender;

        firstValue = Convert.ToInt32(calculatorScreen.Text);
        calculatorScreen.Clear();
    }

    private void result_Click(object sender, EventArgs e)
    {
        secondValue = Convert.ToInt32(calculatorScreen.Text);

        if (operationButton.Text.Equals("+"))
        {
            int result = firstValue + secondValue;
            calculatorScreen.Text = result.ToString();
        }
        else if (operationButton.Text.Equals("-"))
        {
            int result = firstValue - secondValue;
            calculatorScreen.Text = result.ToString();
        }
    }
}
