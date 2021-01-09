using NUnit.Framework;


public class UnitsLifecycle
{
	private Contexts _contexts;
	private HealthSystem _healthSys;
	private GameEntity _entity;

	[SetUp]
	public void Init()
	{
		_contexts = new Contexts();
		_healthSys = new HealthSystem(_contexts.game);
		_entity = _contexts.game.CreateEntity();
	}
	
	[Test]
	public void CheckDestroyByPositiveHealth()
	{
		_entity.AddHealth(100);

		_healthSys.Execute();

		Assert.False(_entity.isDestroyed);
	}

	[Test]
	public void CheckDestroyByZeroHealth()
	{
		_entity.AddHealth(0);

		_healthSys.Execute();

		Assert.True(_entity.isDestroyed);
	}
	
	[Test]
	public void CheckDestroyByNegativeHealth()
	{
		_entity.AddHealth(-1);

		_healthSys.Execute();

		Assert.True(_entity.isDestroyed);
	}
	
}