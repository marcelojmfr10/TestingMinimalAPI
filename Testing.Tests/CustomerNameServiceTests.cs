using System;

namespace Testing.Tests;

public class CustomerNameServiceTests
{
    [Fact]
    public void GetDisplayName_GivenFirstAndLastName_ReturnsFullName()
    {
        var service = new CustomerNameService();
        var displayName = service.GetDisplayName("Marcelo", "Fuentes");
        Assert.Equal("Marcelo Fuentes", displayName);
    }

    [Fact]
    public void GetDisplayName_TrimsExtraSpacesFromFirstAndLastName()
    {
        var service = new CustomerNameService();
        var displayName = service.GetDisplayName(" Marcelo  ", "    Fuentes     ");
        Assert.Equal("Marcelo Fuentes", displayName);
    }

    [Fact]
    public void GetDisplayName_ReturnsStartsWithFirstNameAndEndsWithLastName()
    {
        var service = new CustomerNameService();
        var displayName = service.GetDisplayName("Marcelo", "Fuentes");
        Assert.StartsWith("Marcelo", displayName);
        Assert.EndsWith("Fuentes", displayName);
    }

    [Fact]
    public void GetDisplayName_ResultContainsSpaceBetweenFirstAndLastName()
    {
        var service = new CustomerNameService();
        var displayName = service.GetDisplayName("Marcelo", "Fuentes");
        Assert.Contains(" ", displayName);
    }

    [Fact]
    public void GetInitials_GivenFirstAndLastName_ReturnsUppercaseInitials()
    {
        var service = new CustomerNameService();
        var displayName = service.GetInitials("Marcelo", "Fuentes");
        Assert.Equal("MF", displayName);
    }

    [Fact]
    public void GetInitials_ReturnsNull_WhenFirstNameIsNullOrWhitespace()
    {
        var service = new CustomerNameService();
        var initialNull = service.GetInitials(null, "Fuentes");
        var initialWhiteSpace = service.GetInitials(" ", "Fuentes");
        Assert.Null(initialNull);
        Assert.Null(initialWhiteSpace);
    }

    [Fact]
    public void GetInitials_ReturnsNull_WhenLastNameIsNullOrWhitespace()
    {
        var service = new CustomerNameService();
        var lastNull = service.GetInitials("Marcelo", null);
        var lastWhiteSpace = service.GetInitials("Marcelo", " ");
        Assert.Null(lastNull);
        Assert.Null(lastWhiteSpace);
    }

    [Theory]
    [InlineData(null, "Fuentes")]
    [InlineData(" ", "Fuentes")]
    [InlineData("Marcelo", null)]
    [InlineData("Marcelo", " ")]
    public void GetInitials_ReturnsNull_WhenFirstOrLastNameIsNullOrWhitespace(string? firstName, string? lastName)
    {
        var service = new CustomerNameService();
        var initials = service.GetInitials(firstName, lastName);
        Assert.Null(initials);
    }

    [Fact]
    public void IsValidFullName_ReturnsTrue_WhenFullNameHasAtLeastOneSpace()
    {
        var service = new CustomerNameService();
        var isValid = service.IsValidFullName("Marcelo Fuentes");
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("Marcelo")]
    public void IsValidFullName_ReturnsFalse_ForInvalidNames(string? fullName)
    {
        var service = new CustomerNameService();
        var isValid = service.IsValidFullName(fullName);
        Assert.False(isValid);
    }
}
