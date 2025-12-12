namespace WinFormsCalculator.Logic;

public class FirstValueHolder(CalculatorEngine ce)
{
    public Operator Operator { get; set; }

    private CalculatorEngine calculatorEngine = ce;

    public double FirstValueCalculation(object obj, TextBox textbox)
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
