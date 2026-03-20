# NEXUS Base Ontology

NodeId: `nexus.core.ontology`

## Purpose

NEXUS is a graph-centered ontology that stays only slightly above graph theory.

It separates:

- Structure — what exists
- Relation — how structure connects
- Meta — how structure is interpreted
- Classification — labels that help keep mental models clear

This separation is important because structure and meaning are not the same.

---

## Core categories

### Structure

Structure defines what exists as first-class things in the graph.

#### Node
Category: Structure  
NodeId: `nexus.node`

A distinct thing in the graph.

Semantics:
- A node is an identifiable unit.
- A node has no required meaning by itself.
- Meaning is assigned later through meta-layer interpretation.

Examples:
- a software command node
- a biological signal node
- a knowledge fact node
- a UI view node

#### Boundary
Category: Structure  
NodeId: `nexus.boundary`

A structural point or region where one context hands off to another.

Semantics:
- A boundary separates contexts while allowing handoff.
- A boundary may be represented as a node or as a region depending on lens.
- Storage, API surfaces, and interfaces are often boundary realizations in domain-specific lenses.

Examples:
- event store boundary
- API boundary
- UI boundary
- file system boundary

#### Context
Category: Structure  
NodeId: `nexus.context`

A bounded region of the graph where a subset of nodes and relations operate together under a specific scope.

Semantics:
- Context is structural, not merely semantic.
- Context answers: what belongs together here?
- Context may contain nodes, relations, and boundaries.

Examples:
- Order Processing context
- Shipping context
- Knowledge Capture context
- Cell Signaling context

---

### Relation

Relation defines how structural things connect.

#### Relation
Category: Relation  
NodeId: `nexus.relation`

A connection between nodes.

Semantics:
- Relation is the generic edge type.
- Domain-specific edges refine Relation.
- Relation alone does not imply derivation or causation.

Examples:
- relates_to
- connected_to
- associated_with

#### Derivation
Category: Relation  
NodeId: `nexus.derivation`

A specialized relation where one node is formed from, based on, or depends on another node.

Semantics:
- Derivation is directional.
- Derivation is the primitive behind projection, transformation, and downstream shaping.
- A node may have multiple independent derivations.

Examples:
- a read model derived from an event
- a report derived from source facts
- a summary derived from a document

Law:
- A node may have multiple independent derivations.

---

### Meta

Meta defines how structure is interpreted.

#### Lens
Category: Meta  
NodeId: `nexus.lens`

A selective view over the graph that reveals only some nodes, relations, or categories.

Semantics:
- A lens does not change the graph.
- A lens changes visibility, emphasis, or interpretation.
- Different lenses may reveal different aspects of the same underlying graph.

Examples:
- node lens
- edge lens
- timeline lens
- runtime lens
- storage lens

#### Domain
Category: Meta  
NodeId: `nexus.domain`

A coherent space of meaning applied to graph structure.

Semantics:
- Domain is not structure.
- Domain defines vocabulary and interpretation.
- The same graph structure may be interpreted differently in different domains.

Examples:
- Software Development
- Knowledge
- Biology
- Logistics
- Communication

#### Meaning
Category: Meta  
NodeId: `nexus.meaning`

A specific semantic interpretation assigned to a structural element within a domain.

Semantics:
- Meaning is not structure.
- Meaning maps a structural element to a role or interpretation.
- The same node may have different meanings in different domains or lenses.

Examples:
- node interpreted as Event in Software Development
- node interpreted as Fact in Knowledge
- node interpreted as Signal in Biology

---

### Classification

Classification helps organize structure without changing the graph itself.

#### Category
Category: Classification  
NodeId: `nexus.category`

A high-level grouping used to keep mental models straight.

Examples:
- Structure
- Relation
- Meta
- Classification

#### Kind
Category: Classification  
NodeId: `nexus.kind`

A category label used to classify a structural or meta element.

Semantics:
- Kind does not change structure.
- Kind is useful for validation, tooling, and readability.

#### Role
Category: Classification  
NodeId: `nexus.role`

A contextual classification of how an element is functioning in a specific lens or context.

Semantics:
- Role is lens-relative or context-relative.
- Role is not necessarily permanent.
- The same node may take different roles in different lenses.

Examples:
- Interface
- Command
- Event
- View
- Processor

---

## Minimal NEXUS laws

### Law 1
NodeId: `nexus.law.node-may-relate`

A node may relate to other nodes.

### Law 2
NodeId: `nexus.law.multiple-independent-derivations`

A node may have multiple independent derivations.

### Law 3
NodeId: `nexus.law.boundary-separates-contexts`

A boundary separates contexts while allowing handoff.

### Law 4
NodeId: `nexus.law.lens-reveals-partial-graph`

A lens reveals only part of the graph.

### Law 5
NodeId: `nexus.law.meaning-does-not-alter-structure`

Meaning does not alter structure.

---

## Event Modeling and software lens notes

At the software / Event Modeling layer, the canonical node sets are:

### Write side
- Interface
- Command
- Event

### Read side
- Event
- View
- Interface

Hard rule:
NEXUS modeling is always EITHER write side OR read side, never a combined chain.

Anti-pattern:
- Interface -> Command -> Event -> View

Correct:
- Write side: Interface, Command, Event
- Read side: Event, View, Interface

---

## Event Modeling placement

Event Modeling is better understood as a coordinated set of lenses, not a domain.

Examples:
- Node lens
- Behavior lens
- Timeline lens
- Example data lens
