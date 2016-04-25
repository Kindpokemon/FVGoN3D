using UnityEngine;
using System.Collections;

[System.Serializable]
public class WorldData {

	public string worldName;
	public int worldDifficulty;

	public WorldData(){

		this.worldName = "_";
		this.worldDifficulty = 0;
	}

}
