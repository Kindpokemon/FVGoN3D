using UnityEngine;
using System.Collections;

[System.Serializable]
public class DialogueLine {

	//Content
	public string text;
	public string emotion;

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

	public DialogueLine(string dia, string emote, int nextLin){
		text = dia;
		emotion = emote;
		nextLine = nextLin;
	}

	public DialogueLine(string dia, string emote, int nextLin, bool com){
		text = dia;
		emotion = emote;
		nextLine = nextLin;
		command = com;
	}

	public DialogueLine(string dia, string emote, bool choi, int nextChoi){
		text = dia;
		emotion = emote;
		nextChoice = nextChoi;
		isChoice = choi;

	}
}
