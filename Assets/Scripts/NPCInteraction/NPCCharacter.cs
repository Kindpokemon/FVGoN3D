using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCCharacter : MonoBehaviour {

	public DialogueController dialogueController;
	public List<ChatArray> dialogueText = new List<ChatArray>();
	public List<ChatArray> dialogueChoices = new List<ChatArray>();
	public List<ChatArray> choiceResults = new List<ChatArray> ();
	public int chatRoute;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
