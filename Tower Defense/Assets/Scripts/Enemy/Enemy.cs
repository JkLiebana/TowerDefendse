using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private int TileIndex = 0;
	public Tile Target;

	public bool canMove = false;

	public bool Alive;

	public void NextTarget()
	{
		TileIndex++;
		if(TileIndex >= MainManager.Instance._MapGenerator.Path.Count)
		{
			return;
		}

		Target = MainManager.Instance._MapGenerator.Path[TileIndex];
		canMove = true;
	}

	public void Kill()
	{
		Alive = false;
		canMove = false;
		gameObject.SetActive(false);
	}
	
	public void Revive()
	{
		Alive = true;
		gameObject.SetActive(true);
	}
}
