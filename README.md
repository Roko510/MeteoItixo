# Weather Data Collector

Tento C# program pravidelně stahuje meteorologická data ve formátu XML a ukládá je do databáze.

## Funkce

- Každých **10 hodin** ukládá aktuální data ze senzorů 
- Každý **1 den** ukládá denní informace.
  
- Následně je ukládá do databáze udělanou přes SQLite
- V databázi jsou dvě tabulky jedna pro 10hodinové data jedna pro každodení data.
- Pro zobrazení databáze jsem použil DBBrowser
  
## Použité NuGet
- EF 
- .NET.Configuration
- Newtonsoft.Json

## Konfigurace

URL pro získání dat je uloženo v souboru `config.json` pro Jednoduchou úpravu bez nutnosti kompilovat kod znovu.

```json
"MeteoSettings": {
  "DataUrl": "https://example.com/data.xml"
}
