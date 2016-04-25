using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class SlotScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IPointerDownHandler {

	public Item item;
	Image itemImage;
	public int slotNumber;
	Inventory inventory;
	Character character;
	ItemDatabase database;


	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();
		itemImage = gameObject.transform.GetChild (0).GetComponent<Image> ();

		///////////////////////////////////Player Inventory///////////////////////////////////////////////
		
		for(int i = 0; i < 80; i++)
		{
			if(Game.current.player.itemList[i].itemName != null)
			{
				inventory.addItem(Game.current.player.itemList[i].itemID, i);

			} else {

				inventory.Items[i] = new Item();

			}
		}
		inventory.addItem (0,0);
		inventory.addItem (1,1);
		inventory.addItem (2,2);
		inventory.addItem (3,3);
		inventory.addItem (4,4);
		inventory.addItem (5,5);
		inventory.addItem (6,6);
		
		////////////////////////////////End of Player Inventory///////////////////////////////////////////
	}

	// Update is called once per frame
	void Update () {


		if (inventory.Items[slotNumber].itemName != null) 
		{

			itemImage.enabled = true;
			itemImage.sprite = inventory.Items[slotNumber].itemIcon;

		} else {

			itemImage.enabled = false;
		}

	}

	public void OnPointerEnter(PointerEventData data)
	{
		if (inventory.Items [slotNumber].itemName != null && inventory.draggingItem == false) {

			inventory.showTooltip(inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition, inventory.Items[slotNumber], 0);
		}
	}

	public void OnPointerExit(PointerEventData data)
	{
		if (inventory.Items [slotNumber].itemName != null) {

			inventory.closeTooltip ();
		}
	}

	public void OnDrag(PointerEventData data)
	{
		if(inventory.draggingItem == false)
		{
			if(inventory.Items[slotNumber].itemName != null){
				Game.current.player.itemList[slotNumber] = new Item();
				inventory.showDraggedItem(inventory.Items[slotNumber], slotNumber);
				inventory.Items[slotNumber] = new Item();


			}
		}
	}


	public void OnPointerDown(PointerEventData data)
	{
		try
		{
			if(slotNumber == 70 && inventory.draggedItem.itemType == Item.ItemType.LeftHand){

				if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) {
					inventory.Items [slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					inventory.closeDraggedItem ();
					inventory.canSwap = true;
					
				} else if(inventory.draggingItem && inventory.Items[slotNumber].itemName != null && inventory.canSwap) {
					
					inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.Items[slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					Game.current.player.itemList[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.closeDraggedItem();
				}


			}

			if(slotNumber == 71 && inventory.draggedItem.itemType == Item.ItemType.Back){
				
				if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) {
					inventory.Items [slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					inventory.closeDraggedItem ();
					inventory.canSwap = true;
					
				} else if(inventory.draggingItem && inventory.Items[slotNumber].itemName != null && inventory.canSwap) {
					
					inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.Items[slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					Game.current.player.itemList[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.closeDraggedItem();
				}
				
				
			}
			
			if(slotNumber == 72 && (inventory.draggedItem.itemType == Item.ItemType.Head || inventory.draggedItem.itemType == Item.ItemType.Face || inventory.draggedItem.itemType == Item.ItemType.Hat)){
				
				if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) {
					inventory.Items [slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					inventory.closeDraggedItem ();
					inventory.canSwap = true;
					
				} else if(inventory.draggingItem && inventory.Items[slotNumber].itemName != null && inventory.canSwap) {
					
					inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.Items[slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					Game.current.player.itemList[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.closeDraggedItem();
				}
				
				
			}
			
			if(slotNumber == 73 && inventory.draggedItem.itemType == Item.ItemType.Neck){
				
				if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) {
					inventory.Items [slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					inventory.closeDraggedItem ();
					inventory.canSwap = true;
					
				} else if(inventory.draggingItem && inventory.Items[slotNumber].itemName != null && inventory.canSwap) {
					
					inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.Items[slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					Game.current.player.itemList[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.closeDraggedItem();
				}
				
				
			}
			
			if(slotNumber == 74 && inventory.draggedItem.itemType == Item.ItemType.RightHand){
				
				if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) {
					inventory.Items [slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					inventory.closeDraggedItem ();
					inventory.canSwap = true;
					
				} else if(inventory.draggingItem && inventory.Items[slotNumber].itemName != null && inventory.canSwap) {
					
					inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.Items[slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					Game.current.player.itemList[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.closeDraggedItem();
				}
				
				
			}
			
			if(slotNumber == 75 && (inventory.draggedItem.itemType == Item.ItemType.Weapon || inventory.draggedItem.itemType == Item.ItemType.Shield)){
				
				if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) {
					inventory.Items [slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					inventory.closeDraggedItem ();
					inventory.canSwap = true;
					
				} else if(inventory.draggingItem && inventory.Items[slotNumber].itemName != null && inventory.canSwap) {
					
					inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.Items[slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					Game.current.player.itemList[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.closeDraggedItem();
				}
				
				
			}
			
			if(slotNumber == 76 && inventory.draggedItem.itemType == Item.ItemType.Pants){
				
				if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) {
					inventory.Items [slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					inventory.closeDraggedItem ();
					inventory.canSwap = true;
					
				} else if(inventory.draggingItem && inventory.Items[slotNumber].itemName != null && inventory.canSwap) {
					
					inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.Items[slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					Game.current.player.itemList[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.closeDraggedItem();
				}
				
				
			}
			
			if(slotNumber == 77 && inventory.draggedItem.itemType == Item.ItemType.Chest){
				
				if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) {
					inventory.Items [slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					inventory.closeDraggedItem ();
					inventory.canSwap = true;
					
				} else if(inventory.draggingItem && inventory.Items[slotNumber].itemName != null && inventory.canSwap) {
					
					inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.Items[slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					Game.current.player.itemList[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.closeDraggedItem();
				}
				
				
			}
			
			if(slotNumber == 78 && inventory.draggedItem.itemType == Item.ItemType.Shoes){
				if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) {
					inventory.Items [slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					inventory.closeDraggedItem ();
					inventory.canSwap = true;
					
				} else if(inventory.draggingItem && inventory.Items[slotNumber].itemName != null && inventory.canSwap) {
					
					inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.Items[slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					Game.current.player.itemList[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.closeDraggedItem();
				}
				
				
			}
			
			if(slotNumber == 79 && inventory.draggedItem.itemType == Item.ItemType.Weapon || inventory.draggedItem.itemType == Item.ItemType.Shield){
				
				if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) {
					inventory.Items [slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					inventory.closeDraggedItem ();
					inventory.canSwap = true;
					
				} else if(inventory.draggingItem && inventory.Items[slotNumber].itemName != null && inventory.canSwap) {
					
					inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.Items[slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					Game.current.player.itemList[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.closeDraggedItem();
				}
				
				
			}
			

			else if(slotNumber < 70) {

				if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) {
					inventory.Items [slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					inventory.closeDraggedItem ();
					inventory.canSwap = true;
					
				} else if(inventory.draggingItem && inventory.Items[slotNumber].itemName != null && inventory.canSwap) {
					
					inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.Items[slotNumber] = inventory.draggedItem;
					Game.current.player.itemList[slotNumber] = inventory.Items[slotNumber];
					Game.current.player.itemList[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
					inventory.closeDraggedItem();
				}

			}
		}catch {

		}
	}
}
