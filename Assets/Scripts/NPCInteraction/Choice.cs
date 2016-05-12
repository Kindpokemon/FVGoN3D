using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Choice {

	public List<string> dialogueOptions;
	public List<int> optionOutcome;
	public string emotion;
	public string fluff;

	public Choice(){

	}

	public Choice(List<string> options, List<int> outcomes, string emote, string floof){
		dialogueOptions = options;
		optionOutcome = outcomes;
		emotion = emote;
		fluff = floof;
	}
}
