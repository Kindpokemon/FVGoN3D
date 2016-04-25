using UnityEngine;
using System.Collections;

public class InventoryCenter : MonoBehaviour {

	public Transform target;
	public float m_speed = 1f;
	GameObject window;
	
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//makes sure the game stays teh same size

		if (target) {
			
			transform.position = Vector3.Lerp(transform.position, target.position, m_speed) + new Vector3(0, 0, -1);//from, to, how fast
			
		}
		
	}
}
