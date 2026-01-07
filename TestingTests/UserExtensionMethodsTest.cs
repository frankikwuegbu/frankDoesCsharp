using FluentAssertions;
using LoginPageDemo;
using LoginPageDemo.entities;

namespace TestingTests;

public class UserExtensionMethodsTest
{
    [Fact]
    public void UserExtensionMethod_GetDto_ReturnsObj()
    {
        //arrange
        var user = new User()
        { 
            Name = "test name",
            UserName = "test username",
            Password = "testPass",
            ConfirmPassword = "testPass"
        };

        //action
        var result = user.GetDto();

        //assert
        result.Should().BeOfType<UserDto>();
        result.Name.Should().Be(user.Name);
    }
}
