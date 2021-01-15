using Entitas.Unity;
using UnityEngine;


[RequireComponent(typeof(EntityLink))]
internal sealed class UnityView : MonoBehaviour, IView
{
	private EntityLink _entityLink;
	
	
	Transform IView.Transform => transform;
	GameObject IView.GameObject => gameObject;
	public Vector3 GetPosition => transform.localPosition;
	public Quaternion GetRotation => transform.localRotation;


	public void InitializeView(GameEntity entity)
	{
		entity.AddView(this);
		_entityLink = gameObject.Link(entity);

		var eventListeners = gameObject.GetComponents<IEventListener>();
		foreach (var listener in eventListeners)
		{
			listener.CreateListeners(entity);
		}

		if (entity.hasPosition)
		{
			SetPosition(entity.position.value);
		}
	}

	public void UnlinkGameObject()
	{
		var eventListeners = gameObject.GetComponents<IEventListener>();
		foreach (var listener in eventListeners)
		{
			listener.DestroyListeners();
		}

		gameObject.Unlink();
	}

	public void InitializeView(GameContext gameContext, GameEntity gameEntity)
	{
		throw new System.NotImplementedException();
	}

	public void SetActive(bool isActive)
	{
		gameObject.SetActive(isActive);
	}

	public void SetParent(Transform parent, bool worldPositionStays = true)
	{
		transform.SetParent(parent, worldPositionStays);
	}
	
	public void SetPosition(Vector3 position, bool isTween = false)
	{
		transform.localPosition = position;
	}

	public void SetRotation(Quaternion rotation)
	{
		transform.rotation = rotation;
	}
	

	public void DestroyView()
	{
		//GameEntity thisEntity = (GameEntity) _entityLink.entity;
		// thisEntity.isAssetLoaded = false;
		Destroy(gameObject);
	}

	public void SetMeshColor(Color color)
	{
		var r =_entityLink.GetComponentInChildren<MeshRenderer>();
		r.material.color = color;
	}

	private void OnDestroy()
	{
		UnlinkGameObject();
	}
}