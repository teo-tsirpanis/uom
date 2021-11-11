using System.Text.Json.Serialization;

namespace Dai19090.DistributedSystems.SigmaBank;

/// <summary>
/// Represents the result of an operation.
/// Can either have a value of type <typeparamref name="T"/>
/// or an error message in string form.
/// </summary>
/// <typeparam name="T">The result value's type.</typeparam>
public sealed class Result<T> where T : class?
{
    private readonly T _value;
    private readonly string? _errorMessage;

    internal Result(T value, string? errorMessage)
    {
        _value = value;
        _errorMessage = errorMessage;
    }

    /// <summary>
    /// Whether the operation represents success.
    /// </summary>
    [MemberNotNullWhen(false, nameof(ErrorMessage)), JsonIgnore]
    public bool IsSuccess => _errorMessage == null;
    /// <summary>
    /// The successful operation's result value.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// The operation had failed (<see cref="IsSuccess"/> had returned <see langword="false"/>
    /// </exception>
    public T? Value => IsSuccess ? _value : throw new InvalidOperationException(_errorMessage);
    /// <summary>
    /// The failed operation's error message.
    /// </summary>
    /// <remarks>
    /// Guard access to it with <see cref="IsSuccess"/> to avoid null checking.
    /// </remarks>
    public string? ErrorMessage => _errorMessage;
}

/// <summary>
/// Helper methods for creating <see cref="Result{T}"/>s.
/// </summary>
public static class Result
{
    public static Result<T> Success<T>(T result) where T : class =>
        new(result, null);

    public static Result<T> Failure<T>(string errorMessage) where T : class =>
        new(null!, errorMessage);

    public static Result<T> Failure<T>(Exception e) where T : class =>
        new(null!, $"{e.GetType().Name}: {e.Message}");
}
