# nexus/core/

This folder defines the base NEXUS ontology.

## Purpose

To hold the minimal canonical definitions that sit just above graph theory.

## Canonical files

- `ontology.md` — human and LLM-readable ontology explanation
- `ontology.toml` — machine-loadable ontology representation
- `ids.md` — stable concept IDs and naming guidance

## Notes

This folder is intentionally small and conservative.

Changes here should be rare and deliberate because they affect the whole system.

## Core separation

NEXUS separates:
- structure
- relation
- meta
- classification

This keeps mental models clear and prevents meaning from being confused with structure.
