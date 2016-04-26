using UnityEngine;
using System.Collections;

public class HidingSpotInfo : MonoBehaviour {

	RaycastHit hit;
	public float hideHeight;

	void Update(){
		if (Physics.Raycast (transform.position, transform.up, out hit, 10f)) {
			if(hit.transform.gameObject.tag != "Player" && hit.transform.gameObject.tag != "NPC")
				hideHeight = hit.distance;
		} else {
			hideHeight = 10;
		}
	}
}
