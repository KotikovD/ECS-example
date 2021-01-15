using Entitas;

public interface IEventListener
{
	void CreateListeners(IEntity entity);
	void DestroyListeners();
}