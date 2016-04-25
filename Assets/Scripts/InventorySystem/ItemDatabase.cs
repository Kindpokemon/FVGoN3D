using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item>();
	
	// Use this for initialization
	void Start () {

		items.Add (new Item ("zillyHammer", 0, "Warhammer of Zillyhoo", "Dev-Tier", 0, 100, 10, 0, 0, "", 0, 10000, Item.ItemType.Weapon));
		items.Add (new Item ("godHat", 1, "Dev Tier Hood", "Dev-Tier", 100, 0, 0, 0, 0, "", 0, 10000, Item.ItemType.Head));
		items.Add (new Item ("godChest", 2, "Dev Tier Shirt", "Dev-Tier", 100, 0, 0, 0, 0, "", 0, 10000, Item.ItemType.Chest));
		items.Add (new Item ("godPants", 3, "Dev Tier Leggings", "Dev-Tier", 100, 0, 0, 0, 0, "", 0, 10000, Item.ItemType.Pants));
		items.Add (new Item ("godBoots", 4, "Dev Tier Shoes", "Dev-Tier", 100, 0, 0, 0, 0, "", 0, 10000, Item.ItemType.Shoes));
		items.Add (new Item ("healthFaygo", 5, "Bloody Strawberry Faygo", "Dank Drank", 0, 0, 0, 100, 0, "", 1, 10000, Item.ItemType.Consumable));
		items.Add (new Item ("pistol", 6, "Pistol", "A Simple Pistol", 0, 6, 1, 0, 0, "", 0, 50, Item.ItemType.Weapon));


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
