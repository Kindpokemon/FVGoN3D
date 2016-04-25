using UnityEngine;
using System.Collections;

[System.Serializable]
public class StorageObject {

	public string name;
	public int slots;
	public int storageNumber;
	public int[,] storedList = new int[100,15];
	public bool initiated;

	public StorageObject(){

		this.name = "";
		this.slots = 0;
		this.storageNumber = 0;
		this.initiated = false;

		for (int s = 0; s < 100; s++) {

			for(int t = 0; t < 15; t++){
				this.storedList[s,t] = -1;
			}
		}
	}

}
