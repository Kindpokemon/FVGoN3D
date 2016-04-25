using UnityEngine;
using System.Collections;

public class PlayerTrigger : MonoBehaviour {

	public bool touchingBox;
	

	void OnTriggerStay2D(Collider2D coll){
		Debug.Log ("Player Fired");
		if (coll.gameObject.tag == "Behindable") {
			touchingBox = true;
		} else {
			touchingBox = false;
		}

	}
}
