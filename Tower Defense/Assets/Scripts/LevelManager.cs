using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public List<LevelInfo> Levels;

	public int currentLevel = 0;
	public int currentWave = 0;

	private LevelInfo CurrentLevelInfo;

	public void Initialize()
	{
		StartNewLevel();
	}

	void StartNewLevel()
	{
		CurrentLevelInfo = Levels[currentLevel];
		StartCoroutine(StartWave());
	}

	private int index;
	IEnumerator StartWave()
	{
		while(index < CurrentLevelInfo.EnemiesPerWave[currentWave])
		{
			var enemy = MainManager.Instance._PoolingManager.SpawnEnemy();
			enemy.transform.position = new Vector3(0f, 0.75f, 0f);

			MainManager.Instance._EnemyManager.InitializeEnemy(ref enemy);

			index++;
			yield return new WaitForSeconds(1);
		}

	}
}
