using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class LogHealthReactiveSystem : ReactiveSystem<GameEntity>
{
	public LogHealthReactiveSystem(Contexts context) : base(context.game)
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
			var health = entity.health.value;
			Debug.Log("Health " + health);
		}
	}
}