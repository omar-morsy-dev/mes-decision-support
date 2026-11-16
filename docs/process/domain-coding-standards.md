# Domain Coding and Comment Standards

- Status: Initial conventions for MES.Domain
- Related issue: #10

## Names and structure

- Public types use PascalCase; parameters, locals, and private fields use
  camelCase (`_field` for instance fields). One primary public type per file.
- Domain objects use domain vocabulary (`ProductionOrder`, not `OrderDto`).
- Do not add EF Core annotations, ASP.NET Core types, UI code, or SQL concerns
  to `MES.Domain`.
- Expose operations through intention-revealing methods rather than mutable
  public setters. Use `IReadOnlyCollection<T>` for aggregate child collections.
- Keep application service interfaces and infrastructure implementations
  separate from domain objects.

## Validation and failures

- Enforce invariants on construction and every state-changing method.
- For invalid user-supplied command values, fail with a clear domain validation
  error (an initial domain-specific exception is acceptable).
- Illegal lifecycle transitions fail with a distinct domain state error.
- Never silently coerce invalid quantities, identities, or durations.
- Use `decimal` for physical or quantity values needing exact base-10
  representation; use explicit units. Use `TimeSpan` for operation durations.
- Avoid hidden calls to current time, database, network or random generators
  inside business-rule evaluation. Supply needed values explicitly.

## Comment policy

- Write XML documentation for public contracts when the invariant, unit,
  lifecycle implication, or usage is not obvious.
- Write short `why` comments for non-obvious business rules and algorithmic
  trade-offs. Never restate obvious code (`// increment i`).
- Refer to the relevant ADR or research experiment when a rule needs context.
- Public APIs should make units and error behavior clear; comments do not
  substitute for descriptive names or tests.
- Every PR includes review notes: what was verified, risks found, changes
  requested, and how concerns were resolved. Do not check boxes unless run.

## Required tests

- Test valid construction and invalid boundary inputs.
- Test lifecycle transitions, including rejected transitions.
- Test duplicate operation sequences and work-center references.
- Test that aggregate children cannot be mutated through a public collection.
- Add architecture tests later to enforce the `Domain` dependency boundary.

## Definition of Done additions

- The changed domain behavior has positive and negative tests.
- Business comments describe intent and constraints; no redundant comments.
- Changes have traceability to an issue and to the minimal thesis scope.
- Automated checks are green and PR verification evidence is recorded.
