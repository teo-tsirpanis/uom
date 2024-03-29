using System.Text.Json.Serialization;

namespace Dai19090.DistributedSystems.SigmaBank;

/// <summary>
/// A user identifier.
/// </summary>
/// <param name="Id">The identifier's numeric value</param>
/// <remarks>
/// <para>This type was introduced in accordance with the Domain Driven Design
/// principles, to distinguish at type-level integers representing users.</para>
/// </remarks>
public sealed record class UserId(int Id)
{
    public override string ToString()
    {
        return Id.ToString();
    }
}

/// <summary>
/// Represents information about a user.
/// </summary>
public sealed class UserInfo
{
    /// <summary>
    /// The user's unique identifier.
    /// </summary>
    public UserId Id { get; }
    /// <summary>
    /// The user's name.
    /// </summary>
    public string Name { get; }
    /// <summary>
    /// The user's surname.
    /// </summary>
    public string Surname { get; }

    public UserInfo(UserId id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }
}

/// <summary>
/// An account identifier.
/// </summary>
/// <param name="Id">The identifier's numeric value</param>
/// <para>This class follows structural equality semantics.
/// Two instances of <see cref="AccountId"/> are equal if
/// they store the same <see cref="Id"/>.</para>
public sealed record class AccountId(int Id)
{
    public override string ToString()
    {
        return Id.ToString();
    }
}

public sealed class AccountInfo
{
    public AccountId AccountId { get; }
    public UserId Owner { get; }
    public decimal Balance { get; }

    public AccountInfo(AccountId accountId, UserId owner, decimal balance)
    {
        AccountId = accountId;
        Owner = owner;
        Balance = balance;
    }
}

/// <summary>
/// The result of a transfer operation.
/// </summary>
/// <param name="OriginAccountInfo">Information about the account which sent the money.</param>
/// <param name="DestinationAccountInfo">Information about the account which received the money.</param>
/// <seealso cref="IBank.TransferAsync"/>
public sealed record class TransferResult(AccountInfo OriginAccountInfo, AccountInfo DestinationAccountInfo);

/// <summary>
/// Abstracts away the operations of SigmaBank.
/// </summary>
public interface IBank
{
    /// <summary>
    /// Creates a user.
    /// </summary>
    /// <param name="name">The user's name.</param>
    /// <param name="surname">The user's surname.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <returns>The new user's information.</returns>
    Task<UserInfo> CreateUserAsync(string name, string surname, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets information about a user.
    /// </summary>
    /// <param name="id">The ID of the user to look for.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    Task<UserInfo?> GetUserInfoAsync(UserId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates an account.
    /// </summary>
    /// <param name="id">The ID of the account's owner.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <returns>The new account's information.</returns>
    Task<AccountInfo> CreateAccountAsync(UserId id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets information about an account.
    /// </summary>
    /// <param name="id">The ID of the account to look for.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    Task<AccountInfo?> GetAccountInfoAsync(AccountId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deposits money to an account.
    /// </summary>
    /// <param name="id">The ID of the account to deposit money in.</param>
    /// <param name="amount">The monetary amount to deposit.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <returns>The account's information after the deposit was performed.</returns>
    Task<AccountInfo> DepositAsync(AccountId id, decimal amount, CancellationToken cancellationToken = default);

    /// <summary>
    /// Withdraws money from an account.
    /// </summary>
    /// <param name="id">The ID of the account to withdraw money from.</param>
    /// <param name="amount">The monetary amount to withdraw.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <returns>The account's information after the withdrawal was performed.</returns>
    Task<AccountInfo> WithdrawAsync(AccountId id, decimal amount, CancellationToken cancellationToken = default);

    /// <summary>
    /// Transfers money between two accounts.
    /// </summary>
    /// <param name="originAccountId">The ID of the account which sends the money.</param>
    /// <param name="destinationAccountId">The ID of the account which receives the money.</param>
    /// <param name="amount">The monetary amount to transfer.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <returns>Both accounts' information after the transfer was performed.</returns>
    Task<TransferResult> TransferAsync(AccountId originAccountId, AccountId destinationAccountId, decimal amount, CancellationToken cancellationToken = default);
}

/// <summary>
/// Signifies that something went wrong with an <see cref="IBank"/> operation.
/// </summary>
/// <remarks>
/// On the server these exceptions' messages will be sent to the client, and
/// on the client they will be displayed to the user without terminating it.
/// </remarks>
public sealed class BankException : Exception
{
    public BankException(string message) : base(message) { }
}
