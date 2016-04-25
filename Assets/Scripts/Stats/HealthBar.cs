using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public RectTransform healthTransform;
	private float cachedY;
	private float minXValue;
	private float maxXValue;
	public Text healthText;
	Character character;
	public float coolDown;
	public bool onCD;
	public bool healthShowing;
	public InventoryAppearScript appearScript;
	public GameObject theWholeThing;

	public int CurrentHealth
	{
		get { return CurrentHealth;}
		set {
			Game.current.player.playerCurrentHealth = value;
			HandleHealth();
		}

	}

	// Use this for initialization
	void Start () {
		cachedY = healthTransform.position.y;
		maxXValue = healthTransform.position.x;
		minXValue = healthTransform.position.x - healthTransform.rect.width;
		coolDown = 3;
		HandleHealth ();
		healthShowing = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator CoolDownDmg()
	{
		onCD = true;
		yield return new WaitForSeconds (coolDown);
		onCD = false;
	}



	private void HandleHealth()
	{
		healthText.text = "Health: " + Game.current.player.playerCurrentHealth;

		float currentXValue = MapValues (Game.current.player.playerCurrentHealth, 0, Game.current.player.playerMaxHealth, minXValue, maxXValue);

		healthTransform.position = new Vector2 (currentXValue, cachedY);
	}

	private float MapValues(float x, int inMin, int inMax, float outMin, float outMax)
	{
		return((x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin);
	}

	void OnTriggerStay(Collider other)
	{
		if (other.name != "Weapon" + Game.current.player.name) {
			if(!onCD && Game.current.player.playerCurrentHealth > 0){
				StartCoroutine(CoolDownDmg());
				//CurrentHealth -= ;
			}
		}
		if (other.name == "HealingBlock") {

		}
	}
}
