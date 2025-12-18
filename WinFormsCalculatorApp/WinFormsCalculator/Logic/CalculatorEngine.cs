namespace WinFormsCalculator.Logic;

public enum Operator
{
    Add,
    Subtract,
    Multiply,
    Divide
}

public class CalculatorEngine
{
    public double FirstValue { get; set; }
    public double SecondValue { get; set; }
    public Operator Operator { get; set; }
    public bool EnteringSecondValue { get; set; }

    public void SetOperator(Operator o)
    {
        Operator = o;
        EnteringSecondValue = true;
    }

    public void HoldValues(string number)
    {
        if (!EnteringSecondValue)
        {
            FirstValue = double.Parse($"{FirstValue}{number}");
        }
        else
        {
            SecondValue = double.Parse($"{SecondValue}{number}");
        }
    }

    public void OneOperatorRule(object obj, TextBox textbox)
    {
        if (!EnteringSecondValue && textbox.Text != "")
        {
            Button operatorButton = (Button)obj;
            SetOperator((Operator)operatorButton.Tag);
            textbox.Text += operatorButton.Text;
        }
        else
        {
            MessageBox.Show("ERROR\nEnter numbers first\nOnly one operator allowed");
        }
    }

    public double Calculations()
    {
        EnteringSecondValue = false;

        return Operator switch
        {
            Operator.Add => FirstValue + SecondValue,
            Operator.Subtract => FirstValue - SecondValue,
            Operator.Multiply => FirstValue * SecondValue,
            Operator.Divide => FirstValue / SecondValue,
            _ => 0
        };
    }

    public void ClearMemory(TextBox textBox)
    {
        FirstValue = 0;
        SecondValue = 0;
        EnteringSecondValue = false;
        textBox.Clear();
    }
}
