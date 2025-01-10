# Task Tracker - WebApp (.NET+Vue)

Nach der Variante für Android mit Kotlin und Jetpack-Compose,
habe ich mir als Ziel gesetzt eine Webapp zum Tracken von Aufgaben zu erstellen.
Damit könnte ich Aufgaben geräteübergreifend verwalten.

> [!NOTE]  
> :de: Dies ist ein Projekt zu Lernzwecken.
> Entsprechend sind einige Entwicklungsaspekte überbetont und andere vernachlässigt.
> In den [Referenzen](#referenzen) findest du Anleitungen, mit denen du ein eigenes Projekt starten kannst.
> 
> :us: This project exists for the purpose of learning.
> It does contain overengeneered parts as well as neglected parts.
> Do not expect anything to do something meaningful.
> See [references](#referenzen) for a list of tutorials to start your own project.

**Designentscheidungen**
+ CI-First.  
  Jedes professionelle Projekt beginnt mit CI, gefolgt von Hello-World und Tests.
+ Backend und Frontend als eigene Projekte.  
  Zu Lernzwecken von Web-APIs und deren Verwendung.
+ .NET Core Backend  
  Verwaltet eine Liste von täglichen Aufgaben.
  Auf Nutzerverwaltung mit Login habe ich vorerst verzichtet.
+ Vue.js Frontend  
  Nutzt die API um die Liste der Aufgaben zu zeigen.
  Perspektivisch soll auch bearbeiten und erledigen von Aufgaben hinzukommen.

# Referenzen
* Backend
  * ASP.NET
    * WebAPI: https://learn.microsoft.com/de-de/training/modules/build-web-api-aspnet-core/
    * testing: https://learn.microsoft.com/de-de/dotnet/core/testing/unit-testing-with-mstest
* Frontend
  * Vue.js
    * getting started: https://vuejs.org/guide/introduction.html
    * testing: https://vuejs.org/guide/scaling-up/testing
  * vitest
    * running tests: https://vitest.dev/guide/