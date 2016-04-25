using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC : MonoBehaviour {

	//public int[] NPCDialogueID = new int[100];
	//public List<string> DialogueText = new List<string>();
	//public Dictionary<int,string> Quests;

	//public int[] RandomTextID = new int[100];
	//public List<string> RandomText = new List<string>();
	//public Dictionary<int,string> RandomDialogue;

	//public int[] ResponseChoiceID = new int[100];
	//public List<string> ResponseChoiceOne = new List<string>();
	//public List<string> ResponseChoiceTwo = new List<string>();
	//public List<string> ResponseChoiceThree = new List<string>();
	//public List<string> ResponseChoiceFour = new List<string>();

	public GameObject dialogueBox;
	public DialogueController dialogueController;

	// Use this for initialization
	void Start () {
		dialogueBox = GameObject.FindGameObjectWithTag("DialogueBox");
		dialogueController = dialogueBox.GetComponent<DialogueController> ();

		//for (int i = 0; i<DialogueText.Count; i++) {
		//	Quests.Add(NPCDialogueID[i],DialogueText[i]);
		//}
		
		//for (int i = 0; i<RandomText.Count; i++) {
		//	RandomDialogue.Add(RandomTextID[i],RandomText[i]);
		//}

	}
	
	// Update is called once per frame


}
