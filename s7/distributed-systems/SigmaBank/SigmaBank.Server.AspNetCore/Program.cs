using Dai19090.DistributedSystems.SigmaBank;
using Dai19090.DistributedSystems.SigmaBank.Data;
using Dai19090.DistributedSystems.SigmaBank.Transport.Grpc;
using Grpc.Core;
using Grpc.Core.Interceptors;

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

if (connectionString == null)
{
    Console.WriteLine("No connection string found.");
    return 1;
}

var bank = await DatabaseUtilities.InitializeSqlServerDatabaseBankAsync(connectionString);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<ExceptionRewritingInterceptor>();
});
builder.Services.AddSingleton<IBank>(bank);

var app = builder.Build();

app.UseRouting();

app.MapGrpcService<BankGrpcReceiver>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

return 0;

/// <summary>
/// Rewrites stray <see cref="BankException"/>s as gRPC errors.
/// </summary>
internal sealed class ExceptionRewritingInterceptor : Interceptor
{
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context);
        }
        catch (BankException e)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, e.Message));
        }
    }
}
