using Entitas;

namespace Systems
{
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
			var e = _contexts.game.CreateEntity();
			e.AddHealth(_gameDataKeeper.Unit.Health);
			e.AddComponentsSpeed(_gameDataKeeper.Unit.Speed);
			e.AddComponentsColor(_gameDataKeeper.Unit.MeshColor);
		}
	}
}