using Microsoft.AspNetCore.Mvc;

namespace Dai19090.DistributedSystems.SigmaBank.Server.AspNetCore;

/// <summary>
/// Manages bank users.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    private readonly IBank _bank;

    /// <summary>
    /// Creates a <see cref="UsersController"/>.
    /// </summary>
    public UsersController(IBank bank) => _bank = bank;

    /// <summary>
    /// Gets information about a user.
    /// </summary>
    /// <param name="id">The user's ID.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <response code="200">Returns the user's information.</response>
    /// <response code="404">The user was not found.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserInfo>> Get(int id, CancellationToken cancellationToken)
    {
        var userInfo = await _bank.GetUserInfoAsync(new(id), cancellationToken);

        if (userInfo is null)
            return NotFound();

        return Ok(userInfo);
    }

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="name">The new user's name.</param>
    /// <param name="surname">The new user's surname.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <response code="200">Returns the created user's information.</response>
    /// <response code="400">There was an error with the given parameters (either empty or too long).</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserInfo>> Post(string name, string surname, CancellationToken cancellationToken)
    {
        try
        {
            var userInfo = await _bank.CreateUserAsync(name, surname, cancellationToken);

            return Ok(userInfo);
        }
        catch (BankException e)
        {
            return BadRequest(e.Message);
        }
    }
}
