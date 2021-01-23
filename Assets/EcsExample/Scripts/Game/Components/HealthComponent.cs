using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class HealthComponent : IComponent
{
	public float value;
}