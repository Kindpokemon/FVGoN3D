using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	//Scripts
	public Animator anim;
	public Collider playerColl;
	public Rigidbody rbody;

	public float distToGround;
	float moveH;
	float moveV;

	//Disabling/Enabling
	public bool movementEnabled;
	public bool moving;

	public bool IsGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, distToGround);
	}

	void Start (){
		anim.SetBool ("Grounded", true);
		distToGround = 0.01f;
	}

	void Update () {
		if (movementEnabled) {
			moveH = Input.GetAxis ("Horizontal");
			moveV = Input.GetAxis ("Vertical");
			Debug.Log (moveH + ", " + moveV);
			anim.SetFloat ("InputY", moveV, 1f, Time.deltaTime * 10f);
			anim.SetFloat ("InputX", moveH, 1f, Time.deltaTime * 10f);
			anim.SetBool ("Crouching", Input.GetButton ("Crouch"));
			anim.SetBool ("Sprinting", Input.GetButton ("Sprint"));
		} else {
			anim.SetFloat ("InputY", 0, 1f, Time.deltaTime * 10f);
			anim.SetFloat ("InputX", 0, 1f, Time.deltaTime * 10f);
			anim.SetBool ("Crouching", false);
			anim.SetBool ("Sprinting", false);
		}
		anim.SetBool ("Grounded", IsGrounded ());
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
			
		}

		if ((Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0) && movementEnabled) {
			moving = true;
		} else {
			moving = false;
		}
	}
}
