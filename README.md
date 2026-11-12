# MES Decision Support

A research-led, open-source reference project for natural-language querying and constraint-based production rescheduling in Manufacturing Execution Systems (MES).

**Status:** Foundation implementation in progress.
Manufacturing workflows, AI features, and production
deployment are not yet implemented.

## Research goals

1. Evaluate natural-language querying over MES data, comparing controlled tools and safe read-only Text-to-SQL.
2. Evaluate constraint-based production rescheduling against deterministic baselines.
3. Investigate multi-agent orchestration, explanation quality, safety, and human approval.

## Planned architecture

- **MES:** ASP.NET Core + Blazor + EF Core + SQL Server
- **Decision support:** Python + FastAPI, local model experiments, OR-Tools CP-SAT
- **Research:** versioned synthetic datasets, reproducible benchmarks, documented baselines
- **Deployment:** containerized reference deployment (later phase)

See [project charter](docs/research/project-charter.md) and [architecture principles](docs/architecture/principles.md).


## Development

### Requirements

- .NET 10 SDK
- Git
- Python 3.12+ for repository foundation validation

### Repository structure

```text
src/mes/
  MES.Domain/          # Manufacturing domain model
  MES.Application/     # Application contracts and use cases
  MES.Infrastructure/  # Infrastructure implementations
  MES.Api/             # ASP.NET Core API
  MES.Web/             # Blazor frontend

tests/
  MES.Domain.Tests/
  MES.Application.Tests/
  MES.Api.Tests/
```

### Restore and build

```powershell
dotnet restore src/mes/MES.slnx
dotnet build src/mes/MES.slnx --configuration Release
```

### Run tests

```powershell
dotnet test src/mes/MES.slnx --configuration Release
```

### Run the API

```powershell
dotnet run --project src/mes/MES.Api
```

Available endpoints:

| Endpoint | Description |
| --- | --- |
| `GET /` | Basic API information |
| `GET /health` | Application health |
| `GET /api/v1/system/info` | Version and UTC timestamp |

The API health endpoint currently reports application health
only. It does not validate database or AI service availability.

### Foundation validation

```powershell
python scripts/check_foundation.py
```

### Continuous integration

GitHub Actions runs:

- Repository foundation validation
- .NET 10 dependency restoration
- Release build with warnings treated as errors
- Automated unit and API integration tests

The .NET workflow runs on every pull request and on
pushes to the `main` branch.

### Current implementation status

The repository contains the initial .NET solution, project
references, infrastructure dependency injection, API endpoints,
and automated foundation tests.

Manufacturing domain logic, SQL Server persistence,
authentication, AI services, production scheduling, and
deployment are planned for subsequent milestones.



## Engineering process

Development follows an issue-driven workflow with
two-week sprint planning and short-lived branches.

Each functional change should have:
- A linked GitHub Issue
- Testable acceptance criteria
- Appropriate automated tests
- A documented Pull Request
- Successful required CI checks
- A structured self-review

See [Engineering Standards](docs/process/engineering-standards.md).

Significant architectural decisions are documented
under [docs/adr](docs/adr).

Manufacturing domain development is currently planned
under the Manufacturing Domain epic.

## Application status

The Blazor application currently presents project
information only.

Production execution and AI decision-support interfaces
have not yet been implemented.

## Safety and data

Never commit production manufacturing records, SAP exports, personal data, credentials, `.env` files, or legacy application dumps. Demo data must be synthetic or explicitly authorized for publication.

## Project conventions

- Trunk branch: `main`
- Changes: short-lived `feat/`, `fix/`, or `docs/` branches and reviewed pull requests
- Commits: Conventional Commits (`docs:`, `feat:`, `fix:`, `test:`, `ci:`)
- Each research claim must be supported by a reproducible experiment

## License

Not selected yet. Until a license is added, default copyright protections apply; public visibility does not grant open-source reuse rights.
