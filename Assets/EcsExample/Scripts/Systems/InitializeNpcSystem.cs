using Entitas;
using UnityEngine;

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
		var pos = npc.StartPosition;
		
		for (int i = 0; i < npc.TotalNpcCount; i++)
		{
			var entity = _contexts.game.CreateEntity();
			entity.AddHealth(npc.Health);
			entity.AddSpeed(npc.Speed);
			entity.AddAsset(npc.AssetName);
			entity.AddPosition(pos += npc.StartPosition);
			entity.isNpc = true;
		}

	}
}