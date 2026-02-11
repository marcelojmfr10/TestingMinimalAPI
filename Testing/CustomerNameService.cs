using System;

namespace Testing;

public class CustomerNameService
{
    public string GetDisplayName(string firstName, string lastName)
    {
        firstName = firstName.Trim();
        lastName = lastName.Trim();
        return $"{firstName} {lastName}";
    }

    public string? GetInitials(string? firstName, string? lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            return null;
        }

        char firstLetterOfFirstName = char.ToUpper(firstName.Trim()[0]);
        char firstLetterOfLastName = char.ToUpper(lastName.Trim()[0]);
        return $"{firstLetterOfFirstName}{firstLetterOfLastName}";
    }

    public bool IsValidFullName(string? fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            return false;
        }

        fullName = fullName.Trim();
        return fullName.Contains(' ');
    }
}