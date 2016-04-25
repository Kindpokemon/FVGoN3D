using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReferenceList : MonoBehaviour {

	public Inventory inventory;
	public Chest chest;
	public PlayerControl playerControl;
	public PlayerCamera playerCamera;
	public ItemDatabase database;
	public AttackDatabase atkDatabase;
	public List<Transform> hidingSpots;

	// Use this for initialization
	void Start () {
		chest.refList = this;
		playerCamera.refList = this;
		GameObject[] test = GameObject.FindGameObjectsWithTag ("hidingSpot");
		for (int i = 0; i < test.Length; i++) {
			hidingSpots.Add (test [i].transform);
		}
	}

}
