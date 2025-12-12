namespace WinFormsCalculator.Logic;

public class CalculatorEngine
{
    public double FirstValue { get; set; }
    public double SecondValue { get; set; }
    //public enum Operators { addition, subtraction, multiplication, division }
    //public Operators Operation { get; set; }

    public string? Operator { get; set; }
    public double Result { get; set; }

    public void Calculations()
    {
        switch (Operator)
        {
            case "+":
                Result = FirstValue + SecondValue;
                break;
            case "-":
                Result = FirstValue - SecondValue;
                break;
            case "*":
                Result = FirstValue * SecondValue;
                break;
            case "/":
                if (SecondValue != 0)
                {
                    Result = FirstValue / SecondValue;
                }
                else
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }
                break;
            default:
                throw new InvalidOperationException("Invalid operator.");
        }
    }
}
