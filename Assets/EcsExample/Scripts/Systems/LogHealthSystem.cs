using Entitas;
using UnityEngine;


public class LogHealthSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public LogHealthSystem(Contexts contexts)
	{
		_entities = contexts.game.GetGroup(GameMatcher.Health);
	}

	public void Execute()
	{
		foreach (var entity in _entities)
		{
			var health = entity.health.value;
			Debug.Log("Health " + health);
		}
	}
}