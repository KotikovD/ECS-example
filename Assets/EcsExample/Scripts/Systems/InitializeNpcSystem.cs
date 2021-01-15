using Entitas;

public class InitializeNpcSystem : IInitializeSystem
{
	private Contexts _contexts;

	public InitializeNpcSystem(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Initialize()
	{
		var npc = _contexts.game.dataService.value.NpcUnit;
		var entity = _contexts.game.CreateEntity();
		
		entity.AddHealth(npc.Health);
		entity.AddSpeed(npc.Speed);
		entity.AddAsset(npc.AssetName);
		entity.AddPosition(npc.StartPosition);
	}
}