# Branching and Commit Conventions

## Purpose

Ensure that all work in the NEXUS repository is clearly categorized and traceable by type of change.

---

## Branch Naming

Branches should reflect the type of NEXUS work being performed.

### Patterns

- `law/...`
- `def/...`
- `lens/...`
- `feat/...`
- `refactor/...`

### Examples

- `law/write-read-separation`
- `def/base-ontology-reconcile`
- `lens/node-lens-refinement`
- `feat/graph-loader`
- `refactor/context-structure`

---

## Commit Naming

Commits should indicate the type of NEXUS change.

### Format

```
<type>(<scope>): <description>
```

### Types

- `law` — changes or additions to NEXUS laws
- `def` — definitions, ontology, or conceptual structure
- `lens` — lens additions or modifications
- `feat` — new functionality or capability
- `refactor` — restructuring without changing meaning

### Examples

- `law(write-read): enforce separation rule`
- `def(core): add derivation semantics`
- `lens(node): clarify node-only representation`
- `feat(loader): parse ontology.toml`
- `refactor(core): simplify context structure`

---

## Key Principle

Every change should clearly communicate:

- What kind of NEXUS change it is
- What part of the system it affects

This ensures clarity for humans, AI systems, and tooling.
