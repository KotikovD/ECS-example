using UnityEngine;

public interface IView
{
	Transform Transform { get; }
	GameObject GameObject { get; }
	Vector3 GetPosition { get; }
	
	Quaternion GetRotation { get; }
	
	void InitializeView(GameContext gameContext, GameEntity gameEntity);
	void SetActive(bool isActive);
	void SetParent(Transform parent, bool worldPositionStays = false);
	void SetPosition(Vector3 position, bool isTween = false);
	void SetRotation(Quaternion rotation);
	void DestroyView();
	void SetMeshColor(Color color);
}