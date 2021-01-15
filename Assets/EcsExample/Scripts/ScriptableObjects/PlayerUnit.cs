using UnityEngine;


[CreateAssetMenu(menuName = "EscExample/PlayerUnit")]
public class PlayerUnit : ScriptableObject
{
	public float Health;
	public float Speed;
	public string AssetName;
	public Color MeshColor;
	public Vector3 StartPosition;
	public Vector3 CameraOffset;
}