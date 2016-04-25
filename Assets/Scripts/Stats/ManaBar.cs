using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManaBar : MonoBehaviour {

	public RectTransform manaTransform;
	private float cachedY;
	private float minXValue;
	private float maxXValue;
	public Text manaText;
	Character character;
	public float coolDown;
	public bool onCD;
	public bool manaShowing;
	public InventoryAppearScript appearScript;
	public GameObject theWholeThing;
	
	public int Currentmana
	{
		get { return Currentmana;}
		set {
			Game.current.player.playerCurrentMana = value;
			Handlemana();
		}
		
	}
	
	// Use this for initialization
	void Start () {
		cachedY = manaTransform.position.y;
		maxXValue = manaTransform.position.x;
		minXValue = manaTransform.position.x - manaTransform.rect.width;
		coolDown = 3;
		Handlemana ();
		manaShowing = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Handlemana()
	{
		manaText.text = "Mana: " + Game.current.player.playerCurrentMana;
		
		float currentXValue = MapValues (Game.current.player.playerCurrentMana, 0, Game.current.player.playerMaxMana, minXValue, maxXValue);
		
		manaTransform.position = new Vector2 (currentXValue, cachedY);
	}
	
	private float MapValues(float x, int inMin, int inMax, float outMin, float outMax)
	{
		return((x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin);
	}
}
