using UnityEngine;
using System.Collections;

public class DialogueController : MonoBehaviour {

	
	public enum DialogueStates{
		
		Reading,
		Choosing
		
	}
	
	public DialogueStates dialogueState;

	// Use this for initialization
	void Start () {

		
		dialogueState = DialogueStates.Reading;

	}
	
	// Update is called once per frame
	void Update () {

        if(dialogueState == DialogueStates.Reading && Input.GetKeyDown(KeyCode.Mouse0))
        {

        }

		if (dialogueState == DialogueStates.Reading) {

			if(Input.GetMouseButtonDown(0)){

				UpdateDialogue(5);

			}

			gameObject.transform.GetChild(0).gameObject.SetActive(true);
			gameObject.transform.GetChild(1).gameObject.SetActive(false);
			gameObject.transform.GetChild(2).gameObject.SetActive(false);
			gameObject.transform.GetChild(3).gameObject.SetActive(false);
			gameObject.transform.GetChild(4).gameObject.SetActive(false);


		} else if (dialogueState == DialogueStates.Choosing) {

			gameObject.transform.GetChild(0).gameObject.SetActive(false);
			gameObject.transform.GetChild(1).gameObject.SetActive(true);
			gameObject.transform.GetChild(2).gameObject.SetActive(true);
			gameObject.transform.GetChild(3).gameObject.SetActive(true);
			gameObject.transform.GetChild(4).gameObject.SetActive(true);

		} else {
			Debug.Log("Morty, what the hell.");
		}
	}

	public void UpdateDialogue(int choice){
		
		if(choice > -1)
        {

        } else
        {
            dialogueState = DialogueStates.Choosing;

        }
		
	}
}
