using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "Level/LevelInfo")]
public class LevelInfo : ScriptableObject {
	public List<int> EnemiesPerWave;

}
