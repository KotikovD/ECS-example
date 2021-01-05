using Helpers;
using UnityEngine;


public class GameDataKeeper
{
	public Unit Unit { get; }

	private GameDataKeeper(Unit unit)
	{
		Unit = unit;
	}

	public static GameDataKeeper LoadDataFromResources()
	{
		var unit = Resources.Load<Unit>(PathKeeper.DataUnit);

		var gameDataKeeper = new GameDataKeeper(unit);
		return gameDataKeeper;
	}
}