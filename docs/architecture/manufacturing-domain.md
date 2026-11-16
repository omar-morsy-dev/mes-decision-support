# Manufacturing Domain Boundaries (Generic Job Shop)

- Status: Initial architecture contract
- Related issues: #10, #11, #17, #18, #19

## Minimal research scenario

A factory dataset contains production orders with ordered operations. Each
operation requires an eligible work center, processing duration, and optional
machine assignment. Machines have finite availability; preceding operations
must finish before following ones start. Scheduling experiments use synthetic
resources, order due dates, and configurable constraints.

No SAP connection, PLC control, live factory writes, inventory, maintenance,
quality management, or operator payroll is included in the first research release.

## Aggregate and entity boundaries

| Concept | Type | Responsibility |
| --- | --- | --- |
| `ProductionOrder` | Aggregate root | Order identity, material reference, planned quantity, lifecycle and ordered operations |
| `ProductionOperation` | Child entity | Stable identity, sequence, required work center, planned duration; lifecycle changes through order |
| `WorkCenter` | Aggregate root | Logical manufacturing capability and active state |
| `Machine` | Aggregate root | Physical resource, work center association and availability metadata |
| `ExternalReference` | Value object | Source, scope, external value, and equality |
| `ScheduleProposal` | Later separate decision-support model | Candidate operation assignments, feasibility results and explanation; never modifies order automatically |

## Initial invariants

1. Production order material and external reference are nonblank; planned
   quantity is strictly positive and has an explicit unit of measure.
2. Creation establishes a documented initial lifecycle state. Allowed
   transitions are explicit; prohibited transitions throw a domain exception.
3. Operation sequence values are positive and unique within an order.
4. Operation planned durations are strictly positive. Precedence derives from
   sequence; no duplicate sequence numbers are accepted.
5. Work center and machine identities are stable. A machine belongs to one
   work center at a time; assignment eligibility is validated against a
   resource snapshot when scheduling.
6. A proposal cannot change live execution state; approval and application
   remain separate authenticated MES operations.

## Ownership rules

- `ProductionOrder` controls adding, removing, and reordering operations.
- Changes that need multiple aggregates are coordinated in an application
  use case, not in a cross-aggregate domain object.
- A schedule solver works from immutable input snapshots and returns a
  proposal. It does not edit `ProductionOrder`, `Machine`, or SQL tables.
- Read-only querying uses approved application tools or independently
  validated read-only SQL, never unrestricted domain repository access.

## Research traceability

- RQ1: orders, operations, and resources define the testable query schema.
- RQ2: precedence, duration, eligibility, and machine availability define
  initial scheduling constraints and baseline comparisons.
- RQ3: proposals and controlled approval boundaries define agent safety.

## Deferred decisions

Exact scheduling horizons, setup times, shift calendars, capacity nuances,
preemption, multi-machine operations, and units need explicit experimental
requirements before implementation. These are not implied by this document.
