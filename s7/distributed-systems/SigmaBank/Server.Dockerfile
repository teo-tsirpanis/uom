FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY SigmaBank.Shared/*.csproj ./SigmaBank.Shared/
RUN dotnet restore SigmaBank.Shared/SigmaBank.Shared.csproj
COPY SigmaBank.Data/*.csproj ./SigmaBank.Data/
RUN dotnet restore SigmaBank.Data/SigmaBank.Data.csproj
COPY SigmaBank.Server/*.csproj ./SigmaBank.Server/
RUN dotnet restore SigmaBank.Server/SigmaBank.Server.csproj

COPY SigmaBank.Shared/. ./SigmaBank.Shared/
COPY SigmaBank.Data/. ./SigmaBank.Data/
COPY SigmaBank.Server/. ./SigmaBank.Server/
RUN dotnet publish SigmaBank.Server/SigmaBank.Server.csproj --no-restore -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SigmaBank.Server.dll"]
