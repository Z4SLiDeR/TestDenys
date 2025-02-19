using Xunit;
using TestDenys.Model;

namespace TestProject1
{
    public class FineManagementTests
    {
        [Theory]
        [InlineData(67890, 15.5, true)]
        [InlineData(null, 15.5, false)]
        [InlineData("stringInsteadOfInt", 15.5, false)]
        [InlineData(67890, -10.0, false)]
        public void ApplyFine_Tests(object reservationId, double amount, bool expected)
        {
            // Arrange
            var fineService = new FineService();

            // Act
            bool result = fineService.ApplyFine(reservationId, amount);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 5.0, 15.0)]
        [InlineData(-3, 5.0, false)]
        [InlineData("stringInsteadOfInt", 5.0, false)]
        [InlineData(3, "stringInsteadOfDecimal", false)]
        public void SetFineAmount_Tests(object overdueDays, object fineRate, object expected)
        {
            // Arrange
            var fineService = new FineService();

            // Act
            object result = fineService.SetFineAmount(overdueDays, fineRate);

            // Assert
            Assert.Equal(expected, result);
        }
        
    }
}