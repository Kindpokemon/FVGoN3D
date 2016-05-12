using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class DialogueLine {

	//Content
	public string text;
	public List<Sprite> sprites;

	//Execution
	public int nextLine;
	public int nextChoice;
	public enum ContinueType{
		Continue,
		End,
		CloseAndMove
	}
	public ContinueType continueType;

	//Properties
	public bool command;
	public bool isChoice;

	public DialogueLine(){

	}

	public DialogueLine(string dia, List<Sprite> emote, int nextLin){
		text = dia;
		sprites = emote;
		nextLine = nextLin;
	}

	public DialogueLine(string dia, List<Sprite> emote, int nextLin, bool com){
		text = dia;
		sprites = emote;
		nextLine = nextLin;
		command = com;
	}

	public DialogueLine(string dia, List<Sprite> emote, bool choi, int nextChoi){
		text = dia;
		sprites = emote;
		nextChoice = nextChoi;
		isChoice = choi;

	}
}
