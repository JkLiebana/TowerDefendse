using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventOnEnemyEnter : UnityEvent<GameObject>
{
}

public class Tile : MonoBehaviour {

	public int x, y;

	public EventOnEnemyEnter OnEnemyEnter;

	void Start()
	{
		OnEnemyEnter = new EventOnEnemyEnter();
	}

	void OnMouseDown()
	{
		MainManager.Instance._PlayerController.BuildTurret(x, y);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag != "Enemy" || OnEnemyEnter == null)
			return;
		
		OnEnemyEnter.Invoke(other.gameObject);
	}
}
