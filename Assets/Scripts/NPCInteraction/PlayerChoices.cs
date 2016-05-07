using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerChoices : MonoBehaviour {

	public int chatButton;
	public string buttonText;
	public float xChange = 10;
	public float yChange = 10;
	public int currentScale;
	public GameObject text;
	public DialogueController dialogueController;
	public int choiceChooser;
	public NPCCharacter npccharacter;

	void Start(){

		text = transform.parent.GetChild (0).gameObject;

	}

	public void MakeAGoddamnChoice(){
		Debug.Log (chatButton);
		Debug.Log (choiceChooser);
		Debug.Log (npccharacter);

		dialogueController.ChoiceResponse (chatButton, choiceChooser, npccharacter);
	}

}
