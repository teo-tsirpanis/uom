namespace Dai19090.DistributedSystems.SigmaBank;

/// <summary>
/// Input argument validation code to be shared by both the client and the server.
/// </summary>
public static class ArgumentValidation
{
    /// <summary>
    /// Validates the input parameters used for user creation.
    /// </summary>
    /// <param name="name">The user's name.</param>
    /// <param name="surname">The user's surname.</param>
    /// <exception cref="ArgumentException">
    /// Either <paramref name="name"/> or <paramref name="surname"/> is
    /// <see langword="null"/> or too big (larger than 32 characters).</exception>
    /// <seealso cref="IBank.CreateAccountAsync"/>
    public static void ValidateAcountCreation([NotNull] string? name, [NotNull] string? surname)
    {
        ValidateName(name, "Name");
        ValidateName(surname, "Surname");

        static void ValidateName([NotNull] string? name, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{fieldName} cannot be empty");
            if (name.Length > 32)
                throw new ArgumentException($"{fieldName} cannot be longer than 32 characters");
        }
    }

    /// <summary>
    /// Validates decimal values representing currency amounts.
    /// </summary>
    /// <param name="amount">The decimal value to validate.</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="amount"/> is negative.
    /// </exception>
    public static void ValidateCurrencyAmount(decimal amount)
    {
        if (amount < 0.0m)
            throw new ArgumentException("Amount cannot be negative.");
    }
}
