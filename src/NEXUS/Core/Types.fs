namespace Nexus.Core

/// These types are the executable in-memory representation of canonical NEXUS content.
/// They work with the ontology under /nexus/core/ but do not replace it.
///
/// Core.fs already existed earlier in the conversation, so this file is intentionally
/// separate and conservative.

[<Struct>]
type Id = Id of string

// =========================
// Classification
// =========================

type Category =
    | Structure
    | Relation
    | Meta
    | Classification

type Kind =
    | NodeKind
    | BoundaryKind
    | ContextKind
    | RelationKind
    | DerivationKind
    | LensKind
    | DomainKind
    | MeaningKind
    | RoleKind

type Role =
    | InterfaceRole
    | CommandRole
    | EventRole
    | ViewRole
    | ProcessorRole
    | CustomRole of string

// =========================
// Structure
// =========================

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
      ParentContext: Id option }

// =========================
// Relation
// =========================

type Relation =
    { Id: Id
      Source: Id
      Target: Id
      Label: string option }

type Derivation =
    { Id: Id
      Source: Id
      Target: Id
      Label: string option
      IsIndependent: bool }

// =========================
// Meta
// =========================

type Lens =
    { Id: Id
      Label: string option
      Description: string option }

type Domain =
    { Id: Id
      Label: string
      Description: string option }

type Meaning =
    { Id: Id
      DomainId: Id
      Label: string
      Description: string option }

// =========================
// Bindings / Interpretation
// =========================

type NodeMeaning =
    { NodeId: Id
      MeaningId: Id }

type RelationMeaning =
    { RelationId: Id
      MeaningId: Id }

type Membership =
    | NodeInContext of NodeId: Id * ContextId: Id
    | RelationInContext of RelationId: Id * ContextId: Id
    | BoundaryInContext of BoundaryId: Id * ContextId: Id
    | DerivationInContext of DerivationId: Id * ContextId: Id

type LensSelection =
    { LensId: Id
      IncludedNodeIds: Id list
      IncludedRelationIds: Id list
      IncludedBoundaryIds: Id list
      IncludedContextIds: Id list }

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
      RelationMeanings: RelationMeaning list
      Memberships: Membership list
      LensSelections: LensSelection list }

module Laws =

    let nodeMayRelateToOtherNodes = true
    let nodeMayHaveMultipleIndependentDerivations = true
    let boundarySeparatesContextsWithHandoff = true
    let lensRevealsOnlyPartOfTheGraph = true
    let meaningDoesNotAlterStructure = true
