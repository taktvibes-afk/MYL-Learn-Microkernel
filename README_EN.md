# TaktVibes · Manage Your Life · Community Learn Microkernel

**Version 0.1.0 / Build 0008 · Visual Studio 2019 · C# / .NET Framework 4.8**

A small educational **C# plugin host** with one test module. Despite its project name, this is **NOT an operating-system kernel**. It is an ordinary Windows console application. Plugins are .NET DLLs running in the **same process**. There is no process isolation, sandboxing, inter-process communication (IPC), or hardware access.

![Original design reference from Build 0004](docs/startbild-referenz-build0004.png)

*Actual screenshot from the earlier Build 0004. The same welcome-screen design is retained in Build 0008; the build number changes.*

## Try it

1. On Windows, install **Visual Studio 2019** with the **.NET desktop development** workload, and the **.NET Framework 4.8 targeting pack** if prompted.
2. Open `MYL.LearnMicrokernel.sln`.
3. Build the whole solution (`Build > Build Solution`). Set `MYL.LearnMicrokernel` as startup project if needed.
4. Run with **Ctrl+F5**. Try `status`, `ping`, `echo Hello`, `stop`, `start`, `splash`, and `exit`.

Project components:

- `MYL.LearnMicrokernel` — host and interactive console
- `MYL.LearnContract` — shared interfaces / contracts
- `MYL.LearnTestModule` — a sample plugin returning `PONG` for `PING`

The module is copied by the build to `MYL.LearnMicrokernel\bin\Debug\Modules` (or `Release`). Only load trusted DLLs: modules run with the host application's permissions.

## Documentation

- [German README and project overview](README.md)
- [Step-by-step learning guide (German)](LERNEN.md)
- [Test plan (German)](TESTPLAN.md)
- [Version policy (German)](VERSIONIERUNG.md)
- [Contributing](CONTRIBUTING.md)
- [Release instructions](GITHUB_RELEASE.md)
- [MIT license](LICENSE)

**Release status:** GitHub-ready source package, not yet an official or Windows-build-verified release. This public educational repository is available under the [MIT License](LICENSE) (Copyright 2026 TaktVibes). This does not license the separate private TaktVibes/MYL kernel. The private TaktVibes/MYL project is not included.
