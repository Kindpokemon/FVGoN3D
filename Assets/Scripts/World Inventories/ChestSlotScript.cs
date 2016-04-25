using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChestSlotScript : MonoBehaviour, IDragHandler, IPointerDownHandler {

	public Item item;
	Image itemImage;
	public int chestSlotNumber;
	public Chest chest;
	Character character;
	ItemDatabase database;
	Inventory inventory;
	public ChestDetails chestDetails;
	GameObject player;
	PolygonCollider2D playerCollider;

	// Use this for initialization
	void Start () {
		chest = GameObject.FindGameObjectWithTag ("ChestInventory").GetComponent<Chest>();
		itemImage = gameObject.transform.GetChild (0).GetComponent<Image> ();
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();
		player = GameObject.FindGameObjectWithTag("Player");
		playerCollider = player.GetComponent<PolygonCollider2D> ();

		///////////////////////////////////Player chest///////////////////////////////////////////////
		

		chest.AddInvChestItem (0,0);
		chest.AddInvChestItem (1,1);
		//chest.addItem (2,2);
		//chest.addItem (3,3);
		//chest.addItem (4,4);
		//chest.addItem (5,5);
		
		////////////////////////////////End of Player chest///////////////////////////////////////////
	}
	
	void Update () {
		chestDetails = chest.details;

		if(chestDetails != null){
			for(int i = 0; i < chestDetails.slotIDs.Length; i++)
			{
				if( chestDetails.slotIDs[i] != -1)
				{
					chest.AddInvChestItem(chestDetails.slotIDs[i], i);
				
				} else {
				
					chest.ChestItems[i] = new Item();
				
				}
			}
		}

		if (chest.ChestItems[chestSlotNumber].itemName != null) 
		{
			
			itemImage.enabled = true;
			itemImage.sprite = chest.ChestItems[chestSlotNumber].itemIcon;
			
		} else {
			
			itemImage.enabled = false;
		}
		
	}
	
	public void OnDrag(PointerEventData data)
	{
		if(inventory.draggingItem == false)
		{
			if(chest.ChestItems[chestSlotNumber].itemName != null){
				inventory.canSwap = false;
				if (!DevStats.DevMode) {
					ItemContainer.currentContainer.storage.storedList [chestDetails.chestID, chestSlotNumber] = -1;
				}
				chestDetails.slotIDs[chestSlotNumber] = -1;
				inventory.showDraggedItem(chest.ChestItems[chestSlotNumber], chestSlotNumber);
				chestDetails.ChestItems[chestSlotNumber] = new Item();
				
				
			}
		}
	}
	
	
	public void OnPointerDown(PointerEventData data)
	{
		try {
			if (chest.ChestItems [chestSlotNumber].itemName == null && inventory.draggingItem) {
				chestDetails.ChestItems [chestSlotNumber] = inventory.draggedItem;
				chestDetails.slotIDs[chestSlotNumber] = inventory.draggedItem.itemID;
				//ItemContainer.currentContainer.storage.storedList[chestDetails.chestID, chestSlotNumber] = chestDetails.ChestItems [chestSlotNumber].itemID;
				inventory.closeDraggedItem ();	
				inventory.canSwap = true;

			} 
				
		} catch {
			
		}
	}
}
