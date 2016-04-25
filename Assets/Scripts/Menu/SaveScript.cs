using UnityEngine;
using System.Collections;

public class SaveScript : MonoBehaviour {

	public GameObject chests;

	public void Save()
	{
		UpdateChests ();
		SaveLoad.SaveOver ();
		SaveLoad.SaveOverChests (World.currentWorld.worldData.worldName);
		SaveLoad.SaveOverWorld ();
	}

	public void UpdateChests(){

		for (int i = 0; i < chests.transform.childCount; i++) {
			for (int k = 0; k < 15; k++) {
				ItemContainer.currentContainer.storage.storedList [i, k] = chests.transform.GetChild (i).GetComponent<ChestDetails> ().slotIDs [k];
			}
		}
	}
}
