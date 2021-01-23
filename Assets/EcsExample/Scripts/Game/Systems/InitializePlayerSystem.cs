using Entitas;


public class InitializePlayerSystem : IInitializeSystem
{
	private Contexts _contexts;

	public InitializePlayerSystem(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Initialize()
	{
		var player = _contexts.game.dataService.value.PlayerUnit;
		GameEntity entity = _contexts.game.CreateEntity();
		
		entity.AddHealth(player.Health);
		entity.AddSpeed(player.Speed);
		entity.AddAsset(player.AssetName);
		entity.AddPosition(player.StartPosition);
		entity.isPlayer = true;
	}
	
}