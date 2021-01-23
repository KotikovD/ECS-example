using System.Collections.Generic;
using Entitas;

public class PositionMoveReactiveSystem : ReactiveSystem<GameEntity>
{
	private readonly Contexts _context;

	public PositionMoveReactiveSystem(Contexts context) : base(context.game)
	{
		_context = context;
	}


	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Position.Added());
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasView;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var entity in entities)
		{
			_context.game.viewService.value.SetPosition(entity);
		}
	}
}