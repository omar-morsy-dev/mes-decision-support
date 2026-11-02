# MES Decision Support

A research-led, open-source reference project for natural-language querying and constraint-based production rescheduling in Manufacturing Execution Systems (MES).

> Status: foundation only. This repository does **not** yet contain a working MES or AI implementation.

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

The project currently has only foundation files. To validate locally:

```bash
python3 scripts/check_foundation.py
```

CI runs the same check. Application build and test jobs will be added when their projects are introduced.

## Safety and data

Never commit production manufacturing records, SAP exports, personal data, credentials, `.env` files, or legacy application dumps. Demo data must be synthetic or explicitly authorized for publication.

## Project conventions

- Trunk branch: `main`
- Changes: short-lived `feat/`, `fix/`, or `docs/` branches and reviewed pull requests
- Commits: Conventional Commits (`docs:`, `feat:`, `fix:`, `test:`, `ci:`)
- Each research claim must be supported by a reproducible experiment

## License

Not selected yet. Until a license is added, default copyright protections apply; public visibility does not grant open-source reuse rights.
