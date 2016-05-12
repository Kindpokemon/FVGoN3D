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
	public int choiceChooser;
	public int choiceNum;
	public ReferenceList reflist;

	void Start(){
		reflist = GameObject.FindGameObjectWithTag ("reflist").GetComponent<ReferenceList> ();
		text = transform.parent.GetChild (0).gameObject;

	}

	public void MakeAGoddamnChoice(){
		reflist.dialogueController.ChoiceResponse (chatButton, choiceNum, reflist.dialogueController.NPC);
	}

}
