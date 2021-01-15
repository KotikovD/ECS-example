using System;
using Entitas;
using UnityEngine;
using TMPro;

public class LabelBehaviour : MonoBehaviour, IEventListener, IHealthListener
{

	[SerializeField] private TextMeshPro _textMeshPro;
	private GameEntity _gameEntity;

	public void CreateListeners(IEntity entity)
	{
		_gameEntity = (GameEntity) entity;
		_gameEntity.AddHealthListener(this);
		SetLabelValue(_gameEntity.health.value);
	}

	public void DestroyListeners()
	{
		_gameEntity.RemoveHealthListener();
	}

	public void OnHealth(GameEntity entity, float value)
	{
		SetLabelValue(value);
	}

	private void SetLabelValue(float value)
	{
		_textMeshPro.text = Math.Round(value, 1).ToString();
	}
}