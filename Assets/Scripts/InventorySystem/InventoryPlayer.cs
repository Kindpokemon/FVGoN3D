using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryPlayer : MonoBehaviour {

	Character character;

	public GameObject player;
	public GameObject playerHair;
	public GameObject playerBeard;
	public GameObject slotParent;
	Inventory inventory;
	public int armorNumber;
	Image playerImage;
	Image hairImage;
	Image beardImage;
	public IngameStaticStats ingamestaticstats;

	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();
		playerImage = player.GetComponent<Image>() ;
		hairImage = playerHair.GetComponent<Image>() ;
		beardImage = playerBeard.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!DevStats.DevMode) {
			playerImage.sprite = Resources.Load<Sprite> ("PlayerRep/PlayerSprites/" + ingamestaticstats.raceLocation + "/" + ingamestaticstats.raceLocation + ingamestaticstats.genderName + Game.current.player.playerSkin);
			hairImage.sprite = Resources.Load<Sprite> ("PlayerRep/Hair/" + ingamestaticstats.genderName + "/hair" + ingamestaticstats.genderName + Game.current.player.hairColor + Game.current.player.hairType);
			beardImage.sprite = Resources.Load<Sprite> ("PlayerRep/Hair/Beards/beard" + Game.current.player.beardColor + Game.current.player.beardType);

			if (inventory.Items [72].itemType == Item.ItemType.Hat || inventory.Items [72].itemType == Item.ItemType.Head) {
				playerHair.SetActive (false);
			} else {
				playerHair.SetActive (true);
			}

			if (inventory.Items [72].itemType == Item.ItemType.Face || inventory.Items [72].itemType == Item.ItemType.Head) {
				playerBeard.SetActive (false);
			} else {
				playerBeard.SetActive (true);
			}
		}
	}
}
