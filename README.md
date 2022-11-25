# Témalaboratórium ORM generátor
## Projekt leírása

A projektem a kódgenerálás témakörben adott bepillantást, melyen belül az Entity Framework Core Database First generálását másoltam le T4 Text Templattel .NET keretrendszerben. Használata a projektemnek is teljesen hasonló, mely demonstrálva is van különböző lekérdezésekkel.

Ahhoz hogy legyen egy relációs adatbázisom melyből generálni lehessen, az MSSQL Servert használtam és ehhez ADO.NET technológiát használtam a különböző metaadatok kinyeréséhez. Ezen adatok segítségével képes voltam az objektum relációs leképezésére az adatbázisnak.

A kódgenerálást, mint említettem a T4 Text Templatettel készítettem el, mely egy irányító logika és szöveg blokkok alapján készít egy kimeneti fájlt. A fájl lehet egy html és txt fájl is, de esetemben egy .cs fájl.

Két fő kihívásom volt a munka során, az egyik a T4 szintaxisának a megértése és használatba ültetése, melyet ha előről kezdeném máshogy csinálnám. A másik pedig a bizonyos metaadatok kiszűrése az adatbázisból.

## Projekt tartalma és használata

A gyökérmappában található egy GeneratedModels és egy Models mappa, melyek közül az utóbbi a referenciaként használt EF Core generált kódja. Az utóbbi viszont maga a projekt, melyben található két .tt fájl amelyek végzik a generálást.

A ContextGenerator.tt fájl generálja a DbContextet, mely az összeköttetést jelenti az adatbázissal és az entity osztályainkkal.

A TableGenerator.tt fájl generálja a különböző entitás POCO-kat, melyek az adattárolásra szolgálnak. Sajnos egy .tt fájl nem képes több fájlt generálni, tehát egy .cs fájlban találhatók az említett entitások.

A projektemet használni úgy lehet, hogy ha egy új projektet hozunk létre, akkor a két .tt fájlt bemásoljuk az alkalmazásunk mappájába, majd a tt fájlok elején található "name" és "connectionString" mezőt a kívánt értékekre állítjuk. Ezután használhatjuk a programunkban úgy, mint az Entity Frameworköt.

## Linkek és megjegyzések
A T4 Text Template megértéséhez és az EF és relációs adatbázisok közötti ORM leképezés és metaadatainak feltérképezéséhez learn.microsoft.com-ot használtam.

Az adatbázishoz és EF sémájához az Adatvezérelt rendszerek nevű tárgy EF gyakorlatát és minta adatbázis scriptjét használtam fel.

Linkek:\
[https://learn.microsoft.com/en-us/visualstudio/modeling/writing-a-t4-text-template?view=vs-2022]\
[https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ole-db-schema-collections]\
[https://learn.microsoft.com/en-us/dotnet/api/system.data.oledb.oledbtype?view=dotnet-plat-ext-6.0]\
[https://learn.microsoft.com/en-us/sql/connect/oledb/ole-db-data-types/data-type-mapping-in-rowsets-and-parameters?view=sql-server-ver16]\
[https://bmeviauac01.github.io/adatvezerelt/db/]\
[https://bmeviauac01.github.io/adatvezerelt/gyakorlat/ef/]\