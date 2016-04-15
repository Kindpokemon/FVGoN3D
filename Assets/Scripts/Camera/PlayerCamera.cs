using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public Camera playerCam;
	public GameObject target;
	public Vector3 targetPos;
	public PlayerControl pControl;

	public bool playerControlEnabled;
	RaycastHit collisionHit;
	public float camMaxDistance;
	public bool backlock;

	public float sensitivityX = 4F;
	public float sensitivityY = 4F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationSpeed = 1;
	float rotationY = 0F;
	public float lastDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (pControl.moving) {
			backlock = true;
			rotationSpeed = .5f;
			target.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		} else {
			rotationSpeed = 1f;
			backlock = false;
		}
		transform.position = target.transform.position + targetPos;
		float rotationX = transform.localEulerAngles.y;

		rotationX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * sensitivityX;
		rotationY += Input.GetAxis ("Mouse Y") * sensitivityY * rotationSpeed;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

		if (backlock) {
			if (Input.GetAxisRaw ("Mouse X") < 0) {
				target.transform.eulerAngles = new Vector3(0, rotationX, 0);
			} else if (Input.GetAxisRaw ("Mouse X") > 0) {
				target.transform.eulerAngles = new Vector3(0, rotationX, 0);
			}
			transform.eulerAngles = new Vector3 (-rotationY, target.transform.eulerAngles.y, target.transform.eulerAngles.z);
		} else {
			transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
		}

		float distance = lastDistance;
		if (Physics.Raycast (transform.position, -transform.forward, out collisionHit, camMaxDistance)) {
			distance = collisionHit.distance;
		} else {
			distance = camMaxDistance;
		}
		Debug.DrawLine (transform.position, collisionHit.point, Color.red, camMaxDistance);
		lastDistance = distance;
		playerCam.transform.localPosition = new Vector3 (0, 0, -distance+.2f);
	}

	void FixedUpdate(){

	}

}
