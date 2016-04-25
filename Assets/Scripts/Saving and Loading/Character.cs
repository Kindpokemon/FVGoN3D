using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Character {

	public string name;
	public int playerGender;
	public int playerRace;
	public int playerSkin;
	public int playerHair;
	public int playerClassFirst;
	public int playerClassSecond;
	public int playerMaxHealth;
	public int playerCurrentHealth;
	public int playerMaxMana;
	public int playerCurrentMana;
	public int playerCurrentStamina;
	public int playerMaxStamina;
	public int playerPulch;
	public int playerVim;
	public int playerInt;
	public int playerVis;
	public int playerDex;
	public int playerCon;
	public float playerSpeed;
	public int playerAC;
	public bool sanityToggle;
	public int playerSanity;
	public bool thaumToggle;
	public int thaumiturgyPoints;
	public int playerExtraHealth;
	public bool extraSkill;

	public float playerLocationX;
	public float playerLocationY;
	public int playerScene;

	public string raceName;
	public string className;
	public string skinName;
	public string hairName;

	public int hairType;
	public int beardType;
	public int hairColor;
	public int beardColor;

	public Inventory inventory;
	public SlotScript slotScript;
	public List<Item> itemList = new List<Item>();

	public Item item;

	public Character(){//string name, int pGender, int race, int skin, int classOne, int classTwo, int healthMax, int healthCurrent, int pulch, int vim, int intel, int vis, int dex, int con, int speed, int ac, int mana, int sanity, int thaumPoints, int extraHealth) {

		this.name = "";
		this.playerGender = 0;
		this.playerRace = 0;
		this.playerSkin = 0;
		this.playerClassFirst = 0;
		this.playerClassSecond = 0;
		this.playerAC = 10;
		this.playerSpeed = 1;
		this.sanityToggle = false;
		this.thaumToggle = false;
		this.playerSanity = 0;
		this.thaumiturgyPoints = 0;
		this.playerExtraHealth = 0;
		this.hairName = "hair" + this.playerGender + this.hairColor + this.playerHair;
		this.playerScene = 1;
		this.beardColor = 0;
		this.hairColor = 0;
		this.hairType = 0;
		this.beardType = 0;

		for (int s = 0; s < 88; s++) {
			itemList.Add (new Item ());
		}

		//Player Classes

		if(playerClassFirst == 0){
			this.className = "Mafia";	//Mafia
			this.playerPulch = 6;
			this.playerVim = 10;
			this.playerInt = 11;
			this.playerVis = 12;
			this.playerDex = 9;
			this.playerCon = 11;
			this.playerMaxHealth = 20;
			this.playerCurrentHealth = this.playerMaxHealth;
			this.playerLocationX = -14.65F;
			this.playerLocationY = -15.89F;
		}

		if(playerClassFirst == 1){
			this.className = "Inspector";	//Inspector
			this.playerPulch = 10;
			this.playerVim = 7;
			this.playerInt = 12;
			this.playerVis = 13;
			this.playerDex = 9;
			this.playerCon = 10;
			this.playerMaxHealth = 18;
			this.playerCurrentHealth = this.playerMaxHealth;
		}
		
		if(playerClassFirst == 2){
			this.className = "Sleuth";	//Sleuth
			this.playerPulch = 13;
			this.playerVim = 11;
			this.playerInt = 10;
			this.playerVis = 10;
			this.playerDex = 8;
			this.playerCon = 9;
			this.playerMaxHealth = 19;
			this.playerCurrentHealth = this.playerMaxHealth;
		}
		
		if(playerClassFirst == 3){
			this.className = "Professor";	//Professor
			this.playerPulch = 11;
			this.playerVim = 10;
			this.playerInt = 13;
			this.playerVis = 11;
			this.playerDex = 9;
			this.playerCon = 8;
			this.playerMaxHealth = 18;
			this.playerCurrentHealth = this.playerMaxHealth;
		}
		
		if(playerClassFirst == 4){
			this.className = "Agent";	//Agent
			this.playerPulch = 11;
			this.playerVim = 12;
			this.playerInt = 11;
			this.playerVis = 8;
			this.playerDex = 10;
			this.playerCon = 10;
			this.playerMaxHealth = 19;
			this.playerCurrentHealth = this.playerMaxHealth;
		}
		
		if(playerClassFirst == 5){
			this.className = "Sorcerer";	//Sorcerer
			this.playerPulch = 12;
			this.playerVim = 9;
			this.playerInt = 12;
			this.playerVis = 10;
			this.playerDex = 11;
			this.playerCon = 7;
			this.playerMaxHealth = 18;
			this.playerCurrentHealth = this.playerMaxHealth;
		}
		
		if(playerClassFirst == 6){
			this.className = "Thug";	//Thug
			this.playerPulch = 8;
			this.playerVim = 13;
			this.playerInt = 8;
			this.playerVis = 10;
			this.playerDex = 10;
			this.playerCon = 12;
			this.playerMaxHealth = 21;
			this.playerCurrentHealth = this.playerMaxHealth;
		}

		this.playerCurrentHealth = this.playerMaxHealth;
		this.playerMaxMana = this.playerVis;
		this.playerCurrentMana = this.playerMaxMana;
		this.playerMaxStamina = this.playerVim;
		this.playerCurrentStamina = this.playerMaxStamina;

		//Player Races

		if(playerRace == 1){

			this.raceName = "Human";
			this.playerAC = 10;
			this.skinName = "Human"+this.playerSkin;
			this.extraSkill = true;
			this.playerSpeed = 1;

		}

		if(playerRace == 2){
			
			this.raceName = "Wraith";
			this.playerAC = 10;
			this.skinName = "Wraith"+this.playerSkin;
			this.extraSkill = false;
			this.playerSpeed = 1;
			
		}
		
		if(playerRace == 3){
			
			this.raceName = "High Elf";
			this.playerAC = 10;
			this.skinName = "HighElf"+this.playerSkin;
			this.extraSkill = false;
			this.playerSpeed = 1;
			
		}
		
		if(playerRace == 4){
			
			this.raceName = "Wood Elf";
			this.playerAC = 10;
			this.skinName = "WoodElf"+this.playerSkin;
			this.extraSkill = false;
			this.playerSpeed = 1.15F;
			
		}
		
		if(playerRace == 5){
			
			this.raceName = "Night Elf";
			this.playerAC = 10;
			this.skinName = "NightElf"+this.playerSkin;
			this.extraSkill = false;
			this.playerSpeed = 1;
			
		}
		
		if(playerRace == 6){
			
			this.raceName = "Oceanid";
			this.playerAC = 10;
			this.skinName = "Oceanid"+this.playerSkin;
			this.extraSkill = false;
			this.playerSpeed = 1;
			
		}
		
		if(playerRace == 7){
			
			this.raceName = "Ent";
			this.playerAC = 13;
			this.skinName = "Ent"+this.playerSkin;
			this.extraSkill = false;
			this.playerSpeed = .85F;
			
		}
		
		if(playerRace == 8){
			
			this.raceName = "Mountainfolk";
			this.playerAC = 10;
			this.skinName = "Mountainfolk"+this.playerSkin;
			this.extraSkill = false;
			this.playerSpeed = 1;
			
		}
		
		if(playerRace == 9){
			
			this.raceName = "Infernal";
			this.playerAC = 10;
			this.skinName = "Infernal"+this.playerSkin;
			this.extraSkill = false;
			this.playerSpeed = 1;
			
		}
		
		if(playerRace == 10){
			
			this.raceName = "Skytouched";
			this.playerAC = 10;
			this.skinName = "Skytouched"+this.playerSkin;
			this.extraSkill = false;
			this.playerSpeed = 1;
			
		}
		
		if(playerRace == 11){
			
			this.raceName = "Half-Deep On";
			this.playerAC = 10;
			this.skinName = "HalfDeepOne"+this.playerSkin;
			this.extraSkill = false;
			this.playerSpeed = 1;
			
		}

		///////////////////////////////////Player Inventory///////////////////////////////////////////////

		
		////////////////////////////////End of Player Inventory///////////////////////////////////////////



	}

}


