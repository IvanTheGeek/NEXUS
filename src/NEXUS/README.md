# src/Nexus/

This folder contains executable F# code for working with canonical NEXUS content.

## Important distinction

The ontology source of truth lives under `/nexus/`.

Code in this folder loads, validates, transforms, and projects that content.
It should not silently redefine canonical ontology terms in a way that diverges from `/nexus/`.

## Typical contents

- loaders
- validators
- graph models
- projection helpers
