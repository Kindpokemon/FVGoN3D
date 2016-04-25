using UnityEngine;
using System.Collections;

public class AssignChildNumbers : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++)
		{
			transform.GetChild(i).GetComponent<DisplayInventoryArmor>().armorNumber = i;
			Debug.Log (transform.GetChild(i).GetComponent<DisplayInventoryArmor>().armorNumber);
		}
	}
}
