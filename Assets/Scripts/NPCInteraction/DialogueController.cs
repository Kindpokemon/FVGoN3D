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

	public DialogueStates dialogueState;
	public List<string> content = new List<string>();
	public List<ChatArray> choices = new List<ChatArray> ();
	public List<ChatArray> contentOverall = new List<ChatArray>();
	public int currentContent = 0;
	public string talkingTo;
	public GameObject NPCInteract;
	public Character character;
	public bool chatDone = true;
	public NPCCharacter NPC;
	public string choiceString;
	public GameObject textBox;
	public PlayerMovement playerMovement;
	public bool canTalk;
	public InventoryAppearScript invAppear;
	public bool firstRun;
	public int choiceChooser;

	// Use this for initialization
	void Start () {
		dialogueState = DialogueStates.Reading;
		NPCInteract = this.gameObject;
		textBox = this.transform.GetChild(0).gameObject;
		firstRun = true;
		canTalk = true;
	}

	// Update is called once per frame
	void Update () {

		if (dialogueState == DialogueStates.Reading) {
			textBox.GetComponent<Text>().text = content[currentContent];
		}
		if (dialogueState == DialogueStates.Choosing) {
			textBox.GetComponent<Text>().text = choices[choiceChooser].chatDialogue[currentContent];
		}

		if (gameObject.activeSelf == true) {
			if (canTalk && dialogueState == DialogueStates.Reading && ((Input.GetKeyDown (KeyCode.Return) && chatDone) || Input.GetKeyDown (KeyCode.P))) {
				if (content [currentContent + 1].Contains ("chatChoice")) {
					choiceString = content[currentContent+1];
					Debug.Log("prechoice");
					Choice (choiceString, NPC);
				} else if (content [currentContent + 1] == "chatEnd") {
					ChatClose ();
				} else if (content[currentContent+1].Contains ("chatContinue")){
					int q = new int();
					for (int j = 0; j < content[currentContent + 1].Length; j++) {
						if (char.IsDigit (content [currentContent + 1] [j])) {
							q = (content [currentContent + 1] [j])-48;
						}
					}
					currentContent = 0;
					content = NPC.dialogueText[q].chatDialogue;
					NPC.chatRoute = q;
				} else if (content [currentContent + 1].Contains ("chatEnd")) {
					for (int j = 0; j < content[currentContent + 1].Length; j++) {
						if (char.IsDigit (content [currentContent + 1] [j])) {
							int k = (content [currentContent + 1] [j])-48;
							NPC.chatRoute = k;
						}
					}
					ChatClose ();
				} else if (content [currentContent] != null) {
					if(!firstRun){
						currentContent = currentContent + 1;
					} else {
						firstRun = false;
					}
				} else {
					Debug.Log ("ChatMessage.Error when talking to " + talkingTo);

				}
			}
		}
		if (dialogueState == DialogueStates.Reading) {

		} else if (dialogueState == DialogueStates.Choosing) {

		} else {
			Debug.Log("Morty, what the h*burp*ell.");
		}
	}

	public void UpdateDialogue(){
		if (!this.gameObject.activeSelf) {
			this.gameObject.SetActive(true);
			content = NPC.dialogueText[NPC.chatRoute].chatDialogue;
			choices = NPC.dialogueChoices;
			contentOverall = NPC.dialogueText;

		}
		Debug.Log ("Dialogue Updated");
	}

	public void Choice(string choiceStr, NPCCharacter npccharacter){
		Debug.Log ("prestatechange");
		dialogueState = DialogueStates.Choosing;
		Debug.Log ("preforloop");
		for (int j = 0; j < choiceStr.Length; j++) {
			Debug.Log (choiceStr+", "+j+", "+choiceStr[j]);
			if (char.IsDigit (choiceStr[j])) {
				Debug.Log ("prechoicechooser");
				choiceChooser = (choiceStr[j])-48;
				Debug.Log (choiceChooser);
			}
		}
		Debug.Log ("precurrentcontent");
		currentContent = 0;
		canTalk = false;
		for (int i = 1; i < npccharacter.dialogueChoices[choiceChooser].chatDialogue.Count; i++) {
			GameObject choiceObject = transform.GetChild(i).gameObject;
			choiceObject.SetActive(true);
			choiceObject.transform.GetChild(0).GetComponent<Text>().text = npccharacter.dialogueChoices[choiceChooser].chatDialogue[i];
			choiceObject.GetComponent<PlayerChoices>().choiceChooser = choiceChooser;
			choiceObject.GetComponent<PlayerChoices>().npccharacter = npccharacter;
		}
	}

	public void ChoiceResponse(int theChiceYouMade, int choiceNumber, NPCCharacter npccharacter){
		Debug.Log ("Debug 1 "+npccharacter.choiceResults [choiceNumber]);
		Debug.Log ("Debug 2 "+npccharacter.choiceResults [choiceNumber].chatDialogue);
		Debug.Log ("Debug 3 "+npccharacter.choiceResults [choiceNumber].chatDialogue[theChiceYouMade][0]);
		int dialogueChoiceThing = npccharacter.choiceResults [choiceNumber].chatDialogue [theChiceYouMade][0]-48;
		Debug.Log ("Its just the debug");
		Debug.Log ("Debug 4 "+npccharacter.dialogueText [dialogueChoiceThing]);
		Debug.Log ("Debug 5 "+npccharacter.dialogueText [dialogueChoiceThing].chatDialogue[0]);

		content = npccharacter.dialogueText [dialogueChoiceThing].chatDialogue;
		for(int p = 1; p < gameObject.transform.childCount; p++){
			gameObject.transform.GetChild(p).gameObject.SetActive(false);
		}
		dialogueState = DialogueStates.Reading;
		canTalk = true;
	}

	public void ChatClose(){
		this.gameObject.SetActive (false);
		currentContent = 0;
		firstRun = true;
	}
}
