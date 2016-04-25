using UnityEngine;
using System.Collections;

[System.Serializable]
public class Attack {

	public string attackName;
	public int attackNumber;
	public int[] idNumbers;
	public Sprite sprite;
	public enum AttackType {
		Shortsword,
		Longsword,
		Pistol,
		Bow
	}
	public AttackType attackType;

	public Attack(string atk, int atkNum, int[] nums, AttackType type){
		attackName = atk;
		attackNumber = atkNum;
		idNumbers = nums;
		attackType = type;
	}

	public Attack(){

	}
}
