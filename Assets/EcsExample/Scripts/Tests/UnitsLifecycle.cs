using NUnit.Framework;


public class UnitsLifecycle
{
	private Contexts _contexts;
	private HealthReactiveSystem _healthReactiveSys;
	private GameEntity _entity;

	[SetUp]
	public void Init()
	{
		_contexts = new Contexts();
		_healthReactiveSys = new HealthReactiveSystem(_contexts);
		_entity = _contexts.game.CreateEntity();
	}
	
	[Test]
	public void CheckDestroyByPositiveHealth()
	{
		_entity.AddHealth(100);

		_healthReactiveSys.Execute();

		Assert.False(_entity.isDestroyed);
	}

	[Test]
	public void CheckDestroyByZeroHealth()
	{
		_entity.AddHealth(0);

		_healthReactiveSys.Execute();

		Assert.True(_entity.isDestroyed);
	}
	
	[Test]
	public void CheckDestroyByNegativeHealth()
	{
		_entity.AddHealth(-1);

		_healthReactiveSys.Execute();

		Assert.True(_entity.isDestroyed);
	}
	
}