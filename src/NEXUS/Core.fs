namespace Nexus.Core

/// NEXUS stays slightly above graph theory.
///
/// This file separates:
/// - Structure: what exists
/// - Relation: how things connect
/// - Meta: how things are interpreted
/// - Classification: labels used for organization and tooling
///
/// Important semantic rule:
/// Meaning and Domain do not alter structure.
/// They interpret structure.

[<Struct>]
type Id = Id of string

// ======================================
// Classification
// ======================================

/// High-level category of an ontology element.
/// This is for clarity, validation, tooling, and mental models.
/// It does not change graph structure.
type Category =
    | Structure
    | Relation
    | Meta
    | Classification

/// A generic kind label.
/// Useful for classifying elements without changing structure.
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

/// A role is a context-relative or lens-relative interpretation.
/// Role is not necessarily permanent.
type Role =
    | InterfaceRole
    | CommandRole
    | EventRole
    | ViewRole
    | ProcessorRole
    | CustomRole of string

// ======================================
// Structure
// ======================================

/// A Node is a distinct thing in the graph.
///
/// Semantics:
/// - A node is an identifiable unit.
/// - A node has no required meaning by itself.
/// - Meaning is applied later through the meta layer.
type Node =
    { Id: Id
      Label: string option
      Roles: Role list }

/// A Boundary is a structural handoff point or region between contexts.
///
/// Semantics:
/// - A boundary separates contexts while allowing handoff.
/// - A boundary may be represented differently in different lenses.
type Boundary =
    { Id: Id
      Label: string option
      FromContext: Id option
      ToContext: Id option }

/// A Context is a bounded region of the graph where nodes and relations
/// operate together under a specific scope.
///
/// Semantics:
/// - Context is structural.
/// - Context answers: what belongs together here?
type Context =
    { Id: Id
      Label: string option
      ParentContext: Id option }

// ======================================
// Relation
// ======================================

/// Relation is the generic connection between two nodes.
///
/// Semantics:
/// - This is the base edge type.
/// - It does not by itself imply derivation, projection, or causation.
type Relation =
    { Id: Id
      Source: Id
      Target: Id
      Label: string option }

/// Derivation is a specialized relation where one node is formed from,
/// based on, or depends on another node.
///
/// Semantics:
/// - Directional.
/// - The primitive behind projection and downstream shaping.
/// - A node may have multiple independent derivations.
type Derivation =
    { Id: Id
      Source: Id
      Target: Id
      Label: string option
      IsIndependent: bool }

// ======================================
// Meta
// ======================================

/// A Lens selectively reveals part of the graph.
///
/// Semantics:
/// - A lens does not change structure.
/// - A lens changes visibility, emphasis, or interpretation.
type Lens =
    { Id: Id
      Label: string option
      Description: string option }

/// A Domain is a coherent space of meaning applied to structure.
///
/// Semantics:
/// - Domain is not structure.
/// - Domain defines vocabulary and interpretation.
type Domain =
    { Id: Id
      Label: string
      Description: string option }

/// Meaning assigns a specific semantic interpretation to a structural element
/// within a domain.
///
/// Semantics:
/// - Meaning is not structure.
/// - Meaning maps a structural element to a role or interpretation.
type Meaning =
    { Id: Id
      DomainId: Id
      Label: string
      Description: string option }

// ======================================
// Bindings / Interpretation
// ======================================

/// Binds a node to a meaning in a domain.
///
/// Example:
/// - Node X is interpreted as Event in Software Development
/// - Node X is interpreted as Fact in Knowledge
type NodeMeaning =
    { NodeId: Id
      MeaningId: Id }

/// Binds a relation to a meaning in a domain.
///
/// Example:
/// - Relation R is interpreted as produces
/// - Relation R is interpreted as projects_to
type RelationMeaning =
    { RelationId: Id
      MeaningId: Id }

/// Assigns a structural element to a context.
type Membership =
    | NodeInContext of NodeId: Id * ContextId: Id
    | RelationInContext of RelationId: Id * ContextId: Id
    | BoundaryInContext of BoundaryId: Id * ContextId: Id

/// Declares what a lens includes or emphasizes.
///
/// This is intentionally simple for an in-memory starting point.
type LensSelection =
    { LensId: Id
      IncludedNodeIds: Id list
      IncludedRelationIds: Id list
      IncludedBoundaryIds: Id list
      IncludedContextIds: Id list }

/// The complete in-memory graph.
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

// ======================================
// Semantics / Laws
// ======================================

module Laws =

    /// Law 1:
    /// A node may relate to other nodes.
    let nodeMayRelateToOtherNodes = true

    /// Law 2:
    /// A node may have multiple independent derivations.
    let nodeMayHaveMultipleIndependentDerivations = true

    /// Law 3:
    /// A boundary separates contexts while allowing handoff.
    let boundarySeparatesContextsWithHandoff = true

    /// Law 4:
    /// A lens reveals only part of the graph.
    let lensRevealsOnlyPartOfTheGraph = true

    /// Law 5:
    /// Meaning does not alter structure.
    let meaningDoesNotAlterStructure = true

// ======================================
// Example
// ======================================

module Example =

    let softwareDomain =
        { Id = Id "domain/software-development"
          Label = "Software Development"
          Description = Some "Domain for software-oriented meanings." }

    let eventMeaning =
        { Id = Id "meaning/software/event"
          DomainId = softwareDomain.Id
          Label = "Event"
          Description = Some "A recorded fact that something occurred." }

    let orderPlacedNode =
        { Id = Id "node/order-placed"
          Label = Some "OrderPlaced"
          Roles = [ EventRole ] }

    let orderStatusViewNode =
        { Id = Id "node/order-status-view"
          Label = Some "OrderStatusView"
          Roles = [ ViewRole ] }

    let orderPlacedToView =
        { Id = Id "derivation/order-placed/order-status-view"
          Source = orderPlacedNode.Id
          Target = orderStatusViewNode.Id
          Label = Some "derives_to"
          IsIndependent = true }