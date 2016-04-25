using UnityEngine;
using System.Collections;

public class DevStats : MonoBehaviour {

	public static bool DevMode = true;
	public bool dev;

	// Use this for initialization
	void Start () {
		Game.current = new Game ();
	}
	
	// Update is called once per frame
	void Update () {
		DevMode = dev;
	}
}
