using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class HotbarSlot : MonoBehaviour, IPointerDownHandler, IDragHandler {

	public Attack attack;
	public Item item;
	Image itemImage;
	public int hotbarNumber;
	Inventory inventory;
	Character character;
	ReferenceList refList;

	void Start(){
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
		itemImage = gameObject.transform.GetChild (0).GetComponent<Image> ();
		refList = GameObject.FindGameObjectWithTag ("reflist").GetComponent<ReferenceList> ();
		if(!DevStats.DevMode){
			if (Game.current.player.itemList[80+hotbarNumber].itemName != null) {
				SetAttack (Game.current.player.itemList [80+hotbarNumber], hotbarNumber);
			}
		} else {
			inventory.Attacks [hotbarNumber] = new Attack ();
		}
	}

	void Update(){
		attack = inventory.Attacks [hotbarNumber];
		if (inventory.Attacks[hotbarNumber].attackName != null) 
		{
			itemImage.enabled = true;
			itemImage.sprite = attack.sprite;

		} else {

			itemImage.enabled = false;
		}
	}

	public void OnPointerDown(PointerEventData data){
		try{
			if(inventory.draggedItem.itemType == Item.ItemType.Consumable || inventory.draggedItem.itemType == Item.ItemType.Weapon || inventory.draggedItem.itemType == Item.ItemType.Shield){
				SetAttack(inventory.draggedItem, hotbarNumber);
				//Game.current.player.hotbarList[hotbarNumber] = inventory.draggedItem.itemID;
			} else if(inventory.draggedItem.itemName == null ){
				inventory.Attacks[hotbarNumber] = new Attack();
				//Game.current.player.hotbarList[hotbarNumber] = new Attack();
			}
		} catch {
			
		}
	}

	public void OnDrag(PointerEventData data){
		if(inventory.draggingItem == false)
		{
			if(inventory.Items[80+hotbarNumber].itemName != null){
				inventory.canSwap = false;
				if (!DevStats.DevMode) {
					Game.current.player.itemList [80+hotbarNumber] = new Item();
				}
				inventory.showDraggedItem(inventory.Items[80+hotbarNumber],80+hotbarNumber);
				inventory.Items[80+hotbarNumber] = new Item();


			}
		}
	}

	public void SetAttack(Item item, int slot){
		for (int i = 0; i < refList.atkDatabase.attacks.Count; i++) {
			for(int j = 0; j < refList.atkDatabase.attacks[i].idNumbers.Length; j++){
				if(refList.atkDatabase.attacks[i].idNumbers[j] == item.itemID){
					Attack atk = refList.atkDatabase.attacks[i];
					atk.sprite = item.itemIcon;
					SetAttackAtSpecificSlot (atk, slot);

				}
			}
		}
	}

	public void SetAttackAtSpecificSlot(Attack attack, int slot){
		inventory.Attacks [slot] = attack;
	}
}
