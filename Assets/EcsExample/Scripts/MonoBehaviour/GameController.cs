using UnityEngine;


public class GameController : MonoBehaviour
{
	private GameSystems _gameSystems;

	private GameDataKeeper _gameDataKeeper;
	private Contexts _contexts;

	void Start()
	{
		_contexts = new Contexts();
		_gameDataKeeper = GameDataKeeper.LoadDataFromResources();

		_gameSystems = new GameSystems(_contexts, _gameDataKeeper);
		_gameSystems.Initialize();
	}

	private void Update()
	{
		_gameSystems.Execute();
	}
}