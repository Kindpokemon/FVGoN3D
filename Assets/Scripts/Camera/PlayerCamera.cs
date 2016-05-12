using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public Camera playerCam;
	public GameObject lookSpot;
	public GameObject target;
	public Vector3 targetPos;
	public ReferenceList refList;

	public Inventory inventory;
	public Chest chest;
	public PlayerControl pControl;

	public bool playerControlEnabled;
	RaycastHit collisionHit;
	RaycastHit hit;
	public float camMaxDistance;
	public bool backlock;
	public bool ableToOpen;

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
		refList = GameObject.FindGameObjectWithTag ("reflist").GetComponent<ReferenceList> ();
		inventory = refList.inventory;
		chest = refList.chest;
		pControl = refList.playerControl;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerControlEnabled) {
			if (pControl.moving) {
				backlock = true;
				rotationSpeed = .5f;
				target.transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
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
					target.transform.eulerAngles = new Vector3 (0, rotationX, 0);
				} else if (Input.GetAxisRaw ("Mouse X") > 0) {
					target.transform.eulerAngles = new Vector3 (0, rotationX, 0);
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
			lastDistance = distance;
			playerCam.transform.localPosition = new Vector3 (0, 0, -distance + .2f);
		}

		if (Physics.Raycast (lookSpot.transform.position, transform.forward, out hit, 2f)) {
			Debug.DrawLine (lookSpot.transform.position, hit.point, Color.blue);
			if (hit.transform.gameObject.tag == "ChestCollider") {
				chest.chestImTouching = hit.transform.parent.gameObject;
				chest.details = chest.chestImTouching.GetComponent<ChestDetails> ();
				ableToOpen = true;
			} else if (hit.transform.gameObject.tag == "NPC") {
				if (Input.GetKeyDown (KeyCode.Return) && refList.dialogueController.canInteract) {
					refList.dialogueController.NPC = hit.transform.gameObject.GetComponent<NPCCharacter> ();
					refList.dialogueController.gameObject.SetActive (true);
					refList.dialogueController.UpdateDialogue ();
				}
			}
		} else {
			chest.chestImTouching = null;
			ableToOpen = false;
		}
		if (chest.chestImTouching != chest.previouslyTouchedChest && chest.previouslyTouchedChest != null && chest.chestOpen) {
			chest.previouslyTouchedChest.GetComponent<ChestDetails> ().anim.SetTrigger ("Close");
		}
		chest.previouslyTouchedChest = chest.chestImTouching;
	}

	void FixedUpdate(){

	}

}
