# 03 – Bottom-up-Integration

Lösung mit xUnit für die Grundaufgaben und den Expresszuschlag.
Quelle: https://github.com/gbssg-russo/m450/tree/main/bottom-up-integration

## Ausführen

Voraussetzung: .NET 10 SDK. Befehl in diesem Ordner ausführen.

```powershell
dotnet test tests/BottomUpIntegrationExercise.Tests/BottomUpIntegrationExercise.Tests.csproj
```

## Teststufen

1. `ItemWeightCalculatorTests` und `ShippingRateCalculatorTests` prüfen Artikelgewicht, Tarifgrenzen und ungültige Werte einzeln.
2. `ParcelWeightCalculatorTests` verwendet den echten Artikelrechner. Zwei Positionen ergeben zusammen 1 kg.
3. `ShippingQuotePlaceholderTests` verwendet einen Tarif-Platzhalter. Er zeichnet das übergebene Gewicht auf und liefert CHF 42.
4. `ShippingQuoteServiceTests` verwendet den echten Tarifrechner und prüft Gewicht, Preis und leere Pakete.
5. `ExpressQuoteTests` vergleicht Standard und Express an der 1-kg-Grenze und darüber. Express kostet CHF 7 mehr, das Gewicht bleibt gleich.
