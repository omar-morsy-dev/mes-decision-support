# Engineering Standards



## Definition of Ready (DoR)

An issue is Ready when:

- The objective and value are clear.

- Scope and acceptance criteria are defined.

- Dependencies are identified.

- The issue is reasonably estimable.

- No unresolved blockers prevent implementation.



## Definition of Done (DoD)

An issue is Done when:

- Implementation is complete.

- Acceptance criteria have been verified.

- Required automated tests pass.

- GitHub Actions is green.

- Code changes have been self-reviewed.

- Required documentation is updated.

- The related PR has been merged.



## Branch Convention

- feat/<short-description>

- fix/<short-description>

- chore/<short-description>

- docs/<short-description>



## Commit Convention

- feat(domain): add production order

- fix(api): handle invalid quantity

- test(domain): cover lifecycle transitions

- docs(architecture): record identity decision



## Pull Request Policy

- One focused change per PR.

- Every functional PR links an Issue.

- Merges require successful CI checks.

- Self-review is documented.

- Main is the integration branch.



## Architecture Decision Records

Significant decisions are documented under docs/adr.

Each ADR includes context, decision, alternatives,

consequences and status.
