public class DataService : IDataService
{
	
	public PlayerUnit PlayerUnit { get; }
	public NpcUnit NpcUnit { get; }
	public Level Level { get; }
	public Camera Camera { get; }

	public DataService(IDataLoader loader)
	{
		PlayerUnit = loader.GetData<PlayerUnit>(PathKeeper.PlayerUnit);
		Level = loader.GetData<Level>(PathKeeper.Level);
		NpcUnit = loader.GetData<NpcUnit>(PathKeeper.NpcUnit);
		Camera = loader.GetData<Camera>(PathKeeper.Camera);
	}

}