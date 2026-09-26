# HdMdNxM4kzEControllerFactory

> **Public-repository boundary.** This reference intentionally documents generic source structure only. Do not add customer-specific context, internal architecture rationale, deployment topology, credentials, or private cross-repository contracts here.


| Field | Source-grounded value |
|---|---|
| Repository | `PepperDash.Essentials.DM` |
| Source file | [`src/Chassis/HdMdNxM4KzEController.cs`](../../../src/Chassis/HdMdNxM4KzEController.cs) |
| Language | C# |
| Declaration | `class HdMdNxM4kzEControllerFactory` with declared base/contract list `EssentialsPluginDeviceFactory<HdMdNxM4kzEController>` |
| Accessibility | `public` |
| Namespace/module | `PepperDash.Essentials.DM.Chassis` |

## What

`HdMdNxM4kzEControllerFactory` is a construction boundary that maps configuration or discovery inputs into concrete objects. This description is grounded in its source declaration and declared inheritance rather than inferred product behavior.

## Why

The type exists to provide a named boundary in the codebase. Its inheritance, implemented contracts, and public members define what surrounding code may rely on. Preserve that boundary unless a deliberate repository-wide compatibility change is intended.

## How it works

Preserve the declared inheritance/contract relationship: `EssentialsPluginDeviceFactory<HdMdNxM4kzEController>`. Public methods declared in this source file include: `ClearRoute`, `EnableHdcp`, `DisableHdcp`, `EnableAutoRoute`, `DisableAutoRoute`, `ExecuteSwitch`, `ExecuteNumericSwitch`, `LinkToApi`, `BuildDevice`. Use repository search to identify callers, implementers, serializers, tests, and configuration references before changing a public name or shape.

## When to modify it

Edit when construction, type registration, or configuration validation changes. Confirm registration and configuration names from source before modifying.

## AI-agent change protocol

Before proposing a change, read this declaration, its full source file, all repository references to `HdMdNxM4kzEControllerFactory`, and its test coverage. Do not invent configuration keys, payload fields, interface members, or lifecycle ordering. Report the affected source files, tests, and consumer boundaries with any proposed change.

## Source authority

The source file linked above is authoritative. This generated reference is an index and decision aid; update it after a declaration, inheritance list, or public member contract changes.
