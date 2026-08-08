# Contributing

## Build & run
- SDK is pinned via `global.json`. Install a matching .NET 10 SDK.
- Build solution: `dotnet build`
- Run application (Blazor Server and Client): `dotnet run --project HomePanel.Builder`

## Tests
- Run tests: `dotnet test`
- Tests use NUnit and the Constraint Model (e.g., `Assert.That(actual, Is.EqualTo(expected));`).

## Formatting & analyzers
- Follow `.editorconfig`. Run `dotnet format` if installed.
- Prefer explicit types in C# (do not use `var`) and follow the repository's C# style.

## Branching & PRs
- Work on feature branches off `main`.
- Keep changes small and focused. Document non-obvious decisions.
- Use descriptive commit messages and PR titles.

## Local secrets
- Do not commit secrets or API keys. Use user secrets or environment variables for local development.

## Notes
- This repository targets .NET 10 and contains a Blazor App. Preserve project structure and prefer minimal, targeted edits.