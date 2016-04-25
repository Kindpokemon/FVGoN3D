using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	Rigidbody2D rbody;
	Animator anim;
	public GameObject xyscenePlayer;
	public StaminaBar staminabar;
	public bool isRunning;
	public float coolDown;
	public bool onCD;
	public bool canSprint;
	public Chest chest;
	public SpriteRenderer playerRenderer;

	// Use this for initialization

	void Start () {
		//set up rigidbody and animation for movement
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		chest = GameObject.FindGameObjectWithTag ("Canvas").transform.GetChild (0).GetComponent<Chest>();
		playerRenderer = gameObject.GetComponent<SpriteRenderer> ();

		Vector2 startSpawn = new Vector2 (Game.current.player.playerLocationX, Game.current.player.playerLocationY);
		xyscenePlayer.transform.position = startSpawn;
		canSprint = true;

	}


	// Update is called once per frame
	void Update () {
		Debug.Log (Game.current.player.playerCurrentStamina);

		if (Game.current.player.playerCurrentStamina < 1) {
			canSprint = false;
		} else {
			canSprint = true;
		}

		if (!Input.GetKey (KeyCode.LeftShift)) {
			isRunning = false;
		}
		//GetAxisRaw for instant 1, 0 or -1
		Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if (movement_vector != Vector2.zero) {
			//if we are walking, outputs that we are walking
			anim.SetBool ("isWalking", true);
			//sets movement vectors to x and y
			anim.SetFloat("Input_X", movement_vector.x);
			anim.SetFloat("Input_Y", movement_vector.y);

		} else {
			//otherwise, it is false
			anim.SetBool ("isWalking", false);

		}

		Game.current.player.playerLocationX = xyscenePlayer.transform.position.x;
		Game.current.player.playerLocationY = xyscenePlayer.transform.position.y;
		
		//move position 

		if (Input.GetKey(KeyCode.LeftShift) && canSprint == true){
			rbody.MovePosition (rbody.position + movement_vector * (Game.current.player.playerSpeed + 1.5F) * Time.deltaTime / 2);
			if(Input.GetKey(KeyCode.W))
			{
				isRunning = true;
			} else if(Input.GetKey(KeyCode.S))
			{
				isRunning = true;
			} else if(Input.GetKey(KeyCode.A))
			{
				isRunning = true;
			} else if(Input.GetKey(KeyCode.D))
			{
				isRunning = true;
			} else {
				isRunning = false;
			}

		}else {
			rbody.MovePosition (rbody.position + movement_vector * Game.current.player.playerSpeed * Time.deltaTime / 2);
		}
	}

}
