using UnityEngine;
using System.Collections;

public class DevOptions : MonoBehaviour {

	public bool noclip;
	//public bool infiniteHealth;
	//public bool infiniteMana;
	//public bool infiniteStamina;
	//public ExitScreenAppear escAppear;
	public bool devShowing = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftAlt) && Input.GetKeyDown (KeyCode.F12)) {
			devShowing = !devShowing;
		}

		if (noclip) {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<BoxCollider2D> ().enabled = false;
		} else {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<BoxCollider2D> ().enabled = true;
		}
	}

	void OnGUI(){
		GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();
		if (devShowing) {
			noclip = GUILayout.Toggle (noclip, "Noclip On/Off");
			GUILayout.Space(100);





		}
		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}
