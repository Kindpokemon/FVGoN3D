using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaBar : MonoBehaviour {

	public RectTransform staminaTransform;
	private float cachedY;
	private float minXValue;
	private float maxXValue;
	public Text staminaText;
	Character character;
	public float coolDown;
	public bool onCD;
	public bool onDrop;
	public bool onWait;
	public bool staminaShowing;
	public InventoryAppearScript appearScript;
	public GameObject theWholeThing;
	public bool usingStamina;
	public PlayerMovement playerMovement;
	
	public int Currentstamina
	{
		get { return Game.current.player.playerCurrentStamina;}
		set {
			Game.current.player.playerCurrentStamina = value;
			Handlestamina();
		}
		
	}
	
	// Use this for initialization
	void Start () {
		cachedY = staminaTransform.position.y;
		maxXValue = staminaTransform.position.x;
		minXValue = staminaTransform.position.x - staminaTransform.rect.width;
		coolDown = 1;
		Handlestamina ();
		staminaShowing = false;
		usingStamina = false;
		onCD = false;
		onDrop = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!usingStamina) {
			if(Game.current.player.playerCurrentStamina < Game.current.player.playerMaxStamina && !onCD &&!onDrop && !onWait && playerMovement.isRunning == false){
				if(Game.current.player.playerCurrentStamina < 0){
					StartCoroutine(CoolDownDmg());
				}
				Currentstamina += 1;
				StartCoroutine(CoolDownDmg());

			}
		}
		if (playerMovement.isRunning == true) {
			usingStamina = true;
		} else {
			usingStamina = false;
		}

		if (usingStamina == true && Game.current.player.playerCurrentStamina > 0 && !onDrop) {
			Currentstamina -= 1;
			StartCoroutine(CoolDownDrop());
		}

		if (Game.current.player.playerCurrentStamina < 0) {
			StartCoroutine(CoolDown());
		}
	}
	
	IEnumerator CoolDownDmg()
	{
		onCD = true;
		yield return new WaitForSeconds (2);
		onCD = false;
	}

	IEnumerator CoolDownDrop()
	{
		onDrop = true;
		yield return new WaitForSeconds (coolDown);
		onDrop = false;
	}

	IEnumerator CoolDown()
	{
		onWait = true;
		yield return new WaitForSeconds (3);
		onWait = false;
	}

	private void Handlestamina()
	{
		staminaText.text = "Stamina: " + Game.current.player.playerCurrentStamina;
		
		float currentXValue = MapValues (Game.current.player.playerCurrentStamina, 0, Game.current.player.playerMaxStamina, minXValue, maxXValue);
		
		staminaTransform.position = new Vector2 (currentXValue, cachedY);
	}
	
	private float MapValues(float x, int inMin, int inMax, float outMin, float outMax)
	{
		return((x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin);
	}
}
