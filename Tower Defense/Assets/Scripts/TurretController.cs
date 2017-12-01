using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

	public GameObject CurrentTarget;
	public GameObject ProjectilePrefab;
	public TileInfo CurrentTile;
	public List<TileInfo> ReachableTiles;

	public int reloadTime = 2;
	public bool shooting;


	public void InitializeTurret(int x, int y)
	{
		CurrentTile = new TileInfo(x,y);
				
		for(int i = x - 1; i <= x + 1; i++)
		{
			for(int j = y - 1; j <= y + 1; j++ )
			{
				ReachableTiles.Add(new TileInfo(i,j));
				
			}
		}

		for(int i = 0; i < ReachableTiles.Count; i++)
		{
			Tile tempTile =	MainManager.Instance._MapGenerator.Path.Find(tile => tile.x == ReachableTiles[i].x && tile.y == ReachableTiles[i].y);
			 
			if(tempTile != null)
			{
				tempTile.OnEnemyEnter.AddListener(GetEnemy);
			}
		}

		shooting = true;
		StartCoroutine(Shoot());
	}
	public void GetEnemy(GameObject enemy)
	{
		CurrentTarget = enemy;
	}

	IEnumerator Shoot()
	{
		while(shooting)
		{
			if(CurrentTarget != null)
			{
				var bullet = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity).GetComponent<BulletController>();
				bullet.target = CurrentTarget.transform;
				bullet.Initialize();
			}
			else
			{
				
			}
			yield return new WaitForSeconds(reloadTime);
		}
	}
}
