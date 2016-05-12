using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCCharacter : MonoBehaviour {

	public DialogueController dialogueController;
	public List<DialogueLine> dialogue = new List<DialogueLine>();
	public List<Choice> choices = new List<Choice>();
	public int chatRoute;

	public NPCCharacter(){

	}

	public NPCCharacter(DialogueController DC, List<DialogueLine> dia, List<Choice> choi, int currentRoute){
		dialogueController = DC;
		dialogue = dia;
		choices = choi;
		chatRoute = currentRoute;
	}
}
