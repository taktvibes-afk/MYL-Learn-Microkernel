# GitHub-Veroeffentlichung – Checkliste

**Projekt:** TaktVibes – Manage Your Life Community Learn Microkernel
**GitHub-Arbeitsstand:** Version **0.1.0**, Build **0008** (Vorbereitung; noch kein offizieller Release)

## A. Vor der ersten Veroeffentlichung

- [ ] Build 0006 als Referenz unveraendert aufbewahren.
- [ ] `MYL.LearnMicrokernel.sln` in Visual Studio 2019 oeffnen und **Debug und Release** erfolgreich erstellen.
- [ ] Befehle und Modulstart gemaess `TESTPLAN.md` testen.
- [ ] Buildnummer auf Startbild, AssemblyInfo (alle drei Projekte), README und Testplan vergleichen.
- [x] **MIT-Lizenz** als `LICENSE`-Datei eingefuegt (Copyright 2026 TaktVibes). Vor der Veroeffentlichung bitte den gewuenschten oeffentlichen Copyright-Namen nochmals kontrollieren.
- [ ] Sicherstellen, dass keine Zugangsdaten, privaten Dateien oder internen Projekte enthalten sind.

## B. Repository anlegen (GitHub-Website)

1. Bei GitHub ein **neues Repository** erstellen (Vorschlag: `MYL-Learn-Microkernel`).
2. Den **Inhalt des entpackten GitHub-Projektordners**, nicht die ZIP als einzige Datei, zum Repository hinzufuegen. Der README soll im Repository-Stamm liegen.
3. Beim Anlegen keine zweite README-Datei erzeugen lassen, da diese bereits existiert.
4. Projektbeschreibung beispielsweise: `TaktVibes MYL Community Learn Microkernel – C# educational plugin host (not an OS kernel).`
5. Erst nach erfolgreichem VS-2019-Test als fertig veroeffentlichen; MIT-Lizenzdatei ist bereits enthalten.

## C. Version / GitHub-Release

- Tag fuer die **erste offiziell getestete Freigabe** koennte `v0.1.0` heissen.
- Release-Text aus `CHANGELOG.md` ableiten.
- **Nicht behaupten**, dass der Windows-Build bestanden wurde, bevor er tatsaechlich geprueft wurde.
- Kein SHA-256-Manifest und keine digitale Signatur vorgesehen (Community-Werkstattregel).

**Wichtig:** Dieses ZIP ist ein Repository-Quellcodepaket und enthaelt **keine fertige kompilierte EXE**. Ein GitHub-Repository wurde noch nicht erstellt oder hochgeladen.
