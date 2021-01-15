public class GameSystems : Feature
{
	public GameSystems(Contexts contexts)
	{
		
		// Init
		Add(new InitializeDataSystem(contexts));
		Add(new InitializeViewSystem(contexts));
		
		Add(new InitializePlayerSystem(contexts));
		
		Add(new InitializeNpcSystem(contexts));
		Add(new InitializeLevelSystem(contexts));
		Add(new MeshColorReactiveSystem(contexts));
		Add(new GameEventSystems(contexts));
		Add(new CameraViewSystem(contexts));
		
		// Input
		
		// Update
		Add(new LogHealthReactiveSystem(contexts));
		Add(new HealthReactiveSystem(contexts));
		Add(new PositionMoveReactiveSystem(contexts));
		Add(new ApplyDamageReactiveSystem(contexts));
		//Add(new CameraViewSystem(contexts));
		
		// View
		Add(new CreateViewByAssetReactiveSystem(contexts));
		
		//Cleanup
		Add(new DestroyEntitySystem(contexts));
		
	}
}