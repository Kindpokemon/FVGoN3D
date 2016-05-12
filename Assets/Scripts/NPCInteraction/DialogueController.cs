using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {


	public enum DialogueStates{
		Reading,
		Choosing,
		Response
	}
	//Reading SHit
	public DialogueStates dialogueState;
	public GameObject NPCInteract;
	public NPCCharacter NPC;
	public Character character;
	public PlayerMovement playerMovement;
	public InventoryAppearScript invAppear;
	public GameObject textBox;

	//Dialogue Tracking
	public DialogueLine currentLine;
	public DialogueLine lastLine;
	public DialogueLine nextLine;
	public Choice currentChoice;

	public bool canInteract = true;


	public string talkingTo;
	public string choiceString;
	public bool canTalk;
	public bool firstRun;
	public int choiceChooser;

	// Use this for initialization
	void Start () {
		dialogueState = DialogueStates.Reading;
		NPCInteract = this.gameObject;
		textBox = this.transform.GetChild(0).gameObject;
		firstRun = true;
		canTalk = true;

		this.transform.GetChild (1).gameObject.SetActive (false);
		this.transform.GetChild (2).gameObject.SetActive (false);
		this.transform.GetChild (3).gameObject.SetActive (false);
		this.transform.GetChild (4).gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

		if (!currentLine.isChoice && NPC != null) {
			nextLine = NPC.dialogue [currentLine.nextLine];
		}

		if (dialogueState == DialogueStates.Reading && currentLine.command) {
			textBox.GetComponent<Text> ().text = lastLine.text;
		} else if(dialogueState == DialogueStates.Reading){
			textBox.GetComponent<Text>().text = currentLine.text;
		} else if (dialogueState == DialogueStates.Choosing) {
			textBox.GetComponent<Text>().text = currentChoice.fluff;
		}

		if (gameObject.activeSelf == true) {
			if (canTalk && dialogueState == DialogueStates.Reading && Input.GetKeyDown (KeyCode.Return)) {
				if (currentLine.continueType == DialogueLine.ContinueType.Continue){
					if (currentLine.isChoice) {
						Choice (NPC.choices [currentLine.nextChoice], NPC);
					} else {
						UpdateDialogue ();
					}
				} else if (currentLine.continueType == DialogueLine.ContinueType.CloseAndMove){
					ChatClose (true);
				} else if (currentLine.continueType == DialogueLine.ContinueType.End){
					ChatClose (false);
				} else {
					Debug.Log ("ChatMessage Error when talking to " + talkingTo);

				}
			}
		}

		if (dialogueState == DialogueStates.Reading) {
			if (currentLine.command) {
				CommandScript.CommandTranslate (currentLine.text);
				if (currentLine.continueType == DialogueLine.ContinueType.Continue) {
					UpdateDialogue ();
				} else if (currentLine.continueType == DialogueLine.ContinueType.End) {
					ChatClose (false);
				} else if (currentLine.continueType == DialogueLine.ContinueType.CloseAndMove) {
					ChatClose (true);
				} else {
					Debug.Log ("ChatMessage Error when talking to " + talkingTo);
				}
			}
		} else if (dialogueState == DialogueStates.Choosing) {

		} else {
			Debug.Log("Morty, what the h*burp*ell.");
		}
	}

	public void UpdateDialogue(){
		if (!textBox.activeSelf) {
			textBox.SetActive (true);
		}
		if (currentLine != null) {
			lastLine = currentLine;
			currentLine = NPC.dialogue [currentLine.nextLine];
		} else {
			currentLine = NPC.dialogue [NPC.chatRoute];
		}
		canInteract = false;
	}

	public void Choice(Choice choice, NPCCharacter npccharacter){
		currentChoice = choice;
		dialogueState = DialogueStates.Choosing;
		canTalk = false;
		transform.GetChild (0).GetComponent<Text> ().text = choice.fluff;
		for (int i = 0; i < choice.dialogueOptions.Count; i++) {
			GameObject choiceObject = transform.GetChild(i+1).gameObject;
			Debug.Log (choiceObject);
			choiceObject.SetActive(true);
			choiceObject.transform.GetChild(0).GetComponent<Text>().text = choice.dialogueOptions[i];
			choiceObject.GetComponent<PlayerChoices> ().choiceNum = currentLine.nextChoice;
		}
	}

	public void ChoiceResponse(int theChoiceYouMade, int choiceNumber, NPCCharacter npccharacter){
		int dialogueChoiceThing = npccharacter.choices[choiceNumber].optionOutcome[theChoiceYouMade];
		currentLine = npccharacter.dialogue[dialogueChoiceThing];
		for(int p = 0; p < currentChoice.dialogueOptions.Count; p++){
			transform.GetChild(p+1).gameObject.SetActive(false);
		}
		dialogueState = DialogueStates.Reading;
		currentChoice = null;
		canTalk = true;
	}

	public void ChatClose(bool changeClose){
		if (changeClose) {
			NPC.chatRoute = currentLine.nextLine;
		}
		canInteract = true;
		firstRun = true;
		textBox.GetComponent<Text> ().text = "";
		this.gameObject.SetActive (false);
	}
}
