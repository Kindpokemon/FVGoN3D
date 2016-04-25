using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayInventoryArmor : MonoBehaviour {

	Inventory inventory;
	ItemDatabase database;
	Character character;
	SlotScript slotscript;
	Image armorImage;
	public int armorNumber;
	public GameObject slotParent;
	
	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();
		armorImage = gameObject.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

		slotscript = slotParent.transform.GetChild (armorNumber+3).GetComponent<SlotScript>();



		if (slotscript.slotNumber == 70 && inventory.Items [70].itemName != null) {

			armorImage.enabled = true;
			armorImage.sprite = Resources.Load<Sprite> ("PlayerRep/LeftHand/" + inventory.Items [70].itemName);


		} else if (slotscript.slotNumber == 71 && inventory.Items [71].itemName != null) {
			
			armorImage.enabled = true;
			armorImage.sprite = Resources.Load<Sprite> ("PlayerRep/Back/" + inventory.Items [71].itemName);
			
			
		} else if (slotscript.slotNumber == 72 && inventory.Items [72].itemName != null) {
			
			armorImage.enabled = true;
			armorImage.sprite = Resources.Load<Sprite> ("PlayerRep/Head/" + inventory.Items [72].itemName);
			
			
		} else if (slotscript.slotNumber == 73 && inventory.Items [73].itemName != null) {
			
			armorImage.enabled = true;
			armorImage.sprite = Resources.Load<Sprite> ("PlayerRep/Neck/" + inventory.Items [73].itemName);

			
			
		} else if (slotscript.slotNumber == 74 && inventory.Items [74].itemName != null) {
			
			armorImage.enabled = true;
			armorImage.sprite = Resources.Load<Sprite> ("PlayerRep/RightHand/" + inventory.Items [74].itemName);
			
			
		} else if (slotscript.slotNumber == 75 && inventory.Items [75].itemName != null) {
			
			armorImage.enabled = true;
			armorImage.sprite = Resources.Load<Sprite> ("PlayerRep/LeftWeapon/" + inventory.Items [75].itemName);
			
			
		} else if (slotscript.slotNumber == 76 && inventory.Items [76].itemName != null) {
			
			armorImage.enabled = true;
			armorImage.sprite = Resources.Load<Sprite> ("PlayerRep/Pants/" + inventory.Items [76].itemName);
			
			
		} else if (slotscript.slotNumber == 77 && inventory.Items [77].itemName != null) {
			
			armorImage.enabled = true;
			armorImage.sprite = Resources.Load<Sprite> ("PlayerRep/Chest/" + inventory.Items [77].itemName);
			
			
		} else if (slotscript.slotNumber == 78 && inventory.Items [78].itemName != null) {
			
			armorImage.enabled = true;
			armorImage.sprite = Resources.Load<Sprite> ("PlayerRep/Shoes/" + inventory.Items [78].itemName);
			
			
		} else if (slotscript.slotNumber == 79 && inventory.Items [79].itemName != null) {
			
			armorImage.enabled = true;
			armorImage.sprite = Resources.Load<Sprite> ("PlayerRep/RightWeapon/" + inventory.Items [79].itemName);
			
			
		} else {
			
			armorImage.enabled = false;
		}


	}
}
