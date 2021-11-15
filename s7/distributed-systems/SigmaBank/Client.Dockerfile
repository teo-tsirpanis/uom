FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY SigmaBank.Shared/*.csproj ./SigmaBank.Shared/
RUN dotnet restore SigmaBank.Shared/SigmaBank.Shared.csproj
COPY SigmaBank.Client/*.csproj ./SigmaBank.Client/
RUN dotnet restore SigmaBank.Client/SigmaBank.Client.csproj

COPY SigmaBank.Shared/. ./SigmaBank.Shared/
COPY SigmaBank.Client/. ./SigmaBank.Client/
RUN dotnet publish SigmaBank.Client/SigmaBank.Client.csproj --no-restore -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app
COPY --from=build-env /app/out .

ENV SERVER_ENDPOINT=127.0.0.1:5959

ENTRYPOINT ["dotnet", "SigmaBank.Client.dll"]
