# Testplan – Community Learn Microkernel 0.1.0 · Build 0008

## A. Bauen in Visual Studio 2019

- [ ] `.sln` wird ohne fehlende Projekte geoeffnet.
- [ ] **Debug | Any CPU**: Gesamte Projektmappe erstellt ohne Fehler.
- [ ] `MYL.LearnMicrokernel\bin\Debug\MYL.LearnMicrokernel.exe` existiert.
- [ ] `MYL.LearnMicrokernel\bin\Debug\Modules\MYL.LearnTestModule.dll` existiert.
- [ ] **Release | Any CPU**: Gesamte Projektmappe erstellt ohne Fehler.

## B. Konsolenbefehle testen

| Aktion | Erwartung |
|---|---|
| Starten | Bewaehrtes farbiges MYL-COMMUNITY-Startbild mit **LEARN MICROKERNEL**, Hinweis **KEIN OS-KERNEL**, Version **0.1.0**, Build **0008**; **TaktVibes** im Konsolenfenstertitel (nicht als zusaetzliche Logozeile) |
| `status` | `myl.testmodule` mit `RUNNING` |
| `ping` | `PONG` |
| `echo Hallo` | `Hallo` |
| `stop` und `status` | `STOPPED` |
| `ping` bei gestopptem Modul | `ERROR: TARGET_OFFLINE` |
| `start` und `ping` | `RUNNING`, danach `PONG` |
| `splash` | Startbild erneut, Modulzustand bleibt erhalten |
| `exit` | Modul wird gestoppt und Kernel sauber beendet |

## C. Fehlerfall pruefen

- [ ] Nach dem Build testweise die DLL aus `...\Modules\` an einen sicheren Ort **verschieben**.
- [ ] Konsole starten: **0 modules found** und **SYSTEM LIMITED**; Programm beendet sich nicht unerwartet.
- [ ] DLL zuruecklegen und erneut starten: Testmodul wird wieder geladen.

**Hinweis:** Ein unbekanntes DLL-Modul ist keine geeignete Testdatei. Nur eigene/vertraute Module verwenden.

## D. Dokumentation pruefen

- [ ] `README.md` erklaert **Plugin-/Modulhost statt Betriebssystemkernel**.
- [ ] `LERNEN.md` erklaert Host, Plugin, Contract und den direkten Methodenaufruf.
- [ ] Klarer Sicherheitshinweis: Nur eigene/vertraute Plugins laden.

## E. Testnachweis

- Test-PC / Windows: ___________________________
- VS-Version: __________________________________
- Debug-Build: PASS / FAIL / OFFEN
- Release-Build: PASS / FAIL / OFFEN
- Laufzeittest: PASS / FAIL / OFFEN
- Beobachtungen: ________________________________

Der Stand wurde hier **nur statisch** kontrolliert. Ein MSBuild/.NET-Framework-Compiler fuer den echten Windows-Build war in dieser Arbeitsumgebung nicht vorhanden. Ein **Build-PASS** darf erst nach erfolgreichem lokalen Test gesetzt werden.

- [ ] GitHub-Dokumente (`README_EN.md`, `CONTRIBUTING.md`, `CHANGELOG.md`, `GITHUB_RELEASE.md`) sind vorhanden.
- [x] MIT-Lizenz als `LICENSE` eingefuegt; Copyright-Namen vor der Veroeffentlichung final bestaetigen.
