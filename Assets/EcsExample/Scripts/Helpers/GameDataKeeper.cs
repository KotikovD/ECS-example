using System;
using UnityEngine;


public class GameDataKeeper
{
	public PlayerUnit PlayerUnit { get; }

	private GameDataKeeper(PlayerUnit playerUnit)
	{
		PlayerUnit = playerUnit;
	}

	public static GameDataKeeper LoadDataFromResources()
	{
		var unit = Resources.Load<PlayerUnit>(PathKeeper.DataUnit);

		if (unit == null)
			throw new Exception("Game " + typeof(PlayerUnit) + " by path = " + PathKeeper.DataUnit + " not found"); 
		
		var gameDataKeeper = new GameDataKeeper(unit);
		return gameDataKeeper;
	}
}