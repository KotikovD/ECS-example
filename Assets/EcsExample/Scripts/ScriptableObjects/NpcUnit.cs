using UnityEngine;

[CreateAssetMenu(menuName = "EscExample/NpcUnit")]
public class NpcUnit : ScriptableObject
{
	public float Health;
	public float Speed;
	public string AssetName;
	public Color MeshColor;
	public Vector3 StartPosition;
}