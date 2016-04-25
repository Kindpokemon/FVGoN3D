using UnityEngine;
using System.Collections;

public class SimpleSteer : MonoBehaviour {

	public int speed;
	Rigidbody2D rbody;
	public Steer2D.Seek AgentSeek;
	public Steer2D.Arrive AgentArrive;

	void Start () {
		//set up rigidbody and animation for movement
		rbody = GetComponent<Rigidbody2D> ();
		if (AgentSeek != null)
			AgentSeek.TargetPoint = transform.position;
		
		if (AgentArrive != null)
			AgentArrive.TargetPoint = transform.position;
	}
	// Update is called once per frame
	void Update () {

		Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		rbody.MovePosition (rbody.position + movement_vector  * speed * Time.deltaTime / 2);

		if (AgentSeek != null)
			AgentSeek.TargetPoint = transform.position;
		
		if (AgentArrive != null)
			AgentArrive.TargetPoint = transform.position;
	}
}
