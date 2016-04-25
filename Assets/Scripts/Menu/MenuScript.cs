using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public enum Menu {
		Menu,
		NewGame,
		Continue,
		LevelSelect,
		CreateLevel,
	}

	public Menu currentMenu;
	const int buttonWidth = 140;
	const int buttonHeight = 60;
	const int smallButtonWidth = 60;
	const int smallButtonHeight = 30;
	public Texture2D buttonTexture;
	public Texture2D buttonHover;
	public Texture2D buttonPress;
	public GUIStyle boxStyle;
	public Game characterCreator;
	public World worldCreator;
	public ItemContainer containerCreator;
	public string gdChooser;
	public StaticStats staticstats;
	public bool detector = false;
	public bool worldDetector = false;
	Texture skinPlace;
	Texture hairPlace;
	Texture beardPlace;
	Texture clothesPlace;
	public GameObject gameLogo;

	//Determine Button's position
	Rect topbox = new Rect (Screen.width / 2 - (buttonWidth / 2), (1.5F * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight);
	Rect midbox = new Rect (Screen.width / 2 - (buttonWidth / 2), (1.9F * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight);
	Rect lowbox = new Rect (Screen.width / 2 - (buttonWidth / 2), (2.3F * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight);

	Rect highhighbox = new Rect (Screen.width / 12, (1.5F * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight/2);
	Rect lowhighbox = new Rect ((Screen.width / 12)+50, (1.7F * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight/2);
	Rect highmedbox = new Rect (Screen.width / 12, (1.9F * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight/2);
	Rect lowmedbox = new Rect (Screen.width / 12, (2.1F * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight/2);
	Rect highlowbox = new Rect (Screen.width / 12, (2.3F * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight/2);
	Rect lowlowbox = new Rect (Screen.width / 12, (2.5F * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight/2);
	Rect highdeepbox = new Rect (Screen.width / 2 - (buttonWidth / 2), (2.7F * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight/2);
	Rect lowdeepbox = new Rect (Screen.width / 2 - (buttonWidth / 2), (2.9F * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight/2);

	//Reverse Arrows
	Rect bback1 = new Rect (Screen.width / 12 - 60, (1.9F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);
	Rect bback2 = new Rect (Screen.width / 12 - 60, (2.1F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);
	Rect bback3 = new Rect (Screen.width / 12 - 60, (2.3F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);
	Rect bback4 = new Rect (Screen.width / 12 - 60, (2.5F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);
	
	Rect fback1 = new Rect (Screen.width - (Screen.width / 12 + 200), (1.9F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);
	Rect fback2 = new Rect (Screen.width - (Screen.width / 12 + 200), (2.1F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);
	Rect fback3 = new Rect (Screen.width - (Screen.width / 12 + 200), (2.3F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);
	Rect fback4 = new Rect (Screen.width - (Screen.width / 12 + 200), (2.5F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);

	//Center
	Rect playerDisplay = new Rect (Screen.width / 2 - (82 / 2), (1.9F * Screen.height / 3) - (buttonHeight / 2), 82, 150);
	Rect nameBox = new Rect (Screen.width / 2 - (buttonWidth / 2), (1.5F * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight/2);
	Rect nameInputBox = new Rect (Screen.width / 2 - (buttonWidth / 2), (1.7F * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight/2);

	//Center Notes
	Rect slider1 = new Rect (Screen.width / 12, (1.9F * Screen.height / 3) - 20, buttonWidth, buttonHeight/2);
	Rect slider2 = new Rect (Screen.width / 12, (2.1F * Screen.height / 3) - 20, buttonWidth, buttonHeight/2);
	Rect slider3 = new Rect (Screen.width / 12, (2.3F * Screen.height / 3) - 20, buttonWidth, buttonHeight/2);
	Rect slider4 = new Rect (Screen.width / 12, (2.5F * Screen.height / 3) - 20, buttonWidth, buttonHeight/2);

	Rect slider5 = new Rect (Screen.width - (Screen.width / 12 + 140), (1.9F * Screen.height / 3) - 20, buttonWidth, buttonHeight/2);
	Rect slider6 = new Rect (Screen.width - (Screen.width / 12 + 140), (2.1F * Screen.height / 3) - 20, buttonWidth, buttonHeight/2);
	Rect slider7 = new Rect (Screen.width - (Screen.width / 12 + 140), (2.3F * Screen.height / 3) - 20, buttonWidth, buttonHeight/2);
	Rect slider8 = new Rect (Screen.width - (Screen.width / 12 + 140), (2.5F * Screen.height / 3) - 20, buttonWidth, buttonHeight/2);

	//Forward Arrows
	Rect bforward1 = new Rect ((Screen.width / 12) + 140, (1.9F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);
	Rect bforward2 = new Rect ((Screen.width / 12) + 140, (2.1F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);
	Rect bforward3 = new Rect ((Screen.width / 12) + 140, (2.3F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);
	Rect bforward4 = new Rect ((Screen.width / 12) + 140, (2.5F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);

	Rect fforward1 = new Rect (Screen.width - (Screen.width / 12), (1.9F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);
	Rect fforward2 = new Rect (Screen.width - (Screen.width / 12), (2.1F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);
	Rect fforward3 = new Rect (Screen.width - (Screen.width / 12), (2.3F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);
	Rect fforward4 = new Rect (Screen.width - (Screen.width / 12), (2.5F * Screen.height / 3) - 20, smallButtonWidth, smallButtonHeight);

	//Rect  = new Rect (Screen.width / 2 - (buttonWidth / 2), (2.3F * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight);
	public float gender = 0.0F;
	public float race = 0.0F;
	public float skin = 0.0F;
	public float playerClass = 0.0F;


	void Start() {

		detector = false;
		worldDetector = false;
	}

	void Update() {



	}


	void OnGUI()
	{
		GUI.skin.button.normal.background = buttonTexture;
		GUI.skin.button.hover.background = buttonHover;
		GUI.skin.button.active.background = buttonPress;
		GUI.skin.box = boxStyle;
		GUI.skin.button = boxStyle;

		if (currentMenu == Menu.Menu || currentMenu == Menu.NewGame) {
			gameLogo.SetActive(true);
		} else {
			gameLogo.SetActive(false);
		}


		if (currentMenu == Menu.Menu) {

			if (GUI.Button (topbox, "New Game")) {
				Game.current = new Game ();
				currentMenu = Menu.NewGame;
			}
			
			if (GUI.Button (midbox, "Continue")) {
				SaveLoad.Load ();
				currentMenu = Menu.Continue;
			}
			
			if (GUI.Button (lowbox, "Quit")) {
				Application.Quit ();
			}

		} else if (currentMenu == Menu.NewGame) {
			skinPlace = Resources.Load<Texture> ("PlayerRep/PlayerSprites/" + staticstats.raceLocation + "/" + staticstats.raceLocation + staticstats.genderName + Game.current.player.playerSkin);
			hairPlace = Resources.Load<Texture> ("PlayerRep/Hair/" + staticstats.genderName + "/hair" + staticstats.genderName + Game.current.player.hairColor + Game.current.player.hairType);
			beardPlace = Resources.Load<Texture> ("PlayerRep/Hair/Beards/beard" + Game.current.player.beardColor + Game.current.player.beardType);
			//clothesPlace = Resources.Load<Texture>();
			detector = true;
			GUI.Box (nameBox, "Name Your Character");
			GUI.DrawTexture (playerDisplay, skinPlace);
			GUI.DrawTexture (playerDisplay, hairPlace);
			GUI.DrawTexture (playerDisplay, beardPlace);
			//GUI.DrawTexture(playerDisplay, clothesPlace);

			Game.current.player.name = GUI.TextField (nameInputBox, Game.current.player.name, 19);

			//Back Arrows
			if (GUI.Button (bback1, "<-") && Game.current.player.playerGender > 0) {
				Game.current.player.playerGender = Game.current.player.playerGender - 1;
				Game.current.player.beardType = 0;
				staticstats.beardName = "None";
			}
			if (GUI.Button (bback2, "<-") && Game.current.player.playerRace > 0) {
				Game.current.player.playerRace = Game.current.player.playerRace - 1;
			}
			if (GUI.Button (bback3, "<-") && Game.current.player.playerSkin > 0) {
				Game.current.player.playerSkin = Game.current.player.playerSkin - 1;
			}
			if (GUI.Button (bback4, "<-") && Game.current.player.playerClassFirst > 0) {
				Game.current.player.playerClassFirst = Game.current.player.playerClassFirst - 1;
			}


			//Center Boxes
			GUI.Box (slider1, "Gender: " + staticstats.genderName);
			GUI.Box (slider2, "Race: " + staticstats.raceName);
			GUI.Box (slider3, "Skin: " + (Game.current.player.playerSkin + 1));
			GUI.Box (slider4, "Class: " + staticstats.className);

			//Forward Boxes
			if (GUI.Button (bforward1, "->") && Game.current.player.playerGender < 1) {
				Game.current.player.playerGender = Game.current.player.playerGender + 1;
				Game.current.player.beardType = 0;
				staticstats.beardName = "None";
			}
			if (GUI.Button (bforward2, "->") && Game.current.player.playerRace < 11) {
				Game.current.player.playerRace = Game.current.player.playerRace + 1;
			}
			if (GUI.Button (bforward3, "->") && Game.current.player.playerSkin < 7) {
				Game.current.player.playerSkin = Game.current.player.playerSkin + 1;
			}
			if (GUI.Button (bforward4, "->") && Game.current.player.playerClassFirst < 7) {
				Game.current.player.playerClassFirst = Game.current.player.playerClassFirst + 1;
			}



			//Back Arrows
			if (GUI.Button (fback1, "<-") && Game.current.player.hairType > 0) {
				Game.current.player.hairType = Game.current.player.hairType - 1;
			}
			if (GUI.Button (fback2, "<-") && Game.current.player.hairColor > 0) {
				Game.current.player.hairColor = Game.current.player.hairColor - 1;
			}
			if (GUI.Button (fback3, "<-") && Game.current.player.beardType > 0 && Game.current.player.playerGender == 0) {
				Game.current.player.beardType = Game.current.player.beardType - 1;
			}
			if (GUI.Button (fback4, "<-") && Game.current.player.beardColor > 0 && Game.current.player.playerGender == 0) {
				Game.current.player.beardColor = Game.current.player.beardColor - 1;
			}
			
			
			//Center Boxes
			GUI.Box (slider5, "Hair: " + staticstats.hairName);
			GUI.Box (slider6, "Hair Color: " + staticstats.hairColor);
			GUI.Box (slider7, "Beard: " + staticstats.beardName);
			GUI.Box (slider8, "Beard Color: " + staticstats.beardColor);
			
			//Forward Boxes
			if (GUI.Button (fforward1, "->") && Game.current.player.hairType < 7) {
				Game.current.player.hairType = Game.current.player.hairType + 1;
			}
			if (GUI.Button (fforward2, "->") && Game.current.player.hairColor < 7) {
				Game.current.player.hairColor = Game.current.player.hairColor + 1;
			}
			if (GUI.Button (fforward3, "->") && Game.current.player.beardType < 7 && Game.current.player.playerGender == 0) {
				Game.current.player.beardType = Game.current.player.beardType + 1;

			}
			if (GUI.Button (fforward4, "->") && Game.current.player.beardColor < 7 && Game.current.player.playerGender == 0) {
				Game.current.player.beardColor = Game.current.player.beardColor + 1;
			}

			//gender = GUI.HorizontalSlider( slider1 , gender, 1.0F, 2.0F);
			//race = GUI.HorizontalSlider( slider2 , race, 1.0F, 11.0F);
			//skin = GUI.HorizontalSlider( slider3 , skin, 1.0F, 8.0F);
			//playerClass = GUI.HorizontalSlider( slider4 , playerClass, 1.0F, 7.0F);
			//Game.current.player.playerGender = (int)gender;
			//Game.current.player.playerRace = (int)race;
			//Game.current.player.playerSkin = (int)skin;
			//Game.current.player.playerClassFirst = (int)playerClass;


			if (GUI.Button (highdeepbox, "Save")) {
				//Save the current Game as a new saved Game
				SaveLoad.Save ();

				//Move on to game...
				
				SaveLoad.LoadWorld();
				currentMenu = Menu.LevelSelect;
			}

			if (GUI.Button (lowdeepbox, "Cancel")) {
				currentMenu = Menu.Menu;
			}
			
		} else if (currentMenu == Menu.Continue) {
			GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height));
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();

			GUILayout.Box ("Select Save File");
			GUILayout.Space (10);
			
			Debug.Log(SaveLoad.savedGames.Count);

			foreach (Game g in SaveLoad.savedGames) {
				if (GUILayout.Button (g.player.name)) {
					Game.current = g;
					//Move on to game...
					Debug.Log ("From Load:" + Game.current.player.name);
					SaveLoad.LoadWorld();
					currentMenu = Menu.LevelSelect;
				}
			
			}

			
			//GUILayout.Space(10);
			//GUILayout.Box("Do Delete, Insert Save Number Below");
			//GUILayout.Space(10);
			//SaveLoad.gameDeleteChooser = GUILayout.TextField(gdChooser);
			//GUILayout.Space(10);
			//if(GUILayout.Button("Delete Save")) {
			//SaveLoad.DeleteSave();
			//}
			GUILayout.Space (10);
			if (GUILayout.Button ("Cancel")) {
				currentMenu = Menu.Menu;
			}
			
			GUILayout.FlexibleSpace ();
			GUILayout.EndVertical ();
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			GUILayout.EndArea ();

		} else if (currentMenu == Menu.LevelSelect) {
			GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height));
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();

			GUILayout.Box ("Select World");
			GUILayout.Space (10);

			foreach ( World w in SaveLoad.savedWorlds) {
				if (GUILayout.Button (w.worldData.worldName)) {
					World.currentWorld = w;
					SaveLoad.LoadChests(w.worldData.worldName);
					ItemContainer.currentContainer = SaveLoad.savedChests[0];
					//Move on to game...
					Debug.Log ("From Load:" + World.currentWorld.worldData.worldName);
					SceneManager.LoadScene (Game.current.player.playerScene);
				}
				
			}

			GUILayout.Space(10);
			if (GUILayout.Button ("Create New World")) {
				World.currentWorld = new World();
				currentMenu = Menu.CreateLevel;
			}

			GUILayout.Space(10);
			
			if (GUILayout.Button ("Cancel")) {
				currentMenu = Menu.Continue;
			}
			GUILayout.FlexibleSpace ();
			GUILayout.EndVertical ();
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			GUILayout.EndArea ();

		} else if (currentMenu == Menu.CreateLevel) {

			worldDetector = true;
			GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height));
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();

			GUILayout.Box("Enter World Name");
			GUILayout.Space(10);

			World.currentWorld.worldData.worldName = GUILayout.TextField (World.currentWorld.worldData.worldName, 20, GUILayout.Width(120));

			GUILayout.Space(10);

			
			if(GUILayout.Button("Difficulty: " + staticstats.difficulty)){
				Debug.Log(World.currentWorld.worldData.worldDifficulty);
				if(World.currentWorld.worldData.worldDifficulty == 3){
					World.currentWorld.worldData.worldDifficulty = 0;
				} else {
					World.currentWorld.worldData.worldDifficulty = World.currentWorld.worldData.worldDifficulty + 1;
				}
				
			}

			GUILayout.Space(10);

			if(!Directory.Exists(Application.persistentDataPath + "/" + World.currentWorld.worldData.worldName)){
				if (GUILayout.Button ( "Save")) {
					Directory.CreateDirectory(Application.persistentDataPath + "/" + World.currentWorld.worldData.worldName);
					//Save the current Game as a new saved Game
					ItemContainer.currentContainer = new ItemContainer();

					SaveLoad.SaveWorld();
					SaveLoad.SaveChests(World.currentWorld.worldData.worldName);
					//Move on to game...
					SceneManager.LoadScene (Game.current.player.playerScene);
				}
			}
			GUILayout.Space(10);

			if (GUILayout.Button ("Cancel")) {
				currentMenu = Menu.LevelSelect;
			}
			
			GUILayout.FlexibleSpace ();
			GUILayout.EndVertical ();
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			GUILayout.EndArea ();
		}


	}

}
