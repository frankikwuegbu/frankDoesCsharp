using System.Security.Cryptography.X509Certificates;

namespace WinFormsCalculator.Logic;

public class FirstValueHolder(CalculatorEngine engine)
{
    private CalculatorEngine calculatorEngine = engine;

    public double SetFirstValueSetOperator(object obj, TextBox textbox)
    {
        if (textbox.Text != "")
        {
            Button operatorButtons = (Button)obj;
            Operator btn = (Operator)operatorButtons.Tag;
            calculatorEngine.SetOperator(btn);
            calculatorEngine.FirstValue = double.Parse(textbox.Text);
            textbox.Clear();

            return calculatorEngine.FirstValue;
        }
        else
        {
            MessageBox.Show("Please enter a number first.");
            return 0;
        }
    }
}
