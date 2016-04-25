using UnityEngine;
using System.Collections;

public class StaticStats : MonoBehaviour {

	public string genderName;
	public string raceName;
	public string className;
	public string hairName;
	public string beardName;
	public string raceLocation;
	public string skinLocation;
	public string classLocation;
	public string hairColor;
	public string beardColor;
	public string difficulty;
	public MenuScript menuscript;
	
	// Update is called once per frame
	void Update () {

		if (menuscript.worldDetector) {

			if(World.currentWorld.worldData.worldDifficulty == 0){
				difficulty = "Easy";
			}
			if(World.currentWorld.worldData.worldDifficulty == 1){
				difficulty = "Normal";
			}
			if(World.currentWorld.worldData.worldDifficulty == 2){
				difficulty = "Hard";
			}
			if(World.currentWorld.worldData.worldDifficulty == 3){
				difficulty = "Hardcore";
			}
		}

		if (menuscript.detector) 
		{
			//Genders
			if (Game.current.player.playerGender == 0) {
				genderName = "Male";
			}
			if (Game.current.player.playerGender == 1) {
				genderName = "Female";
			}

			//Races
			if (Game.current.player.playerRace == 0) {
				raceName = "Human";
				raceLocation = "human";
			}
			if (Game.current.player.playerRace == 1) {
				raceName = "Wraith";
				raceLocation = "wraith";
			}
			if (Game.current.player.playerRace == 2) {
				raceName = "High Elf";
				raceLocation = "highelf";
			}
			if (Game.current.player.playerRace == 3) {
				raceName = "Wood Elf";
				raceLocation = "woodelf";
			}
			if (Game.current.player.playerRace == 4) {
				raceName = "Night Elf";
				raceLocation = "nightelf";
			}
			if (Game.current.player.playerRace == 5) {
				raceName = "Oceanid";
				raceLocation = "oceanid";
			}
			if (Game.current.player.playerRace == 6) {
				raceName = "Ent";
				raceLocation = "ent";
			}
			if (Game.current.player.playerRace == 7) {
				raceName = "Mountainfolk";
				raceLocation = "mountainfolk";
			}
			if (Game.current.player.playerRace == 8) {
				raceName = "Infernal";
				raceLocation = "infernal";
			}
			if (Game.current.player.playerRace == 9) {
				raceName = "Skytouched";
				raceLocation = "skytouched";
			}
			if (Game.current.player.playerRace == 10) {
				raceName = "Half-Deep One";
				raceLocation = "halfdeepone";
			}

			//Classname
			if (Game.current.player.playerClassFirst == 0) {
				className = "Mafia";
			}
			if (Game.current.player.playerClassFirst == 1) {
				className = "Inspector";
			}
			if (Game.current.player.playerClassFirst == 2) {
				className = "Sleuth";
			}
			if (Game.current.player.playerClassFirst == 3) {
				className = "Professor";
			}
			if (Game.current.player.playerClassFirst == 4) {
				className = "Agent";
			}
			if (Game.current.player.playerClassFirst == 5) {
				className = "Sorceror";
				//I put on my robe and wizard's hat
			}
			if (Game.current.player.playerClassFirst == 6) {
				className = "Thug";
			}

			//Hairname
				//Male
			if (Game.current.player.hairType == 0 && Game.current.player.playerGender == 0) {
				hairName = "Bald";
			}
			if (Game.current.player.hairType == 1 && Game.current.player.playerGender == 0) {
				hairName = "Butch";
			}
			if (Game.current.player.hairType == 2 && Game.current.player.playerGender == 0) {
				hairName = "Crew Cut";
			}
			if (Game.current.player.hairType == 3 && Game.current.player.playerGender == 0) {
				hairName = "Balding";
			}
			if (Game.current.player.hairType == 4 && Game.current.player.playerGender == 0) {
				hairName = "Curtained";
			}
			if (Game.current.player.hairType == 5 && Game.current.player.playerGender == 0) {
				hairName = "Cornrows";
			}
			if (Game.current.player.hairType == 6 && Game.current.player.playerGender == 0) {
				hairName = "Afro";
			}
			if (Game.current.player.hairType == 7 && Game.current.player.playerGender == 0) {
				hairName = "Slicked Back";
			}


				//Female
			if (Game.current.player.hairType == 0 && Game.current.player.playerGender == 1) {
				hairName = "Bald";
			}
			if (Game.current.player.hairType == 1 && Game.current.player.playerGender == 1) {
				hairName = "Bob";
			}
			if (Game.current.player.hairType == 2 && Game.current.player.playerGender == 1) {
				hairName = "Long Hair";
			}
			if (Game.current.player.hairType == 3 && Game.current.player.playerGender == 1) {
				hairName = "Short Hair";
			}
			if (Game.current.player.hairType == 4 && Game.current.player.playerGender == 1) {
				hairName = "Pigtail";
			}
			if (Game.current.player.hairType == 5 && Game.current.player.playerGender == 1) {
				hairName = "Bun";
			}
			if (Game.current.player.hairType == 6 && Game.current.player.playerGender == 1) {
				hairName = "French Braid";
			}
			if (Game.current.player.hairType == 7 && Game.current.player.playerGender == 1) {
				hairName = "Lopsided";
			}

				//Beards
			if (Game.current.player.beardType == 0 && Game.current.player.playerGender == 0) {
				beardName = "None";
			}
			if (Game.current.player.beardType == 1 && Game.current.player.playerGender == 0) {
				beardName = "Pencil-Stache";
			}
			if (Game.current.player.beardType == 2 && Game.current.player.playerGender == 0) {
				beardName = "Moustache";
			}
			if (Game.current.player.beardType == 3 && Game.current.player.playerGender == 0) {
				beardName = "Fu-Manchu";
			}
			if (Game.current.player.beardType == 4 && Game.current.player.playerGender == 0) {
				beardName = "Handlebar";
			}
			if (Game.current.player.beardType == 5 && Game.current.player.playerGender == 0) {
				beardName = "Short Beard";
			}
			if (Game.current.player.beardType == 6 && Game.current.player.playerGender == 0) {
				beardName = "Long Beard";
			}
			if (Game.current.player.beardType == 7 && Game.current.player.playerGender == 0) {
				beardName = "Goatee";
			}

			if (Game.current.player.beardColor == 0){
				beardColor = "Black";
			}
			if (Game.current.player.beardColor == 1){
				beardColor = "Blonde";
			}
			if (Game.current.player.beardColor == 2){
				beardColor = "Brown";
			}
			if (Game.current.player.beardColor == 3){
				beardColor = "Red";
			}
			if (Game.current.player.beardColor == 4){
				beardColor = "Blue";
			}
			if (Game.current.player.beardColor == 5){
				beardColor = "Pink";
			}
			if (Game.current.player.beardColor == 6){
				beardColor = "Green";
			}
			if (Game.current.player.beardColor == 7){
				beardColor = "Yellow";
			}


			if (Game.current.player.hairColor == 0){
				hairColor = "Black";
			}
			if (Game.current.player.hairColor == 1){
				hairColor = "Blonde";
			}
			if (Game.current.player.hairColor == 2){
				hairColor = "Brown";
			}
			if (Game.current.player.hairColor == 3){
				hairColor = "Red";
			}
			if (Game.current.player.hairColor == 4){
				hairColor = "Blue";
			}
			if (Game.current.player.hairColor == 5){
				hairColor = "Pink";
			}
			if (Game.current.player.hairColor == 6){
				hairColor = "Green";
			}
			if (Game.current.player.hairColor == 7){
				hairColor = "Yellow";
			}

		}
	}
}
