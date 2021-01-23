using System;
using Entitas;
using UnityEngine;

public class ApplyPlayerUnitMovementSystem :  IExecuteSystem, IInitializeSystem
{
	private InputContext _inputContext;
	private GameContext _gameContext;
	private GameEntity _playerEntity;
	private InputEntity _inputEntity;
	private IGroup<InputEntity> _inputGroup;
	private PlayerUnit _playerUnitData;
	private const float SENSITIVITY = 0.1f; //TODO move to data
	
	public ApplyPlayerUnitMovementSystem(Contexts context)
	{
		_inputContext = context.input;
		_gameContext = context.game;
	}

	public void Initialize()
	{
		_playerEntity = _gameContext.playerEntity;
		_playerUnitData = _gameContext.dataService.value.PlayerUnit;
		_inputGroup = _inputContext.GetGroup(InputMatcher.PlayerUnitMove);
	}
	
	public void Execute()
	{
		_inputEntity = _inputGroup.GetSingleEntity();
		var playerPosition = _playerEntity.position.value;
		
		if (isPlayerMoveVertical())
		{
			_playerEntity.ReplacePosition(playerPosition += new Vector3(0,0,_inputEntity.playerUnitMove.Vertical * _playerUnitData.Speed * Time.deltaTime));
		}

		if (isPlayerMoveHorizontal())
		{
			_playerEntity.ReplacePosition(playerPosition += new Vector3(_inputEntity.playerUnitMove.Horizontal * _playerUnitData.Speed * Time.deltaTime,0,0));
		}

	}

	private bool isPlayerMoveVertical()
	{
		return _inputEntity.playerUnitMove.Vertical > SENSITIVITY ||
		       _inputEntity.playerUnitMove.Vertical < SENSITIVITY * -1;
	}
	
	private bool isPlayerMoveHorizontal()
	{
		return _inputEntity.playerUnitMove.Horizontal > SENSITIVITY ||
		       _inputEntity.playerUnitMove.Horizontal < SENSITIVITY * -1;
	}
	
}