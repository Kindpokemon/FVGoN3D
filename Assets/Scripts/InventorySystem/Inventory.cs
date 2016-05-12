using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Inventory : MonoBehaviour {

	public List<GameObject> Slots =  new List<GameObject>();
	public List<Item> Items = new List<Item>();
	public List<Attack> Attacks = new List<Attack>();
	public GameObject slots;
	ItemDatabase database;
	float x = -196F;
	float y = -10.5F;
	
	public GameObject armorSlot;
	float armorX = -73.4F;
	float armorY = 130.4F;

	public GameObject chestSlot;

	// Use this for initialization

	public GameObject tooltip;
	public GameObject draggedItemGameObject;
	public bool draggingItem = false;
	public Item draggedItem;
	public int indexOfDraggedItem;
	public bool activeToolip = false;

	public GameObject word;

	public SlotScript slotScript;
	
	public bool canSwap = true;

	public bool looping;

	void Update()
	{
		if (draggingItem) {

			Vector3 posi = (Input.mousePosition - GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>().localPosition);
			draggedItemGameObject.GetComponent<RectTransform>().localPosition = new Vector3(posi.x + 15, posi.y - 15, posi.z);
		}

	}

	public void displayPlayerName()
	{
		word.transform.GetChild (0).GetComponent<Text> ().text = Game.current.player.name;
		
		
	}

	public void showTooltip(Vector3 toolPosition, Item item, float extraX)
	{

		tooltip.SetActive (true);
		activeToolip = true;
		tooltip.GetComponent<RectTransform> ().localPosition = new Vector3 (toolPosition.x + 130F + extraX, toolPosition.y - 60F, toolPosition.z);
		//information
		tooltip.transform.GetChild (0).GetComponent<Text>().text = item.itemDesc;
		tooltip.transform.GetChild (1).GetComponent<Text>().text = '"' + item.itemRarity + '"';
		tooltip.transform.GetChild (2).GetComponent<Text>().text = item.itemWorth + " Spondulicks";
		if (item.itemDamage > 0) {
			tooltip.transform.GetChild (3).GetComponent<Text>().text = "Deals " + item.itemDamage + " DMG at " + item.itemSpeed + " SPS.";

		} else if (item.itemHeal > 0) {
			tooltip.transform.GetChild (3).GetComponent<Text>().text = "Heals " + item.itemHeal + " Health";

		} else if (item.itemBuff > 0) {
			tooltip.transform.GetChild (3).GetComponent<Text>().text = item.buffType + item.itemBuff;

		} else if (item.itemArmor > 0) {
			tooltip.transform.GetChild (3).GetComponent<Text>().text = "Armor: " + item.itemArmor;

		} else {
			tooltip.transform.GetChild (3).GetComponent<Text>().text = "This item is not equipable or consumable.";

		}
	}

	public void closeTooltip()
	{
		tooltip.SetActive (false);
		activeToolip = false;
	}

	public void showDraggedItem(Item item, int slotnumber)
	{
		indexOfDraggedItem = slotnumber;
		closeTooltip ();
		draggedItemGameObject.SetActive (true);
		draggedItem = item;
		draggingItem = true;
		draggedItemGameObject.GetComponent<Image> ().sprite = item.itemIcon;
	}

	public void dragRetention(){
		draggedItemGameObject.SetActive (true);
	}

	public void closeDraggedItem()
	{
		draggingItem = false;
		draggedItem = new Item ();
		draggedItemGameObject.SetActive (false);
	}
	void Start () {

		slotScript = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<SlotScript>();
		/// 
		displayPlayerName ();

		int Slotamount = 0;
	
		database = GameObject.FindWithTag ("ItemDatabase").GetComponent<ItemDatabase> ();



		for (int i = 0; i < 5; i++) {

			for (int k = 0; k < 14; k++) {
				GameObject slot = (GameObject)Instantiate (slots);

				slot.GetComponent<SlotScript>().slotNumber = Slotamount;

				Slots.Add (slot);
				Items.Add (new Item ());

				slot.transform.SetParent(this.gameObject.transform);
				slot.GetComponent<RectTransform> ().localPosition = new Vector3 (x, y, 0);
				x = x + 28.333F;
				if (k == 13) {

					x = -196F;
					y = y - 28.333F;
				}
				Slotamount++;

			}
		}

		for (int j = 0; j < 2; j++) {
			
			for (int l = 0; l < 5; l++) {
				GameObject slot = (GameObject)Instantiate (armorSlot);
				
				slot.GetComponent<SlotScript>().slotNumber = Slotamount;
				
				Slots.Add (slot);
				Items.Add (new Item ());

				//transform.GetChild(i+81).GetComponent<CharacterSlot>().index = i;
				slot.transform.SetParent(this.gameObject.transform);
				slot.GetComponent<RectTransform> ().localPosition = new Vector3 (armorX, armorY, 0);
				armorX = armorX + 67F;
				if (l == 4) {
					
					armorX = -73.4F;
					armorY = armorY - 67F;
				}
				Slotamount++;
				
			}
		}
		for (int i = 0; i < 8; i++) {
			Items.Add (new Item ());
		}
		gameObject.SetActive (false);
	}

	public bool checkIfItemExists(Item itemOne, Item itemTwo)
	{
		if(itemOne.itemID == itemTwo.itemID)
		{

			return true;
				
		}

		else{

			return false;
				
		}
	}
	///Item Slots

	public void addItem(int id, int slot)
	{
		for (int i = 0; i < database.items.Count; i++) {

			if(database.items[i].itemID == id)
			{

				Item item = database.items[i];
				addItemAtSpecificSlot(item, slot);


			}
		}
	}

	public void addItemAtEmptySlot(Item item)
	{
		for (int i = 0; i < Items.Count; i++) {

			if (Items[i].itemName == null)
			{
				Items[i] = item;
				break;
			}
		}
	}

	void addItemAtSpecificSlot(Item item, int specificSlot)
	{
		Items [specificSlot] = item;
	}

	///Armor Slots
	
	public void addArmor(int id, int armorSlot)
	{
		for (int i = 0; i < database.items.Count; i++) {
			
			if(database.items[i].itemID == id)
			{
				
				Item item = database.items[i];
				addArmorAtSpecificSlot(item, armorSlot);
				
				
			}
		}
	}
	
	public void addArmorAtEmptySlot(Item item)
	{
		for (int i = 0; i < Items.Count; i++) {
			
			if (Items[i].itemName == null)
			{
				Items[i] = item;
				break;
			}
		}
	}
	
	void addArmorAtSpecificSlot(Item item, int specificSlot)
	{
		Items [specificSlot] = item;
	}



}

