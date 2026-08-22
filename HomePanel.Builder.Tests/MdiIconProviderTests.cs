using HomePanel.Builder.Services;

namespace HomePanel.Builder.Tests;

public class MdiIconProviderTests
{
    [Test]
    public void GetIconNames_Returns_Non_Null_Array()
    {
        // Arrange
        MdiIconProvider mdiIconService = new(null!);

        // Act
        string[] iconNames = mdiIconService.GetIconNames("test");

        // Assert
        Assert.That(iconNames, Is.Not.Null);
    }
}
