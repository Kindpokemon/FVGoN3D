using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Chest : MonoBehaviour {

	public ReferenceList refList;

	public bool chestOpen;
	public GameObject player;
	public BoxCollider actionRange;
	public bool click;
	public List<GameObject> ChestSlots = new List<GameObject>();
	public List<Item> ChestItems = new List<Item>();

	public ItemDatabase database;
	public PlayerControl pControl;
	public PlayerCamera pCamera;
	public Text text;

	public GameObject chestSlots;
	float x = -28.333F;
	float y = 38.5F;
	public bool touchingAChest;
	public bool canTouch;
	public GameObject chestImTouching;
	public GameObject previouslyTouchedChest;
	public ChestDetails details;

	// Use this for initialization
	void Start () {
		refList = GameObject.FindGameObjectWithTag ("reflist").GetComponent<ReferenceList> ();
		database = refList.database;
		pControl = refList.playerControl;
		pCamera = refList.playerCamera;

		player = GameObject.FindGameObjectWithTag ("Player");
		int Slotamount = 0;

		for (int i = 0; i < 5; i++) {
			
			for (int k = 0; k < 3; k++) {
				GameObject slot = (GameObject)Instantiate (chestSlots);
				
				slot.GetComponent<ChestSlotScript> ().chestSlotNumber = Slotamount;
				
				ChestSlots.Add (slot);
				ChestItems.Add (new Item ());
				
				slot.transform.SetParent(this.gameObject.transform);
				slot.GetComponent<RectTransform> ().localPosition = new Vector3 (x, y, 0);
				x = x + 28.333F;
				if (k == 2) {
					x = -28.333F;
					y = y - 28.333F;
				}
				Slotamount++;
				
			}
		}

		if (!DevStats.DevMode) {
			ItemContainer.currentContainer.storage.initiated = true;
		}
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void  Update (){
		if (canTouch) {
			touchingAChest = false;
		}
		if (chestImTouching != previouslyTouchedChest && chestImTouching != null) {
			for(int i = 0; 0 < 15; i++){
				if(i == 15){
					break;
				}

				if(chestImTouching.GetComponent<ChestDetails>().slotIDs[i] != -1){
					AddInvChestItem(chestImTouching.GetComponent<ChestDetails>().slotIDs[i], i);
				} else {
					ChestItems[i] = new Item();
				}
			}
		}
	}
	
	public void ToggleChest(bool yorn){
		if (yorn) {
			chestOpen = true;
			details.anim.SetTrigger ("Open");
			gameObject.SetActive (true);
		} else {
			chestOpen = false;
			details.anim.SetTrigger ("Close");
		}
	}

	public void AddInvChestItem(int id, int chestSlot)
	{
		for (int i = 0; i < database.items.Count; i++) {
			
			if(database.items[i].itemID == id)
			{
				
				Item item = database.items[i];
				AddItemToInvChestSlot(item, chestSlot);
				
				
			}
		}
	}
	
	void AddItemToEmptyInvChestSlot(Item item)
	{
		for (int i = 0; i < ChestItems.Count; i++) {
			
			if (ChestItems[i].itemName == null)
			{
				ChestItems[i] = item;
				break;
			}
		}
	}
	
	void AddItemToInvChestSlot(Item item, int chestSlot){
		ChestItems [chestSlot] = item;
	}
}
