# TaktVibes / MYL Community Learn Microkernel – Versionsregeln

**Geltungsbereich:** Nur fuer das oeffentliche GitHub-Lehrprojekt. Unsere private Manage-Your-Life-Kernel-Versionierung bleibt unabhaengig.

## 1. Zwei getrennte Nummern

- **Version `MAJOR.MINOR.PATCH`**: Kennzeichnet eine fuer Nutzer freigegebene Version des Lernprojekts.
- **Build `0001`, `0002`, ...**: Jede neue gepackte Arbeitsfassung erhaelt eine **neue, niemals wiederverwendete** Buildnummer. Auch ein reines Design-/Doku-Update zaehlt.

## 2. Wann steigt die Versionsnummer?

- **PATCH** (`0.1.0` -> `0.1.1`): Fehlerkorrektur bzw. kleines Wartungsrelease.
- **MINOR** (`0.1.x` -> `0.2.0`): Neue, erklaerte Lernfunktion (z.B. zweites Modul).
- **MAJOR** (`0.x` -> `1.0.0`): Bewusst freigegebener stabiler Meilenstein.

Eine neue Buildnummer bedeutet **nicht automatisch** eine neue Produktversion. Die Version wird erst mit einem geplanten Release erhoeht. Nicht jeder Test-Build muss veroeffentlicht werden.

## 3. Aktuelle Historie

| Stand | Status | Bedeutung |
|---|---|---|
| 0.1.0 / Build 0004 | FROZEN (unveraenderlich) | Getesteter Startbild-/Modulstart-Referenzstand; weiterer VS-Test noch offen. |
| 0.1.0 / Build 0005 | Arbeitsstand | TaktVibes-Branding und Versionsregel; noch nicht als GitHub-Release freigegeben. |
| 0.1.0 / Build 0006 | Arbeitsstand (Referenz) | Rueckkehr zum Startbild von 0004; TaktVibes bleibt als Projektmarke erhalten. |
| 0.1.0 / Build 0007 | GitHub-Vorbereitung | Quellcode der 0006 uebernommen; Dokumentation/Release-Vorbereitung und reine Versionspflege, noch kein freigegebener Release. |
| 0.1.0 / Build 0008 | GitHub-Vorbereitung mit MIT-Lizenz | `LICENSE` und Lizenzhinweise ergaenzt, keine Laufzeit-Funktionsaenderung; VS-Test noch offen. |
| 0.1.1 / Build 0009 | Beispiel, nicht angelegt | Denkbares naechstes Wartungsrelease. |
| 0.2.0 / Build 0010 | Beispiel, nicht angelegt | Denkbare spaetere Funktionserweiterung. |

Die Beispiele sind keine vorweggenommenen Release-Zusagen. Buildnummern nur nach realer Erstellung vergeben.

## 4. Pflicht vor einem offiziellen Release

1. Den letzten funktionsfaehigen Stand unveraendert archivieren.
2. Neue Arbeitskopie mit fortlaufender Endnummer verwenden (z.B. `_005`, `_006`).
3. Vor dem Build alle Angaben in **Startbild, AssemblyInfo (3 Projekte), README, STARTBILD, TESTPLAN und Release-Dokumentation** angleichen.
4. Gesamte Projektmappe in VS 2019 (Debug und Release) fehlerfrei erstellen und `TESTPLAN.md` lokal abhaken.
5. Erst dann GitHub-Version/Tag und Release veroeffentlichen.
6. An dem eingefrorenen Referenzstand nie etwas ueberschreiben.

## 5. Identitaet

**TaktVibes** = Projektmarke; **Manage Your Life / MYL** = Projektfamilie; **Learn Microkernel** = oeffentliches Lehrprojekt.

Es handelt sich technisch um eine **C#-Windows-Konsolenanwendung mit Plugin-/Modulhost**, nicht um einen Kernel eines Betriebssystems und nicht um den privaten TaktVibes.Kernel.
