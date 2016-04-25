using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIRender : MonoBehaviour {

	public ReferenceList reflist;
	public GameObject topBar;
	public List<Image> topbarSprites;
	public int mousedOver;
	public GameObject outline;

	// Use this for initialization
	void Start () {
		reflist = GameObject.FindGameObjectWithTag ("reflist").GetComponent<ReferenceList> ();
		for (int i = 0; i < topBar.transform.childCount; i++) {
			topbarSprites.Add (topBar.transform.GetChild (i).GetComponent<Image>());
		}
	}
	
	// Update is called once per frame
	void Update () {
		//TopBar

		//Middle
		if (outline.GetComponent<Image>().enabled) {
			topbarSprites [0].sprite = outline.transform.parent.GetComponent<Image> ().sprite;
			topbarSprites [0].enabled = true;
		} else {
			topbarSprites[0].sprite = null;
			topbarSprites[0].enabled = false;
		}
		//Left
		if (reflist.inventory.Items [75].itemName != null) {
			topbarSprites [1].sprite = reflist.inventory.Items [75].itemIcon;
			topbarSprites[1].enabled = true;
		} else {
			topbarSprites[1].sprite = null;
			topbarSprites[1].enabled = false;
		}
		//Right
		if (reflist.inventory.Items [79].itemName != null) {
			topbarSprites [2].sprite = reflist.inventory.Items [79].itemIcon;
			topbarSprites[2].enabled = true;
		} else {
			topbarSprites[2].sprite = null;
			topbarSprites[2].enabled = false;
		}
		//Slots
		for (int i = 0; i < 8; i++) {
			if (reflist.inventory.Attacks [i].attackName != null) {
				topbarSprites [i+3].sprite = reflist.inventory.Attacks [i].sprite;
				topbarSprites [i+3].enabled = true;
			} else {
				topbarSprites [i+3].sprite = null;
				topbarSprites [i+3].enabled = false;
			}
		}

		for(int s = 1; s < 9; s++){
			if (Input.GetKeyDown (s + "")) {
				if (topbarSprites [s + 2].enabled) {
					if (outline.transform.parent == topbarSprites [s + 2].transform && mousedOver == s) {
						outline.GetComponent<Image> ().enabled = false;
						mousedOver = -1;
					} else {
						outline.transform.SetParent (topbarSprites [s + 2].transform);
						outline.GetComponent<RectTransform> ().anchoredPosition = Vector2.zero;
						outline.GetComponent<Image> ().enabled = true;
						mousedOver = s;
					}
				}
			}
		}
	}
}
