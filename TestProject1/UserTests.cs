using Xunit;
using TestDenys.Model;

namespace TestProject1
{
    public class UserTests
    {
        [Theory]
        [InlineData("user@example.com", "valid123", true)]
        [InlineData("user@example.com", null, false)]
        [InlineData("12345", "valid123", false)]
        [InlineData("user@example.com", "67890", false)]
        public void Login_Tests(string email, string password, bool expected)
        {
            // Arrange
            var user = new User { Email = "user@example.com", Password = "valid123" };

            // Act
            bool result = user.Login(email, password);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("oldPass", "newPass", true)]
        [InlineData("wrongPass", "newPass", false)]
        [InlineData("OldPass", "12345", false)]
        [InlineData(null, "newPass", false)]
        public void ChangePassword_Tests(string currentPassword, string newPassword, bool expected)
        {
            // Arrange
            var user = new User { Password = "oldPass" };

            // Act
            bool result = user.ChangePassword(currentPassword, newPassword);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("John", "Doe", "john@example.com", "12345", true)]
        [InlineData(null, "Doe", "john@example.com", "12345", false)]
        [InlineData("123", "Doe", "john@example.com", "12345", false)]
        [InlineData("John", "Doe", "12345", "12345", false)]
        public void Register_Tests(string firstName, string lastName, string email, string password, bool expected)
        {
            // Act
            var user = new User();
            bool result = user.Register(firstName, lastName, email, password);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DeleteProfile_Test()
        {
            // Arrange
            var user = new User();

            // Act
            bool result = user.DeleteProfile();

            // Assert
            Assert.True(result);
        }
        
        [Theory]
        [InlineData("John", true)]
        [InlineData("Éléonore", true)]
        [InlineData("Jean-Luc", true)]
        [InlineData("O'Connor", true)]
        [InlineData("Anna Maria", true)]
        [InlineData("A", false)]
        [InlineData("John123", false)]
        [InlineData("-Luc", false)]
        [InlineData("Anna Maria123", false)]
        [InlineData("J@ne", false)]
        [InlineData("Él3onore", false)]
        [InlineData("LoooooooooooooooooooooooooooooooooooooooooooooongNom", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void isValidName_Tests(string name, bool expected)
        {
            var userService = new User();
            bool result = userService.isValidName(name);
            Assert.Equal(expected, result);
        }
    }
}
