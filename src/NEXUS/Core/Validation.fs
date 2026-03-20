namespace Nexus.Core

/// Minimal validation hooks for NEXUS content.
///
/// This starts small on purpose.
/// The goal is to create a clear place for validation logic without forcing
/// all rules to be executable immediately.

module Validation =

    let ensureUniqueIds<'a> (getId: 'a -> string) (items: 'a list) =
        let ids = items |> List.map getId
        let dupes =
            ids
            |> List.countBy id
            |> List.filter (fun (_, count) -> count > 1)

        if not dupes.IsEmpty then
            let message =
                dupes
                |> List.map fst
                |> String.concat ", "
            Error $"Duplicate IDs found: {message}"
        else
            Ok ()
