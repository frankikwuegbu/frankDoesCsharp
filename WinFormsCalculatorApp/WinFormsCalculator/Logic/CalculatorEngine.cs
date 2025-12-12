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
    public double Result { get; set; }

    public void SetOperator(Operator o)
    {
        Operator = o;
    }
    public double Calculations()
    {
        return Operator switch
        {
            Operator.Add => FirstValue + SecondValue,
            Operator.Subtract => FirstValue - SecondValue,
            Operator.Multiply => FirstValue * SecondValue,
            Operator.Divide => FirstValue / SecondValue,
            _ => 0
        };
    }
}
