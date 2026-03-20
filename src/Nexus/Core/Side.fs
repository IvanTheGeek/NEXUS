namespace Nexus.Core

/// A NEXUS context is always modeled as either Write or Read.
/// Never both at once.
type Side =
    | Write
    | Read
