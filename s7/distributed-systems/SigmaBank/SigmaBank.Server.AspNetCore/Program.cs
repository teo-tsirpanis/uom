using Dai19090.DistributedSystems.SigmaBank;
using Dai19090.DistributedSystems.SigmaBank.Data;
using Dai19090.DistributedSystems.SigmaBank.Transport.Grpc;
using Grpc.Core;
using Grpc.Core.Interceptors;
using System.Reflection;

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
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new() { Title = "Sigma Bank REST API", Version = "v1" });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.MapGrpcService<BankGrpcReceiver>();

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
