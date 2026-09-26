# DmTx401CController

> **Public-repository boundary.** This reference intentionally documents generic source structure only. Do not add customer-specific context, internal architecture rationale, deployment topology, credentials, or private cross-repository contracts here.


| Field | Source-grounded value |
|---|---|
| Repository | `PepperDash.Essentials.DM` |
| Source file | [`src/Endpoints/Transmitters/DmTx401CController.cs`](../../../src/Endpoints/Transmitters/DmTx401CController.cs) |
| Language | C# |
| Declaration | `class DmTx401CController` with declared base/contract list `DmTxControllerBase, ITxRoutingWithFeedback, IIROutputPorts, IComPorts, IHasFreeRun, IVgaBrightnessContrastControls` |
| Accessibility | `public` |
| Namespace/module | `PepperDash.Essentials.DM` |

## What

`DmTx401CController` is a source-level implementation type with responsibilities defined by its members and inheritance. This description is grounded in its source declaration and declared inheritance rather than inferred product behavior.

## Why

The type exists to provide a named boundary in the codebase. Its inheritance, implemented contracts, and public members define what surrounding code may rely on. Preserve that boundary unless a deliberate repository-wide compatibility change is intended.

## How it works

Preserve the declared inheritance/contract relationship: `DmTxControllerBase, ITxRoutingWithFeedback, IIROutputPorts, IComPorts, IHasFreeRun, IVgaBrightnessContrastControls`. Public methods declared in this source file include: `LinkToApi`, `ExecuteNumericSwitch`, `ExecuteSwitch`, `SetFreeRunEnabled`, `SetVgaBrightness`, `SetVgaContrast`. Use repository search to identify callers, implementers, serializers, tests, and configuration references before changing a public name or shape.

## When to modify it

Edit when the responsibility implied by the declaration or its public members changes. Inspect callers, tests, and configuration before changing signatures.

## AI-agent change protocol

Before proposing a change, read this declaration, its full source file, all repository references to `DmTx401CController`, and its test coverage. Do not invent configuration keys, payload fields, interface members, or lifecycle ordering. Report the affected source files, tests, and consumer boundaries with any proposed change.

## Source authority

The source file linked above is authoritative. This generated reference is an index and decision aid; update it after a declaration, inheritance list, or public member contract changes.
