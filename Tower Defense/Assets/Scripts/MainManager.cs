using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : Singleton<MainManager> {

	public MapGenerator _MapGenerator;
	public EnemyManager _EnemyManager;
	public PoolingManager _PoolingManager;
	public LevelManager _LevelManager;

	public PlayerController _PlayerController;

	void Start()
	{
		_PoolingManager.Initialize();
		_MapGenerator.CreateMap();
		_LevelManager.Initialize();		
	}
}
