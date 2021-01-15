using Entitas;


public class InitializeViewSystem : IInitializeSystem
{
	private readonly GameContext _context;

	public InitializeViewSystem(Contexts context)
	{
		_context = context.game;
	}

	public void Initialize()
	{
		_context.SetViewService(new ViewService(new PrefabLoader()));
	}
}