# --------- 1. Build Stage (mit SDK) ----------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
# Alles ins Image kopieren (relativ zum Kontext)
COPY . .
# Nur das API-Projekt restoren & publishen
RUN dotnet restore src/MiniVehicleAPI.Api/MiniVehicleAPI.Api.csproj
RUN dotnet publish src/MiniVehicleAPI.Api/MiniVehicleAPI.Api.csproj -c Release -o /app/publish


# --------- 2. Runtime Stage (leichteres Image) ----------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
# Publizierte Dateien aus Build-Stage kopieren
COPY --from=build /app/publish .
# Optional: Port-Doku (nur Info)
EXPOSE 80
# Startbefehl für die API
ENTRYPOINT ["dotnet", "MiniVehicleAPI.Api.dll"]