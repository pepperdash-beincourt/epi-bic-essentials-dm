# StubDevice

> **Public-repository boundary.** This reference intentionally documents generic source structure only. Do not add customer-specific context, internal architecture rationale, deployment topology, credentials, or private cross-repository contracts here.


| Field | Source-grounded value |
|---|---|
| Repository | `PepperDash.Essentials.DM` |
| Source file | [`tests/DmRouteFeedbackTrackerTests.cs`](../../../tests/DmRouteFeedbackTrackerTests.cs) |
| Language | C# |
| Declaration | `class StubDevice` with declared base/contract list `IRoutingInputs, IRoutingOutputs` |
| Accessibility | `private` |
| Namespace/module | `PepperDash.Essentials.DM.Tests` |

## What

`StubDevice` is a device-model type that owns lifecycle, controls, feedback, or communication responsibilities. This description is grounded in its source declaration and declared inheritance rather than inferred product behavior.

## Why

The type exists to provide a named boundary in the codebase. Its inheritance, implemented contracts, and public members define what surrounding code may rely on. Preserve that boundary unless a deliberate repository-wide compatibility change is intended.

## How it works

Preserve the declared inheritance/contract relationship: `IRoutingInputs, IRoutingOutputs`. Public methods declared in this source file include: `Breakaway_audio_and_video_to_same_output_are_tracked_independently`, `Re_routing_one_signal_type_replaces_only_that_descriptor`, `Null_input_clears_only_that_signal_and_returns_a_clear_descriptor`, `Distinct_outputs_are_tracked_independently`, `Null_output_is_ignored_and_returns_null`, `Clear_removes_all_routes_and_reports_whether_anything_changed`, `CurrentRoutes_instance_is_stable_across_updates`. Use repository search to identify callers, implementers, serializers, tests, and configuration references before changing a public name or shape.

## When to modify it

Edit when the device lifecycle, communications, control behavior, or feedback model changes. Confirm activation ordering before issuing hardware work.

## AI-agent change protocol

Before proposing a change, read this declaration, its full source file, all repository references to `StubDevice`, and its test coverage. Do not invent configuration keys, payload fields, interface members, or lifecycle ordering. Report the affected source files, tests, and consumer boundaries with any proposed change.

## Source authority

The source file linked above is authoritative. This generated reference is an index and decision aid; update it after a declaration, inheritance list, or public member contract changes.
