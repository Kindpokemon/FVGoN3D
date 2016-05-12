using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Choice {

	public List<string> dialogueOptions;
	public List<int> optionOutcome;
	public List<Sprite> sprites;
	public string fluff;

	public Choice(){

	}

	public Choice(List<string> options, List<int> outcomes, List<Sprite> emote, string floof){
		dialogueOptions = options;
		optionOutcome = outcomes;
		sprites = emote;
		fluff = floof;
	}
}
