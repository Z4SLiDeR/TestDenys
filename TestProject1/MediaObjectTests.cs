using Xunit;
using TestDenys.Model;

namespace TestProject1
{
    public class MediaObjectTests
    {
        [Theory]
        [InlineData(12345, true)]
        [InlineData(null, false)]
        [InlineData("stringInsteadOfInt", false)]
        public void BookMediaObject_Tests(object mediaId, bool expected)
        {
            // Arrange
            var media = new MediaService();

            // Act
            bool result = media.BookMediaObject(mediaId);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(54321, true)]
        [InlineData(null, false)]
        [InlineData("stringInsteadOfInt", false)]
        public void ReturnMediaObject_Tests(object mediaId, bool expected)
        {
            // Arrange
            var media = new MediaService();

            // Act
            bool result = media.ReturnMediaObject(mediaId);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(12345, true)]
        [InlineData(null, false)]
        [InlineData("stringInsteadOfInt", false)]
        public void BlockUserFromBooking_Tests(object mediaId, bool expected)
        {
            // Arrange
            var media = new MediaService();

            // Act
            bool result = media.BlockUserFromBooking(mediaId);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "Le Livre de la jungle", true, "Usé", "01.02.1878", true)]
        [InlineData("", "Le Livre de la jungle", true, "Usé", "01.02.1878", false)]
        [InlineData(1, "", true, "Usé", "01.02.1878", false)]
        [InlineData(1, "Le Livre de la jungle", "", "Usé", "01.02.1878", false)]
        [InlineData(1, "Le Livre de la jungle", true, "", "01.02.1878", false)]
        [InlineData(1, "Le Livre de la jungle", true, "Usé", "", false)]
        [InlineData("", "", "", "", "", false)]
        [InlineData(null, null, null, null, null, false)]
        public void CreateMediaObject_Tests(object id, string title, object availability, string state, string date, bool expected)
        {
            var mediaService = new MediaService();
            bool result = mediaService.CreateMediaObject(id, title, availability, state, date);
            Assert.Equal(expected, result);
        }

    }
}