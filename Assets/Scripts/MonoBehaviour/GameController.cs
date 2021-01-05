using System;
using Systems;
using UnityEngine;


public class GameController : MonoBehaviour
{
	private RootSystem _rootSystem;

	private GameDataKeeper _gameDataKeeper;
	private Contexts _contexts;

	void Start()
	{
		_contexts = new Contexts();
		_gameDataKeeper = GameDataKeeper.LoadDataFromResources();

		_rootSystem = new RootSystem(_contexts, _gameDataKeeper);
		_rootSystem.Initialize();
	}

	private void Update()
	{
		_rootSystem.Execute();
	}
}