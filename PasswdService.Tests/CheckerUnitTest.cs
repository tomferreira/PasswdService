using PasswdService.Domain;
using Xunit;

namespace PasswdService.Tests
{
    public class CheckerUnitTest
    {
        [Fact]
        public void Null_Or_Whitespace_Password_Should_Be_Invalid()
        {
            Assert.Equal(Checker.Result.InvalidMinimumLenght, Checker.IsValid(null));
            Assert.Equal(Checker.Result.InvalidMinimumLenght, Checker.IsValid(""));
            Assert.Equal(Checker.Result.InvalidMinimumLenght, Checker.IsValid(" "));
            
            Assert.NotEqual(Checker.Result.Valid, Checker.IsValid("          "));
        }

        [Fact]
        public void Short_Password_Should_Be_Invalid()
        {
            Assert.Equal(Checker.Result.InvalidMinimumLenght, Checker.IsValid("paswd"));
            Assert.Equal(Checker.Result.InvalidMinimumLenght, Checker.IsValid("A@c1"));
            Assert.Equal(Checker.Result.InvalidMinimumLenght, Checker.IsValid("12345678"));
        }

        [Fact]
        public void None_Digit_Password_Should_Be_Invalid()
        {
            Assert.Equal(Checker.Result.InvalidNoneDigit, Checker.IsValid("Abcdefgh+"));
        }

        [Fact]
        public void None_Upper_Letter_Password_Should_Be_Invalid()
        {
            Assert.Equal(Checker.Result.InvalidNoneUpperLetter, Checker.IsValid("abcdefg+1"));
        }

        [Fact]
        public void None_Lower_Letter_Password_Should_Be_Invalid()
        {
            Assert.Equal(Checker.Result.InvalidNoneLowerLetter, Checker.IsValid("ABCDEFG+1"));
        }

        [Fact]
        public void None_Special_Char_Password_Should_Be_Invalid()
        {
            Assert.Equal(Checker.Result.InvalidNoneSpecialChar, Checker.IsValid("AbC2DeFG1"));

            // ~ is not a special char
            Assert.Equal(Checker.Result.InvalidNoneSpecialChar, Checker.IsValid("~bC2DeFG1"));
        }

        [Fact]
        public void Repeated_Character_Password_Should_Be_Invalid()
        {
            Assert.Equal(Checker.Result.InvalidNoneSpecialChar, Checker.IsValid("Abcdefgh1"));
        }

        [Fact]
        public void Valid_Password()
        {
            // Test all special characters
            Assert.Equal(Checker.Result.Valid, Checker.IsValid("!Bcd3fghijkl"));
            Assert.Equal(Checker.Result.Valid, Checker.IsValid("B@cd3fghijkl"));
            Assert.Equal(Checker.Result.Valid, Checker.IsValid("Bc#d3fghijkl"));
            Assert.Equal(Checker.Result.Valid, Checker.IsValid("Bcd$3fghijkl"));
            Assert.Equal(Checker.Result.Valid, Checker.IsValid("Bcd3%fghijkl"));
            Assert.Equal(Checker.Result.Valid, Checker.IsValid("Bcd3f^ghijkl"));
            Assert.Equal(Checker.Result.Valid, Checker.IsValid("Bcd3fg&hijkl"));
            Assert.Equal(Checker.Result.Valid, Checker.IsValid("Bcd3fgh*ijkl"));
            Assert.Equal(Checker.Result.Valid, Checker.IsValid("Bcd3fghi(jkl"));
            Assert.Equal(Checker.Result.Valid, Checker.IsValid("Bcd3fghij)kl"));
            Assert.Equal(Checker.Result.Valid, Checker.IsValid("Bcd3fghijk-l"));
            Assert.Equal(Checker.Result.Valid, Checker.IsValid("Bcd3fghijkl+"));

            Assert.Equal(Checker.Result.Valid, 
                Checker.IsValid("0123456789AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz!@#$%^&*()-+"));
        }

            [Fact]
        public void Sample_Passwords_Should_Pass()
        {
            Assert.NotEqual(Checker.Result.Valid, Checker.IsValid("aa"));
            Assert.NotEqual(Checker.Result.Valid, Checker.IsValid("ab"));
            Assert.NotEqual(Checker.Result.Valid, Checker.IsValid("AAAbbbCc"));
            Assert.NotEqual(Checker.Result.Valid, Checker.IsValid("AbTp9!foo"));
            Assert.NotEqual(Checker.Result.Valid, Checker.IsValid("AbTp9!foA"));
            Assert.NotEqual(Checker.Result.Valid, Checker.IsValid("AbTp9 fok"));
            
            Assert.Equal(Checker.Result.Valid, Checker.IsValid("AbTp9!fok"));
        }
    }
}
