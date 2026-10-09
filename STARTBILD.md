# Startbild – Vorschau (Build 0008)

Beim Start erscheint ein farbiges ASCII-Panel in der Windows-Konsole:

```text
 +--------------------------------------------------------------------+
 |                                                                    |
 |                              M Y L                                 |
 |                                                                    |
 |                  M A N A G E   Y O U R   L I F E                   |
 |                         C O M M U N I T Y                          |
 |                                                                    |
 |                L E A R N   M I C R O K E R N E L                   |
 |               C# PLUGIN-/MODULHOST - KEIN OS-KERNEL                |
 |             VERSION 0.1.0 | BUILD 0008 | COMMUNITY EDITION         |
 +--------------------------------------------------------------------+

 [MODULES ] 1 module found / 1 running
 [SYSTEM  ] READY

 MYL> _
```

Der Hinweis **"KEIN OS-KERNEL"** soll von Anfang an zeigen: Das ist ein **C#-Plugin-/Modulhost**, keine Betriebssystem-Komponente.

Die Grafik ist eine **vereinfachte Textvorschau**, kein Laufzeit-Screenshot. Die echte Ausgabe liegt in `MYL.LearnMicrokernel/StartupScreen.cs` und hat ein groesseres ASCII-MYL-Logo, Farbe, Willkommenstext und Befehlsliste. `splash` zeigt das Logo erneut. Falls kein Modul geladen ist, erscheint `LIMITED` statt `READY`.

Das bewährte **Startbild von Build 0004** ist in Aufbau, Farben und Reihenfolge wiederhergestellt; nur die angezeigte Buildnummer wurde aktualisiert. **TaktVibes** bleibt in Konsolenfenstertitel, Assembly-Metadaten und Dokumentation enthalten, ohne das gewohnte Startbild zu veraendern.
