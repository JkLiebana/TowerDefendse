using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Transform TileSelected;
	public GameObject TurretPrefab;


	public void BuildTurret(int x, int y)
	{
		Vector3 position = new Vector3(x, 1, y);
		
		var turret = Instantiate(TurretPrefab, position, Quaternion.identity);
		turret.GetComponent<TurretController>().InitializeTurret(x, y);
	}
}
