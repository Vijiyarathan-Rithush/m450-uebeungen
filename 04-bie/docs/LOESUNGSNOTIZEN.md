# BIE – Lösungsnotizen

## Testebenen

- Eine Person liest den Code. Das ist ein statisches Review. Der Code wird dabei nicht ausgeführt.
- Der Test von `EntryPolicy.Evaluate` ist ein Unit-Test. Er prüft die Fachregel ohne HTTP oder Datenbank.
- Der Test mit POST, GET und SQLite ist ein Integrationstest. Er erkennt beispielsweise falsche HTTP-Statuscodes, Fehler beim Speichern oder falsch ausgelesene Werte.
- Der Selenium-Test ist ein E2E-Test. Er prüft, ob das Formular den Antrag abschickt und die Oberfläche das Ergebnis sowie den gespeicherten Fall anzeigt.

## Tourismusgrenze

30 Tage ist der letzte erlaubte Wert. Ein Fehler mit `>= 30` würde bei 10 Tagen unbemerkt bleiben. 29, 30 und 31 Tage prüfen beide Seiten und die Grenze selbst. Ein Unit-Test passt dafür, weil die Regel allein in `EntryPolicy` liegt.

## Browser und Neuladen

Nach dem Neuladen baut die App die Liste erneut aus der API auf. Damit prüft der Test auch, ob der richtige Fall im Register erscheint. Der Test wartet auf das sichtbare Ergebnis und dann auf die Zeile mit der Fall-ID. Eine feste Pause könnte auf einem langsameren Rechner zu kurz sein.

## Abschlussfragen

1. Ja. Ein Unit-Test ist auch ein Regressionstest, wenn er einen bekannten Fehler bei einer späteren Änderung erkennt. Der 30-Tage-Fall erkennt die falsche Grenze.
2. Der Browser kann beispielsweise wegen eines falschen Selektors oder einer fehlerhaften API-Anfrage scheitern, obwohl die isolierte Fachregel korrekt entscheidet.
3. Der Merge bleibt blockiert, wenn ein gültiges Partnerreview fehlt oder der Branch gemäss Schutzregel noch aktualisiert werden muss. Neue Commits können eine frühere Zustimmung verwerfen.

Partnerreview und Merge werden im Pull Request dokumentiert.
