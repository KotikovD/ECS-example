using System.Collections.Generic;
using System.Linq;
using Entitas;


public class CreateViewByAssetReactiveSystem : ReactiveSystem<GameEntity>, ITearDownSystem
{
	private readonly GameContext _context;

	public CreateViewByAssetReactiveSystem(Contexts contexts) : base(contexts.game)
	{
		_context = contexts.game;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Asset.Added());
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasAsset;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var entity in entities)
		{
			_context.viewService.value.DestroyView(entity);
			_context.viewService.value.CreateView(_context, entity);
		}
	}

	public void TearDown()
	{
		foreach (var entity in _context.GetEntities().Where(a => a.hasView))
			_context.viewService.value.DestroyView(entity);
	}
	
}