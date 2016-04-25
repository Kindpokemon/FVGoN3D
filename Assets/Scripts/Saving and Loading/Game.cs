using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game {

	public static Game current;
	public Character player;
	Character character;

	public Game(){

		player = new Character ();//character.name, character.playerGender, character.playerRace, character.playerSkin, character.playerClassFirst, character.playerClassSecond, character.playerMaxHealth, character.playerCurrentHealth, character.playerPulch, character.playerVim, character.playerInt, character.playerVis, character.playerDex, character.playerCon, character.playerSpeed, character.playerAC, character.playerMana, character.playerSanity, character.thaumiturgyPoints, character.playerExtraHealth);

	}

}

