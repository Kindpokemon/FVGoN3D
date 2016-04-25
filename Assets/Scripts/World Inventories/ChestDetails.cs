using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChestDetails : MonoBehaviour {

	public int[] slotIDs = new int[15];
	public List<Item> ChestItems = new List<Item>();
	public ItemDatabase database;
	public int chestID;
	public bool chestOpen;
	public GameObject player;
	public BoxCollider actionRange;
	public bool click;
	public ItemContainer itemContainer;
	public bool hasLoaded;
	public GameObject ChestUI;
	public Chest chest;
	public Animator anim;
	public bool boop = false;
	public bool hasRun = false;
	public string chestName;
	
	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag("Player");
		database = GameObject.FindWithTag ("ItemDatabase").GetComponent<ItemDatabase> ();
		chest = ChestUI.GetComponent<Chest>();
		anim = this.GetComponent<Animator> ();
		if (!DevStats.DevMode) {
			hasRun = true;
		}
		if (!DevStats.DevMode && hasRun == false) {
			if (ItemContainer.currentContainer.storage.initiated) {
				for (int i = 0; i < slotIDs.Length; i++) {
					if (ItemContainer.currentContainer.storage.storedList [chestID, i] != -1) {
						slotIDs [i] = ItemContainer.currentContainer.storage.storedList [chestID, i];
						AddChestItem (ItemContainer.currentContainer.storage.storedList [chestID, i], i);

					} else {
						slotIDs [i] = -1;
						ChestItems [i] = new Item ();
				
					}

				}

				hasRun = true;
			}
		} else if (hasRun == true) {
			for (int i = 0; i < 15; i++) {
				for (int j = 0; j < database.items.Count; j++) {
					if (slotIDs [i] != -1) {
						AddChestItem (j, i);
						//ItemContainer.currentContainer.storage.storedList [chestID, i] = slotIDs [i];
					} else {
						ChestItems [i] = new Item (); 
						//ItemContainer.currentContainer.storage.storedList [chestID, i] = -1;
					}
				}
			}
		}

	}
	// Update is called once per frame
	void Update () {

	}

	public void AddChestItem(int id, int chestSlot)
	{
		for (int i = 0; i < database.items.Count; i++) {
			
			if(database.items[i].itemID == id)
			{
				
				Item item = database.items[i];
				AddItemToChestSlot(item, chestSlot);
				
				
			}
		}
	}
	
	void AddItemToEmptyChestSlot(Item item)
	{
		for (int i = 0; i < ChestItems.Count; i++) {
			
			if (ChestItems[i].itemName == null)
			{
				ChestItems[i] = item;
				break;
			}
		}
	}
	
	void AddItemToChestSlot(Item item, int chestSlot){
		ChestItems [chestSlot] = item;
	}
}
