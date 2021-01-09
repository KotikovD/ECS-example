public class GameSystems : Feature
{
	public GameSystems(Contexts contexts, GameDataKeeper gameDataKeeper)
	{
		
		// Init
		Add(new InitializePlayerSystem(contexts, gameDataKeeper));
		
		// Input
		
		// Update
		Add(new ReactiveLogHealthSystem(contexts.game));
		Add(new HealthSystem(contexts.game));
		
		// View
		
		//Cleanup
		Add(new DestroyEntitySystem(contexts));
		
	}
}