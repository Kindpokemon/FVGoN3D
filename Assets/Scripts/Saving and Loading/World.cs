using UnityEngine;
using System.Collections;

[System.Serializable]
public class World {

	public static World currentWorld;
	public WorldData worldData;
	WorldData world;

	public World(){

		worldData = new WorldData ();

	}
}
