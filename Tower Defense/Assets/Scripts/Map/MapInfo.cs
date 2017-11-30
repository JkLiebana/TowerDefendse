using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapInfo", menuName = "Map/MapInfo")]
public class MapInfo : ScriptableObject {

	public int xSize, ySize;

	public List<TileInfo> PathZone;

	public int[,] tileType;

	public List<GameObject> TileTypes;
	public void GenerateMapInfo()
	{
		tileType = new int[xSize, ySize];

		for(int i = 0; i < xSize; i++)
		{
			for(int j = 0; j < ySize; j++)
			{
				tileType[i,j] = 0;
			}
		}

		for(int i = 0; i < PathZone.Count; i++)
		{
			tileType[PathZone[i].x, PathZone[i].y] = 1;
		}
	}
	
}
