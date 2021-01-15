﻿using Entitas;

public class DestroyEntitySystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _group;

	public DestroyEntitySystem(Contexts contexts)
	{
		_group = contexts.game.GetGroup(GameMatcher.Destroyed);
	}

	public void Execute()
	{
		foreach (var entity in _group.GetEntities())
		{
			entity.view.Value.DestroyView();
			entity.Destroy();
		}
	}
}