# Lernheft – TaktVibes / MYL Learn Microkernel 0.1.0

**Ziel:** Die ersten Grundlagen eines modularen C#-Programms verstehen. Keine Vorkenntnisse in Betriebssystementwicklung noetig.

## Vorab: "Microkernel" ist hier nur ein Projektname

Unser Learn Microkernel ist **kein Kernel eines Betriebssystems**. Ein echter OS-Kernel organisiert unter anderem Prozesse, Speicher und Hardware. Unser Beispiel ist dagegen eine **gewoehnliche C#-Konsolenanwendung fuer Windows**, die Plugins (Module) als DLLs einbindet.

```text
MYL.LearnMicrokernel.exe   <- Plugin-/Modulhost (normales Programm)
           |
           | benutzt die gemeinsamen Interfaces
           v
MYL.LearnContract.dll      <- Vereinbarung: Was muss ein Modul koennen?
           ^
           | implementiert die Interfaces
           |
MYL.LearnTestModule.dll    <- Plugin: antwortet z.B. auf PING
```

**Merkhilfe:** Die Anwendung ist der Gastgeber (Host), die Erweiterungen sind die Gaeste (Plugins). Alle laufen hier im **selben Prozess**. Das ist **keine echte IPC und keine Sicherheits-Sandbox**.

## Lektion 1: Wo startet das Programm?

**Datei:** `MYL.LearnMicrokernel/Program.cs`

- `Main()` wird beim Start der Konsolenanwendung aufgerufen.
- `StartupScreen.ShowWelcome()` zeigt das farbige Logo.
- Der Befehl `status` zeigt, ob das Modul laeuft.

**Uebung:** Aendere in `StartupScreen.cs` den Begruessungstext, baue die gesamte Projektmappe und starte erneut.

## Lektion 2: Was macht der Modulhost?

**Datei:** `MYL.LearnMicrokernel/KernelHost.cs`

1. `LoadModules()` sucht nach `.dll`-Dateien im Ordner `Modules`.
2. `StartAll()` startet das gefundene Testmodul.
3. `Send()` ruft `Receive()` des Zielmoduls direkt auf.
4. `StopAll()` beendet aktive Module.

**Uebung:** Tippe `stop`, dann `status` und dann `start`. Beobachte die Statusaenderung.

**Merke:** Das ist **keine** Prozess-IPC. Ein ungeprueftes Modul hat Zugriff auf denselben Prozess. Unbekannte DLLs duerfen nicht ausprobiert werden.

## Lektion 3: Warum brauchen wir einen Contract?

**Dateien:** `MYL.LearnContract/IModule.cs` und `IKernelContext.cs`

Ein **Interface** ist eine Vereinbarung: Jedes Modul hat eine ID und kann `Start`, `Stop` und `Receive` ausfuehren. Das Interface sagt nur **was** ein Modul koennen muss, nicht **wie**.

**Uebung:** Suche in `IModule.cs` das Mitglied `Receive(...)` und finde die dazugehoerige Methode im Testmodul.

## Lektion 4: Eine eigene Antwort einbauen

**Datei:** `MYL.LearnTestModule/TestModule.cs`

Das Modul antwortet bereits auf `PING` mit `PONG` und auf `ECHO Hallo` mit `Hallo`. Im Quellcode findest du:

```csharp
if (string.Equals(message, "PING", StringComparison.OrdinalIgnoreCase))
    return "PONG";
```

**Uebung:** Aendere testweise `"PONG"` zu `"PONG AUS MEINEM MODUL"`.
Baue die **gesamte Projektmappe**. Tippe danach `ping` in die Konsole: Die neue Antwort erscheint.

## Drei wichtige Begriffe

- **Plugin-/Modulhost:** Unser zentrales Programm, das DLL-Erweiterungen organisiert (kein OS-Kernel).
- **Plugin / Modul:** Eine eigene DLL, die den gemeinsamen Contract umsetzt.
- **Contract / Interface:** Feste Regeln fuer die Kommunikation zwischen Host und Modul.

## Ausblick

Erst wenn 0.1.0 lokal funktioniert, koennen wir in einer spaeteren Version z.B. ein zweites Modul, einfaches Logging oder eine besser strukturierte Nachrichtenklasse als Lernuebung hinzufuegen. Kein Anspruch auf produktive Sicherheit.
