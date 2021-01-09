using System;
using System.Collections.Generic;
using Entitas;

public class HealthSystem : ReactiveSystem<GameEntity>
{
	public HealthSystem(IContext<GameEntity> context) : base(context)
	{
	}
	

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Health);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasHealth;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var entity in entities)
		{
			if (entity.health.value <= 0)
				entity.isDestroyed = true;
		}
	}
}