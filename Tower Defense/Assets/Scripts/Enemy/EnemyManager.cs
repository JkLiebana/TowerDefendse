using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	public List<Enemy> AliveEnemies;

	public float unitSpeed = 1f;

	public bool EnemiesMoving = false;
	public void InitializeEnemy(ref Enemy enemy)
	{
		AliveEnemies.Add(enemy);
		enemy.NextTarget();
	}
	void Update()
	{
		for(int i = 0; i < AliveEnemies.Count; i++)
		{
			if(AliveEnemies[i].canMove)
				MoveUnit(AliveEnemies[i]);
		}
	}

	Vector3 newPosition;
	void MoveUnit(Enemy enemyUnit)
	{
		newPosition = Vector3.MoveTowards(enemyUnit.transform.position, enemyUnit.Target.position, Time.deltaTime * unitSpeed);
		newPosition.y = 0.75f;
		enemyUnit.transform.position = newPosition;

		CheckTargetReached(enemyUnit);
	}

	void CheckTargetReached(Enemy enemyUnit)
	{
		if(Vector3.Distance(enemyUnit.transform.position,enemyUnit.Target.transform.position) <= 0.85f)
		{
			enemyUnit.NextTarget();
		}
	}
}
