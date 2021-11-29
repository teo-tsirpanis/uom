FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY SigmaBank.Shared/*.csproj ./SigmaBank.Shared/
RUN dotnet restore SigmaBank.Shared/SigmaBank.Shared.csproj
COPY SigmaBank.Transport.Grpc/*.csproj ./SigmaBank.Transport.Grpc/
RUN dotnet restore SigmaBank.Transport.Grpc/SigmaBank.Transport.Grpc.csproj
COPY SigmaBank.Client/*.csproj ./SigmaBank.Client/
RUN dotnet restore SigmaBank.Client/SigmaBank.Client.csproj

COPY SigmaBank.Shared/. ./SigmaBank.Shared/
COPY SigmaBank.Transport.Grpc/. ./SigmaBank.Transport.Grpc/
COPY SigmaBank.Client/. ./SigmaBank.Client/
RUN dotnet publish SigmaBank.Client/SigmaBank.Client.csproj --no-restore -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app
COPY --from=build-env /app/out .

ENV SOCKETS_ENDPOINT=127.0.0.1:5959
ENV GRPC_ENDPOINT=http://localhost:6060

ENTRYPOINT ["dotnet", "SigmaBank.Client.dll"]
