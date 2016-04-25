 using UnityEngine;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Runtime.Serialization;
using System.Reflection;

public static class SaveLoad {
	
	public static List<Game> savedGames = new List<Game>();
	public static List<ItemContainer> savedChests = new List<ItemContainer> ();
	public static List<World> savedWorlds = new List<World>();
	
	//it's static so we can call it from anywhere
	public static void Save() {
		SaveLoad.savedGames.Add(Game.current);
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.fgon"); //you can call it anything you want
		bf.Serialize(file, SaveLoad.savedGames);
		Debug.Log ("File saved to " + Application.persistentDataPath);
		file.Close();
	}   
	
	public static void Load() {
		if(File.Exists(Application.persistentDataPath + "/savedGames.fgon")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.fgon", FileMode.Open);
			SaveLoad.savedGames = (List<Game>)bf.Deserialize(file);
			file.Close();
		}
	}

	public static void SaveOver(){
		if (File.Exists (Application.persistentDataPath + "/savedGames.fgon")) {

			Game gameToRemove = Game.current; //Replace with game you want to remove

			if (gameToRemove != null)	
			{
				SaveLoad.savedGames.Remove(gameToRemove);
			}

			SaveLoad.Save();

		} else {

			Save();

		}

	}
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////World Saving////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public static void SaveWorld() {
		SaveLoad.savedWorlds.Add(World.currentWorld);
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/savedWorld.fgon"); //you can call it anything you want
		bf.Serialize(file, SaveLoad.savedWorlds);
		Debug.Log ("File saved to " + Application.persistentDataPath);
		file.Close();
	}   
	
	public static void LoadWorld() {
		if(File.Exists(Application.persistentDataPath + "/savedWorld.fgon")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedWorld.fgon", FileMode.Open);
			SaveLoad.savedWorlds = (List<World>)bf.Deserialize(file);
			file.Close();
		}
	}
	
	public static void SaveOverWorld(){
		if (File.Exists (Application.persistentDataPath + "/savedWorld.fgon")) {
			
			World worldToRemove = World.currentWorld; //Replace with game you want to remove
			
			if (worldToRemove != null)	
			{
				SaveLoad.savedWorlds.Remove(worldToRemove);
			}
			
			SaveLoad.SaveWorld();
			
		} else {
			
			SaveWorld();
			
		}
		
	}

	///////////////////////////////////////////////////////Chests////////////////////////////////////////////////////////



	public static void SaveChests(string worldName) {
		SaveLoad.savedChests.Add(ItemContainer.currentContainer);
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/" + worldName + "/savedChests.fgon"); //you can call it anything you want
		bf.Serialize(file, SaveLoad.savedChests);
		Debug.Log ("File saved to " + Application.persistentDataPath);
		file.Close();
	}   
	
	public static void LoadChests(string worldName) {
		if(File.Exists(Application.persistentDataPath + "/" + worldName + "/savedChests.fgon")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/" + worldName + "/savedChests.fgon", FileMode.Open);
			SaveLoad.savedChests = (List<ItemContainer>)bf.Deserialize(file);
			file.Close();
		}
	}
	
	public static void SaveOverChests(string worldName){
		if (File.Exists (Application.persistentDataPath + "/" + worldName + "/savedChests.fgon")) {
			
			ItemContainer containersToRemove = ItemContainer.currentContainer; //Replace with game you want to remove
			
			if (containersToRemove != null)	
			{
				SaveLoad.savedChests.Remove(containersToRemove);
			}
			
			SaveLoad.SaveChests(worldName);
			
		} else {
			
			SaveChests(worldName);
			
		}
		
	}

}

