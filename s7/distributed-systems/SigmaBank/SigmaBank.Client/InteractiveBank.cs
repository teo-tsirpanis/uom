using static System.Console;

namespace Dai19090.DistributedSystems.SigmaBank.Client;

/// <summary>
/// Uses the console to interact with an <see cref="IBank"/>.
/// </summary>
/// <remarks>
/// Thanks to the abstraction <see cref="IBank"/> provides, nothing can
/// prevent us from moving this file to the server and with very few changes
/// directly communicate with the database, merging the upper two tiers.
/// </remarks>
public sealed class InteractiveBank
{
    private readonly IBank _bank;

    public InteractiveBank(IBank bank)
    {
        _bank = bank;
    }

    private static void DisplayOptions()
    {
        WriteLine("Welcome to Sigma Bank. You can do the following things:");
        WriteLine("1 Create user");
        WriteLine("2 Get user info");
        WriteLine("3 Create account");
        WriteLine("4 Get account info");
        WriteLine("5 Deposit");
        WriteLine("6 Withdraw");
        WriteLine("7 Transfer");
        WriteLine("8 Exit");
        WriteLine();
    }

    private static void DisplayUserInfo(UserInfo userInfo)
    {
        WriteLine($"ID:      {userInfo.Id}");
        WriteLine($"Name:    {userInfo.Name}");
        WriteLine($"Surname: {userInfo.Surname}");
    }

    private static void DisplayAccountInfo(AccountInfo accountInfo)
    {
        WriteLine($"ID:       {accountInfo.AccountId}");
        WriteLine($"Owner ID: {accountInfo.Owner}");
        WriteLine($"Balance:  {accountInfo.Balance:C}");
    }

    private async Task HandleCreateUserAsync(CancellationToken cancellationToken)
    {
        Write("Enter your name: ");
        var name = ReadLine();
        Write("Enter your surname: ");
        var surname = ReadLine();

        ArgumentValidation.ValidateAcountCreation(name, surname);
        var userInfo = await _bank.CreateUserAsync(name, surname, cancellationToken);

        WriteLine("User created successfully:");
        DisplayUserInfo(userInfo);
        WriteLine("Thanks for choosing Sigma Bank. Make sure you remember your user ID in order to create an account");
    }

    private async Task HandleGetUserInfoAsync(CancellationToken cancellationToken)
    {
        Write("Enter your user ID: ");
        var id = ReadLine();

        if (!int.TryParse(id, out var userId))
        {
            WriteLine("Sorry, your user ID has to be a number. Please try again.");
            return;
        }
        var userInfo = await _bank.GetUserInfoAsync(new UserId(userId), cancellationToken);

        if (userInfo == null)
        {
            WriteLine("User not found.");
            return;
        }

        WriteLine("User found:");
        DisplayUserInfo(userInfo);
    }

    private async Task HandleCreateAccountAsync(CancellationToken cancellationToken)
    {
        Write("Enter the account owner's ID: ");
        var id = ReadLine();

        if (!int.TryParse(id, out var userId))
        {
            WriteLine("Sorry, your user ID has to be a number. Please try again.");
            return;
        }
        var accountInfo = await _bank.CreateAccountAsync(new UserId(userId), cancellationToken);

        WriteLine("Account created successfully:");
        DisplayAccountInfo(accountInfo);
    }

    private async Task HandleGetAccountInfoAsync(CancellationToken cancellationToken)
    {
        Write("Enter the account ID: ");
        var id = ReadLine();

        if (!int.TryParse(id, out var accountId))
        {
            WriteLine("Sorry, the account ID has to be a number. Please try again.");
            return;
        }
        var accountInfo = await _bank.GetAccountInfoAsync(new AccountId(accountId), cancellationToken);

        if (accountInfo == null)
        {
            WriteLine("Account not found.");
            return;
        }

        WriteLine("Account found:");
        DisplayAccountInfo(accountInfo);
    }

    private async Task HandleDepositAsync(CancellationToken cancellationToken)
    {
        Write("Enter the account ID: ");
        var id = ReadLine();

        if (!int.TryParse(id, out var accountId))
        {
            WriteLine("Sorry, the account ID has to be a number. Please try again.");
            return;
        }
        Write("Enter the amount to deposit: ");
        var amount = ReadLine();

        if (!decimal.TryParse(amount, out var amountToDeposit))
        {
            WriteLine("Sorry, the amount has to be a number. Please try again.");
            return;
        }
        var accountInfo = await _bank.DepositAsync(new AccountId(accountId), amountToDeposit, cancellationToken);

        WriteLine("Deposit successful:");
        DisplayAccountInfo(accountInfo);
    }

    private async Task HandleWithdrawAsync(CancellationToken cancellationToken)
    {
        Write("Enter the account ID: ");
        var id = ReadLine();

        if (!int.TryParse(id, out var accountId))
        {
            WriteLine("Sorry, the account ID has to be a number. Please try again.");
            return;
        }
        Write("Enter the amount to withdraw: ");
        var amount = ReadLine();

        if (!decimal.TryParse(amount, out var amountToWithdraw))
        {
            WriteLine("Sorry, the amount has to be a number. Please try again.");
            return;
        }
        var accountInfo = await _bank.WithdrawAsync(new AccountId(accountId), amountToWithdraw, cancellationToken);

        WriteLine("Withdraw successful:");
        DisplayAccountInfo(accountInfo);
    }

    private async Task HandleTransferAsync(CancellationToken cancellationToken)
    {
        Write("Enter the account ID to transfer money from: ");
        var sourceId = ReadLine();

        if (!int.TryParse(sourceId, out var sourceAccountId))
        {
            WriteLine("Sorry, the source account ID has to be a number. Please try again.");
            return;
        }
        Write("Enter the account ID to transfer money to: ");
        var destinationId = ReadLine();

        if (!int.TryParse(destinationId, out var destinationAccountId))
        {
            WriteLine("Sorry, the destination account ID has to be a number. Please try again.");
            return;
        }
        Write("Enter the amount to transfer: ");
        var amount = ReadLine();

        if (!decimal.TryParse(amount, out var amountToTransfer))
        {
            WriteLine("Sorry, the amount has to be a number. Please try again.");
            return;
        }
        var transferResult = await _bank.TransferAsync(new AccountId(sourceAccountId), new AccountId(destinationAccountId), amountToTransfer, cancellationToken);

        WriteLine("Transfer successful.");
        WriteLine($"Origin account:");
        DisplayAccountInfo(transferResult.OriginAccountInfo);
        WriteLine($"Destination account:");
        DisplayAccountInfo(transferResult.DestinationAccountInfo);
    }

    private async Task<bool> AskCommandAndDispatchAsync(CancellationToken cancellationToken)
    {
        Write("Write your command: ");
        var command = ReadLine();

        if (!int.TryParse(command, out var commandNumber))
        {
            WriteLine("Sorry, the command number has to be a number. Please try again.");
            return true;
        }

        switch (commandNumber)
        {
            case 1:
                await HandleCreateUserAsync(cancellationToken);
                break;
            case 2:
                await HandleGetUserInfoAsync(cancellationToken);
                break;
            case 3:
                await HandleCreateAccountAsync(cancellationToken);
                break;
            case 4:
                await HandleGetAccountInfoAsync(cancellationToken);
                break;
            case 5:
                await HandleDepositAsync(cancellationToken);
                break;
            case 6:
                await HandleWithdrawAsync(cancellationToken);
                break;
            case 7:
                await HandleTransferAsync(cancellationToken);
                break;
            case 8: return false;
            default:
                WriteLine("Sorry, the command number is not valid. Please try again.");
                break;
        }

        return true;
    }

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        DisplayOptions();
        while (true)
        {
            try
            {
                if (!await AskCommandAndDispatchAsync(cancellationToken))
                    break;
            }
            catch (OperationCanceledException oce) when (oce.CancellationToken == cancellationToken)
            {
                break;
            }
            catch (BankException e)
            {
                WriteLine($"Error: {e.Message}");
            }
            WriteLine();
        }
    }
}
