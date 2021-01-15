using System.Collections.Generic;
using Entitas;
using UnityEngine;

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
		return entity.hasView && !entity.isCamera;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var entity in entities)
		{
			entity.view.Value.SetMeshColor(Random.ColorHSV());
		}
	}
}