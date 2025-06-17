# Weather Data Collector

Tento C# program pravidelně stahuje meteorologická data ve formátu XML a ukládá je do databáze.

## Funkce

- Každou **1 hodinu** ukládá aktuální data ze senzorů 
- Každý **1 den** ukládá denní informace.
  
- Následně je ukládá do databáze udělanou přes SQLite
- V databázi jsou dvě tabulky jedna pro 10hodinové data jedna pro každodení data.
- Pro zobrazení databáze jsem použil DBBrowser
- db file a config file se nachází v **bin\Debug\net9.0**
  
## Použité NuGet
- EF 
- .NET.Configuration
- Newtonsoft.Json

## Čas

- Tato práce zabrala cca 3 hodiny 

## Konfigurace

URL pro získání dat je uloženo v souboru `config.json` pro Jednoduchou úpravu bez nutnosti kompilovat kod znovu.


```json
"MeteoSettings": {
  "DataUrl": "https://example.com/data.xml"
}



