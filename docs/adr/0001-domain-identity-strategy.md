
# ADR-0001: Domain Identity Strategy

- Status: Proposed
- Date: 2026-11-11
- Area: Manufacturing Domain

## Context

The MES must represent production orders, operations,
work centers, machines, and external SAP references.

Internal identity and external business identifiers
have different responsibilities.

## Proposed Decision

Use stable internal identifiers for domain entities.

Represent external identifiers explicitly and
do not assume they are globally unique without
a defined source and scope.

Avoid coupling domain identity to persistence
or infrastructure implementation details.

## Alternatives

1. Use external SAP identifiers as entity identity.
2. Use database-generated integer identifiers.
3. Use application-assigned internal identifiers.

## Consequences

- External system identifiers remain integration data.
- Domain entities can exist before persistence.
- Mapping between internal and external identifiers
  must be handled explicitly.
- Uniqueness constraints must be defined by context.

## Open Questions

- Should internal identity use Guid, UUIDv7, or another type?
- Which external identifiers are unique within a plant?
- How are external identity collisions handled?
- How will identity mapping survive resynchronization?

## Decision Required

Finalize this ADR before completing the
ProductionOrder aggregate implementation.
