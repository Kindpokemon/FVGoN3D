 using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryAppearScript : MonoBehaviour {

	public GameObject menu;
	public GameObject chestMenu;
	public bool isShowing;
	public GameObject toolTip;
	public GameObject draggedItem;
	ReferenceList reflist;
	public GameObject HUD;
	public bool escIsShowing;
	public GameObject escMenu;

	void Start(){
		reflist = GameObject.FindGameObjectWithTag ("reflist").GetComponent<ReferenceList> ();
		isShowing = false;
	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.E)) {
			//Debug.Log ("From Appear: " + Game.current.player.name);
			if (!escIsShowing) {
				if (isShowing) {
					isShowing = false;
					menu.SetActive (false);
					chestMenu.SetActive (false);
				} else {
					isShowing = true;
					menu.SetActive (true);
				}
				if (reflist.playerCamera.ableToOpen) {
					if (reflist.chest.chestOpen) {
						reflist.chest.ToggleChest (false);
					} else {
						reflist.chest.ToggleChest (true);
					}
				}
			}
			if (isShowing && reflist.inventory.draggingItem && !reflist.inventory.draggedItemGameObject.activeSelf) {
				reflist.inventory.dragRetention ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (isShowing) {
				isShowing = false;
				escIsShowing = true;
				menu.SetActive (false);
				chestMenu.SetActive (false);
				escMenu.SetActive (true);
			} else if (escIsShowing) {
				escIsShowing = false;
				escMenu.SetActive (false);

			} else {
				escIsShowing = true;
				escMenu.SetActive (true);
				menu.SetActive (false);
				chestMenu.SetActive (false);
			}
			if (!isShowing && reflist.chest.chestOpen) {
				reflist.chest.ToggleChest (false);
			}
		}

		if (isShowing == false && escIsShowing == false) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			reflist.playerControl.movementEnabled = true;
			reflist.playerCamera.playerControlEnabled = true;
			HUD.SetActive (true);
			toolTip.SetActive (false);
			draggedItem.SetActive (false);
			if (reflist.chest.details != null) {
				if (reflist.chest.details.chestName.Length > 0 ) {
					reflist.chest.text.text = reflist.chest.details.chestName;
				} else {
					reflist.chest.text.text = reflist.chest.details.gameObject.name;
				}
			}

		} else {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			reflist.playerControl.movementEnabled = false;
			reflist.playerCamera.playerControlEnabled = false;
			HUD.SetActive (false);

		}
	}


}
