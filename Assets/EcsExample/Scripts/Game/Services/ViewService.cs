using UnityEngine;

public class ViewService : IViewService
{
	private readonly IPrefabLoader _prefabLoader;
	
	public ViewService(IPrefabLoader prefabLoader)
	{
		_prefabLoader = prefabLoader;
	}
	
	public void CreateView(GameContext context, GameEntity entity)
	{
		var prefab = _prefabLoader.GetPrefab(entity.asset.Value);
		var obj = Object.Instantiate(prefab);
		var view = obj.GetComponent<UnityView>();
		view.InitializeView(entity);
	}

	public void DestroyView(GameEntity entity)
	{
		if (!entity.hasView) return;

		entity.view.Value.DestroyView();
		entity.RemoveView();
	}

	public void SetParent(GameEntity entity)
	{
		throw new System.NotImplementedException();
	}

	public void SetPosition(GameEntity entity)
	{
		entity.view.Value.SetPosition(entity.position.value);
	}

	public void SetTweenPosition(GameEntity entity)
	{
		throw new System.NotImplementedException();
	}
}