using FluentAssertions;
using WinFormsCalculator.Logic;

namespace CalculatorTests;
public class CalculatorEngineTests
{
    TextBox textbox = new TextBox();

    [Fact]
    public void CalculatorEngine_ClearMemory_ReturnClearScreen()
    {
        //arrange
        var calcEngine = new CalculatorEngine();

        //action
        calcEngine.ClearMemory(textbox);
        double firstValue = calcEngine.FirstValue;

        //assert
        firstValue.Should().Be(0);
    }
}
