# Architecture principles — initial ADR notes

1. Operational writes are performed only by the MES application after explicit authorization and human approval.
2. AI services have no direct write credentials to MES persistence.
3. Every proposed schedule includes a machine-verifiable constraint check, explanation and revision/version metadata.
4. Natural-language queries use restricted tools or validated read-only SQL with least-privilege access.
5. Keep deterministic scheduling and query baselines to measure AI-related gains.
6. Testable vertical slices take priority over creating empty layers and scaffolding.
7. Separate synthetic public data from private company data; never import legacy secrets into the new repository.
