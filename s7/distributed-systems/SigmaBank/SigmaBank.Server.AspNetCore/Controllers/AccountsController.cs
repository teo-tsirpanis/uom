using Microsoft.AspNetCore.Mvc;

namespace Dai19090.DistributedSystems.SigmaBank.Server.AspNetCore.Controllers;

/// <summary>
/// Manages bank accounts.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class AccountsController : ControllerBase
{
    private readonly IBank _bank;

    /// <summary>
    /// Creates an <see cref="AccountsController"/>.
    /// </summary>
    public AccountsController(IBank bank) => _bank = bank;

    /// <summary>
    /// Gets information about an account.
    /// </summary>
    /// <param name="id">The account's ID.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <response code="200">Returns the account's information.</response>
    /// <response code="404">The account was not found.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AccountInfo>> Get(int id, CancellationToken cancellationToken)
    {
        var accountInfo = await _bank.GetAccountInfoAsync(new(id), cancellationToken);

        if (accountInfo is null)
            return NotFound();

        return Ok(accountInfo);
    }

    /// <summary>
    /// Creates an account.
    /// </summary>
    /// <param name="userId">The owning user's ID.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <response code="200">Returns the account's information.</response>
    /// <response code="400">There was a problem with the account's creation.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AccountInfo>> Post(int userId, CancellationToken cancellationToken)
    {
        try
        {
            var accountInfo = await _bank.CreateAccountAsync(new(userId), cancellationToken);

            return Ok(accountInfo);
        }
        catch (BankException e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Deposits money to an account.
    /// </summary>
    /// <param name="id">The account's ID.</param>
    /// <param name="amount">The monetary amount to deposit.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <response code="200">Returns the account's information after the deposit.</response>
    /// <response code="400">There was a problem with the account's creation.</response>
    [HttpPost("deposit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AccountInfo>> Deposit(int id, decimal amount, CancellationToken cancellationToken)
    {
        try
        {
            var accountInfo = await _bank.DepositAsync(new(id), amount, cancellationToken);

            return Ok(accountInfo);
        }
        catch (BankException e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Withdraws money from an account.
    /// </summary>
    /// <param name="id">The account's ID.</param>
    /// <param name="amount">The monetary amount to withdraw.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <response code="200">Returns the account's information after the withdrawal.</response>
    /// <response code="400">There was a problem with the account's creation.</response>
    [HttpPost("withdraw")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AccountInfo>> Withdraw(int id, decimal amount, CancellationToken cancellationToken)
    {
        try
        {
            var accountInfo = await _bank.WithdrawAsync(new(id), amount, cancellationToken);

            return Ok(accountInfo);
        }
        catch (BankException e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Transders money between two accounts.
    /// </summary>
    /// <param name="originId">The origin account's ID.</param>
    /// <param name="destinationId">The destination account's ID.</param>
    /// <param name="amount">The monetary amount to transfer.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <response code="200">Returns both accounts' information after the transfer.</response>
    /// <response code="400">There was a problem with the account's creation.</response>
    [HttpPost("transfer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TransferResult>> Transfer(int originId, int destinationId, decimal amount, CancellationToken cancellationToken)
    {
        try
        {
            var transferResult = await _bank.TransferAsync(new(originId), new(destinationId), amount, cancellationToken);

            return Ok(transferResult);
        }
        catch (BankException e)
        {
            return BadRequest(e.Message);
        }
    }
}
