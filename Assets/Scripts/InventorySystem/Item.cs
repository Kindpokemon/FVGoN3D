using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {


	public string itemName;
	public int itemID;
	public string itemDesc;
	public Sprite itemIcon;
	public string itemRarity;
	public GameObject itemModel;
	public int itemArmor;
	public int itemDamage;
	public int itemHeal;
	public int itemBuff;
	public string buffType;
	public int itemSpeed; //swingspeed
	public int itemValue;
	public int itemWorth;
	public ItemType itemType;

	public enum ItemType
	{
		//declare different item types
		None,
		Weapon,
		Shield,
		Consumable,
		Quest,
		Head,
		Face,
		Hat,
		Chest,
		Back,
		Pants,
		Shoes,
		Neck,
		LeftHand,
		RightHand,
		Misc
	}

	public Item(string name, int id, string desc, string rarity, int armor, int damage, int speed, int heal, int buff, string BuffType, int value, int worth, ItemType type)
	{
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemRarity = rarity;
		itemArmor = armor;
		itemDamage = damage;
		itemSpeed = speed;
		itemHeal = heal;
		itemBuff = buff;
		buffType = BuffType;
		itemValue = value;
		itemWorth = worth;
		itemType = type;
		itemIcon = Resources.Load<Sprite> ("" + name);
	}

	public Item()
	{

	}
}
