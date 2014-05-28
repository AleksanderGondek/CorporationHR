# Bezpieczeństwo Systemów Komputerowych
## Projekt – Implementacja mechanizmów kontroli dostępu do baz danych
### Autorzy: Aleksander Gondek 131508, Krzysztof Duda  131491

Celem projektu było zaimplementowanie modelu MAC do ochrony bazy danych typu MSSQL. Realizacja została w całości wykonana w oparciu o narzędzia udostępniane przez platformę .NET 4.0

### 1.	Opis projektu
W ramach projektu została zaimplementowana aplikacja internetowa służąca do przeglądania i analizy technologii opracowanych i opracowywanych w korporacji. Użytkownik naszej aplikacji może przeglądać technologie rozwijane przez naszą firmę, poznać ich autorów, sprawdzić stan patentów czy też poznać plany firmy dotyczące poszczególnych wynalazków. 
Mechanizmem kontroli dostępu implementowanym w naszym projekcie jest MAC, co sprawia iż każdy użytkownik naszej aplikacji ma przypisaną „przepustkę” od której zależeć będzie co takiego zobaczy w naszej bazie danych i w jakie będą możliwości zapisywania informacji (zasada: no-read-up, no-write-down). 

### 2.	Użyte technologie
Do stworzenia naszej aplikacji internetowej posłużymy się następującymi technologiami:
* .NET MVC 4 - Framework do realizowania aplikacji internetowych, używać go będziemy w języku C#
* Entity Framework 5 - Framework ORM do „rozmowy” z bazą danych
* MSSQL Express 2012  - Baza danych
* Ninject 3.2 – narzędzie do Dependency Injection dla naszej aplikacji
* Boostrap 3 – Front-end framework
* Visual Studio 2013 – IDE do programowania i testowego deploymentu witryny internetowej

### 3. Jak uruchomić ?
Potrzebne będzie wyłącznie środowisko programowania Visual Studio 2013 wraz z menadżerem paczek Nuget - budowanie projektu powinno przebiec bezproblemowo, wystarczy następnie uruchomić projekt.

Uwaga
> Domyslnie włączone jest obowiązkowe łączenie się poprzez SSL i przekierowanie na adres https aplikacji. Jeżeli lokalny IIS Express robi problemy, należy wyłączyć to przekierowanie i usunąć w całym projekcie linijkę kodu "[RequireHttps]"