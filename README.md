# MiniVehicleAPI

Eine moderne Vehicle API mit Clean Architecture, Entity Framework Core und PostgreSQL.

## 🏗️ Architektur

- **API Layer**: ASP.NET Core Web API mit Swagger
- **Application Layer**: Business Logic und Services
- **Domain Layer**: Entities und Abstractions
- **Infrastructure Layer**: Entity Framework Core und PostgreSQL
- **Tests**: Unit Tests mit xUnit und FluentAssertions

## 🌳 Branching Strategy

### Branches

- **`master`**: Produktionsreifer Code (nur über Pull Requests)
- **`development`**: Hauptentwicklungsbranch (für Features)
- **`feature/*`**: Feature-Branches (z.B. `feature/user-authentication`)
- **`bugfix/*`**: Bugfix-Branches (z.B. `bugfix/vin-validation`)
- **`hotfix/*`**: Kritische Hotfixes (z.B. `hotfix/security-patch`)

### Workflow

1. **Feature entwickeln:**
   ```bash
   git checkout development
   git pull origin development
   git checkout -b feature/neue-funktion
   # Entwickeln...
   git add .
   git commit -m "Add: Neue Funktion implementiert"
   git push origin feature/neue-funktion
   ```

2. **Pull Request erstellen:**
   - Gehen Sie zu GitHub
   - Erstellen Sie einen Pull Request von `feature/neue-funktion` → `development`

3. **Nach Merge:**
   ```bash
   git checkout development
   git pull origin development
   git branch -d feature/neue-funktion
   ```

## 🚀 Setup

### Voraussetzungen
- .NET 9.0 SDK
- PostgreSQL
- Visual Studio 2022 oder VS Code

### Installation
```bash
git clone https://github.com/djzh23/MiniVehicleAPI.git
cd MiniVehicleAPI
dotnet restore
dotnet build
```

### Datenbank Setup
```bash
dotnet ef database update --project src/miniVehicleAPI.Infrastructure --startup-project src/MiniVehicleAPI.Api
```

### Starten
```bash
dotnet run --project src/MiniVehicleAPI.Api
```

## 📊 API Endpoints

- `GET /api/vehicles` - Alle Fahrzeuge abrufen
- `GET /api/vehicles/{id}` - Einzelnes Fahrzeug abrufen
- `POST /api/vehicles` - Neues Fahrzeug erstellen
- `PUT /api/vehicles/{id}` - Fahrzeug aktualisieren
- `DELETE /api/vehicles/{id}` - Fahrzeug löschen

## 🧪 Tests

```bash
dotnet test tests/MinivehicleAPI.Tests/
```

## 📝 Features

- ✅ Clean Architecture
- ✅ Entity Framework Core 9.0
- ✅ PostgreSQL Integration
- ✅ VIN-Validierung mit Duplikat-Prüfung
- ✅ Swagger/OpenAPI Dokumentation
- ✅ Unit Tests
- ✅ Automatische Datenbankinitialisierung
- ✅ Transaktionsmanagement

## 🔧 Entwicklung

### Neue Features hinzufügen
1. Erstellen Sie einen Feature-Branch von `development`
2. Entwickeln Sie die Funktionalität
3. Schreiben Sie Tests
4. Erstellen Sie einen Pull Request

### Code Standards
- Verwenden Sie aussagekräftige Commit-Messages
- Schreiben Sie Tests für neue Features
- Folgen Sie der Clean Architecture
- Dokumentieren Sie wichtige Änderungen

## 📄 Lizenz

MIT License
