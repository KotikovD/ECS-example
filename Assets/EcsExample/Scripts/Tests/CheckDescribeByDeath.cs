using NUnit.Framework;

public class CheckDescribeByDeath
{
	private Contexts _contexts;
	private DestroyEntitySystem _destroySys;
	private GameEntity _entity;

	[SetUp]
	public void Init()
	{
		_contexts = new Contexts();
		_destroySys = new DestroyEntitySystem(_contexts);
		_entity = _contexts.game.CreateEntity();
	}

	[Test]
	public void UndescribeWhenDestroyed()
	{
		_entity.isDestroyed = true;

		_destroySys.Execute();

		Assert.False(_entity.isEnabled);
		Assert.Zero(_contexts.game.count);
	}
	
	[Test]
	public void HoldDescribeWhenNotDestroyed()
	{
		_entity.isDestroyed = false;

		_destroySys.Execute();

		Assert.True(_entity.isEnabled);
		Assert.Positive(_contexts.game.count);
	}
}