using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public MapInfo _MapInfo;

	public List<Tile> Path;
	
	public void CreateMap()
	{
		_MapInfo.GenerateMapInfo();
		InstantiateMap();		
	}

	void InstantiateMap()
	{
		for(int i = 0; i < _MapInfo.xSize; i++)
		{
			for(int j = 0; j < _MapInfo.ySize; j++)
			{
				var tempTile = Instantiate(_MapInfo.TileTypes[_MapInfo.tileType[i,j]], Vector3.zero, Quaternion.identity);

				tempTile.transform.position = new Vector3(i, 0f, j);
				tempTile.transform.SetParent(gameObject.transform);

				var tileInfo = tempTile.GetComponent<Tile>();

				tileInfo.x = i;
				tileInfo.y = j;

				if(_MapInfo.tileType[i,j] == 1)
				{
					Path.Add(tileInfo);
				}
			}
		}
	}


	
}
