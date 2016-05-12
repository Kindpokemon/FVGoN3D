using UnityEngine;
using System.Collections;

public static class CommandScript {

	public static void CommandTranslate(string inputCommand){
		string[] command = inputCommand.Split(' ');
		if (command[0].Equals ("giveitem")) {
			Inventory inv = GameObject.FindGameObjectWithTag ("reflist").GetComponent<ReferenceList> ().inventory;
			ItemDatabase data = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDatabase> ();
			int k = 0;
			bool arb = true;
			for (int i = 1; i < command.Length; i++) {
				if (!int.TryParse (command [i], out k)) {
					arb = false;
					break;
				}
			}
			if (command.Length >= 3 && arb) {
				if (data.items.Count - 1 >= int.Parse (command [1])) {
					int sepis = int.Parse(command[1]);
					for (int q = 0; q < sepis; q++) {
						int bepis = int.Parse (command [1]);
						inv.addItemAtEmptySlot (data.items [bepis]);
					}
				} else {
					Debug.LogError ("Item ID " + command [1] + " Doesn't exist!");
				}
			} else {
				Debug.LogError ("Input has " + command.Length + " Arguments and All Numbers = " + arb);
			}
		} else if (command[0].Equals ("summonid")) {

		} else if (command[0].Equals ("kill_plr")) {

		} else if (command[0].Equals ("kill_plr")) {

		} else {
			Debug.LogError ("Command of type " + command[0] + " not a valid command");
		}
	}

}
