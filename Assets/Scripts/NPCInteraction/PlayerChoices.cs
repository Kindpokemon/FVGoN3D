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

	void Start(){

		text = transform.parent.GetChild (0).gameObject;

	}

	public void MakeAGoddamnChoice(){


		dialogueController.UpdateDialogue (this.chatButton);
	}

	public void OnMouseEnter(){
		Debug.Log("Enter");
		gameObject.transform.localScale += new Vector3(.5F,.5F,0);
		if (chatButton == 0) {
			gameObject.transform.position += new Vector3(0,10,0);
		} else if (chatButton == 1) {
			gameObject.transform.position += new Vector3(10,0,0);
		} else if (chatButton == 2) {
			gameObject.transform.position -= new Vector3(0,10,0);
		} else if (chatButton == 3) {
			gameObject.transform.position -= new Vector3(10,0,0);
		} else {
			Debug.Log("Goddamn it, Morty, you broke the code!");
		}
	}
	
	public void OnMouseExit(){
		Debug.Log("Exit");
		gameObject.transform.localScale -= new Vector3(.5F,.5F,0);
		if (chatButton == 0) {
			gameObject.transform.position -= new Vector3(0,10,0);
		} else if (chatButton == 1) {
			gameObject.transform.position -= new Vector3(10,0,0);
		} else if (chatButton == 2) {
			gameObject.transform.position += new Vector3(0,10,0);
		} else if (chatButton == 3) {
			gameObject.transform.position += new Vector3(10,0,0);
		} else {
			Debug.Log("Goddamn it, Morty, you broke the code!");
		}
		
	}
}
