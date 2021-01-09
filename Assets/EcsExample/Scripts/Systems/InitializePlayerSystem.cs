using Entitas;


public class InitializePlayerSystem : IInitializeSystem
{
	private Contexts _contexts;
	private GameDataKeeper _gameDataKeeper;

	public InitializePlayerSystem(Contexts contexts, GameDataKeeper gameDataKeeper)
	{
		_contexts = contexts;
		_gameDataKeeper = gameDataKeeper;
	}

	public void Initialize()
	{
		GameEntity e = _contexts.game.CreateEntity();
		e.AddHealth(_gameDataKeeper.PlayerUnit.Health);
		e.AddSpeed(_gameDataKeeper.PlayerUnit.Speed);
		e.AddColor(_gameDataKeeper.PlayerUnit.MeshColor);
	}
}