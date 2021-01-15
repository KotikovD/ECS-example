using Entitas;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class CameraViewSystem : IAnyPlayerListener, IPositionListener, IInitializeSystem
{
	private Contexts _contexts;
	private GameEntity _cameraEntity;
	private GameEntity _cachePlayer;
	private Camera _cameraData;
	private TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> _doTweenMover;


	public CameraViewSystem(Contexts contexts)
	{
		_contexts = contexts;
	}
	
	public void Initialize()
	{
		_cachePlayer = _contexts.game.playerEntity;
		_cachePlayer.AddPositionListener(this);
		_cachePlayer.AddAnyPlayerListener(this);
		
		_cameraData = _contexts.game.dataService.value.Camera;
		_cameraEntity = _contexts.game.CreateEntity();
		_cameraEntity.AddPosition(Vector3.zero);
		_cameraEntity.AddAsset("MainCamera");
		_cameraEntity.isCamera = true;

		MoveCamera(_cachePlayer);
	}

	public void OnAnyPlayer(GameEntity entity)
	{
		if (_cachePlayer.creationIndex != entity.creationIndex)
		{
			_cachePlayer.RemovePositionListener();
			entity.AddPositionListener(this);
			_cachePlayer = entity;
			MoveCamera(entity);
		}
	}

	public void OnPosition(GameEntity entity, Vector3 value)
	{
		MoveCamera(entity);
	}
	
	private void MoveCamera(GameEntity entity)
	{
		var endPosition = new []{entity.position.value + GetCameraOffset(entity)};
		var duration = new []{_cameraData.LerpSpeed};
		
		_doTweenMover = DOTween.ToArray(() => _cameraEntity.position.value, _cameraEntity.ReplacePosition, endPosition, duration);
	}
	
	private Vector3 GetCameraOffset(GameEntity entity)
	{
		return _cameraData.UnitOffset;
	}
}
