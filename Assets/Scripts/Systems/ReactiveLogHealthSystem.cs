using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
	public class ReactiveLogHealthSystem : ReactiveSystem<GameEntity>
	{
		public ReactiveLogHealthSystem(IContext<GameEntity> context) : base(context)
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
}