namespace Nexus.Core

open System
open System.IO

/// Minimal starting loader.
///
/// This file is intentionally small. It gives you a stable place to grow
/// TOML loading logic without overcommitting too early.
///
/// Current behavior:
/// - reads the ontology TOML as text
/// - leaves parsing/normalization as the next step
///
/// Why keep this separate?
/// - /nexus/core/ontology.toml is canonical content
/// - this loader works with canonical content
/// - this code is not itself the source of truth

module Loader =

    let readOntologyToml (path: string) : string =
        if String.IsNullOrWhiteSpace path then
            invalidArg (nameof path) "Path must not be empty."

        if not (File.Exists path) then
            invalidArg (nameof path) $"Ontology TOML file not found: {path}"

        File.ReadAllText path

    let loadPlaceholder (path: string) : string =
        readOntologyToml path
