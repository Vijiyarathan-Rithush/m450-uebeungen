# M450 – Applikationen testen

Übungen und Beispiele aus dem Modul M450. Jede Aufgabe hat eine eigene Anleitung und kann separat ausgeführt werden.

| Übung | Inhalt | Voraussetzung |
| --- | --- | --- |
| [01 · Bankkonto](01-bankkonto/) | Testgetriebene Entwicklung mit xUnit | .NET 8 |
| [02 · Test Doubles](02-test-doubles/) | Tests mit Platzhaltern und Mocks | .NET 10 |
| [03 · Bottom-up-Integration](03-bottom-up-integration/) | Paketgewicht, Versandtarife und Integrationstests | .NET 10 |
| [04 · BIE](04-bie/) | Unit-, Integrations- und Browser-Tests für die Einreise-App | .NET 10 und Chrome |

Die ersten drei Übungen lassen sich vom Repository-Root aus testen:

```sh
dotnet test 01-bankkonto/BankAccount.sln
dotnet test 02-test-doubles/tests/TestDoublesExercise.Tests/TestDoublesExercise.Tests.csproj
dotnet test 03-bottom-up-integration/tests/BottomUpIntegrationExercise.Tests/BottomUpIntegrationExercise.Tests.csproj
```

Die [BIE-Anleitung](04-bie/README.md) enthält die separaten Schritte für die Web-App und die Browser-Tests.
