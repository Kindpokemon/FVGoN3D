using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AttackDatabase : MonoBehaviour {

	public List<Attack> attacks = new List<Attack>();

	// Use this for initialization
	void Start () {
		attacks.Add(new Attack("Sword", 0, new int[1]{0},Attack.AttackType.Shortsword));
		attacks.Add(new Attack("Pistol", 1, new int[1]{6},Attack.AttackType.Pistol));


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
