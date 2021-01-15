using System.Collections.Generic;
using Entitas;

public class ApplyDamageReactiveSystem : ReactiveSystem<GameEntity>
{
	private readonly GameContext _context;

	public ApplyDamageReactiveSystem(Contexts context) : base(context.game)
	{
		_context = context.game;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Damage.Added());
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasDamage;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var entity in entities)
		{
			entity.ReplaceHealth(entity.health.value -= entity.damage.Value);
			entity.RemoveDamage();
		}
	}
}