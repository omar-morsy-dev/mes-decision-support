# Project charter — draft v0.1

## Working title
A Multi-Agent Decision Support System for Natural Language Querying and Constraint-Based Rescheduling in MES.

## Problem
MES information can require specialized query knowledge, while rescheduling must respect complex manufacturing constraints. Unvalidated language models should not directly execute operational changes.

## Research questions
- RQ1: How accurate and safe are read-only Text-to-SQL queries compared with approved tool-based querying for representative MES questions?
- RQ2: How does a CP-SAT rescheduler compare with simple dispatching heuristics for feasibility, tardiness, makespan and runtime?
- RQ3: Can a manager-plus-specialist multi-agent system reliably classify requests and provide transparent, auditable recommendations without unauthorized writes?

## Initial scope
- Synthetic, representative production orders, work centers, equipment, operations and constraints.
- Read-only operational analysis.
- Scheduling proposals with explicit user approval; no automatic shop-floor execution.
- Offline and reproducible evaluation datasets and baselines.

## Out of scope for the first release
- Live SAP integration, PLC control, factory actuation and unattended production decision execution.
- Claims of production safety without industrial verification.

## Release criteria (to refine)
- Repeatable builds and automated tests.
- Security review, threat model and auditability.
- Evaluated natural-language accuracy, SQL safety and scheduling feasibility.
- Documented datasets, baselines, runtime, reproducibility and known limitations.
