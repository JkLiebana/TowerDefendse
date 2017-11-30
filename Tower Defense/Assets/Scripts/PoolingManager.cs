using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour {

	public int PoolSize;
	public GameObject EnemyPrefab;

	public List<Enemy> Pool;

	public void Initialize()
	{
		for(int i = 0; i < PoolSize; i++)
		{
			var enemyTemp = Instantiate(EnemyPrefab, Vector3.zero, Quaternion.identity);
			enemyTemp.transform.SetParent(gameObject.transform);
			
			var enemy = enemyTemp.GetComponent<Enemy>();

			enemy.Kill();
			Pool.Add(enemy);
		}
	}

	public Enemy SpawnEnemy()
	{
		for(int i = 0; i < Pool.Count; i++)
		{
			if(!Pool[i].Alive)
			{
				Pool[i].Revive();
				return Pool[i];
			}
		}

		var enemyTemp = Instantiate(EnemyPrefab, Vector3.zero, Quaternion.identity);
		var enemy = enemyTemp.GetComponent<Enemy>();
		enemy.Revive();
		Pool.Add(enemy);
		
		return enemy;
	}


	public void DespawnEnemy(Enemy enemy)
	{
		enemy.Kill();
	}
}
