using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeshColorReactiveSystem : ReactiveSystem<GameEntity>
{
	private readonly GameContext _context;

	public MeshColorReactiveSystem(Contexts context) : base(context.game)
	{
		_context = context.game;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.View.Added());
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isPlayer || entity.isNpc;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var entity in entities)
		{
			entity.view.Value.SetMeshColor(GetColor(entity));
		}
	}

	private Color GetColor(GameEntity entity)
	{
		if (entity.isNpc)
			return Random.ColorHSV();

		if (entity.isPlayer)
			return _context.dataService.value.PlayerUnit.MeshColor;
		
		throw new Exception("No color getter for entity.creationIndex = " + entity.creationIndex);
	}
	
}