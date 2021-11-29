FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY SigmaBank.Shared/*.csproj ./SigmaBank.Shared/
RUN dotnet restore SigmaBank.Shared/SigmaBank.Shared.csproj
COPY SigmaBank.Data/*.csproj ./SigmaBank.Data/
RUN dotnet restore SigmaBank.Data/SigmaBank.Data.csproj
COPY SigmaBank.Transport.Grpc/*.csproj ./SigmaBank.Transport.Grpc/
RUN dotnet restore SigmaBank.Transport.Grpc/SigmaBank.Transport.Grpc.csproj
COPY SigmaBank.Server.AspNetCore/*.csproj ./SigmaBank.Server.AspNetCore/
RUN dotnet restore SigmaBank.Server.AspNetCore/SigmaBank.Server.AspNetCore.csproj

COPY SigmaBank.Shared/. ./SigmaBank.Shared/
COPY SigmaBank.Data/. ./SigmaBank.Data/
COPY SigmaBank.Transport.Grpc/. ./SigmaBank.Transport.Grpc/
COPY SigmaBank.Server.AspNetCore/. ./SigmaBank.Server.AspNetCore/
RUN dotnet publish SigmaBank.Server.AspNetCore/SigmaBank.Server.AspNetCore.csproj --no-restore -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SigmaBank.Server.AspNetCore.dll"]
