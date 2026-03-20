namespace Nexus.Core

/// Core NEXUS types
///
/// Structure, Relation, Meta, and Classification are explicitly separated.
/// Meaning must not alter structure.

[<Struct>]
type Id = Id of string

// -----------------------------
// Classification
// -----------------------------

type Category =
    | Structure
    | Relation
    | Meta
    | Classification

// Roles are lens/context dependent
type Role =
    | Interface
    | Command
    | Event
    | View
    | Processor
    | Custom of string

// -----------------------------
// Structure
// -----------------------------

type Node =
    { Id: Id
      Label: string option
      Roles: Role list }

type Boundary =
    { Id: Id
      Label: string option
      FromContext: Id option
      ToContext: Id option }

type Context =
    { Id: Id
      Label: string option
      Parent: Id option }

// -----------------------------
// Relation
// -----------------------------

type Relation =
    { Id: Id
      Source: Id
      Target: Id
      Label: string option }

/// Derivation = directional dependency
/// One node may have many independent derivations

type Derivation =
    { Id: Id
      Source: Id
      Target: Id
      Label: string option
      IsIndependent: bool }

// -----------------------------
// Meta
// -----------------------------

type Lens =
    { Id: Id
      Label: string option
      Description: string option }

type Domain =
    { Id: Id
      Label: string
      Description: string option }

/// Meaning assigns interpretation only
type Meaning =
    { Id: Id
      DomainId: Id
      Label: string
      Description: string option }

// -----------------------------
// Bindings
// -----------------------------

type NodeMeaning =
    { NodeId: Id
      MeaningId: Id }

type RelationMeaning =
    { RelationId: Id
      MeaningId: Id }

// -----------------------------
// Graph container
// -----------------------------

type NexusGraph =
    { Nodes: Node list
      Boundaries: Boundary list
      Contexts: Context list
      Relations: Relation list
      Derivations: Derivation list
      Lenses: Lens list
      Domains: Domain list
      Meanings: Meaning list
      NodeMeanings: NodeMeaning list
      RelationMeanings: RelationMeaning list }
