using UnityEngine;
using System.Collections;

public class Console : MonoBehaviour {

	public bool showChat;
	public string chatLine;

	void Update(){
		//if(Input.GetKeyDown()) // change it to the key you want
		//{
			//toggleChat();
		//}
	}

	public void toggleChat()
	{
		if(showChat)
		{
			if(chatLine != "")
			{
				chatCommands(chatLine);
			}
			
			showChat = false;
		}
		else
		{
			showChat = true;
		}
	}
	
	
	
	void chatCommands(string tempString)
	{
		chatLine = tempString;
		
		if(tempString.Substring(0, 1) == "/")
		{
			tempString = tempString.Substring(1, tempString.Length - 1);
			string[] stringArr = tempString.Split(' ');
			
			switch(stringArr[0].ToLower())
			{
			
				
			//case "additem":
				//if(stringArr.Length > 2)

				//else
				//	chatCommands("USAGE: '/additem ID Number'");
				//break;
				
			default:
				chatCommands("Command not found!");
				break;
			}
			
			chatLine = "";
		}
		else
		{
			//lineSize++;
			
			//if(lineSize > 7)
				//chatLineSize++;
			
			//chatText += chatLine + "\n";
			//chatLine = "";
			
			//scrollPos = new Vector2(0, (chatLineSize * 13));
		}
	}
	
	
	
	void OnGUI()
	{
		// Chat Box
		GUI.BeginGroup(new Rect(5, Screen.height - 250, 310, 300));
		
		GUI.Box(new Rect(0, 0, 310, 145), "");
		//scrollPos = GUI.BeginScrollView (new Rect(5, 10, 300, 135), scrollPos, new Rect(0, 0, 980, (chatLineSize * 13) + 5), false, false);
		//GUI.Label(new Rect(0, 0, 1000, 10000), chatText);
		GUI.EndScrollView ();
		
		// Chat Line
		if(showChat)
		{
			GUI.FocusControl ("chatField");
			GUI.SetNextControlName ("chatField");
			chatLine = GUI.TextField(new Rect(0, 150, 310, 20), chatLine, 100);
		}
		
		GUI.EndGroup();
	}
}
