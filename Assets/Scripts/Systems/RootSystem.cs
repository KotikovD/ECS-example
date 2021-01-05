namespace Systems
{
	public class RootSystem : Feature
	{
		public RootSystem(Contexts contexts, GameDataKeeper gameDataKeeper)
		{
			Add(new InitializePlayerSystem(contexts, gameDataKeeper));
			Add(new ReactiveLogHealthSystem(contexts.game));
		}
	}
}