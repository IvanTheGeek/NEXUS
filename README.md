# NEXUS

This repository contains the current Git-based source of truth for the foundational NEXUS ontology and the executable code that works with it.

## Repository map

- `nexus/` — canonical knowledge content: ontology, laws, definitions, lenses, and examples
- `src/` — F# code that loads, validates, transforms, and projects canonical NEXUS content
- `site/` — website projection target, if and when you add it
- `tools/` — utilities and pipelines, if and when you add them later

## Source of truth rule

Canonical content lives under `nexus/`.

Code under `src/` works with canonical content but is not itself the ontology source of truth.

Generated or projected outputs must not silently replace canonical content.

## Start here

1. `nexus/core/ontology.md`
2. `nexus/laws/write-read-separation.md`
3. `nexus/core/ontology.toml`
4. `src/Nexus/Core/Types.fs`

## NEXUS system roles

- `LOGOS` — persisted knowledge and fact record
- `ATLAS` — studio for humans to shape and finalize graphs/specs
- `FORGE` — projection / build / materialization engine
- `CORTEX` — AI support layer that helps across all aspects of NEXUS

### Hard rule

Accepted outputs from ATLAS must be persisted into LOGOS.
