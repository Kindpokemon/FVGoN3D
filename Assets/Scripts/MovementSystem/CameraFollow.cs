using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float m_speed = 1f;
	Camera mycam;


	// Use this for initialization
	void Start () {

		mycam = GetComponent<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {
		//makes sure the game stays teh same size
		mycam.orthographicSize = (Screen.height / 100f / 5f);

		if (target) {

			transform.position = Vector3.Lerp(transform.position, target.position, m_speed) + new Vector3(0, 0, -5);//from, to, how fast

		}

	}
}
