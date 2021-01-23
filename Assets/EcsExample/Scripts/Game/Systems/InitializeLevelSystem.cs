using Entitas;


public class InitializeLevelSystem : IInitializeSystem
{
	private Contexts _contexts;

	public InitializeLevelSystem(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Initialize()
	{
		var entity = _contexts.game.CreateEntity();
		entity.AddAsset(_contexts.game.dataService.value.Level.AssetName);
		entity.AddPosition(_contexts.game.dataService.value.Level.StartPosition);
		entity.isLevel = true;
	}
}