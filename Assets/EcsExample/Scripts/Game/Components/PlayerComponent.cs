using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
[Unique]
[Event(EventTarget.Any)]
public sealed class PlayerComponent : IComponent
{
}