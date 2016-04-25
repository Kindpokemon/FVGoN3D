using UnityEngine;
using System.Collections;

[System.Serializable]
public class ItemContainer {

	public static ItemContainer currentContainer;
	public StorageObject storage;
	StorageObject storageData;

	public ItemContainer(){

		storage = new StorageObject();

	}
}
