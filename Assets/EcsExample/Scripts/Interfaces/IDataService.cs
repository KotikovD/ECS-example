using Entitas.CodeGeneration.Attributes;


[Game, Unique, ComponentName("DataService")]
public interface IDataService
{
	PlayerUnit PlayerUnit { get; }
	NpcUnit NpcUnit { get; }
	Level Level { get; }
	Camera Camera { get; }
}